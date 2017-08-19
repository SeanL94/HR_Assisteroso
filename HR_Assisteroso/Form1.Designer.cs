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
            this.addClinician.Location = new System.Drawing.Point(16, 15);
            this.addClinician.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addClinician.Name = "addClinician";
            this.addClinician.Size = new System.Drawing.Size(207, 28);
            this.addClinician.TabIndex = 0;
            this.addClinician.Text = "Add Clinician";
            this.addClinician.UseVisualStyleBackColor = true;
            this.addClinician.Click += new System.EventHandler(this.addClinician_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 421);
            this.Controls.Add(this.addClinician);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addClinician;
    }
}

