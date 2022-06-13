using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tourist__Office
{
    public partial class AuthentificationAndRegistration : Form
    {
        private SqlConnection sqlConnection = null; 

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;
        public AuthentificationAndRegistration()
        {
            InitializeComponent();
        }


        private void SignUpAsClient_Click(object sender, EventArgs e)
        {
            //dataSet = new DataSet();
            //sqlDataAdapter = new SqlDataAdapter();
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            if (ClientFullName.Text == "" || ClientPhoneNumber.Text == "" ||  ClientEmail.Text == "" || ClientPassword.Text == "" || ClientInternationalPassport.Text == "")
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                //if (ClientEmail.Text != "")
                SqlCommand CheckLogin = new SqlCommand("CheckLogin", sqlConnection);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.Add("@login", SqlDbType.VarChar).Value = ClientLogin.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckLogin.Parameters.Add(answer);

                CheckLogin.ExecuteNonQuery();
                var res0 = answer.Value.ToString();

                if (res0 == "Присутствует в базе")
                {
                    MessageBox.Show("Такой логин уже занят");
                }
                else if (res0 == "Отсутствует в базе")
            { 
                      



                SqlCommand CheckClEmail = new SqlCommand("CheckClEmail", sqlConnection);
                CheckClEmail.CommandType = CommandType.StoredProcedure;
                CheckClEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = ClientEmail.Text;


                var answer0 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer0.Direction = System.Data.ParameterDirection.Output;
                answer0.Size = 64;
                CheckClEmail.Parameters.Add(answer0);

                CheckClEmail.ExecuteNonQuery();
                var res = answer0.Value.ToString();

                if (res == "Почта Присутствует в базе")
                {
                    MessageBox.Show("Почта Присутствует в базе");
                }
                else if (res == "Почта отсутствует в базе")
                {
                    //CheckPhoneNumber
                    SqlCommand CheckPhoneNumber = new SqlCommand("CheckPhoneNumber", sqlConnection);
                    CheckPhoneNumber.CommandType = CommandType.StoredProcedure;
                    CheckPhoneNumber.Parameters.Add("@clientphonenumber", SqlDbType.VarChar).Value = ClientPhoneNumber.Text;

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
                        CheckClPassport.Parameters.Add("@passport", SqlDbType.VarChar).Value = ClientPassport.Text;

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
                            CheckClIntPassport.Parameters.Add("@intpassport", SqlDbType.VarChar).Value = ClientInternationalPassport.Text;

                            var answer3 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                            answer3.Direction = System.Data.ParameterDirection.Output;
                            answer3.Size = 64;
                           CheckClIntPassport.Parameters.Add(answer3);

                            CheckClIntPassport.ExecuteNonQuery();
                            var res3 = answer3.Value.ToString();

                            if (res3 == "Загранпаспорт Присутствует в базе")
                            {
                                MessageBox.Show("Загранпаспорт Присутствует в базе");
                            }
                            else if (res3 == "Загранпаспорт отсутствует в базе")
                            {
                                //(@Login nvarchar(15),@Password nvarchar(15),@ClientFullName nvarchar(60),@ClientPhoneNumber nvarchar(12),@DateOfBirth date, @Email nvarchar(30),@Passport nvarchar(11),@InternationalPassport nvarchar(10))
                                SqlCommand ClientRegistration = new SqlCommand("ClientRegistration", sqlConnection);
                                ClientRegistration.CommandType = CommandType.StoredProcedure;
                                ClientRegistration.Parameters.Add("@Login", SqlDbType.VarChar).Value = ClientLogin.Text;
                                ClientRegistration.Parameters.Add("@password", SqlDbType.VarChar).Value = Verification.GetSHA256Hash(AuthPassword.Text);
                                ClientRegistration.Parameters.Add("@ClientFullName", SqlDbType.VarChar).Value = ClientFullName.Text;
                                ClientRegistration.Parameters.Add("@ClientPhoneNumber", SqlDbType.VarChar).Value = ClientPhoneNumber.Text;
                                ClientRegistration.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = ClDateOfB.SelectionStart.Date.ToString("yyyy-MM-dd");
                                ClientRegistration.Parameters.Add("@Email", SqlDbType.VarChar).Value = ClientEmail.Text;
                                ClientRegistration.Parameters.Add("@Passport", SqlDbType.VarChar).Value = ClientPassport.Text;
                                ClientRegistration.Parameters.Add("@InternationalPassport", SqlDbType.VarChar).Value = ClientInternationalPassport.Text;

                                ClientRegistration.ExecuteNonQuery();

                                SqlCommand GetRegisteredClientUserId = new SqlCommand("Select MAX(IdUser) as UserId FROM Users", sqlConnection);
                                var readeruserid = GetRegisteredClientUserId.ExecuteReader();

                                if (readeruserid.HasRows)
                                {
                                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                    while (readeruserid.Read())
                                    {
                                        DataBank.CurrentUserID = (readeruserid.GetInt32(0));
                                    }
                                }
                                readeruserid.Close();
                                    //sqlDataAdapter.Update(dataSet);
                                    //sqlDataAdapter.Update(dataSet);


                                    MessageBox.Show("Вы успешно зарегестрированы.");

                                    SqlCommand GetRegisteredClientId = new SqlCommand("Select MAX(ClientID) as ClientID FROM ClientProfile", sqlConnection);
                                    var readerClientid = GetRegisteredClientId.ExecuteReader();

                                    if (readerClientid.HasRows)
                                    {
                                        //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                        while (readerClientid.Read())
                                        {
                                            DataBank.CurrentClientID = (readerClientid.GetInt32(0));
                                        }
                                    }

                                    //DataBank.CurrentClientID = ;
                                    DataBank.CurrentClientFullname = ClientFullName.Text;
                                    DataBank.CurrentClientPhoneNumber = ClientPhoneNumber.Text;
                                    DataBank.CurrentClientDateOfBirth = ClDateOfB.SelectionStart.Date.ToString("yyyy-MM-dd");
                                    DataBank.CurrentClientEmail = ClientEmail.Text;
                                    DataBank.CurrentClientPassport = ClientPassport.Text;
                                    DataBank.CurrentClientInternationalPassport = ClientInternationalPassport.Text;

                                    DataBank.Cl.ClientFullNameUpd.Text = DataBank.CurrentClientFullname;
                                    DataBank.Cl.ClientPhoneNumberUpd.Text = DataBank.CurrentClientPhoneNumber;
                                    DataBank.Cl.ClientDateOfBirth.SetDate(ClDateOfB.SelectionStart.Date);
                                    //Cl.ClientDateOfBirthUpd.Text = DataBank.CurrentClientDateOfBirth;
                                    DataBank.Cl.ClientEmailUpd.Text = DataBank.CurrentClientEmail;
                                    DataBank.Cl.ClientPassportUpd.Text = DataBank.CurrentClientPassport;
                                    DataBank.Cl.ClientInternationalPassportUpd.Text = DataBank.CurrentClientInternationalPassport;
                                    //DataBank.Cl.ClNameFR.Text = reader2.GetString(1);
                                    this.Hide();
                                    DataBank.Cl.Show();
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



        }

        private void SignUpAsManager_Click(object sender, EventArgs e)
        {
            //dataSet = new DataSet();
            //sqlDataAdapter = new SqlDataAdapter();
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            if (ManagerFullName.Text == "" || ManagerEmail.Text == "" || ManagerPhoneNumber.Text == "")
            {
                MessageBox.Show("Пустое поле");
            }

            else
            {
                //if (ManagerEmail.Text != "")
                SqlCommand CheckLogin = new SqlCommand("CheckLogin", sqlConnection);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.Add("@login", SqlDbType.VarChar).Value = ClientLogin.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckLogin.Parameters.Add(answer);

                CheckLogin.ExecuteNonQuery();
                var res0 = answer.Value.ToString();

                if (res0 == "Присутствует в базе")
                {
                    MessageBox.Show("Такой логин уже занят");
                }
                else if (res0 == "Отсутствует в базе")
                {

                    {
                        SqlCommand CheckManEmail = new SqlCommand("CheckManEmail", sqlConnection);
                        CheckManEmail.CommandType = CommandType.StoredProcedure;
                        CheckManEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = ManagerEmail.Text;


                        var answer0 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer0.Direction = System.Data.ParameterDirection.Output;
                        answer0.Size = 64;
                        CheckManEmail.Parameters.Add(answer0);

                        CheckManEmail.ExecuteNonQuery();
                        var res = answer0.Value.ToString();

                        if (res == "Почта Присутствует в базе")
                        {
                            MessageBox.Show("Почта Присутствует в базе");
                        }
                        else if (res == "Почта отсутствует в базе")
                        {
                            //CheckPhoneNumber
                            SqlCommand CheckManPhone = new SqlCommand("CheckPhoneNumber", sqlConnection);
                            CheckManPhone.CommandType = CommandType.StoredProcedure;
                            CheckManPhone.Parameters.Add("@manphonenumber", SqlDbType.VarChar).Value = ManagerPhoneNumber.Text;

                            var answer1 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                            answer1.Direction = System.Data.ParameterDirection.Output;
                            answer1.Size = 64;
                            CheckManPhone.Parameters.Add(answer1);

                            CheckManPhone.ExecuteNonQuery();
                            var res1 = answer1.Value.ToString();

                            if (res1 == "Номер телефона Присутствует в базе")
                            {
                                MessageBox.Show("Номер телефона Присутствует в базе");
                            }

                            else if (res1 == "Номер телефона отсутствует в базе")
                            {
                                SqlCommand ManagerRegistration = new SqlCommand("ManagerRegistration", sqlConnection);
                                ManagerRegistration.CommandType = CommandType.StoredProcedure;
                                ManagerRegistration.Parameters.Add("@Login", SqlDbType.VarChar).Value = ManagerLogin.Text;
                                ManagerRegistration.Parameters.Add("@password", SqlDbType.VarChar).Value = Verification.GetSHA256Hash(ManagerPassword.Text);
                                ManagerRegistration.Parameters.Add("@ManagerFullName", SqlDbType.VarChar).Value = ManagerFullName.Text;
                                ManagerRegistration.Parameters.Add("@Email", SqlDbType.VarChar).Value = ManagerEmail.Text;
                                ManagerRegistration.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = ManagerPhoneNumber.Text;
                                ManagerRegistration.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = ManDateOfBirth.SelectionStart.Date.ToString("yyyy-MM-dd");
                               

                                ManagerRegistration.ExecuteNonQuery();

                                SqlCommand GetRegisteredClientUserId = new SqlCommand("Select MAX(IdUser) as UserId FROM Users", sqlConnection);
                                var readeruserid = GetRegisteredClientUserId.ExecuteReader();

                                if (readeruserid.HasRows)
                                {
                                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                    while (readeruserid.Read())
                                    {
                                        DataBank.CurrentUserID = (readeruserid.GetInt32(0));
                                    }
                                }
                                readeruserid.Close();
                                //sqlDataAdapter.Update(dataSet);
                                //sqlDataAdapter.Update(dataSet);
                                MessageBox.Show("Вы успешно зарегестрированы.");

                                SqlCommand GetRegisteredManagerId = new SqlCommand("Select MAX(ManagerID) as ManagerID FROM Manager", sqlConnection);
                                var readerManagid = GetRegisteredManagerId.ExecuteReader();

                                if (readerManagid.HasRows)
                                {
                                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                    while (readerManagid.Read())
                                    {
                                        DataBank.CurrentManagerID = (readerManagid.GetInt32(0));
                                    }
                                }

                                //DataBank.CurrentManagerID = reader2.GetInt32(0);
                                DataBank.CurrentManagerFullname = ManagerFullName.Text;
                                DataBank.CurrentManagerEmail = ManagerEmail.Text;
                                DataBank.CurrentManagerPhoneNumber = ManagerPhoneNumber.Text;
                                DataBank.CurrentManagerDateOfBirth = ManDateOfBirth.SelectionStart.Date.ToString("yyyy-mm-dd");

                                DataBank.Man.ManagerFullName.Text = DataBank.CurrentManagerFullname;
                                DataBank.Man.ManagerPhoneNumber.Text = DataBank.CurrentManagerPhoneNumber;
                                DataBank.Man.ManDateOfBirth.SetDate(ManDateOfBirth.SelectionStart.Date);
                                DataBank.Man.ManagerEmail.Text = DataBank.CurrentManagerEmail;
                                this.Hide();
                                DataBank.Man.Show();

                            }

                        }
                    }

                    //Hide();
                    //Cl.Show();
                }
            }
            //{

            //        Hide();
            //        Man.Show();

            //}

        }

        private void SignUpAsAdministrator_Click(object sender, EventArgs e)
        {
            //dataSet = new DataSet();
            //sqlDataAdapter = new SqlDataAdapter();
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            if (AdministratorFullName.Text == "" || AdministratorEmail.Text == "" || AdministratorPhoneNumber.Text == "")
            {
                MessageBox.Show("Пустое поле");
            }
            else
            {
                //if (ManagerEmail.Text != "")
                SqlCommand CheckLogin = new SqlCommand("CheckLogin", sqlConnection);
                CheckLogin.CommandType = CommandType.StoredProcedure;
                CheckLogin.Parameters.Add("@login", SqlDbType.VarChar).Value = ClientLogin.Text;


                var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
                answer.Direction = System.Data.ParameterDirection.Output;
                answer.Size = 64;
                CheckLogin.Parameters.Add(answer);

                CheckLogin.ExecuteNonQuery();
                var res0 = answer.Value.ToString();

                if (res0 == "Присутствует в базе")
                {
                    MessageBox.Show("Такой логин уже занят");
                }
                else if (res0 == "Отсутствует в базе")
                {

                    {
                        SqlCommand CheckAdmEmail = new SqlCommand("CheckAdmEmail", sqlConnection);
                        CheckAdmEmail.CommandType = CommandType.StoredProcedure;
                        CheckAdmEmail.Parameters.Add("@Email", SqlDbType.VarChar).Value = ManagerEmail.Text;


                        var answer0 = new SqlParameter("@Answer", SqlDbType.NVarChar);
                        answer0.Direction = System.Data.ParameterDirection.Output;
                        answer0.Size = 64;
                        CheckAdmEmail.Parameters.Add(answer0);

                        CheckAdmEmail.ExecuteNonQuery();
                        var res = answer0.Value.ToString();

                        if (res == "Почта Присутствует в базе")
                        {
                            MessageBox.Show("Почта Присутствует в базе");
                        }
                        else if (res == "Почта отсутствует в базе")
                        {
                            //CheckPhoneNumber
                            SqlCommand CheckAdmPhoneNumber = new SqlCommand("CheckAdmPhoneNumber", sqlConnection);
                            CheckAdmPhoneNumber.CommandType = CommandType.StoredProcedure;
                            CheckAdmPhoneNumber.Parameters.Add("@admphonenumber", SqlDbType.VarChar).Value = ManagerPhoneNumber.Text;

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
                                SqlCommand AdministratorRegistration = new SqlCommand("ManagerRegistration", sqlConnection);
                                AdministratorRegistration.CommandType = CommandType.StoredProcedure;
                                AdministratorRegistration.Parameters.Add("@Login", SqlDbType.VarChar).Value = AdminLogin.Text;
                                AdministratorRegistration.Parameters.Add("@password", SqlDbType.VarChar).Value = Verification.GetSHA256Hash(AdminPassword.Text);

                                AdministratorRegistration.Parameters.Add("@AdministratorFullName", SqlDbType.VarChar).Value = AdministratorFullName.Text;
                                AdministratorRegistration.Parameters.Add("@Email", SqlDbType.VarChar).Value = AdministratorEmail.Text;
                                AdministratorRegistration.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = AdministratorPhoneNumber.Text;
                                AdministratorRegistration.Parameters.Add("@DateOfBirth", SqlDbType.VarChar).Value = AdmDateOfB.SelectionStart.Date.ToString("yyyy-MM-dd");
                               

                                AdministratorRegistration.ExecuteNonQuery();

                                SqlCommand GetRegisteredClientUserId = new SqlCommand("Select MAX(IdUser) as UserId FROM Users", sqlConnection);
                                var readeruserid = GetRegisteredClientUserId.ExecuteReader();

                                if (readeruserid.HasRows)
                                {
                                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                    while (readeruserid.Read())
                                    {
                                        DataBank.CurrentUserID = (readeruserid.GetInt32(0));
                                    }
                                }
                                readeruserid.Close();
                                //sqlDataAdapter.Update(dataSet);
                                //sqlDataAdapter.Update(dataSet);
                                MessageBox.Show("Вы успешно зарегестрированы.");

                                SqlCommand GetRegisteredAdminId = new SqlCommand("Select MAX(AdministratorID) as AdministratorID FROM Administrator", sqlConnection);
                                var readerAdminid = GetRegisteredAdminId.ExecuteReader();

                                if (readerAdminid.HasRows)
                                {
                                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                                    while (readerAdminid.Read())
                                    {
                                        DataBank.CurrentAdministratorID = (readerAdminid.GetInt32(0));
                                    }
                                }

                                DataBank.CurrentAdministratorFullname = AdministratorFullName.Text;
                                DataBank.CurrentAdministratorEmail = AdministratorEmail.Text;
                                DataBank.CurrentAdministratorPhoneNumber = AdministratorPhoneNumber.Text;
                                DataBank.CurrentAdministratorDateOfBirth = AdmDateOfB.SelectionStart.Date.ToString("yyyy-mm-dd");

                                //DataBank.CurrentManagerID = reader.GetInt32(0);
                                //DataBank.CurrentManagerFullname = reader.GetString(1);
                                //DataBank.CurrentManagerEmail = reader.GetString(2);
                                //DataBank.CurrentManagerPhoneNumber = reader.GetString(3);
                                //DataBank.CurrentManagerDateOfBirth = reader.GetDateTime(4).ToString();

                                DataBank.Adm.UpdAdministratorFullName.Text = DataBank.CurrentAdministratorFullname;
                                DataBank.Adm.UpdAdministratorPhoneNumber.Text = DataBank.CurrentAdministratorPhoneNumber;
                                DataBank.Adm.AdmDateOfB.SetDate(AdmDateOfB.SelectionStart.Date);
                                DataBank.Adm.UpdAdministratorEmail.Text = DataBank.CurrentAdministratorEmail;
                                this.Hide();
                                DataBank.Adm.Show();
                            }

                        }
                    }

                    //Hide();
                    //Adm.Show();
                }
            }
        }
        private String IsInBase()
        {


            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            sqlDataAdapter = new SqlDataAdapter("SELECT * from Users", sqlConnection);
            sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);


            dataSet = new DataSet();

            sqlDataAdapter.Fill(dataSet, "Users");

            SqlCommand CheckAuth = new SqlCommand("Authentification", sqlConnection);
            CheckAuth.CommandType = CommandType.StoredProcedure;
            CheckAuth.Parameters.Add("@login", SqlDbType.VarChar).Value = AuthLogin.Text;
            CheckAuth.Parameters.Add("@password", SqlDbType.VarChar).Value = Verification.GetSHA256Hash(AuthPassword.Text);
            //CheckAuth.Parameters.Add("@Answer", SqlDbType.VarChar).Value = "";

            string login = AuthLogin.Text;
            string password = Verification.GetSHA256Hash(AuthPassword.Text).ToLower();

            var answer = new SqlParameter("@Answer", SqlDbType.NVarChar);
            answer.Direction = System.Data.ParameterDirection.Output;
            answer.Size = 64;
            CheckAuth.Parameters.Add(answer);

            CheckAuth.ExecuteNonQuery();
            var res = answer.Value.ToString();
            return res;
        }


        private void GetIdUser()
        {
            string login = AuthLogin.Text;
            string password = Verification.GetSHA256Hash(AuthPassword.Text).ToLower();
            //MessageBox.Show("Отсутствует в базе");
            SqlCommand GetIdUser = new SqlCommand("SELECT IdUser from Users Where Login = '" + login + "'" + " AND Password = '" + password + "'", sqlConnection);
            //sqlDataAdapter = new SqlDataAdapter
            //dataSet = new DataSet();

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //connection.Open();
                //SqlCommand FillRequests = new SqlCommand("ShowAllRequests", connection);
                //FillRequests.CommandType = CommandType.StoredProcedure;
                // указываем, что команда представляет хранимую процедуру
                //SqlCommand GetUserProfile1 = new SqlCommand("SELECT IdUser from Users Where Login =" + AuthLogin.Text + " AND Password = " + Verification.GetSHA256Hash(AuthPassword.Text), sqlConnection);

                var reader1 = GetIdUser.ExecuteReader();

                if (reader1.HasRows)
                {
                    //Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

                    while (reader1.Read())
                    {
                        DataBank.CurrentUserID = (reader1.GetInt32(0));
                    }
                }
                reader1.Close();

            }
        }

        private void SignIn_Click(object sender, EventArgs e)
        {

               
      }


        private void AuthentificationAndRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void GoBitch_Click(object sender, EventArgs e)
        {
            Hide();
            DataBank.Adm.Show();
        }

        private void SignIn_Click_1(object sender, EventArgs e)
        {
            //bool loginright = false;
            //bool passwordright = false;
            bool loginright = false;
            bool passwordright = false;

            string login = AuthLogin.Text;
            string password = Verification.GetSHA256Hash(AuthPassword.Text).ToLower();

            //string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            //sqlConnection = new SqlConnection(ConnectionString);
            //sqlConnection.Open();

            //sqlDataAdapter = new SqlDataAdapter("SELECT * from Users", sqlConnection);
            //sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);


            //dataSet = new DataSet();

            //sqlDataAdapter.Fill(dataSet, "Users");

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
            var res = IsInBase();

            {
                if ((res == "Отсутствует в базе"))
                //if (Int32.Parse(reader.GetString(0)) == 0)
                {
                    //MessageBox.Show("Отсутствует в базе");
                    MessageBox.Show("Неправильный логин или пароль");
                }
                else if ((res == "Присутствует в базе"))
                {
                    loginright = true;
                    passwordright = true;

                    GetIdUser();

                    string ProfileData = "SELECT * FROM ClientProfile WHERE ClientProfile.UserID = @UserId  " +
                   "SELECT * FROM Manager       WHERE Manager.UserID       = @UserId  " +
                   "SELECT * FROM Administrator WHERE Administrator.UserID = @UserId";

                    using (var GetUserProfile = new SqlCommand(ProfileData, sqlConnection))
                    {
                        GetUserProfile.Parameters.Add("UserId", SqlDbType.Int).Value = DataBank.CurrentUserID;

                        using (var reader2 = GetUserProfile.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                DataBank.CurrentClientID = reader2.GetInt32(0);
                                DataBank.CurrentClientFullname = reader2.GetString(1);
                                DataBank.CurrentClientPhoneNumber = reader2.GetString(2);
                                DataBank.CurrentClientDateOfBirth = reader2.GetDateTime(3).ToString();
                                DataBank.CurrentClientEmail = reader2.GetString(4);
                                DataBank.CurrentClientPassport = reader2.GetString(5);
                                DataBank.CurrentClientInternationalPassport = reader2.GetString(6);

                                DataBank.Cl.ClientFullNameUpd.Text = DataBank.CurrentClientFullname;
                                DataBank.Cl.ClientPhoneNumberUpd.Text = DataBank.CurrentClientPhoneNumber;
                                DataBank.Cl.ClientDateOfBirth.SetDate(reader2.GetDateTime(3));
                                //Cl.ClientDateOfBirthUpd.Text = DataBank.CurrentClientDateOfBirth;
                                DataBank.Cl.ClientEmailUpd.Text = DataBank.CurrentClientEmail;
                                DataBank.Cl.ClientPassportUpd.Text = DataBank.CurrentClientPassport;
                                DataBank.Cl.ClientInternationalPassportUpd.Text = DataBank.CurrentClientInternationalPassport;
                                DataBank.Cl.ClNameFR.Text = reader2.GetString(1); 
                                this.Hide();
                                DataBank.Cl.Show();
                               
                            }


                            if (reader2.NextResult()) // move to Manager data
                            {
                                while (reader2.Read())
                                {
                                    // Обратите внимание: индексы колонок снова с нуля
                                    DataBank.CurrentManagerID = reader2.GetInt32(0);
                                    DataBank.CurrentManagerFullname = reader2.GetString(1);
                                    DataBank.CurrentManagerEmail = reader2.GetString(2);
                                    DataBank.CurrentManagerPhoneNumber = reader2.GetString(3);
                                    DataBank.CurrentManagerDateOfBirth = reader2.GetDateTime(4).ToString();

                                    DataBank.Man.ManagerFullName.Text = DataBank.CurrentManagerFullname;
                                    DataBank.Man.ManagerPhoneNumber.Text = DataBank.CurrentManagerPhoneNumber;
                                    DataBank.Man.ManDateOfBirth.SetDate(reader2.GetDateTime(4));
                                    DataBank.Man.ManagerEmail.Text = DataBank.CurrentManagerEmail;
                                    this.Hide();
                                    DataBank.Man.Show(); 
                                }
                            }

                            if (reader2.NextResult()) // move to Administrator data
                            {
                                while (reader2.Read())
                                {
                                    // Обратите внимание: индексы колонок снова с нуля
                                    DataBank.CurrentAdministratorID = reader2.GetInt32(0);
                                    DataBank.CurrentAdministratorFullname = reader2.GetString(1);
                                    DataBank.CurrentAdministratorEmail = reader2.GetString(2);
                                    DataBank.CurrentAdministratorPhoneNumber = reader2.GetString(3);
                                    DataBank.CurrentAdministratorDateOfBirth = reader2.GetDateTime(4).ToString();

                                    //DataBank.CurrentManagerID = reader.GetInt32(0);
                                    //DataBank.CurrentManagerFullname = reader.GetString(1);
                                    //DataBank.CurrentManagerEmail = reader.GetString(2);
                                    //DataBank.CurrentManagerPhoneNumber = reader.GetString(3);
                                    //DataBank.CurrentManagerDateOfBirth = reader.GetDateTime(4).ToString();

                                    DataBank.Adm.UpdAdministratorFullName.Text = DataBank.CurrentAdministratorFullname;
                                    DataBank.Adm.UpdAdministratorPhoneNumber.Text = DataBank.CurrentAdministratorPhoneNumber;
                                    DataBank.Adm.AdmDateOfB.SetDate(reader2.GetDateTime(4));
                                    DataBank.Adm.UpdAdministratorEmail.Text = DataBank.CurrentAdministratorEmail;
                                    this.Hide();
                                    DataBank.Adm.Show();
                                }
                            }
                        }
                    }

                }

                //sqlConnection.Close();
                if (!loginright || !passwordright)
                    MessageBox.Show("Неправильный логин или пароль");

            }
        }




        //RequestsForManagerTable.DataSource = dataSet.Tables["Request"];
        //data = sqlActions.doSqlCommand("select * from Users", 7);

        //foreach (var d in dataSet)
        //{
        //    var AuthsLogin = AuthLogin.Text.Trim();
        //    var AuthsPassWord = AuthPassword.Text.Trim();

        //    if (loginWord == d[5].Trim()) 
        //        loginright = true;


        //    if (Verifycation.VerifySHA512Hash(passWord, d[6].Trim())) 
        //        passwordright = true;




        //    role_id = d[1];

        //    if (login && password)
        //    {
        //        ifAvtorizationTrue(role_id.Trim(), d[2].Trim(), d[3].Trim(), Convert.ToInt32(d[0].Trim()));
        //        break;
        //    }

        //    login = false; password = false;
        //}


    }




    }

