
namespace Trang_Granville
{
    partial class Main
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
            this.label3 = new System.Windows.Forms.Label();
            this.calendar = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.apptButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.userReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(166, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Scheduling Software";
            // 
            // calendar
            // 
            this.calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar.Location = new System.Drawing.Point(191, 294);
            this.calendar.Name = "calendar";
            this.calendar.Size = new System.Drawing.Size(178, 46);
            this.calendar.TabIndex = 12;
            this.calendar.Text = "Calendar Report";
            this.calendar.UseVisualStyleBackColor = true;
            this.calendar.Click += new System.EventHandler(this.calendar_Click);
            // 
            // customerButton
            // 
            this.customerButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerButton.Location = new System.Drawing.Point(191, 133);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(178, 46);
            this.customerButton.TabIndex = 13;
            this.customerButton.Text = "Manage Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // apptButton
            // 
            this.apptButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptButton.Location = new System.Drawing.Point(191, 209);
            this.apptButton.Name = "apptButton";
            this.apptButton.Size = new System.Drawing.Size(178, 48);
            this.apptButton.TabIndex = 14;
            this.apptButton.Text = "Manage Appointment";
            this.apptButton.UseVisualStyleBackColor = true;
            this.apptButton.Click += new System.EventHandler(this.apptButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutButton.Location = new System.Drawing.Point(455, 469);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 23);
            this.logOutButton.TabIndex = 15;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // userReport
            // 
            this.userReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userReport.Location = new System.Drawing.Point(191, 375);
            this.userReport.Name = "userReport";
            this.userReport.Size = new System.Drawing.Size(178, 45);
            this.userReport.TabIndex = 16;
            this.userReport.Text = "Consultant Report";
            this.userReport.UseVisualStyleBackColor = true;
            this.userReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 537);
            this.Controls.Add(this.userReport);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.apptButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.label3);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calendar;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button apptButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button userReport;
    }
}