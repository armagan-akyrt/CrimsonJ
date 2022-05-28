
namespace CrimsonJ
{
    partial class FrmCrimsonJ
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCrimsonJ));
            this.cldCJ = new System.Windows.Forms.MonthCalendar();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.rtxEntry = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnContacts = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnAppointment = new System.Windows.Forms.Button();
            this.btnJournal = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowContacts = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnShowAppointment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cldCJ
            // 
            this.cldCJ.Location = new System.Drawing.Point(5, 68);
            this.cldCJ.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.cldCJ.Name = "cldCJ";
            this.cldCJ.TabIndex = 0;
            this.cldCJ.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.Transparent;
            this.btnToday.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToday.BackgroundImage")));
            this.btnToday.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnToday.Location = new System.Drawing.Point(99, 28);
            this.btnToday.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(89, 26);
            this.btnToday.TabIndex = 1;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.Transparent;
            this.btnForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnForward.BackgroundImage")));
            this.btnForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnForward.Location = new System.Drawing.Point(194, 28);
            this.btnForward.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(89, 26);
            this.btnForward.TabIndex = 2;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.Location = new System.Drawing.Point(5, 28);
            this.btnBack.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 26);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1183, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(5, 269);
            this.listBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(263, 272);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // rtxEntry
            // 
            this.rtxEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxEntry.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxEntry.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtxEntry.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxEntry.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtxEntry.Location = new System.Drawing.Point(281, 62);
            this.rtxEntry.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.rtxEntry.Name = "rtxEntry";
            this.rtxEntry.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtxEntry.ShowSelectionMargin = true;
            this.rtxEntry.Size = new System.Drawing.Size(883, 510);
            this.rtxEntry.TabIndex = 7;
            this.rtxEntry.Text = "";
            this.rtxEntry.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(579, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 26);
            this.button1.TabIndex = 8;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(703, 28);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Insert";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(823, 28);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 26);
            this.button3.TabIndex = 10;
            this.button3.Text = "Format";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnContacts
            // 
            this.btnContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContacts.BackColor = System.Drawing.Color.Transparent;
            this.btnContacts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContacts.BackgroundImage")));
            this.btnContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnContacts.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnContacts.Image = ((System.Drawing.Image)(resources.GetObject("btnContacts.Image")));
            this.btnContacts.Location = new System.Drawing.Point(937, 28);
            this.btnContacts.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnContacts.Name = "btnContacts";
            this.btnContacts.Size = new System.Drawing.Size(89, 26);
            this.btnContacts.TabIndex = 11;
            this.btnContacts.Text = "Contacts";
            this.btnContacts.UseVisualStyleBackColor = false;
            this.btnContacts.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnAppointment
            // 
            this.btnAppointment.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAppointment.BackColor = System.Drawing.Color.Transparent;
            this.btnAppointment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAppointment.BackgroundImage")));
            this.btnAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppointment.Location = new System.Drawing.Point(703, 96);
            this.btnAppointment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAppointment.Name = "btnAppointment";
            this.btnAppointment.Size = new System.Drawing.Size(168, 26);
            this.btnAppointment.TabIndex = 11;
            this.btnAppointment.Text = "Insert Appointment";
            this.btnAppointment.UseVisualStyleBackColor = false;
            this.btnAppointment.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnJournal
            // 
            this.btnJournal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnJournal.BackColor = System.Drawing.Color.Transparent;
            this.btnJournal.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnJournal.BackgroundImage")));
            this.btnJournal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnJournal.Location = new System.Drawing.Point(703, 62);
            this.btnJournal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnJournal.Name = "btnJournal";
            this.btnJournal.Size = new System.Drawing.Size(168, 26);
            this.btnJournal.TabIndex = 10;
            this.btnJournal.Text = "Insert Journal";
            this.btnJournal.UseVisualStyleBackColor = false;
            this.btnJournal.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(1075, 612);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 26);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnShowContacts
            // 
            this.btnShowContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowContacts.BackColor = System.Drawing.Color.Transparent;
            this.btnShowContacts.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowContacts.BackgroundImage")));
            this.btnShowContacts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowContacts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnShowContacts.Location = new System.Drawing.Point(937, 62);
            this.btnShowContacts.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnShowContacts.Name = "btnShowContacts";
            this.btnShowContacts.Size = new System.Drawing.Size(168, 26);
            this.btnShowContacts.TabIndex = 14;
            this.btnShowContacts.Text = "Show Contacts";
            this.btnShowContacts.UseVisualStyleBackColor = false;
            this.btnShowContacts.Click += new System.EventHandler(this.button4_Click_3);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddContact.BackColor = System.Drawing.Color.Transparent;
            this.btnAddContact.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddContact.BackgroundImage")));
            this.btnAddContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddContact.Location = new System.Drawing.Point(937, 96);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(168, 26);
            this.btnAddContact.TabIndex = 15;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = false;
            this.btnAddContact.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // btnShowAppointment
            // 
            this.btnShowAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAppointment.BackColor = System.Drawing.Color.Transparent;
            this.btnShowAppointment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShowAppointment.BackgroundImage")));
            this.btnShowAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowAppointment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnShowAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAppointment.Image")));
            this.btnShowAppointment.Location = new System.Drawing.Point(1049, 28);
            this.btnShowAppointment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnShowAppointment.Name = "btnShowAppointment";
            this.btnShowAppointment.Size = new System.Drawing.Size(115, 26);
            this.btnShowAppointment.TabIndex = 16;
            this.btnShowAppointment.Text = "Show Appointments";
            this.btnShowAppointment.UseVisualStyleBackColor = false;
            this.btnShowAppointment.Click += new System.EventHandler(this.btnShowAppointment_Click);
            // 
            // FrmCrimsonJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1183, 651);
            this.Controls.Add(this.btnShowAppointment);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.btnShowContacts);
            this.Controls.Add(this.btnAppointment);
            this.Controls.Add(this.btnJournal);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnContacts);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtxEntry);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.cldCJ);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Constantia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmCrimsonJ";
            this.Text = "CrimsonJ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar cldCJ;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.RichTextBox rtxEntry;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnContacts;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnAppointment;
        private System.Windows.Forms.Button btnJournal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnShowContacts;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnShowAppointment;
    }
}

