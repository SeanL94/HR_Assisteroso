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
    public partial class addClinicianForm : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sean\documents\visual studio 2017\Projects\HR_Assisteroso\HR_Assisteroso\Clinicians.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public addClinicianForm()
        {
            InitializeComponent();
            cmd.Connection = cn;
        }

        private void submitClinician_Click(object sender, EventArgs e)
        {
            
            String dateOfBirthString = dateOfBirth.Text;
            String firstNameString = firstName.Text;
            String lastNameString = lastName.Text;

            cn.Open();
            cmd.CommandText = "INSERT INTO clinicians (First_Name, Last_Name, DOB) VALUES ('"+firstName.Text+"','"+lastName.Text+"','"+dateOfBirth.Text+"')";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            System.Windows.Forms.MessageBox.Show(String.Format("Success!\r\r{0}\r{1}\r{2}", firstNameString, lastNameString, dateOfBirthString));

            this.Close();
        }
    }
}
