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

    public partial class ClientInterface : Form
    {

        private SqlConnection sqlConnection = null;

        //private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        private void LoadData()
        {

            try
            {



                sqlDataAdapter = new SqlDataAdapter("SELECT TourDate,TourPlacement,TourPrice,TourDescription From Tour", sqlConnection);


                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "Tour");
                ToursTableForUser.DataSource = dataSet.Tables["Tour"];


                sqlDataAdapter = new SqlDataAdapter("SELECT TourPlacement,TourDate From MostPopularTours", sqlConnection);
                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);


                dataSet = new DataSet();


                sqlDataAdapter.Fill(dataSet, "MostPopularTours");
                MostPopTors.DataSource = dataSet.Tables["MostPopularTours"];




                //String ShowClientProfileQuery = "SELECT ClientFullName, ClientPhoneNumber,DateOfBirth,Email,Passport, InternationalPassport, 'Update' as [Update] From ClientProfile Where ClientID = " + DataBank.CurrentClientID + " ";
                //sqlDataAdapter = new SqlDataAdapter(ShowClientProfileQuery, sqlConnection);
                ////sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                ////sqlBuilder.GetInsertCommand();
                ////sqlBuilder.GetUpdateCommand();
                ////sqlBuilder.GetDeleteCommand();

                //dataSet = new DataSet();
                ////@ClientID = DataBank.CurrentClientID;

                //sqlDataAdapter.Fill(dataSet, "ClientProfile");
                //ClientWatchAndUpdateProfile.DataSource = dataSet.Tables["ClientProfile"];

                //for (int i = 0; i < ToursTableForUser.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    ClientWatchAndUpdateProfile[6, i] = linkCell;
                //}

                //                String ShowCHistoryOfRequestQuery = "SELECT TourPlacement, TourPrice, RequestDate,ManagerFullName,Acceptance FROM ClientProfile Inner Join Request on (ClientProfile.ClientID = Request.ClientID) Inner Join Tour on  (Tour.TourID = Request.TourID) Where ClientID = " + DataBank.CurrentClientID;
                //                sqlDataAdapter = new SqlDataAdapter(ShowClientProfileQuery, sqlConnection);
                //                //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //                dataSet = new DataSet();
                //=

                //                sqlDataAdapter.Fill(dataSet, "Request");
                //                ClHistOfReq.DataSource = dataSet.Tables["Request"];

                //                for (int i = 0; i < ToursTableForUser.Rows.Count; i++)
                //                {
                //                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //                    ClHistOfReq[6, i] = linkCell;
                //                }








            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public ClientInterface()
        {
            InitializeComponent();


            sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True");
            sqlConnection.Open();

            LoadData();
        }

        private void LeaveaRequest_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True"))
            {

                connection.Open();
                //DataBank.CurrentClientFullname = "Воробьёв  Иван Сергеевич";
                //DataBank.CurrentClientID = 2;

                //String AddRequestForTour = "AddRequestForTour";


                SqlCommand CheckManExists = new SqlCommand("CheckManExists", sqlConnection);
                CheckManExists.CommandType = CommandType.StoredProcedure;
                CheckManExists.Parameters.Add("@ManagerFullName", SqlDbType.VarChar).Value = DataBank.Cl.ManFullNameReq.Text;


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
                    SqlCommand CheckTourExists = new SqlCommand("CheckTourExists", sqlConnection);
                    CheckTourExists.CommandType = CommandType.StoredProcedure;
                    CheckTourExists.Parameters.Add("@TourPlacement", SqlDbType.VarChar).Value = DataBank.Cl.TourPlacementReq.Text;


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
                        SqlCommand AddRequestForTourQuery = new SqlCommand("AddRequestForTour", sqlConnection);
                    // указываем, что команда представляет хранимую процедуру
                    AddRequestForTourQuery.CommandType = CommandType.StoredProcedure;
                    AddRequestForTourQuery.Parameters.Add("@ClientID", SqlDbType.Int);
                    AddRequestForTourQuery.Parameters.Add("@TourPlacement", SqlDbType.VarChar);
                    AddRequestForTourQuery.Parameters.Add("@ManagerFullName", SqlDbType.VarChar);
                    AddRequestForTourQuery.Parameters.Add("@RequestDate", SqlDbType.VarChar);



                    AddRequestForTourQuery.Parameters["@ClientID"].Value = DataBank.CurrentClientID;
                    AddRequestForTourQuery.Parameters["@TourPlacement"].Value = DataBank.Cl.TourPlacementReq.Text;
                    AddRequestForTourQuery.Parameters["@ManagerFullName"].Value = DataBank.Cl.ManFullNameReq.Text;
                    AddRequestForTourQuery.Parameters["@RequestDate"].Value = DataBank.Cl.RequestDateCalend.SelectionStart.Date.ToString("yyyy-MM-dd");


                        AddRequestForTourQuery.ExecuteNonQuery();
                        MessageBox.Show("Заявка на тур оставлена");
                    }

                    //var reader = ShowHist.ExecuteReader();
                    //ClHISTOFREQS.Text += Convert.ToString (reader.GetName(0) + Convert.ToString ( reader.GetName(1)) + Convert.ToString (reader.GetName(2)) ) + Convert.ToString(reader.GetName(3))  + Convert.ToString(reader.GetName(4))   +Convert.ToString(reader.GetName(5)) + Convert.ToString(reader.GetName(6));


                    //if (reader.HasRows)
                    //{
                    //    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    //    while (reader.Read())
                    //    {
                    //        //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                    //        HstOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                    //    }
                    //}
                    //reader.Close();
                }
            }


        }

        private void ClientInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void UpdateClientProfile_Click(object sender, EventArgs e)
        {
            if (ClientFullNameUpd.Text == "")
            {
                MessageBox.Show("ФИО пустое!");
            }
            if (ClientEmailUpd.Text == "")
            {
                MessageBox.Show("Email пустое!");
            }
            if (ClientPhoneNumberUpd.Text == "")
            {
                MessageBox.Show("Номер пустое!");
            }

            if (ClientPassportUpd.Text == "")
            {
                MessageBox.Show("Паспорт пустое!");
            }

            if (ClientInternationalPassportUpd.Text == "")
            {
                MessageBox.Show("Загранпаспорт пустое!");
            }

            {
                SqlCommand CheckClEmail = new SqlCommand("CheckClEmail", sqlConnection);
                CheckClEmail.CommandType = CommandType.StoredProcedure;
                CheckClEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = DataBank.Cl.ClientEmailUpd.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckClEmail.Parameters.Add(answer);

                CheckClEmail.ExecuteNonQuery();
                var res = answer.Value.ToString();

                if (res == "Почта Присутствует в базе")
                {
                    MessageBox.Show("Почта Присутствует в базе");
                }
                else if (res == "Почта отсутствует в базе")
                {
                    //CheckPhoneNumber
                    SqlCommand CheckPhoneNumber = new SqlCommand("CheckPhoneNumber", sqlConnection);
                    CheckPhoneNumber.CommandType = CommandType.StoredProcedure;
                    CheckPhoneNumber.Parameters.Add("@clientphonenumber", SqlDbType.VarChar).Value = DataBank.Cl.ClientPhoneNumberUpd.Text;

                    var answer1 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                    answer1.Direction = System.Data.ParameterDirection.Output;
                    answer1.Size = 64;
                    CheckPhoneNumber.Parameters.Add(answer1);

                    CheckPhoneNumber.ExecuteNonQuery();
                    var res1 = answer1.Value.ToString();

                    if (res1 == "Номер телефона Присутствует в базе")
                    {
                        MessageBox.Show("Номер телефона Присутствует в базе");
                    }

                    else if (res1 == "Номер телефона отсутствует в базе")
                    {
                        SqlCommand CheckClPassport = new SqlCommand("CheckClPassport", sqlConnection);
                        CheckClPassport.CommandType = CommandType.StoredProcedure;
                        CheckClPassport.Parameters.Add("@passport", SqlDbType.VarChar).Value = DataBank.Cl.ClientPassportUpd.Text;

                        var answer2 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer2.Direction = System.Data.ParameterDirection.Output;
                        answer2.Size = 64;
                        CheckClPassport.Parameters.Add(answer2);

                        CheckClPassport.ExecuteNonQuery();
                        var res2 = answer2.Value.ToString();

                        if (res2 == "Паспорт Присутствует в базе")
                        {
                            MessageBox.Show("Паспорт Присутствует в базе");
                        }
                        else if (res2 == "Паспорт отсутствует в базе")
                        {
                            SqlCommand CheckClIntPassport = new SqlCommand("CheckClIntPassport", sqlConnection);
                            CheckClIntPassport.CommandType = CommandType.StoredProcedure;
                            CheckClIntPassport.Parameters.Add("@intpassport", SqlDbType.VarChar).Value = DataBank.Cl.ClientInternationalPassportUpd.Text;

                            var answer3 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                            answer3.Direction = System.Data.ParameterDirection.Output;
                            answer3.Size = 64;
                            CheckClPassport.Parameters.Add(answer3);

                            CheckClIntPassport.ExecuteNonQuery();
                            var res3 = answer3.Value.ToString();

                            if (res3 == "Загранпаспорт Присутствует в базе")
                            {
                                MessageBox.Show("Загранпаспорт Присутствует в базе");
                            }
                            else if (res3 == "Загранпаспорт отсутствует в базе")
                            {
                                SqlCommand UpdateClientProfile = new SqlCommand("Update ClientProfile " +
                                                "Set ClientFullName = " + DataBank.Cl.ClientFullNameUpd.Text + ", ClientPhoneNumber = " + DataBank.Cl.ClientPhoneNumberUpd.Text +
                                                ", DateOfBirth = " + DataBank.Cl.ClientDateOfBirth.SelectionStart.Date.ToString("yyyy-MM-dd") + ", Email = " + DataBank.Cl.ClientEmailUpd.Text +
                                                ", Passport = " + DataBank.Cl.ClientPassportUpd.Text + " , InternationalPassport ='" + DataBank.Cl.ClientInternationalPassportUpd.Text +
                                                "  Where ClientID =" + DataBank.CurrentClientID, sqlConnection);


                                UpdateClientProfile.ExecuteNonQuery();

                                MessageBox.Show("Профиль обновлён");

                                //SqlCommand CheckAuth = new SqlCommand("Authentification", sqlConnection);
                                //CheckAuth.CommandType = CommandType.StoredProcedure;
                                //CheckAuth.Parameters.Add("@login", SqlDbType.VarChar).Value = AuthLogin.Text;
                                //CheckAuth.Parameters.Add("@password", SqlDbType.VarChar).Value = Verification.GetSHA256Hash(AuthPassword.Text);
                                ////CheckAuth.Parameters.Add("@Answer", SqlDbType.VarChar).Value = "";

                                //string login = AuthLogin.Text;
                                //string password = Verification.GetSHA256Hash(AuthPassword.Text).ToLower();

                                //var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                                //answer.Direction = System.Data.ParameterDirection.Output;
                                //answer.Size = 64;
                                //CheckAuth.Parameters.Add(answer);

                                //CheckAuth.ExecuteNonQuery();
                                //var res = answer.Value.ToString();

                                //Cl.ClientFullNameUpd.Text = ClientFullName.Text;
                                //Cl.ClientPhoneNumberUpd.Text = ClientPhoneNumber.Text;
                                //Cl.ClientDateOfBirthUpd.Text = ClDateOfB.SelectionStart.Date.ToString("yyyy-MM-dd");
                                //Cl.ClientEmailUpd.Text = ClientEmail.Text;
                                //Cl.ClientPassportUpd.Text = ClientPassport.Text;
                                //Cl.ClientInternationalPassportUpd.Text = ClientInternationalPassport.Text;
                                //DataBank.CurrentClientID = (reader2.GetInt32(0));
                                //DataBank.CurrentClientFullname = (reader2.GetString(1));
                                //DataBank.CurrentClientPhoneNumber = (reader2.GetString(2));
                                //DataBank.CurrentClientDateOfBirth = reader2.GetDateTime(3).ToString();
                                //DataBank.CurrentClientEmail = reader2.GetString(4);
                                //DataBank.CurrentClientPassport = (reader2.GetString(5));
                                //DataBank.CurrentClientInternationalPassport = (reader2.GetString(6));


                                //Cl.ClientFullNameUpd.Text = DataBank.CurrentClientFullname;
                                //Cl.ClientPhoneNumberUpd.Text = DataBank.CurrentClientPhoneNumber;
                                //Cl.ClientDateOfBirthUpd.Text = DataBank.CurrentClientDateOfBirth;
                                //Cl.ClientEmailUpd.Text = DataBank.CurrentClientEmail;
                                //Cl.ClientPassportUpd.Text = DataBank.CurrentClientPassport;
                                //Cl.ClientInternationalPassportUpd.Text = DataBank.CurrentClientInternationalPassport;
                                //this.Hide();
                                //Cl.Show();


                            }

                        }



                    }

                }
            }

            //Hide();
            //Cl.Show();
        }

        private void ShowClHistOfReq_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True"))
            {
                connection.Open();


                String ShowCHistoryOfRequestQuery = "ShowHistoryOfRequests";

                SqlCommand ShowHist = new SqlCommand(ShowCHistoryOfRequestQuery, sqlConnection);

                ShowHist.CommandType = CommandType.StoredProcedure;
                ShowHist.Parameters.Add("@ClientFullName", SqlDbType.VarChar);
                //ShowHist.Parameters["@ClientFullName"].Value = DataBank.CurrentClientFullname;
                //ShowHist.Parameters["@ClientFullName"].Value = ClientFullNameUpd.Text;
                ShowHist.Parameters["@ClientFullName"].Value = DataBank.Cl.ClNameFR.Text;

                var reader = ShowHist.ExecuteReader();


                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                        DataBank.Cl.HstOfReq.Text += ("   " + Convert.ToString(reader["TourPlacement"]) + "                                                                     " + Convert.ToString(reader["TourPrice"]) + "                                     " + Convert.ToString(reader["RequestDate"]) + "                                                           " + Convert.ToString(reader["ManagerFullName"]) + "                                             " + Convert.ToString(reader["Acceptance"]) + "\n");
                    } 
                }
                reader.Close();
            }
        }

        private void ShowClTourGroups_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True"))
            {
                connection.Open();


                String ShowClGroupListQuery = "Select ClientsGroupList.TourGroupID as GroupNumber, TourPlacement, TourDate From Tour inner Join TourGroup on (TourGroup.TourID = Tour.TourID) inner Join ClientsGroupList on (TourGroup.TourGroupID = ClientsGroupList.TourGroupID) Where ClientsGroupList.ClientID = " + DataBank.CurrentClientID + " ";

                SqlCommand ShowClGroupList = new SqlCommand(ShowClGroupListQuery, sqlConnection);

                //ShowHist.CommandType = CommandType.StoredProcedure;
                //ShowHist.Parameters.Add("@ClientFullName", SqlDbType.VarChar);
                //ShowHist.Parameters["@ClientFullName"].Value = DataBank.CurrentClientFullname;
                //ShowHist.Parameters["@ClientFullName"].Value = ClientFullNameUpd.Text;
                //ShowHist.Parameters["@ClientFullName"].Value = DataBank.Cl.ClNameFR.Text;

                var reader = ShowClGroupList.ExecuteReader();


                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        //ClHistOfReq.Text += (Convert.ToString(reader["TourPlacement"]) + "    " + Convert.ToString(reader["TourPrice"]) + "    " + Convert.ToString(reader["RequestDate"]) + "    " + Convert.ToString(reader["ManagerFullName"]) + "       " + Convert.ToString(reader["Acceptance"]) + "\n");
                        DataBank.Cl.ClTourGr.Text += "               " +       reader.GetInt32(0) + "                                             " + reader.GetString(1) + "                                             " + reader.GetDateTime(2) + "                                   "  + "\n"; 
                    }
                }
                reader.Close();
            }




            
        }
    }
    }

