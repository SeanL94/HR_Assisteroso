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
        //string firstName;
        //string lastName;
        //string dob;

        public Form1()
        {
            InitializeComponent();
            OpenSqlConnection();
            //cmd.Connection = cn;
        }

        private void addClinician_Click(object sender, EventArgs e)
        {
            addClinicianForm acf = new addClinicianForm();
            acf.Show();
        }

        private void viewData_Click(object sender, EventArgs e)
        {
            string connectionString = GetConnectionString();
            Button btn = (Button)sender;
            string firstName = btn.Text.ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);
                //string command = String.Format("Select * from clinicians Where First_Name = {0}", firstName);
                //MessageBox.Show(firstName);

                SqlCommand cmd = new SqlCommand("Select * from clinicians Where First_Name = '"+firstName+"'", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string lastName = dr.GetValue(2).ToString();
                    string dob = dr.GetValue(3).ToString();
                    MessageBox.Show(firstName + lastName + dob);
                }
            }

        }

        private void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int top = 50;
                int left = 100;

                Console.WriteLine("State: {0}", connection.State);
                Console.WriteLine("ConnectionString: {0}",
                    connection.ConnectionString);

                SqlCommand cmd = new SqlCommand("Select * from clinicians", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    foreach (var element in dr) {
                        Button viewData = new Button();
                        viewData.Text = dr.GetValue(1).ToString();
                        viewData.Location = new Point(30, viewData.Bottom + 30);

                        string firstName = dr.GetValue(1).ToString();
                        string lastName = dr.GetValue(2).ToString();
                        string dob = dr.GetValue(3).ToString();

                        viewData.Left = left;
                        viewData.Top = top;
                        Controls.Add(viewData);
                        left += viewData.Width + 2;
                        if (left >= 500)
                        {
                            left = 100;
                            top += viewData.Height + 2;
                        }


                        viewData.Click += new EventHandler(this.viewData_Click);
                        //MessageBox.Show(String.Format(dr.GetValue(0).ToString() + dr.GetValue(1).ToString() + dr.GetValue(2).ToString() + dr.GetValue(3).ToString()));
                    }
                }
                
            }
        }

        static private string GetConnectionString()
        { 
            return @"Data Source=(localDB)\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\Clinicians.mdf;Integrated security=True";
        }

        
    }
}
