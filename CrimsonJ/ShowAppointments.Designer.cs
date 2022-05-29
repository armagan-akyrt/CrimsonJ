
namespace CrimsonJ
{
    partial class ShowAppointments
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
            this.cldAppointments = new System.Windows.Forms.MonthCalendar();
            this.lstAppointments = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAppointment = new System.Windows.Forms.TextBox();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.rtxEntry = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpMeetingDate = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Date for Appointment";
            // 
            // cldAppointments
            // 
            this.cldAppointments.Location = new System.Drawing.Point(15, 50);
            this.cldAppointments.Name = "cldAppointments";
            this.cldAppointments.TabIndex = 4;
            this.cldAppointments.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cldAppointments_DateChanged);
            // 
            // lstAppointments
            // 
            this.lstAppointments.FormattingEnabled = true;
            this.lstAppointments.Location = new System.Drawing.Point(15, 241);
            this.lstAppointments.Name = "lstAppointments";
            this.lstAppointments.Size = new System.Drawing.Size(227, 160);
            this.lstAppointments.TabIndex = 5;
            this.lstAppointments.SelectedIndexChanged += new System.EventHandler(this.lstAppointments_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select an Appointment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Appointment name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Details:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contact:";
            // 
            // txtAppointment
            // 
            this.txtAppointment.Location = new System.Drawing.Point(358, 47);
            this.txtAppointment.Name = "txtAppointment";
            this.txtAppointment.Size = new System.Drawing.Size(204, 20);
            this.txtAppointment.TabIndex = 10;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(358, 73);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(204, 20);
            this.txtContact.TabIndex = 11;
            // 
            // rtxEntry
            // 
            this.rtxEntry.Location = new System.Drawing.Point(358, 125);
            this.rtxEntry.Name = "rtxEntry";
            this.rtxEntry.Size = new System.Drawing.Size(204, 247);
            this.rtxEntry.TabIndex = 12;
            this.rtxEntry.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Meeting Date:";
            // 
            // dtpMeetingDate
            // 
            this.dtpMeetingDate.Location = new System.Drawing.Point(358, 99);
            this.dtpMeetingDate.Name = "dtpMeetingDate";
            this.dtpMeetingDate.Size = new System.Drawing.Size(200, 20);
            this.dtpMeetingDate.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(483, 378);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ShowAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 441);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtpMeetingDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtxEntry);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtAppointment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstAppointments);
            this.Controls.Add(this.cldAppointments);
            this.Controls.Add(this.label1);
            this.Name = "ShowAppointments";
            this.Text = "ShowAppointments";
            this.Load += new System.EventHandler(this.ShowAppointments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar cldAppointments;
        private System.Windows.Forms.ListBox lstAppointments;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAppointment;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.RichTextBox rtxEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpMeetingDate;
        private System.Windows.Forms.Button btnDelete;
    }
}