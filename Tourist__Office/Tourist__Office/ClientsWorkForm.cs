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
    
    public partial class ClientsWorkForm : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        private bool newClientProfileRowAdding = false;
        public ClientsWorkForm()
        {
            InitializeComponent();
           
        }

        private void BackToMainApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            //newAdmForm.Show();
            DataBank.Adm.Show();
        }


        private void ReloadData()
        {
            try
            {
                dataSet.Tables["ClientProfile"].Clear();

                sqlDataAdapter.Fill(dataSet, "ClientProfile");
                ClientsTable.DataSource = dataSet.Tables["ClientProfile"];

                for (int i = 0; i < ClientsTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    ClientsTable[8, i] = linkCell;
                }
                ClientsTable.Columns["ClientID"].ReadOnly = true;
                ClientsTable.Columns["UserID"].ReadOnly = true;

                sqlDataAdapter.Update(dataSet, "ClientProfile");
                ClientsTable.Refresh();
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
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS[Command] FROM ClientProfile", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "ClientProfile");
                ClientsTable.DataSource = dataSet.Tables["ClientProfile"];

                for (int i = 0; i < ClientsTable.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    ClientsTable[8, i] = linkCell;
                }
                ClientsTable.Columns["ClientID"].ReadOnly = true; 
                ClientsTable.Columns["UserID"].ReadOnly = true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



       private void ClientsTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                //if (!Regex.Match(ClientsTable.Columns[1].ToString(), @"[а-яА-Я]|[a-zA-Z][-]").Success)
                //{
                //    MessageBox.Show("Может содержать только буквы и символ-разделитель «-» ");
                //}

                //else if (!Regex.Match(ClientsTable.Columns[2].ToString(), @"[0-9|[+]").Success)
                //{
                //    MessageBox.Show("Может содержать только цифры и символ «+» в начале");
                //}

                //else if (!Regex.Match(ClientsTable.Columns[4].ToString(), @"[0-9]").Success)
                //{
                //    MessageBox.Show("Может содержать только цифры");
                //}
                //else if (!Regex.Match(ClientsTable.Columns[5].ToString(), @"[0-9][a-zA-Z]").Success)
                //{
                //    MessageBox.Show("Может содержать только цифры и 4 латинские буквы в начале");
                //}

                ClientsTable.DataError += new DataGridViewDataErrorEventHandler(ClientsTable_DataError);

                if (newClientProfileRowAdding == false)
                {

                    int rowIndex = ClientsTable.SelectedCells[0].RowIndex;

                    DataGridViewRow TourEditingRow = ClientsTable.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    ClientsTable[8, rowIndex] = linkCell;

                    TourEditingRow.Cells["Command"].Value = "Update";

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    string task = ClientsTable.Rows[e.RowIndex].Cells[8].Value.ToString();
                    if (task == "Delete")
                    {

                        SqlCommand CheckClientHasRequest = new SqlCommand("CheckClientHasRequest", sqlConnection);
                        CheckClientHasRequest.CommandType = CommandType.StoredProcedure;
                        CheckClientHasRequest.Parameters.Add("@ClientID", SqlDbType.VarChar).Value = ClientsTable.CurrentCell.RowIndex;


                        var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer.Direction = System.Data.ParameterDirection.Output;
                        answer.Size = 64;
                        CheckClientHasRequest.Parameters.Add(answer);

                        CheckClientHasRequest.ExecuteNonQuery();
                        var res  = answer.Value.ToString();

                        if (res  == "Заявки от этого клиента нет")
                        {
                            //System.Windows.MessageBox.Show("Менеджер с таким ФИО отсутствует в базе");
                            if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                ClientsTable.Rows.RemoveAt(rowIndex);

                                sqlDataAdapter.Update(dataSet, "ClientProfile");
                            }

                        }
                        else if (res  == "Заявки от этого клиента есть")
                        {

                            if (MessageBox.Show("'От этого клиента есть заявки. Вы уверены, что хотите удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                            {
                                int rowIndex = e.RowIndex;
                                ClientsTable.Rows.RemoveAt(rowIndex);

                                sqlDataAdapter.Update(dataSet, "ClientProfile");
                            }

                        }
                    }
                    //else if (task == "Insert")
                    //{
                    //    int rowIndex = ClientsTable.Rows.Count - 2;

                    //    DataRow ClientProfileRow = dataSet.Tables["ClientProfile"].NewRow();

                    //    ClientProfileRow["ClientFullName"] = ClientsTable.Rows[rowIndex].Cells["ClientFullName"].Value;
                    //    ClientProfileRow["ClientPhoneNumber"] = ClientsTable.Rows[rowIndex].Cells["ClientPhoneNumber"].Value;
                    //    ClientProfileRow["DateOfBirth"] = ClientsTable.Rows[rowIndex].Cells["DateOfBirth"].Value;
                    //    ClientProfileRow["Email"] = ClientsTable.Rows[rowIndex].Cells["Email"].Value;
                    //    ClientProfileRow["Passport"] = ClientsTable.Rows[rowIndex].Cells["Passport"].Value;
                    //    ClientProfileRow["InternationalPassport"] = ClientsTable.Rows[rowIndex].Cells["InternationalPassport"].Value;

                    //    dataSet.Tables["ClientProfile"].Rows.Add(ClientProfileRow);

                    //    dataSet.Tables["ClientProfile"].Rows.RemoveAt(dataSet.Tables["ClientProfile"].Rows.Count - 1);

                    //    ClientsTable.Rows.RemoveAt(ClientsTable.Rows.Count - 2);

                    //    ClientsTable.Rows[e.RowIndex].Cells[8].Value = "Delete";

                    //    sqlDataAdapter.Update(dataSet, "ClientProfile");

                    //    newClientProfileRowAdding = false;
                    //}
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;



                        dataSet.Tables["ClientProfile"].Rows[r]["ClientFullName"] = ClientsTable.Rows[r].Cells["ClientFullName"].Value;
                        dataSet.Tables["ClientProfile"].Rows[r]["ClientPhoneNumber"] = ClientsTable.Rows[r].Cells["ClientPhoneNumber"].Value;
                        dataSet.Tables["ClientProfile"].Rows[r]["DateOfBirth"] = ClientsTable.Rows[r].Cells["DateOfBirth"].Value;
                        dataSet.Tables["ClientProfile"].Rows[r]["Email"] = ClientsTable.Rows[r].Cells["Email"].Value;
                        dataSet.Tables["ClientProfile"].Rows[r]["Passport"] = ClientsTable.Rows[r].Cells["Passport"].Value;
                        dataSet.Tables["ClientProfile"].Rows[r]["InternationalPassport"] = ClientsTable.Rows[r].Cells["InternationalPassport"].Value;

                        //dataSet.Tables["ClientProfile"].Rows[r]["Amount"] = ClientsTable.Rows[r].Cells["Amount"].Value;

                        sqlDataAdapter.Update(dataSet, "ClientProfile");

                        ClientsTable.Rows[e.RowIndex].Cells[8].Value = "Update";
                        //ClientsTable.DataError += new DataGridViewDataErrorEventHandler(ClientsTable_DataError);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClientsWorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ClientsWorkForm_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();

            //private void dg1_dataerror(object sender, DataGridViewDataErrorEventArgs e)
            //{
            //    // Если ты сюда ни чего не вставишь, то при ошибочном значение, не произойдет ничего, кроме того что ты не
            //    // сможешь перейти в другую ячейку, до тех пор пока не введешь правильное значение.
            //    // Можешь поставить MessageBox (...) со своим сообщением.
            //}
            //// Установка обработчика события:
            //dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dg1_dataerror);



        }

        private void ReloadClientTable_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        private void ClientsTable_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ошибка ввода!");
            e.ThrowException = false;
            
        }

    }
}
