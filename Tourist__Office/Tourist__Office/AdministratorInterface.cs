using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourist__Office
{
    public partial class AdministratorInterface : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        

        //private bool newTourGroupRowAdding = false;

        //private bool newClientProfileRowAdding = false;

        //private bool newTourRowAdding = false;

        //SqlConnection сonnection;
        public AdministratorInterface()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            try
            {
                //sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] From Tour", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();

                ////sqlDataAdapter.Fill(dataSet, "Tour");
                ////TourTable.DataSource = dataSet.Tables["Tour"];

                ////for (int i = 0; i < TourTable.Rows.Count; i++)
                ////{
                ////    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                ////    TourTable[5, i] = linkCell;
                ////}


                //sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Delete] From TourGroup", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();

                //sqlDataAdapter.Fill(dataSet, "TourGroup");
                //TourGroupTable.DataSource = dataSet.Tables["TourGroup"];

                //for (int i = 0; i < TourGroupTable.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    TourGroupTable[3, i] = linkCell;
                //}


                //sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS[Command] FROM ClientProfile", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();

                //sqlDataAdapter.Fill(dataSet, "ClientProfile");
                //ClientsTable.DataSource = dataSet.Tables["ClientProfile"];

                //for (int i = 0; i < ClientsTable.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    ClientsTable[8, i] = linkCell;
                //}



                sqlDataAdapter = new SqlDataAdapter("SELECT *  From ManagersMonthSales", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "ManagersMonthSales");
                ManagersMnthSales.DataSource = dataSet.Tables["ManagersMonthSales"];

                //for (int i = 0; i < ManagersMnthSales.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    ManagersMnthSales[8, i] = linkCell;
                //}


                //string ManagWithBestSalesQuery = ;
                //sqlDataAdapter = new SqlDataAdapter("ManagerWithBestSales", sqlConnection);
                SqlCommand ManagWithBestSales = new SqlCommand("Select * FROM ManWithBestSales", sqlConnection);
                //ManagWithBestSales.CommandType = CommandType.StoredProcedure;
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                var reader = ManagWithBestSales.ExecuteReader();
                //ClHISTOFREQS.Text += Convert.ToString (reader.GetName(0) + Convert.ToString ( reader.GetName(1)) + Convert.ToString (reader.GetName(2)) ) + Convert.ToString(reader.GetName(3))  + Convert.ToString(reader.GetName(4))   +Convert.ToString(reader.GetName(5)) + Convert.ToString(reader.GetName(6));
            
                if (reader.HasRows)
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                        ManagWithBestSa.Text += reader.GetString(0);
                    }
                }
                reader.Close();
            

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

            //dataSet = new DataSet();

            //sqlDataAdapter.Fill(dataSet);
            //ManagerWithBstSales.DataSource = dataSet.Tables["ManagerWithBestSales"];

            //for (int i = 0; i < ManagersMnthSales.Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    ManagersMnthSales[8, i] = linkCell;
            //}

        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AdministratorInterface_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True");
            sqlConnection.Open();

            LoadData();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ShowSalesPlanFulf_Click(object sender, EventArgs e)
        {

            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            //SqlDataReader sqlReader = null;
            //var cultureInfo = new CultureInfo("	it-it");
            SqlCommand SalesPlanFulfilment = new SqlCommand("SalesPlanFulfilment", sqlConnection);
            SalesPlanFulfilment.CommandType = CommandType.StoredProcedure;
            SalesPlanFulfilment.Parameters.Add("@Date1", SqlDbType.Date);
            SalesPlanFulfilment.Parameters.Add("@Date2", SqlDbType.Date);
            //SalesPlanFulfilment.Parameters["@Date1"].Value = DataBank.Adm.DateFrom.SelectionStart.Date.ToString("yyyy-MM-dd");
            //SalesPlanFulfilment.Parameters["@Date2"].Value = DataBank.Adm.DateTo.SelectionStart.Date.ToString("yyyy-MM-dd");
            SalesPlanFulfilment.Parameters["@Date1"].Value = DateFrom.SelectionStart.Date.ToString("yyyy-MM-dd");
            SalesPlanFulfilment.Parameters["@Date2"].Value = DateTo.SelectionStart.Date.ToString("yyyy-MM-dd");

            var reader = SalesPlanFulfilment.ExecuteReader();

            if (reader.HasRows)
            {
                //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                //+ "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ClientFullName"]) + "    " + Convert.ToString(reader["RequestDate"]) + "       " + Convert.ToString(reader["Acceptance"]) +
                while (reader.Read()) /*ManagerFullName,RequestDate,ClientFullName,Acceptance*/
                {
                    SalesPlansFulfilment.Text += (Convert.ToString(reader["ManagerFullName"]) + "\n");
                }
            }
            reader.Close();

        }

        private void TourTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 5)
            //    {
            //        string task = TourTable.Rows[e.RowIndex].Cells[5].Value.ToString();
            //        if (task == "Delete")
            //        {
            //            if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //                == DialogResult.Yes)
            //            {
            //                int rowIndex = e.RowIndex;
            //                TourTable.Rows.RemoveAt(rowIndex);

            //                sqlDataAdapter.Update(dataSet, "Tour");
            //            }
            //        }
            //        else if (task == "Insert")
            //        {
            //            int rowIndex = TourTable.Rows.Count - 2;

            //            DataRow TourRow = dataSet.Tables["Tour"].NewRow();

            //            TourRow["TourDate"] = TourTable.Rows[rowIndex].Cells["TourDate"].Value;
            //            TourRow["TourPlacement"] = TourTable.Rows[rowIndex].Cells["TourPlacement"].Value;
            //            TourRow["TourPrice"] = TourTable.Rows[rowIndex].Cells["TourPrice"].Value;
            //            TourRow["TourDescription"] = TourTable.Rows[rowIndex].Cells["TourDescription"].Value;

            //            dataSet.Tables["Tour"].Rows.Add(TourRow);

            //            dataSet.Tables["Tour"].Rows.RemoveAt(dataSet.Tables["Tour"].Rows.Count - 1);

            //            TourTable.Rows.RemoveAt(TourTable.Rows.Count - 2);

            //            TourTable.Rows[e.RowIndex].Cells[5].Value = "Delete";

            //            sqlDataAdapter.Update(dataSet, "Tour");

            //            newTourRowAdding = false;
            //        }
            //        else if (task == "Update")
            //        {
            //            int r = e.RowIndex;

            //            dataSet.Tables["Tour"].Rows[r]["TourDate"] = TourTable.Rows[r].Cells["TourDate"].Value;
            //            dataSet.Tables["Tour"].Rows[r]["TourPlacement"] = TourTable.Rows[r].Cells["TourPlacement"].Value;
            //            dataSet.Tables["Tour"].Rows[r]["TourPrice"] = TourTable.Rows[r].Cells["TourPrice"].Value;
            //            dataSet.Tables["Tour"].Rows[r]["TourDescription"] = TourTable.Rows[r].Cells["TourDescription"].Value;

            //            sqlDataAdapter.Update(dataSet, "Tour");

            //            TourTable.Rows[e.RowIndex].Cells[5].Value = "Delete";
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void TourTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //try
            //{
            //    if (newTourRowAdding == false)
            //    {
            //        newTourRowAdding = true;
            //        int lastTourRow = TourTable.Rows.Count - 2;

            //        DataGridViewRow TourRow = TourTable.Rows[lastTourRow];
            //        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //        TourTable[5, lastTourRow] = linkCell;

            //        TourRow.Cells["Command"].Value = "Insert";

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void TourTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (newTourRowAdding == false)
            //    {

            //        int rowIndex = TourTable.SelectedCells[0].RowIndex;

            //        DataGridViewRow TourEditingRow = TourTable.Rows[rowIndex];
            //        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //        TourTable[5, rowIndex] = linkCell;

            //        TourEditingRow.Cells["Command"].Value = "Update";

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }



        //private void TourTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    e.Control.KeyPress -= new KeyPressEventHandler(TourColumn_KeyPress);

        //    if (TourTable.CurrentCell.ColumnIndex == 3)
        //    {
        //        TextBox textBox = e.Control as TextBox;

        //        if(textBox != null)
        //        {
        //            textBox.KeyPress += new KeyPressEventHandler(TourColumn_KeyPress);
        //        }
        //    }
        //}

        // private void TourColumn_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar)&& !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void ShowTourGroupForTour_Click(object sender, EventArgs e)
        {
            SqlCommand CheckTourExists = new SqlCommand("CheckTourExists", sqlConnection);
            CheckTourExists.CommandType = CommandType.StoredProcedure;
            CheckTourExists.Parameters.Add("@TourPlacement", SqlDbType.VarChar).Value = TourPlacementForTourShow.Text;


            var answer0 = new SqlParameter("@Answer", SqlDbType.NVarChar);
            answer0.Direction = System.Data.ParameterDirection.Output;
            answer0.Size = 64;
            CheckTourExists.Parameters.Add(answer0);

            CheckTourExists.ExecuteNonQuery();
            var res1 = answer0.Value.ToString();

            if (res1 == "Такой тур отсутствует в базе")
            {
                System.Windows.MessageBox.Show("Такой тур отсутствует в базе");
            }
            else if (res1 == "Такой тур присутствует в базе")

            { 
                String ShowTourGroupsForTours = "ShowTourGroupsForTour";

            SqlCommand ShowTourGroupsForToursQuery = new SqlCommand(ShowTourGroupsForTours, sqlConnection);
            // указываем, что команда представляет хранимую процедуру
            ShowTourGroupsForToursQuery.CommandType = CommandType.StoredProcedure;
            ShowTourGroupsForToursQuery.Parameters.Add("@TourPlacement", SqlDbType.VarChar);
            ShowTourGroupsForToursQuery.Parameters["@TourPlacement"].Value = TourPlacementForTourShow.Text;
            //ShowHist.ExecuteNonQuery();
            var reader = ShowTourGroupsForToursQuery.ExecuteReader();
            //ClHISTOFREQS.Text += Convert.ToString (reader.GetName(0) + Convert.ToString ( reader.GetName(1)) + Convert.ToString (reader.GetName(2)) ) + Convert.ToString(reader.GetName(3))  + Convert.ToString(reader.GetName(4))   +Convert.ToString(reader.GetName(5)) + Convert.ToString(reader.GetName(6));

            if (reader.HasRows)
            {
                //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read())
                {
                    //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                    ShowTourGroupForTours.Text += ("         " + Convert.ToString(reader["TourGroupID"]) + "                                                                                " + Convert.ToString(reader["TourID"]) + "                                                                              " + Convert.ToString(reader["Amount"]) + "\n");
                }
            }
            reader.Close();
            }
        }


        //private void AdministratorPhoneNumber_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void AdministratorEmail_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void AdministratorFullName_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void label5_Click(object sender, EventArgs e)
        //{

        //}

        //private void label9_Click(object sender, EventArgs e)
        //{

        //}

        //private void label6_Click(object sender, EventArgs e)
        //{

        //}

        //private void AdministratorDateOfBirth_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void AdministratorInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void TourTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {


            //DataGridViewTextBoxCell cell = TourTable[3, e.RowIndex] as DataGridViewTextBoxCell;

            //if (cell != null)
            //{
            //    if (e.ColumnIndex == 1)
            //    {
            //        char[] chars = e.FormattedValue.ToString().ToCharArray();
            //        foreach (char c in chars)
            //        {
            //            if ((char.IsDigit(c) ||  ((c) == '-')  ) == false)
            //            {
            //                MessageBox.Show("Дата может быть задана только цифрами");

            //                e.Cancel = true;
            //                break;
            //            }
            //        }
            //    }

            //    if (e.ColumnIndex == 2)
            //    {
            //        char[] chars = e.FormattedValue.ToString().ToCharArray();
            //        foreach (char c in chars)
            //        {
            //            if ( (char.IsLetter(c) || ((c) == '-') == false))
            //            {
            //                MessageBox.Show("Место назначения может быть задано только буквами");

            //                e.Cancel = true;
            //                break;
            //            }
            //        }
            //    }

            //    if (e.ColumnIndex == 3)
            //    {
            //        char[] chars = e.FormattedValue.ToString().ToCharArray();
            //        foreach (char c in chars)
            //        {
            //            if ((char.IsDigit(c) == false))
            //            {
            //                MessageBox.Show("Цена может быть задана только цифрами");

            //                e.Cancel = true;
            //                break;
            //            }
            //        }
            //    }


            //if (e.ColumnIndex == 4)
            //{
            //    char[] chars = e.FormattedValue.ToString().ToCharArray();
            //    foreach (char c in chars)
            //    {
            //        if (char.IsLetter(c) == false)
            //        {
            //            MessageBox.Show("Описание может быть задано только буквами");

            //            e.Cancel = true;
            //            break;
            //        }
            //    }
            //}


            //}
        }

        private void ReloadTourData_Click(object sender, EventArgs e)
        {
            //sqlDataAdapter = new SqlDataAdapter("SELECT *, 'Delete' AS [Command] From Tour", sqlConnection);
            //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

            //sqlBuilder.GetInsertCommand();
            //sqlBuilder.GetUpdateCommand();
            //sqlBuilder.GetDeleteCommand();

            //dataSet = new DataSet();



            //dataSet.Tables["Tour"].Clear();

            //sqlDataAdapter.Fill(dataSet, "Tour");
            //TourTable.DataSource = dataSet.Tables["Tour"];

            //for (int i = 0; i < TourTable.Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    TourTable[5, i] = linkCell;
            //}

        }

        private void TourGroupTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 3)
            //    {
            //        string task = TourGroupTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            //        if (task == "Delete")
            //        {
            //            if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //                == DialogResult.Yes)
            //            {
            //                int rowIndex = e.RowIndex;
            //                TourGroupTable.Rows.RemoveAt(rowIndex);

            //                sqlDataAdapter.Update(dataSet, "TourGroup");
            //            }
            //        }
            //        else if (task == "Insert")
            //        {
            //            int rowIndex = TourGroupTable.Rows.Count - 2;

            //            DataRow TourGroupRow = dataSet.Tables["TourGroup"].NewRow();


            //            TourGroupRow["TourID"] = TourGroupTable.Rows[rowIndex].Cells["TourID"].Value;
            //            TourGroupRow["Amount"] = TourGroupTable.Rows[rowIndex].Cells["Amount"].Value;

            //            dataSet.Tables["TourGroup"].Rows.Add(TourGroupRow);

            //            dataSet.Tables["TourGroup"].Rows.RemoveAt(dataSet.Tables["TourGroup"].Rows.Count - 1);

            //            TourGroupTable.Rows.RemoveAt(TourGroupTable.Rows.Count - 2);

            //            TourGroupTable.Rows[e.RowIndex].Cells[3].Value = "Insert";

            //            sqlDataAdapter.Update(dataSet, "TourGroup");

            //            newTourGroupRowAdding = false;
            //        }
            //        else if (task == "Update")
            //        {
            //            int r = e.RowIndex;


            //            dataSet.Tables["TourGroup"].Rows[r]["TourID"] = TourGroupTable.Rows[r].Cells["TourID"].Value;
            //            dataSet.Tables["TourGroup"].Rows[r]["Amount"] = TourGroupTable.Rows[r].Cells["Amount"].Value;

            //            sqlDataAdapter.Update(dataSet, "TourGroup");

            //            TourGroupTable.Rows[e.RowIndex].Cells[3].Value = "Update";
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void TourGroupTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //try
            //{
            //    if (newTourGroupRowAdding == false)
            //    {
            //        newTourGroupRowAdding = true;
            //        int lastTourGroupRow = TourGroupTable.Rows.Count - 2;

            //        DataGridViewRow TourGroupRow = TourGroupTable.Rows[lastTourGroupRow];
            //        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //        TourGroupTable[3, lastTourGroupRow] = linkCell;

            //        TourGroupRow.Cells["Command"].Value = "Insert";

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void RealoadTourGroupData_Click(object sender, EventArgs e)
        {
            //dataSet.Tables["TourGroup"].Clear();

            //sqlDataAdapter.Fill(dataSet, "TourGroup");
            //TourGroupTable.DataSource = dataSet.Tables["TourGroup"];

            //for (int i = 0; i < TourGroupTable.Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    TourGroupTable[3, i] = linkCell;
            //}
        }

        private void ClientsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 8)
            //    {
            //        string task = ClientsTable.Rows[e.RowIndex].Cells[8].Value.ToString();
            //        if (task == "Delete")
            //        {
            //            if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //                == DialogResult.Yes)
            //            {
            //                int rowIndex = e.RowIndex;
            //                ClientsTable.Rows.RemoveAt(rowIndex);

            //                sqlDataAdapter.Update(dataSet, "ClientProfile");
            //            }
            //        }
            //        //else if (task == "Insert")
            //        //{
            //        //    int rowIndex = ClientsTable.Rows.Count - 2;

            //        //    DataRow ClientProfileRow = dataSet.Tables["ClientProfile"].NewRow();

            //        //    ClientProfileRow["ClientFullName"] = ClientsTable.Rows[rowIndex].Cells["ClientFullName"].Value;
            //        //    ClientProfileRow["ClientPhoneNumber"] = ClientsTable.Rows[rowIndex].Cells["ClientPhoneNumber"].Value;
            //        //    ClientProfileRow["DateOfBirth"] = ClientsTable.Rows[rowIndex].Cells["DateOfBirth"].Value;
            //        //    ClientProfileRow["Email"] = ClientsTable.Rows[rowIndex].Cells["Email"].Value;
            //        //    ClientProfileRow["Passport"] = ClientsTable.Rows[rowIndex].Cells["Passport"].Value;
            //        //    ClientProfileRow["InternationalPassport"] = ClientsTable.Rows[rowIndex].Cells["InternationalPassport"].Value;

            //        //    dataSet.Tables["ClientProfile"].Rows.Add(ClientProfileRow);

            //        //    dataSet.Tables["ClientProfile"].Rows.RemoveAt(dataSet.Tables["ClientProfile"].Rows.Count - 1);

            //        //    ClientsTable.Rows.RemoveAt(ClientsTable.Rows.Count - 2);

            //        //    ClientsTable.Rows[e.RowIndex].Cells[8].Value = "Delete";

            //        //    sqlDataAdapter.Update(dataSet, "ClientProfile");

            //        //    newClientProfileRowAdding = false;
            //        //}
            //        else if (task == "Update")
            //        {
            //            int r = e.RowIndex;



            //            dataSet.Tables["ClientProfile"].Rows[r]["ClientFullName"] = ClientsTable.Rows[r].Cells["ClientFullName"].Value;
            //            dataSet.Tables["ClientProfile"].Rows[r]["ClientPhoneNumber"] = ClientsTable.Rows[r].Cells["ClientPhoneNumber"].Value;
            //            dataSet.Tables["ClientProfile"].Rows[r]["DateOfBirth"] = ClientsTable.Rows[r].Cells["DateOfBirth"].Value;
            //            dataSet.Tables["ClientProfile"].Rows[r]["Email"] = ClientsTable.Rows[r].Cells["Email"].Value;
            //            dataSet.Tables["ClientProfile"].Rows[r]["Passport"] = ClientsTable.Rows[r].Cells["Passport"].Value;
            //            dataSet.Tables["ClientProfile"].Rows[r]["InternationalPassport"] = ClientsTable.Rows[r].Cells["InternationalPassport"].Value;

            //            //dataSet.Tables["ClientProfile"].Rows[r]["Amount"] = ClientsTable.Rows[r].Cells["Amount"].Value;

            //            sqlDataAdapter.Update(dataSet, "ClientProfile");

            //            ClientsTable.Rows[e.RowIndex].Cells[8].Value = "Update";
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void ReloadClientTable_Click(object sender, EventArgs e)
        {
            //dataSet.Tables["ClientProfile"].Clear();

            //sqlDataAdapter.Fill(dataSet, "ClientProfile");
            //ClientsTable.DataSource = dataSet.Tables["ClientProfile"];

            //for (int i = 0; i < ClientsTable.Rows.Count; i++)
            //{
            //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
            //    ClientsTable[8, i] = linkCell;
            //}
        }

        //private void ClientsTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (newTourRowAdding == false)
        //        {
        //            newClientProfileRowAdding = true;
        //            int lastProfileRow = ClientsTable.Rows.Count - 2;

        //            DataGridViewRow ClientProfileRow = ClientsTable.Rows[lastProfileRow];
        //            DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
        //            ClientsTable[8, lastProfileRow] = linkCell;

        //            ClientProfileRow.Cells["Command"].Value = "Insert";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void UpdateAdmProfile_Click(object sender, EventArgs e)
        {
            //AdmDateOfB

            if (UpdAdministratorFullName.Text == "" || UpdAdministratorEmail.Text == "" || UpdAdministratorPhoneNumber.Text == "")
            {
                System.Windows.MessageBox.Show("Пустое поле");
            }

            else
            {
                //if (ManagerEmail.Text != "")
                {
                    SqlCommand CheckAdmEmail = new SqlCommand("CheckAdmEmail", sqlConnection);
                    CheckAdmEmail.CommandType = CommandType.StoredProcedure;
                    CheckAdmEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = UpdAdministratorEmail.Text;


                    var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                    answer.Direction = System.Data.ParameterDirection.Output;
                    answer.Size = 64;
                    CheckAdmEmail.Parameters.Add(answer);

                    CheckAdmEmail.ExecuteNonQuery();
                    var res = answer.Value.ToString();

                    if (res == "Почта Присутствует в базе")
                    {
                        MessageBox.Show("Почта Присутствует в базе");
                    }
                    else if (res == "Почта отсутствует в базе")
                    {
                        //CheckPhoneNumber
                        SqlCommand CheckAdmPhoneNumber = new SqlCommand("CheckAdmPhoneNumber", sqlConnection);
                        CheckAdmPhoneNumber.CommandType = CommandType.StoredProcedure;
                        CheckAdmPhoneNumber.Parameters.Add("@clientphonenumber", SqlDbType.VarChar).Value = UpdAdministratorPhoneNumber.Text;

                        var answer1 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer1.Direction = System.Data.ParameterDirection.Output;
                        answer1.Size = 64;
                        CheckAdmPhoneNumber.Parameters.Add(answer1);

                        CheckAdmPhoneNumber.ExecuteNonQuery();
                        var res1 = answer1.Value.ToString();

                        if (res1 == "Номер телефона Присутствует в базе")
                        {
                            MessageBox.Show("Номер телефона Присутствует в базе");
                        }

                        else if (res1 == "Номер телефона отсутствует в базе")
                        {

                            SqlCommand UpdateAdminProfile = new SqlCommand("Update Administrator " +
                            "Set AdministratorFullName = " + UpdAdministratorFullName.Text + ", Email = " + UpdAdministratorEmail.Text +
                            ", PhoneNumber = " + UpdAdministratorPhoneNumber.Text + ", DateOfBirth = " + AdmDateOfB.SelectionStart.Date.ToString("yyyy-MM-dd") +
                             "  Where AdministratorID =" + DataBank.CurrentAdministratorID, sqlConnection);


                            UpdateAdminProfile.ExecuteNonQuery();

                            MessageBox.Show("Профиль обновлён");


                        }

                    }
                }

                //Hide();
                //Cl.Show();
            }

        }

        private void ToTourForm_Click(object sender, EventArgs e)
        {
            this.Hide();
            TourForms newToursForm = new TourForms();
            newToursForm.Show();
        }

        private void WorkWithTourGroups_Click(object sender, EventArgs e)
        {
            this.Hide();
            TourGroupForm newTourGroupForm = new TourGroupForm ();
            newTourGroupForm.Show();
        }

        private void WorkWIthClientsTable_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientsWorkForm newClientsWorkForm = new ClientsWorkForm();
            newClientsWorkForm.Show();
        }

        private void WatchHistOfOps_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistoryOfOperations newHistOfOpsForm = new HistoryOfOperations();
            newHistOfOpsForm.Show();
        }

        private void ClientsGroupList_Click(object sender, EventArgs e)
        {

        }
    }

}

