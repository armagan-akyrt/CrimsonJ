using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;
using CrimsonJ.Classes;



namespace CrimsonJ
{
    public partial class FrmCrimsonJ : Form
    {
        
        #pragma warning disable IDE1006 // Naming Styles
        string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CrimsonJ\\";
        bool en, enCnt;
        string textIn;
        Connection conn;

        public FrmCrimsonJ()
        {

            InitializeComponent();

        }
        
        /// <summary>
        /// Formats text according to user input. Check github readme for more documentation.
        /// </summary>
        public void formatText()

        {
            string txt = rtxEntry.Text;
            textIn = txt;
            JournalEntry journal = new JournalEntry(1, txt, cldCJ.SelectionRange.Start);
            
            List<int[]> lst = journal.format();

            //rtxEntry.Text = journal.Entry;

            for (int i = 0; i < lst.Count; i++)
            {
                
                int type = lst[i][0];
                rtxEntry.SelectionStart = lst[i][1];
                rtxEntry.SelectionLength = lst[i][2];

                

                switch (type)
                {
                    case 0: // header, font: standart, 24, bold
                        
                        rtxEntry.SelectionFont = new Font(rtxEntry.Font.Name, 24, FontStyle.Bold);
                        break;

                    case 1: // underline, font: standart, def, underline
                        rtxEntry.SelectionFont = new Font(rtxEntry.Font.Name, rtxEntry.Font.Size, FontStyle.Underline);
                        break;

                    case 2: // italic, font: standart, def, italic
                        rtxEntry.SelectionFont = new Font(rtxEntry.Font.Name, rtxEntry.Font.Size, FontStyle.Italic);
                        break;

                    case 3: // strikeout, font: standart, def, strikeout
                        rtxEntry.SelectionFont = new Font(rtxEntry.Font.Name, rtxEntry.Font.Size, FontStyle.Strikeout);
                        break;

                    case 4: // bullet point
                        
                        rtxEntry.SelectionBullet = true;
                        break;
                }
                
            }
        }

        public void saveToFile(string fPath)
        {
            
            string replaced;
            string replacement = rtxEntry.Text ;

            if (File.Exists(fPath))
            {
                FileStream fs = File.OpenRead(fPath);
                var sr = new StreamReader(fs);

                
                string today = cldCJ.SelectionStart.ToShortDateString();
                string pattern = "(" + today + ")((.|\n)*)(" + today + ")";
                Regex entry = new Regex(pattern);

                string jEntry = sr.ReadToEnd();
                Match mt = entry.Match(jEntry);
                Match repl = entry.Match(replacement);
                replacement = repl.Groups[2].Value;
                replaced = mt.Groups[2].Value;

                fs.Close(); sr.Close();

                FileStream fw = File.OpenWrite(fPath);
                var sw = new StreamWriter(fw);
                jEntry = jEntry.Replace(replaced, replacement);
                sw.Write(jEntry);

                sw.Close();

            }
        }

        public void retrieveFromJournal(string fPath)
        {
            if (File.Exists(fPath))
            {
                FileStream fs = File.OpenRead(fPath);
                var sr = new StreamReader(fs);

                
                string today = cldCJ.SelectionStart.ToShortDateString();
                string pattern = "(" + today + ")((.|\n)*)(" + today + ")";
                Regex entry = new Regex(pattern);

                string jEntry = sr.ReadToEnd();
                Match mt = entry.Match(jEntry);
                rtxEntry.Text = mt.Value;

                fs.Close(); sr.Close();
            }
            else
            {
                FileStream fs = File.Create(fPath);
                fs.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);

            conn = new Connection();
            conn.Connect();

            textIn = rtxEntry.Text;
            en = false;



           
            rtxEntry.Text = conn.GetFromJournal(cldCJ.TodayDate);
            

            btnJournal.Hide();
            btnAppointment.Hide();

            btnAddContact.Hide();
            btnShowContacts.Hide();


            DateTime today = DateTime.Today;

            Dictionary<string, List<string>> listAppointments = new Dictionary<string, List<string>>();

            for (int i = 0; i < 7; i++)
            {
                
                listAppointments = conn.GetAppointments(today);
                today = today.AddDays(1);


                for (int j = 0; j < listAppointments["names"].Count; j++)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(listAppointments["names"][j] + "\t");
                    sb.Append(listAppointments["createdFor"][j]);

                    listBox1.Items.Add(sb.ToString());
                }

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textIn = rtxEntry.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // attempting to make this  a drop down menu 
            if (!en)
            {
                btnAppointment.Show();
                btnJournal.Show();
                en = true;
            }
            else
            {
                btnAppointment.Hide();
                btnJournal.Hide();
                en = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Whenever this button is clicked, goes back by 1 day.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            DateTime curr = cldCJ.SelectionStart;
            curr = curr.AddDays(-1);
            cldCJ.SelectionStart = curr;
        }

        /// <summary>
        /// Whenever this button is clicked, goes forward by 1 day.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForward_Click(object sender, EventArgs e)
        {
            DateTime curr = cldCJ.SelectionStart;
            curr = curr.AddDays(1);
            cldCJ.SelectionStart = curr;
        }

        /// <summary>
        /// Whenever clicked, jumps to today.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToday_Click(object sender, EventArgs e)
        {
            cldCJ.SelectionStart = DateTime.Today;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // structure for dropdown menu.
            if (!enCnt)
            {
                btnShowContacts.Show();
                btnAddContact.Show();
                enCnt = true;

            }
            else
            {
                btnShowContacts.Hide();
                btnAddContact.Hide();
                enCnt = false;
            }
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            cldCJ.MaxSelectionCount = 1;

            rtxEntry.Text = conn.GetFromJournal(cldCJ.SelectionStart); // retrieve data from the journal
            formatText(); // format the entry.

            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formatText();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // save the entry into the database
            conn.InsertToJournal(cldCJ.SelectionStart, rtxEntry.Text);
         
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // open insert appointment form.

            AddAppointment frm = new AddAppointment(rtxEntry.Text);
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            // edit the journal content
            conn.UpdateJournal(cldCJ.SelectionStart, rtxEntry.Text);
        }

        private void button4_Click_3(object sender, EventArgs e)
        {
            // open show contacts form.

            ShowContacts frm = new ShowContacts(false); 
            frm.ShowDialog();
        }

        private void btnShowAppointment_Click(object sender, EventArgs e)
        {
            // open show appointments form.

            ShowAppointments frm = new ShowAppointments();
            frm.ShowDialog();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // open insert contact form.

            AddContact frm = new AddContact();
            frm.ShowDialog();
        }

    }
}
