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
    public partial class TourForms : Form
    {
        private SqlConnection sqlConnection = null;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
        //sqlConnection(ConnectionString);
        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        private bool newTourRowAdding = false;

        public TourForms()
        {
            InitializeComponent();
        }


        private void TourTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TourTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void TourTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Tour"].Clear();

                sqlDataAdapter.Fill(dataSet, "Tour");
                TourTable.DataSource = dataSet.Tables["Tour"];

                for (int i = 0; i < TourTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourTable[5, i] = linkCell;
                }
                TourTable.Columns["TourID"].ReadOnly = true;
                //TourTable.Refresh();
                sqlDataAdapter.Update(dataSet, "Tour");
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TourForms_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();
        }


        private void LoadData()
        {

            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] From Tour", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Tour");
                TourTable.DataSource = dataSet.Tables["Tour"];

                for (int i = 0; i < TourTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourTable[5, i] = linkCell;
                }
                TourTable.Columns["TourID"].ReadOnly = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BackToMainApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            DataBank.Adm.Show();
            //newAdmForm.Show();
        }

        private void TourForms_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TourTable_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string value;
                float number;

                //if (!Regex.Match(TourTable.Columns[2].ToString(), @"[а-яА-Я]|[a-zA-Z][-]").Success)
                //{
                //    MessageBox.Show("Может содержать только буквы и символ-разделитель «-» ");
                //}
                //if (!(Single.TryParse(TourTable.Columns[3].ToString(), out number)))
                //{
                //    MessageBox.Show("Может содержать только десятичные цифры");
                //}
                    //(TourTable.Columns[1].ToString("yyyy-MM-dd")


                if (newTourRowAdding == false)
                {

                    int rowIndex = TourTable.SelectedCells[0].RowIndex;

                    DataGridViewRow TourEditingRow = TourTable.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourTable[5, rowIndex] = linkCell;

                    TourEditingRow.Cells["Command"].Value = "Update";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TourTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = TourTable.Rows[e.RowIndex].Cells[5].Value.ToString();



                        if (task == "Delete")
                        {
                        SqlCommand TourIsInRequest = new SqlCommand("TourIsInRequest", sqlConnection);
                        TourIsInRequest.CommandType = CommandType.StoredProcedure;
                        TourIsInRequest.Parameters.Add("@TourID", SqlDbType.VarChar).Value = TourTable.CurrentCell.RowIndex;


                        var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer.Direction = System.Data.ParameterDirection.Output;
                        answer.Size = 64;
                        TourIsInRequest.Parameters.Add(answer);

                        TourIsInRequest.ExecuteNonQuery();
                        var res = answer.Value.ToString();

                        if (res == "Заявок на этот тур нет")
                        {

                            if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                TourTable.Rows.RemoveAt(rowIndex);

                                sqlDataAdapter.Update(dataSet, "Tour");
                            }

                            else if (res == "Заявки на этот тур есть")
                            {
                                //System.Windows.MessageBox.Show("Менеджер с таким ФИО отсутствует в базе");
                                if (MessageBox.Show("Заявки на этот тур есть. Вы уверены, что хотите удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int rowIndex = e.RowIndex;
                                    TourTable.Rows.RemoveAt(rowIndex);

                                    sqlDataAdapter.Update(dataSet, "Tour");
                                }
                            }

                        }

                    }
                    



                    else if (task == "Insert")
                    {


                        int rowIndex = TourTable.Rows.Count - 2;

                        DataRow TourRow = dataSet.Tables["Tour"].NewRow();

                        TourRow["TourDate"] = TourTable.Rows[rowIndex].Cells["TourDate"].Value;
                        TourRow["TourPlacement"] = TourTable.Rows[rowIndex].Cells["TourPlacement"].Value;
                        TourRow["TourPrice"] = TourTable.Rows[rowIndex].Cells["TourPrice"].Value;
                        TourRow["TourDescription"] = TourTable.Rows[rowIndex].Cells["TourDescription"].Value;

                        dataSet.Tables["Tour"].Rows.Add(TourRow);

                        dataSet.Tables["Tour"].Rows.RemoveAt(dataSet.Tables["Tour"].Rows.Count - 1);

                        TourTable.Rows.RemoveAt(TourTable.Rows.Count - 2);

                        TourTable.Rows[e.RowIndex].Cells[5].Value = "Delete";

                        sqlDataAdapter.Update(dataSet, "Tour");

                        newTourRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Tour"].Rows[r]["TourDate"] = TourTable.Rows[r].Cells["TourDate"].Value;
                        dataSet.Tables["Tour"].Rows[r]["TourPlacement"] = TourTable.Rows[r].Cells["TourPlacement"].Value;
                        dataSet.Tables["Tour"].Rows[r]["TourPrice"] = TourTable.Rows[r].Cells["TourPrice"].Value;
                        dataSet.Tables["Tour"].Rows[r]["TourDescription"] = TourTable.Rows[r].Cells["TourDescription"].Value;

                        sqlDataAdapter.Update(dataSet, "Tour");

                        TourTable.Rows[e.RowIndex].Cells[5].Value = "Update";
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TourTable_UserAddedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newTourRowAdding == false)
                {
                    newTourRowAdding = true;
                    int lastTourRow = TourTable.Rows.Count - 2;

                    DataGridViewRow TourRow = TourTable.Rows[lastTourRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    TourTable[5, lastTourRow] = linkCell;

                    TourRow.Cells["Command"].Value = "Insert";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadTourTable_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
    }



}