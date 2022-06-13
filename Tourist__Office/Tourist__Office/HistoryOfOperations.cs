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
    public partial class HistoryOfOperations : Form
    {
        private SqlConnection sqlConnection = null;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
        //sqlConnection(ConnectionString);
        private SqlCommandBuilder sqlBuilder = null;

        private SqlDataAdapter sqlDataAdapter = null;

        private DataSet dataSet = null;

        public HistoryOfOperations()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            try
            {
 
                sqlDataAdapter = new SqlDataAdapter("SELECT * From HistoryOfTours", sqlConnection);
                //sqlDataAdapter = new SqlDataAdapter("SELECT HistoryID, TourID, Operation, TimeOfOperation From HistoryOfTours", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                //sqlBuilder.GetInsertCommand();
                //sqlBuilder.GetUpdateCommand();
                //sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();

                sqlDataAdapter.Fill(dataSet, "HistoryOfTours");
                HistOfOps.DataSource = dataSet.Tables["HistoryOfTours"];

                //for (int i = 0; i < HistOfOps.Rows.Count; i++)
                //{
                //    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //    TourTable[5, i] = linkCell;
                //}
                HistOfOps.Columns["HistoryID"].ReadOnly = true;
                HistOfOps.Columns["TourID"].ReadOnly = true;
                HistOfOps.Columns["Operation"].ReadOnly = true;
                HistOfOps.Columns["TimeOfOperation"].ReadOnly = true;
            


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void HistoryOfOperations_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hzcho\source\repos\Tourist__Office\Tourist__Office\Tourist_office.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            //AdministratorInterface newAdmForm = new AdministratorInterface();
            DataBank.Adm.Show();
        }

        private void HistoryOfOperations_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
