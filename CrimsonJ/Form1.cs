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


namespace CrimsonJ
{
    public partial class FrmCrimsonJ : Form
    {
        bool en;
        string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CrimsonJ\\";


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
            JournalEntry journal = new JournalEntry(1, txt, cldCJ.SelectionRange.Start);

            List<int[]> lst = journal.format();

            for (int i = 0; i < lst.Count; i++)
            {
                int type = lst[i][0];
                rtxEntry.SelectionStart = lst[i][1];
                rtxEntry.SelectionLength = lst[i][2];

                switch (type)
                {
                    case 0: // header, font: standart, 18, bold
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
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);

            en = false;

            btnJournal.Hide();
            btnAppointment.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnForward_Click(object sender, EventArgs e)
        {

        }

        private void btnToday_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            cldCJ.MaxSelectionCount = 1;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            
            string txt = rtxEntry.Text;
            JournalEntry journal = new JournalEntry(1, txt, cldCJ.SelectionRange.Start);
            //string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CrimsonJ\\Journal\\";
            temp += "Journal\\";
            // Start writing to file
            if (!Directory.Exists(temp))
                Directory.CreateDirectory(temp);

            string date = journal.CreatedAt.Year + "-" + journal.CreatedAt.Month+ ".txt";
            string path = Path.Combine(temp, date);

            string startEnd = "\n" + journal.CreatedAt.ToShortDateString() + "\n";
            FileStream fs;
            if (!File.Exists(path))
                fs = File.Create(path);

            else
                fs = File.Open(path, FileMode.Append);


            var sr = new StreamWriter(fs);
            sr.Write(startEnd + rtxEntry.Text+ startEnd);
            

            sr.Close(); fs.Close();
            // End writing to file

            formatText();

        
        }

        
    }
}
