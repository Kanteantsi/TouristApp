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
    public partial class ClientsGroupList : Form
    {
        private SqlConnection sqlConnection = null;

        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        public ClientsGroupList()
        {
            InitializeComponent();
        }

        private void ToMainApp_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            //newAdmForm.Show();
            DataBank.Man.Show();
        }

        private void LoadData()
        {

            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT * FROM ClientsGroupList", sqlConnection);


                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "ClientsGroupList");
                ClientsGroupLists.DataSource = dataSet.Tables["ClientsGroupList"];

                ClientsGroupLists.Columns["ClientsGroupListID"].ReadOnly = true;
                ClientsGroupLists.Columns["ClientID"].ReadOnly = true;
                ClientsGroupLists.Columns["TourGroupID"].ReadOnly = true;
                //for (int i = 0; i < ClientsGroupLists.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    ClientsGroupLists[8, i] = linkCell;
                //}
                //ClientsTable.Columns["ClientID"].ReadOnly = true;
                //ClientsTable.Columns["UserID"].ReadOnly = true;
            }

            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClientsGroupList_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();
        }

        private void ClientsGroupList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
