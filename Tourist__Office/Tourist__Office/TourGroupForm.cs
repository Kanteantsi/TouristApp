using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourist__Office
{
    public partial class TourGroupForm : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        bool newTourGroupRowAdding = false;
        public TourGroupForm()
        {
            InitializeComponent();
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["TourGroup"].Clear();

                sqlDataAdapter.Fill(dataSet, "TourGroup");
                TourGroupTable.DataSource = dataSet.Tables["TourGroup"];

                for (int i = 0; i < TourGroupTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourGroupTable[3, i] = linkCell;
                }
                //TourGroupTable.Columns["TourGroupID"].ReadOnly = true;

                sqlDataAdapter.Update(dataSet, "TourGroup");
                //TourGroupTable.Refresh();
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadData()
        {

            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] From TourGroup", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "TourGroup");
                TourGroupTable.DataSource = dataSet.Tables["TourGroup"];

                for (int i = 0; i < TourGroupTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourGroupTable[3, i] = linkCell;
                }
                //TourGroupTable.Columns["TourGroupID"].ReadOnly = true;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void TourGroupForm_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();
        }

        private void TourGroupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TourGroupTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    string task = TourGroupTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            TourGroupTable.Rows.RemoveAt(rowIndex);

                            sqlDataAdapter.Update(dataSet, "TourGroup");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = TourGroupTable.Rows.Count - 2;

                        DataRow TourGroupRow = dataSet.Tables["TourGroup"].NewRow();


                        TourGroupRow["TourID"] = TourGroupTable.Rows[rowIndex].Cells["TourID"].Value;
                        TourGroupRow["Amount"] = TourGroupTable.Rows[rowIndex].Cells["Amount"].Value;

                        dataSet.Tables["TourGroup"].Rows.Add(TourGroupRow);

                        dataSet.Tables["TourGroup"].Rows.RemoveAt(dataSet.Tables["TourGroup"].Rows.Count - 1);

                        TourGroupTable.Rows.RemoveAt(TourGroupTable.Rows.Count - 2);

                        TourGroupTable.Rows[e.RowIndex].Cells[3].Value = "Insert";

                        sqlDataAdapter.Update(dataSet, "TourGroup");

                        newTourGroupRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;


                        dataSet.Tables["TourGroup"].Rows[r]["TourID"] = TourGroupTable.Rows[r].Cells["TourID"].Value;
                        dataSet.Tables["TourGroup"].Rows[r]["Amount"] = TourGroupTable.Rows[r].Cells["Amount"].Value;

                        sqlDataAdapter.Update(dataSet, "TourGroup");

                        TourGroupTable.Rows[e.RowIndex].Cells[3].Value = "Update";
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TourGroupTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newTourGroupRowAdding == false)
                {
                    newTourGroupRowAdding = true;
                    int lastTourGroupRow = TourGroupTable.Rows.Count - 2;

                    DataGridViewRow TourGroupRow = TourGroupTable.Rows[lastTourGroupRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourGroupTable[3, lastTourGroupRow] = linkCell;

                    TourGroupRow.Cells["Command"].Value = "Insert";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TourGroupTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int x;
                
                //if (Int32.TryParse(TourGroupTable.Columns[1].ToString(), out x) == false)
                //{
                //    MessageBox.Show("Может содержать только цифры ");
                //}
                //if (Int32.TryParse(TourGroupTable.Columns[2].ToString(), out x) == false)
                //{
                //    MessageBox.Show("Может содержать только цифры ");
                //}

                if (newTourGroupRowAdding == false)
                {

                    int rowIndex = TourGroupTable.SelectedCells[0].RowIndex;

                    DataGridViewRow TourEditingRow = TourGroupTable.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourGroupTable[3, rowIndex] = linkCell;

                    TourEditingRow.Cells["Command"].Value = "Update";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackToMainApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            //newAdmForm.Show();
            DataBank.Adm.Show();
        }

        private void ReloadTourGroupTable_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }
}
