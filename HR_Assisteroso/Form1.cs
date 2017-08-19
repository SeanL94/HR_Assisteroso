using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;


namespace HR_Assisteroso
{   
    public partial class Form1 : Form
    {
        private SQLiteConnection db;

        public Form1()
        {
            InitializeComponent();
            SQLiteConnection.CreateFile("db.sqlite");
            db = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            db.Open();



            //Figure out how to run once
            //string SQL = "CREATE TABLE clinicians (id INT AUTO_INCREMENT, First_Name TEXT, Last_Name TEXT, DOB TEXT, PRIMARY KEY (id))";
            //SQLiteCommand create = new SQLiteCommand(SQL, db);
            //create.ExecuteNonQuery();

            string SQL = "SELECT * FROM clinicians";
            SQLiteCommand pull = new SQLiteCommand(SQL, db);
            SQLiteDataReader dr = pull.ExecuteReader();

            int top = 50;
            int left = 100;

            while (dr.Read())
            {
                foreach (var element in dr)
                {
                    Button viewData = new Button();
                    viewData.Text = dr.GetValue(1).ToString();
                    viewData.Location = new Point(30, viewData.Bottom + 30);

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
                }
            }
        }

        private void addClinician_Click(object sender, EventArgs e)
        {
            addClinicianForm acf = new addClinicianForm();
            acf.Show();
        }

        private void viewData_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string firstName = btn.Text.ToString();
            string SQL = "SELECT * FROM clinicians WHERE First_Name = '"+firstName+"'";
            SQLiteCommand pull = new SQLiteCommand(SQL, db);
            SQLiteDataReader dr = pull.ExecuteReader();

            if (dr.Read())
            {
                string lastName = dr.GetValue(2).ToString();
                string dob = dr.GetValue(3).ToString();
                MessageBox.Show(firstName + lastName + dob);
            }
        }
    }
}
