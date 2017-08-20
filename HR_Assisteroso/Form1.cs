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
using Microsoft.Office.Interop.Word;
using System.IO;

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

            string SQLcreate = "CREATE TABLE IF NOT EXISTS clinicians (id INT AUTO_INCREMENT, First_Name TEXT, Last_Name TEXT, DOB TEXT, PRIMARY KEY (id))";
            SQLiteCommand create = new SQLiteCommand(SQLcreate, db);
            create.ExecuteNonQuery();
            showClinicians();
            //db.Close();
        }

        private void addClinician_Click(object sender, EventArgs e)
        {
            //db.Close();
            addClinicianForm acf = new addClinicianForm();
            acf.Show();
        }

        private void viewData_Click(object sender, EventArgs e)
        {
            //db.Open();
            Button btn = (Button)sender;
            string firstName = btn.Text.ToString();
            string SQL = "SELECT * FROM clinicians WHERE First_Name = '"+firstName+"'";
            SQLiteCommand pull = new SQLiteCommand(SQL, db);
            SQLiteDataReader dr = pull.ExecuteReader();

            if (dr.Read())
            {
                string lastName = dr.GetValue(2).ToString();
                string dob = dr.GetValue(3).ToString();
                createDocument(firstName, lastName, dob, "Template.docx");
                createDocument(firstName, lastName, dob, "secondTemplate.docx");
                dr.Dispose();
            }
            //db.Close();
        }

        public void showClinicians()
        {
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
                    viewData.Location = new System.Drawing.Point(30, viewData.Bottom + 30);

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
            dr.Dispose();
        }

        private void createDocument(String firstname, String lastname, String dob, String fileName)
        {
            try
            {
                //db.Open();
                //Create an instance for word app
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application
                winword.ShowAnimation = true;

                //Set status for word application is to be visible or not.
                winword.Visible = true;

                //Create a missing variable for missing value
                object missing = System.Reflection.Missing.Value;

                //get file path for Tempalte.docx
                //string fileName = "Template.docx";
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

                //Create a new document
                Document document = winword.Documents.Open(path);


                //adding text to document
                document.Variables["First_Name"].Value = firstname;
                document.Variables["Last_Name"].Value = lastname;
                document.Variables["DOB"].Value = dob;
                document.Fields.Update();

                //Save the document
                //object filename = @"c:\users\sean\documents\Demo.docx";
                //document.SaveAs2(ref filename);
                //document.Close(ref missing, ref missing, ref missing);
                //document = null;
                //winword.Quit(ref missing, ref missing, ref missing);
                //winword = null;
                //MessageBox.Show("Document created successfully!");
                //Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                //Document doc = app.Documents.Open(filename);
                //app.Visible = true;
                //db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
