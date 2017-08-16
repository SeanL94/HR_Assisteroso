using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace HR_Assisteroso
{
    public partial class Form1 : Form
    {
        //SqlConnection cn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sean\documents\visual studio 2017\Projects\HR_Assisteroso\HR_Assisteroso\Clinicians.mdf;Integrated Security=True");
        //SqlCommand cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
            //cmd.Connection = cn;
        }

    private void addClinician_Click(object sender, EventArgs e)
        {
            addClinicianForm acf = new addClinicianForm();
            acf.Show();
        }

    private void viewData_Click(object sender, EventArgs e)
        {
            //cn.Open();
            OpenSqlConnection();
            //SqlCommand cmd1 = new SqlCommand ("Select * from clinicians", );
            //SqlDataReader dr = cmd1.ExecuteReader();
            //if (dr.Read())
            //{
            //    MessageBox.Show(String.Format(dr.GetValue(0).ToString() + dr.GetValue(1).ToString()));
            //}
            //cn.Close();

        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);

                SqlCommand cmd = new SqlCommand("Select * from clinicians", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    MessageBox.Show(String.Format(dr.GetValue(0).ToString() + dr.GetValue(1).ToString() + dr.GetValue(2).ToString() + dr.GetValue(3).ToString()));
                }
            }
        }

        static private string GetConnectionString()
        { 
            return @"Data Source=(localDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Clinicians.mdf;Integrated security=True";
        }
    }
}
