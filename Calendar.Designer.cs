
namespace Trang_Granville
{
    partial class Calendar
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCalendar = new System.Windows.Forms.DataGridView();
            this.cancelButton = new System.Windows.Forms.Button();
            this.allAppointment = new System.Windows.Forms.RadioButton();
            this.byMonth = new System.Windows.Forms.RadioButton();
            this.byWeek = new System.Windows.Forms.RadioButton();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calendar View";
            // 
            // dataGridViewCalendar
            // 
            this.dataGridViewCalendar.AllowUserToAddRows = false;
            this.dataGridViewCalendar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalendar.Location = new System.Drawing.Point(492, 73);
            this.dataGridViewCalendar.Name = "dataGridViewCalendar";
            this.dataGridViewCalendar.RowHeadersVisible = false;
            this.dataGridViewCalendar.Size = new System.Drawing.Size(628, 401);
            this.dataGridViewCalendar.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(945, 573);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(141, 43);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Back to Main Portal";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // allAppointment
            // 
            this.allAppointment.AutoSize = true;
            this.allAppointment.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allAppointment.Location = new System.Drawing.Point(63, 168);
            this.allAppointment.Name = "allAppointment";
            this.allAppointment.Size = new System.Drawing.Size(119, 20);
            this.allAppointment.TabIndex = 3;
            this.allAppointment.TabStop = true;
            this.allAppointment.Text = "All Appointment";
            this.allAppointment.UseVisualStyleBackColor = true;
            this.allAppointment.CheckedChanged += new System.EventHandler(this.allAppointment_CheckedChanged);
            // 
            // byMonth
            // 
            this.byMonth.AutoSize = true;
            this.byMonth.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byMonth.Location = new System.Drawing.Point(63, 254);
            this.byMonth.Name = "byMonth";
            this.byMonth.Size = new System.Drawing.Size(152, 20);
            this.byMonth.TabIndex = 4;
            this.byMonth.TabStop = true;
            this.byMonth.Text = "Monthly Appointment";
            this.byMonth.UseVisualStyleBackColor = true;
            this.byMonth.CheckedChanged += new System.EventHandler(this.byMonth_CheckedChanged);
            // 
            // byWeek
            // 
            this.byWeek.AutoSize = true;
            this.byWeek.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.byWeek.Location = new System.Drawing.Point(63, 328);
            this.byWeek.Name = "byWeek";
            this.byWeek.Size = new System.Drawing.Size(146, 20);
            this.byWeek.TabIndex = 5;
            this.byWeek.TabStop = true;
            this.byWeek.Text = "Weekly Appointment";
            this.byWeek.UseVisualStyleBackColor = true;
            this.byWeek.CheckedChanged += new System.EventHandler(this.byWeek_CheckedChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(243, 168);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 6;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 660);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.byWeek);
            this.Controls.Add(this.byMonth);
            this.Controls.Add(this.allAppointment);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataGridViewCalendar);
            this.Controls.Add(this.label1);
            this.Name = "Calendar";
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCalendar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton allAppointment;
        private System.Windows.Forms.RadioButton byMonth;
        private System.Windows.Forms.RadioButton byWeek;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}