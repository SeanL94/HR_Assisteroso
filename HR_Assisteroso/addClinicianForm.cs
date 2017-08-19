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
using System.Data.SQLite;

namespace HR_Assisteroso
{
    public partial class addClinicianForm : Form
    {
        private SQLiteConnection db;
        public addClinicianForm()
        {
            InitializeComponent();
            db = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            db.Open();
        }

        private void submitClinician_Click(object sender, EventArgs e)
        {
            
            String dateOfBirthString = dateOfBirth.Text;
            String firstNameString = firstName.Text;
            String lastNameString = lastName.Text;

            string SQL = "INSERT INTO clinicians (First_Name, Last_Name, DOB) VALUES ('"+firstName.Text+"','"+lastName.Text+"','"+dateOfBirth.Text+"')";
            SQLiteCommand push = new SQLiteCommand(SQL, db);
            push.ExecuteNonQuery();
            System.Windows.Forms.MessageBox.Show(String.Format("Success!\r\r{0}\r{1}\r{2}", firstNameString, lastNameString, dateOfBirthString));
            if (System.Windows.Forms.Application.OpenForms["Form1"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Form1"] as Form1).showClinicians();
            }
            this.Close();
        }

        private void addClinicianForm_Load(object sender, EventArgs e)
        {

        }
    }
}
