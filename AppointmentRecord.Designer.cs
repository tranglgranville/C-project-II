
namespace Trang_Granville
{
    partial class AppointmentRecord
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.appID = new System.Windows.Forms.TextBox();
            this.customerName = new System.Windows.Forms.TextBox();
            this.custID = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.startTime = new System.Windows.Forms.DateTimePicker();
            this.endTime = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewAppt = new System.Windows.Forms.DataGridView();
            this.typeApp = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.appType = new System.Windows.Forms.Button();
            this.ClearTextbox = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointment Records";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Appointment ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Customer ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(86, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(58, 343);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Start Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(62, 391);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "End Time";
            // 
            // appID
            // 
            this.appID.Location = new System.Drawing.Point(141, 163);
            this.appID.Name = "appID";
            this.appID.ReadOnly = true;
            this.appID.Size = new System.Drawing.Size(196, 20);
            this.appID.TabIndex = 13;
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(141, 245);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(196, 20);
            this.customerName.TabIndex = 14;
            // 
            // custID
            // 
            this.custID.Location = new System.Drawing.Point(141, 205);
            this.custID.Name = "custID";
            this.custID.Size = new System.Drawing.Size(196, 20);
            this.custID.TabIndex = 15;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(39, 516);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 45);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Add Appointment";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateButton.Location = new System.Drawing.Point(161, 516);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(87, 45);
            this.updateButton.TabIndex = 26;
            this.updateButton.Text = "Update Appointment";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(280, 516);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(92, 45);
            this.deleteButton.TabIndex = 27;
            this.deleteButton.Text = "Delete Appointment";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // startTime
            // 
            this.startTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.startTime.CustomFormat = "yyyy-MM-dd HH:mm:ss ";
            this.startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTime.Location = new System.Drawing.Point(141, 338);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(200, 20);
            this.startTime.TabIndex = 29;
            this.startTime.ValueChanged += new System.EventHandler(this.startTime_ValueChanged);
            // 
            // endTime
            // 
            this.endTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTime.Location = new System.Drawing.Point(141, 386);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(200, 20);
            this.endTime.TabIndex = 30;
            this.endTime.ValueChanged += new System.EventHandler(this.endTime_ValueChanged);
            // 
            // dataGridViewAppt
            // 
            this.dataGridViewAppt.AllowUserToAddRows = false;
            this.dataGridViewAppt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAppt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppt.Location = new System.Drawing.Point(395, 60);
            this.dataGridViewAppt.Name = "dataGridViewAppt";
            this.dataGridViewAppt.RowHeadersVisible = false;
            this.dataGridViewAppt.Size = new System.Drawing.Size(846, 516);
            this.dataGridViewAppt.TabIndex = 31;
            this.dataGridViewAppt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAppt_CellClick);
            // 
            // typeApp
            // 
            this.typeApp.Location = new System.Drawing.Point(141, 293);
            this.typeApp.Name = "typeApp";
            this.typeApp.Size = new System.Drawing.Size(196, 20);
            this.typeApp.TabIndex = 20;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(1084, 632);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(139, 33);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Back to Main Portal";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // appType
            // 
            this.appType.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appType.Location = new System.Drawing.Point(892, 634);
            this.appType.Name = "appType";
            this.appType.Size = new System.Drawing.Size(137, 31);
            this.appType.TabIndex = 33;
            this.appType.Text = "Appointment Type";
            this.appType.UseVisualStyleBackColor = true;
            this.appType.Click += new System.EventHandler(this.appType_Click);
            // 
            // ClearTextbox
            // 
            this.ClearTextbox.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearTextbox.Location = new System.Drawing.Point(249, 433);
            this.ClearTextbox.Name = "ClearTextbox";
            this.ClearTextbox.Size = new System.Drawing.Size(92, 23);
            this.ClearTextbox.TabIndex = 34;
            this.ClearTextbox.Text = "Clear Textbox";
            this.ClearTextbox.UseVisualStyleBackColor = true;
            this.ClearTextbox.Click += new System.EventHandler(this.ClearTextbox_Click);
            // 
            // AppointmentRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 700);
            this.Controls.Add(this.ClearTextbox);
            this.Controls.Add(this.appType);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataGridViewAppt);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.typeApp);
            this.Controls.Add(this.custID);
            this.Controls.Add(this.customerName);
            this.Controls.Add(this.appID);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AppointmentRecord";
            this.Text = "AppointmentRecord";
            this.Load += new System.EventHandler(this.AppointmentRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox appID;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox custID;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker startTime;
        private System.Windows.Forms.DateTimePicker endTime;
        private System.Windows.Forms.DataGridView dataGridViewAppt;
        private System.Windows.Forms.TextBox typeApp;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button appType;
        private System.Windows.Forms.Button ClearTextbox;
    }
}