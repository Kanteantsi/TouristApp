using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourist__Office
{
    public partial class WorkWithRequests : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        bool newRequestRowAdding = false;

        private bool newRowAdding = false;

        public WorkWithRequests()
        {
            InitializeComponent();
        }

        private void ReloadRequestsTable_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ToMainApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            //newAdmForm.Show();
            DataBank.Man.Show();
        }
        private void ReloadData()
        {
            try
            {
                dataSet.Tables["Request"].Clear();

                sqlDataAdapter.Fill(dataSet, "Request");
                RequestsForManagerTable.DataSource = dataSet.Tables["Request"];

                for (int i = 0; i < RequestsForManagerTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    RequestsForManagerTable[6, i] = linkCell;
                }


                RequestsForManagerTable.Columns["RequestID"].ReadOnly = true;

                //sqlDataAdapter.Update(dataSet, "Request");
                //RequestsForManagerTable.Refresh();
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
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] From Request", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Request");
                RequestsForManagerTable.DataSource = dataSet.Tables["Request"];

                for (int i = 0; i < RequestsForManagerTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    RequestsForManagerTable[6, i] = linkCell;
                }

                RequestsForManagerTable.Columns[0].ReadOnly = true;
                //RequestsForManagerTable.Columns[1].ReadOnly = true;
                //RequestsForManagerTable.Columns[2].ReadOnly = true;
                //RequestsForManagerTable.Columns[3].ReadOnly = true;
                //RequestsForManagerTable.Columns[4].ReadOnly = true;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void RequestsForManagerTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRequestRowAdding == false)
                {

                    int rowIndex = RequestsForManagerTable.SelectedCells[0].RowIndex;

                    DataGridViewRow TourEditingRow = RequestsForManagerTable.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    RequestsForManagerTable[6, rowIndex] = linkCell;

                    TourEditingRow.Cells["Command"].Value = "Update";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RequestsForManagerTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    string task = RequestsForManagerTable.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            RequestsForManagerTable.Rows.RemoveAt(rowIndex);

                            sqlDataAdapter.Update(dataSet, "Request");
                        }
                    }
                    //else if (task == "Insert")
                    //{
                    //    int rowIndex = RequestsForManagerTable.Rows.Count - 2;

                    //    DataRow TourGroupRow = dataSet.Tables["TourGroup"].NewRow();


                    //    TourGroupRow["TourID"] = RequestsForManagerTable.Rows[rowIndex].Cells["TourID"].Value;
                    //    TourGroupRow["Amount"] = RequestsForManagerTable.Rows[rowIndex].Cells["Amount"].Value;

                    //    dataSet.Tables["TourGroup"].Rows.Add(TourGroupRow);

                    //    dataSet.Tables["TourGroup"].Rows.RemoveAt(dataSet.Tables["TourGroup"].Rows.Count - 1);

                    //    RequestsForManagerTable.Rows.RemoveAt(RequestsForManagerTable.Rows.Count - 2);

                    //    RequestsForManagerTable.Rows[e.RowIndex].Cells[3].Value = "Insert";

                    //    sqlDataAdapter.Update(dataSet, "TourGroup");

                    //    newTourGroupRowAdding = false;
                    //}
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        dataSet.Tables["Request"].Rows[r]["ClientID"] = RequestsForManagerTable.Rows[r].Cells["ClientID"].Value;
                        dataSet.Tables["Request"].Rows[r]["TourID"] = RequestsForManagerTable.Rows[r].Cells["TourID"].Value;
                        dataSet.Tables["Request"].Rows[r]["RequestDate"] = RequestsForManagerTable.Rows[r].Cells["RequestDate"].Value;
                        dataSet.Tables["Request"].Rows[r]["ManagerID"] = RequestsForManagerTable.Rows[r].Cells["ManagerID"].Value;
                        dataSet.Tables["Request"].Rows[r]["Acceptance"] = RequestsForManagerTable.Rows[r].Cells["Acceptance"].Value;

                        sqlDataAdapter.Update(dataSet, "Request");

                        RequestsForManagerTable.Rows[e.RowIndex].Cells[6].Value = "Update";
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkWithRequests_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();
        }
    }
}
