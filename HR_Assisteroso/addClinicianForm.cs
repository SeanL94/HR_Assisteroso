using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Assisteroso
{
    public partial class addClinicianForm : Form
    {
        public addClinicianForm()
        {
            InitializeComponent();
        }

        private void submitClinician_Click(object sender, EventArgs e)
        {
            //TextBox dateOfBirth = (TextBox)sender;
            //TextBox firstName = (TextBox)sender;
            //TextBox lastName = (TextBox)sender;

            String dateOfBirthString = dateOfBirth.Text;
            String firstNameString = firstName.Text;
            String lastNameString = lastName.Text;

            //System.Windows.Forms.MessageBox.Show("Success! " + dateOfBirthString + firstNameString + lastNameString);
            System.Windows.Forms.MessageBox.Show(String.Format("Success!\r\r{0}\r{1}\r{2}", firstNameString, lastNameString, dateOfBirthString));

            this.Close();
        }
    }
}
