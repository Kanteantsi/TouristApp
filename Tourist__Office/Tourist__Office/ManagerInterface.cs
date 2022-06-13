using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Tourist__Office
{
    public partial class ManagerInterface : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        //SqlConnection sqlconnection;
        public ManagerInterface()
        {
            InitializeComponent();

        }
        private void SearchRequestsForPeriod_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            //SqlDataReader sqlReader = null;
            //var cultureInfo = new CultureInfo("	it-it");
            SqlCommand RequestsForPeriod = new SqlCommand("RequestsForPeriod", sqlConnection);
            RequestsForPeriod.CommandType = CommandType.StoredProcedure;
            RequestsForPeriod.Parameters.Add("@Date1", SqlDbType.Date);
            RequestsForPeriod.Parameters.Add("@Date2", SqlDbType.Date);
            RequestsForPeriod.Parameters["@Date1"].Value = DataBank.Man.Date1ToChoose.SelectionStart.Date.ToString("yyyy-MM-dd");
            RequestsForPeriod.Parameters["@Date2"].Value = DataBank.Man.Date2ToChoose.SelectionStart.Date.ToString("yyyy-MM-dd");
            //RequestsForPeriod.Parameters["@Date1"].Value = Date1ToChoose.SelectionStart.Date.ToString("yyyy-MM-dd");
            //RequestsForPeriod.Parameters["@Date2"].Value = Date2ToChoose.SelectionStart.Date.ToString("yyyy-MM-dd");


            var reader = RequestsForPeriod.ExecuteReader();

            if (reader.HasRows)
            {
                //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                while (reader.Read()) /*ManagerFullName,RequestDate,ClientFullName,Acceptance*/
                {
                    ReqForPer.Text += (Convert.ToString(reader["ManagerFullName"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ClientFullName"]) + "    " + Convert.ToString(reader["RequestDate"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                }
            }
            reader.Close();
        }
         //RequestsForPeriod.
            //String str1 = Date1.Text.ToString();
            //Date1.Text.ToString("YYYY/MM/DD");
            //RequestsForPeriod.Parameters["@Date1"].Value = Date1.Text.GetDateTimeFormats()[5];
            //Date1ToChoose.ToString("yyyy-MM-dd"));



            //RequestsForPeriod.ExecuteNonQuery();


       


        private void LoadData()
        {

            try
            {
                //sqlDataAdapter = new SqlDataAdapter("SELECT * From Request ", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                ////sqlBuilder.GetInsertCommand();
                ////sqlBuilder.GetUpdateCommand();
                ////sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();

                //sqlDataAdapter.Fill(dataSet, "Request");
                //RequestsForManagerTable.DataSource = dataSet.Tables["Request"];

                //for (int i = 0; i < RequestsForManagerTable.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    RequestsForManagerTable[5, i] = linkCell;
                //}

                sqlDataAdapter = new SqlDataAdapter("SELECT * From FiveMostActiveClient", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();


                sqlDataAdapter.Fill(dataSet, "FiveMostActiveClient");
                DataBank.Man.FiveMstActCl.DataSource = dataSet.Tables["FiveMostActiveClient"];

                //for (int i = 0; i < FiveMstActCl.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    FiveMstActCl[1, i] = linkCell;
                //}


                sqlDataAdapter = new SqlDataAdapter("SELECT * From MostPopularTours", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();


                sqlDataAdapter.Fill(dataSet, "MostPopularTours");
                DataBank.Man.MstPopTr.DataSource = dataSet.Tables["MostPopularTours"];

                //sqlDataAdapter = new SqlDataAdapter("SELECT * From MostPopTours", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                ////sqlBuilder.GetInsertCommand();
                ////sqlBuilder.GetUpdateCommand();
                ////sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();


                //sqlDataAdapter.Fill(dataSet, "MostPopTours");
                //MstPopTr.DataSource = dataSet.Tables["MostPopTours"];




                sqlDataAdapter = new SqlDataAdapter("SELECT * From LessPopTours", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();


                sqlDataAdapter.Fill(dataSet, "LessPopTours");
                DataBank.Man.LessPopTr.DataSource = dataSet.Tables["LessPopTours"];

                





                //for (int i = 0; i < RequestsForManagerTable.Rows.Count; i++)
                //    for (int j = 0; j < RequestsForManagerTable.Columns.Count; j++)

                //    {
                //       if (RequestsForManagerTable[j, i].Value.Equals(true))

                //        {
                //            RequestsForManagerTable[j, i].ReadOnly = true;
                //        }
                //    }




                //sqlDataAdapter = new SqlDataAdapter("MostActiveClient", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                ////sqlBuilder.GetInsertCommand();
                ////sqlBuilder.GetUpdateCommand();
                ////sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();

                //sqlDataAdapter.Fill(dataSet, "MostActiveClient");
                //MstActCl.DataSource = dataSet.Tables["MostActiveClient"];


                //SqlCommand MostActiveClient = new SqlCommand("MostActiveClient", sqlConnection);
                //MostActiveClient.CommandType = CommandType.StoredProcedure;

                //var reader1 = MostActiveClient.ExecuteReader();

                //if (reader1.HasRows)
                //{
                //    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                //    while (reader1.Read()) /*ManagerFullName,RequestDate,ClientFullName,Acceptance*/
                //    {
                //        MostActCl.Text += " " + reader1.GetString(0);
                //        AAAAAAAAAAAAA.Text = " " + reader1.GetString(0);
                //        MAC.Text = " " + reader1.GetString(0);
                //    }

                //}
                //reader1.Close();


                SqlCommand MostActiveClient1 = new SqlCommand("Select * From MostActiveClientSales", sqlConnection);
                var reader2 = MostActiveClient1.ExecuteReader();


                if (reader2.HasRows)
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader2.Read()) /*ManagerFullName,RequestDate,ClientFullName,Acceptance*/
                    {
                        MostActCl.Text += " " + reader2.GetString(0);
                    }

                }
                reader2.Close();
                //for (int i = 0; i < MstPopTr.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    MstPopTr[5, i] = linkCell;
                //}




            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void ManagerInterface_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
            //string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            //sqlconnection = new SqlConnection(ConnectionString);
            //sqlconnection.Open();
            //SqlDataReader sqlReader = null;




            //SqlCommand MostPopularTours = new SqlCommand("Select * From MostPopularTours   ", sqlconnection);


            //    using (SqlConnection connection = new SqlConnection(ConnectionString))
            //    {
            //        connection.Open();
            //        SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
            //        FillRequests.CommandType = CommandType.StoredProcedure;
            //        // указываем, что команда представляет хранимую процедуру

            //        var reader = FillRequests.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //            while (reader.Read())
            //            {
            //                Requests.Text += (Convert.ToString(reader["RequestId"]) + "    " + Convert.ToString(reader["ClientId"]) + "    " + Convert.ToString(reader["TourId"]) + "    " + Convert.ToString(reader["RequestDate"]) + "       " + Convert.ToString(reader["ManagerId"]) + "    " + Convert.ToString(reader["Acceptance"]) + "\n");
            //            }
            //        }
            //        reader.Close();
            //    }

            //    using (SqlConnection connection = new SqlConnection(ConnectionString))
            //    {
            //        connection.Open();
            //        //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
            //        SqlCommand MostActiveClient = new SqlCommand("MostActiveClient", connection);
            //        MostActiveClient.CommandType = CommandType.StoredProcedure;

            //        // указываем, что команда представляет хранимую процедуру

            //        var reader = MostActiveClient.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //            while (reader.Read())
            //            {
            //                MstActClient.Text += (Convert.ToString(reader["ClientID"]) + "    " + Convert.ToString(reader["ClientFullName"]) + "    " + Convert.ToString(reader["ClientPhoneNumber"]) + "    " + Convert.ToString(reader["DateOfBirth"]) + "       " + Convert.ToString(reader["Email"]) + "    " + Convert.ToString(reader["Passport"]) + "    " + Convert.ToString(reader["InternationalPassport"]) + "\n");
            //            }
            //        }
            //        reader.Close();
            //    }



            //    using (SqlConnection connection = new SqlConnection(ConnectionString))
            //    {
            //        connection.Open();
            //        //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
            //        SqlCommand MostPopularTour = new SqlCommand("Select * From MostPopularTours  ", connection);
            //        //MostPopularTour.CommandType = CommandType.StoredProcedure;

            //        // указываем, что команда представляет хранимую процедуру

            //        var reader = MostPopularTour.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //            while (reader.Read())
            //            {
            //                MstPopTrs.Text += (Convert.ToString(reader["TourID"]) + "    " + Convert.ToString(reader[" TourDate"]) + "    " + Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "       " + Convert.ToString(reader["TourDescription"]) + "\n");
            //            }
            //        }
            //        reader.Close();
            //    }



            //}

            //private void выходToolStripMenuItem_Click(object sender, EventArgs e)
            //{
            //    if (sqlconnection != null && sqlconnection.State != ConnectionState.Closed)
            //        sqlconnection.Close();
            //}



            //private void ClientsIssuedByTheManage_Click(object sender, EventArgs e)
            //{
            //    string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            //    using (SqlConnection connection = new SqlConnection(ConnectionString))
            //    {
            //        connection.Open();
            //        //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
            //        SqlCommand ClientsIssuedByTheManager = new SqlCommand("ClientsIssuedByTheManager @ClientFullName  ", connection);
            //        ClientsIssuedByTheManager.CommandType = CommandType.StoredProcedure;
            //        ClientsIssuedByTheManager.Parameters.Add("@ClientFullName", SqlDbType.NVarChar);
            //        // указываем, что команда представляет хранимую процедуру
            //        ClientsIssuedByTheManager.Parameters["@ManagerFullName"].Value = ManagerFullNameForCl.Text;
            //        var reader = ClientsIssuedByTheManager.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //            while (reader.Read())
            //            {
            //                ClientsIssuedByTheManag.Text += (Convert.ToString(reader["TourID"]) + "    " + Convert.ToString(reader[" TourDate"]) + "    " + Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "       " + Convert.ToString(reader["TourDescription"]) + "\n");
            //            }
            //        }
            //        reader.Close();
            //    }
            //}

            //private void ShowClientsHistoryOfRequests_Click(object sender, EventArgs e)
            //{
            //    string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            //    using (SqlConnection connection = new SqlConnection(ConnectionString))
            //    {
            //        connection.Open();
            //        //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
            //        SqlCommand ShowHistoryOfRequests = new SqlCommand("ShowHistoryOfRequests @ClientFullName  ", connection);
            //        ShowHistoryOfRequests.CommandType = CommandType.StoredProcedure;
            //        ShowHistoryOfRequests.Parameters.Add("@ClientFullName", SqlDbType.NVarChar);
            //        // указываем, что команда представляет хранимую процедуру
            //        ShowHistoryOfRequests.Parameters["@ClientFullName"].Value = ClientFullNameForHist.Text;
            //        var reader = ShowHistoryOfRequests.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            //            while (reader.Read())
            //            {
            //                HstOfReq.Text += (Convert.ToString(reader["TourID"]) + "    " + Convert.ToString(reader[" TourDate"]) + "    " + Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "       " + Convert.ToString(reader["TourDescription"]) + "\n");
            //            }
            //        }
            //        reader.Close();
            //    }
        }

        private void ChangeStatus_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            
            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{             
            //    {
            //        connection.Open();
            //        SqlCommand UpdateRequest = new SqlCommand("UpdateRequest (@RequestID, @Acceptance, @TourPlacement", connection);
            //        UpdateRequest.Parameters.Add("@RequestID", SqlDbType.NVarChar);

            //        if ((RequestStatus.Text == " Не принята")&&(AnotherTour.Text == ""))
            //        {
            //            System.Windows.Forms.MessageBox.Show("Нельзя обновить статус заявки, не указав другой тур");
            //        }

            //        else   if ((RequestStatus.Text == " Не принята") && (AnotherTour.Text != ""))
            //        {
            //            UpdateRequest.Parameters["@TourPlacement"].Value = AnotherTour.Text;
            //            UpdateRequest.Parameters["@RequestID"].Value = RequestIDToUpdate.Text;
            //            UpdateRequest.Parameters["@Acceptance"].Value = 1;
            //            UpdateRequest.ExecuteNonQuery();
            //        }
            //        else if (RequestStatus.Text == "Принята")
            //        {
            //            UpdateRequest.Parameters["@RequestID"].Value  = RequestIDToUpdate.Text;
            //            UpdateRequest.Parameters["@Acceptance"].Value = 1;
            //            UpdateRequest.ExecuteNonQuery();
            //        }


                                
                    
            //    }
            //}
        }

        private void ClientsIssuedByTheManage_Click(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand CheckManExists = new SqlCommand("CheckManExists", sqlConnection);
                CheckManExists.CommandType = CommandType.StoredProcedure;
                CheckManExists.Parameters.Add("@ManagerFullName", SqlDbType.VarChar).Value = ManagerFullNameForCl.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckManExists.Parameters.Add(answer);

                CheckManExists.ExecuteNonQuery();
                var res0 = answer.Value.ToString();

                if (res0 == "Менеджер с таким ФИО отсутствует в базе")
                {
                    System.Windows.MessageBox.Show("Менеджер с таким ФИО отсутствует в базе");
                }
                else if (res0 == "Менеджер с таким ФИО присутствует в базе")
                {
                    //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
                    SqlCommand ClientsIssuedByTheManager = new SqlCommand("ClientsIssuedByTheManager", connection);
                    ClientsIssuedByTheManager.CommandType = CommandType.StoredProcedure;
                    ClientsIssuedByTheManager.Parameters.Add("@ManagerFullName", SqlDbType.VarChar);
                    ClientsIssuedByTheManager.Parameters["@ManagerFullName"].Value = ManagerFullNameForCl.Text;


                    // указываем, что команда представляет хранимую процедуру

                    var reader = ClientsIssuedByTheManager.ExecuteReader();

                    if (reader.HasRows)
                    {
                        //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                        while (reader.Read()) /*ClientFullName, ClientPhoneNumber,ManagerFullName*/
                        {
                            ClientsIssuedByTheManag.Text += (Convert.ToString(reader["ClientFullName"]) + "    " + Convert.ToString(reader["ClientPhoneNumber"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "\n");
                        }
                    }
                    reader.Close();
                }

            }
        }

        private void ManagerInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void UpdateManProfile_Click(object sender, EventArgs e)
        {
            if (ManagerFullName.Text == "" || ManagerEmail.Text == "" || ManagerPhoneNumber.Text == "")
            {
                System.Windows.MessageBox.Show("Пустое поле");
            }

            else
            {
                //if (ManagerEmail.Text != "")
                {
                    SqlCommand CheckManEmail = new SqlCommand("CheckManEmail", sqlConnection);
                    CheckManEmail.CommandType = CommandType.StoredProcedure;
                    CheckManEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = ManagerEmail.Text;


                    var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                    answer.Direction = System.Data.ParameterDirection.Output;
                    answer.Size = 64;
                    CheckManEmail.Parameters.Add(answer);

                    CheckManEmail.ExecuteNonQuery();
                    var res = answer.Value.ToString();

                    if (res == "Почта Присутствует в базе")
                    {
                        System.Windows.MessageBox.Show("Почта Присутствует в базе");
                    }
                    else if (res == "Почта отсутствует в базе")
                    {
                        //CheckPhoneNumber
                        SqlCommand CheckManPhone = new SqlCommand("CheckPhoneNumber", sqlConnection);
                        CheckManPhone.CommandType = CommandType.StoredProcedure;
                        CheckManPhone.Parameters.Add("@clientphonenumber", SqlDbType.VarChar).Value = ManagerPhoneNumber.Text;

                        var answer1 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer1.Direction = System.Data.ParameterDirection.Output;
                        answer1.Size = 64;
                        CheckManPhone.Parameters.Add(answer1);

                        CheckManPhone.ExecuteNonQuery();
                        var res1 = answer1.Value.ToString();

                        if (res1 == "Номер телефона Присутствует в базе")
                        {
                            System.Windows.MessageBox.Show("Номер телефона Присутствует в базе");
                        }

                        else if (res1 == "Номер телефона отсутствует в базе")
                        {
                            //SqlCommand UpdateManager = new SqlCommand("ManagerRegistration", sqlConnection);

                            SqlCommand UpdateManagerProfile = new SqlCommand("Update Manager " +
                            "Set ManagerFullName = " + ManagerFullName.Text + ", Email = " + ManagerEmail.Text +
                            ", PhoneNumber = " + ManagerPhoneNumber.Text + ", DateOfBirth = " + ManDateOfBirth.SelectionStart.Date.ToString("yyyy-MM-dd") +                             
                             "  Where ManagerID =" + DataBank.CurrentManagerID, sqlConnection);


                            UpdateManagerProfile.ExecuteNonQuery();


                            System.Windows.MessageBox.Show("Профиль обновлён");

                        }

                    }
                }

                //Hide();
                //Cl.Show();
            }

        }

        private void WorkWithRequests_Click(object sender, EventArgs e)
        {
            this.Hide();
            WorkWithRequests newWorkWithRequests = new WorkWithRequests();
            newWorkWithRequests.Show();
        }

        private void ShowClientsHistoryOfRequests_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True"))
            {
                connection.Open();
                //DataBank.CurrentClientFullname = "Воробьёв  Иван Сергеевич";
                //DataBank.CurrentClientID = 2;

                SqlCommand CheckClExists = new SqlCommand("CheckClExists", sqlConnection);
                CheckClExists.CommandType = CommandType.StoredProcedure;
                CheckClExists.Parameters.Add("@ClientFullName", SqlDbType.VarChar).Value = ClientFullNameForHist.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckClExists.Parameters.Add(answer);

                CheckClExists.ExecuteNonQuery();
                var res0 = answer.Value.ToString();

                if (res0 == "Клиент с таким ФИО отсутствует в базе") 
                {
                    System.Windows.MessageBox.Show("Клиент с таким ФИО отсутствует в базе");
                }
                else if (res0 == "Клиент с таким ФИО присутствует в базе")
                { 


                    String ShowCHistoryOfRequestQuery = "ShowHistoryOfRequests";

                SqlCommand ShowHist = new SqlCommand(ShowCHistoryOfRequestQuery, sqlConnection);
                // указываем, что команда представляет хранимую процедуру
                ShowHist.CommandType = CommandType.StoredProcedure;
                ShowHist.Parameters.Add("@ClientFullName", SqlDbType.VarChar);
                ShowHist.Parameters["@ClientFullName"].Value = DataBank.Man.ClientFullNameForHist.Text;
                //ShowHist.Parameters["@ClientFullName"].Value = DataBank.CurrentClientFullname;
                //ShowHist.ExecuteNonQuery();
                var reader = ShowHist.ExecuteReader();
                //ClHISTOFREQS.Text += Convert.ToString (reader.GetName(0) + Convert.ToString ( reader.GetName(1)) + Convert.ToString (reader.GetName(2)) ) + Convert.ToString(reader.GetName(3))  + Convert.ToString(reader.GetName(4))   +Convert.ToString(reader.GetName(5)) + Convert.ToString(reader.GetName(6));


                if (reader.HasRows)
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader.Read())
                    {
                        //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                        DataBank.Man.HstOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                    }
                }
                reader.Close();
            }
          }
        }

        private void ClientsGroupList_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientsGroupList newClientsGroupList = new ClientsGroupList();
            newClientsGroupList.Show();
        }
        //private void SearchRequestsForPeriod_Click(object sender, EventArgs e)
        //{
        //    Date1ToChoose
        //}
    }
}
