namespace HR_Assisteroso
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addClinician = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addClinician
            // 
            this.addClinician.Location = new System.Drawing.Point(230, 156);
            this.addClinician.Name = "addClinician";
            this.addClinician.Size = new System.Drawing.Size(155, 23);
            this.addClinician.TabIndex = 0;
            this.addClinician.Text = "Add Clinician";
            this.addClinician.UseVisualStyleBackColor = true;
            this.addClinician.Click += new System.EventHandler(this.addClinician_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 342);
            this.Controls.Add(this.addClinician);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addClinician;
    }
}

