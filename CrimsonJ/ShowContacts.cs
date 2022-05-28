using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrimsonJ.Classes;

namespace CrimsonJ
{
    public partial class ShowContacts : Form
    {
    
        Connection conn;
        Contact selectedContact = new Contact("", "", "","", "");
        Dictionary<string, List<string>> contacts = new Dictionary<string, List<string>>();
        bool linkAppointment = false;
        string email = string.Empty;
        public ShowContacts(bool linkAppointment)
        {
            
            InitializeComponent();
            this.linkAppointment = linkAppointment; // check whether this panel is for linking appointment.
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            email = lstContacts.Text;

            if (email.Length == 0) ;
            else
            {
                Regex rx = new Regex("(.*\\s)(.+@.+\\.[A-z]+)(\\s.*)");
                Match match = rx.Match(email);

                email = match.Groups[2].Value;

                Dictionary<string, string> cnt = new Dictionary<string, string>();
                cnt = conn.GetContact(email);
                selectedContact = new Contact(cnt["name"], cnt["surname"], cnt["address"], cnt["gsm"], cnt["email"]);
            }
            
        }

        private void ShowContacts_Load(object sender, EventArgs e)
        {

            

            List<string> contact = new List<string>();
            conn = new Connection();
            conn.Connect();

            contacts = conn.GetAllContacts();

            for (int i = 0; i < contacts["emails"].Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(contacts["names"][i] + " " + contacts["surnames"][i] + "\t \t ");
                //sb.Append(contacts["surnames"][i] + ",");
                sb.Append(contacts["gsms"][i] + "\t \t ");
                sb.Append(contacts["emails"][i] + " \t \t  ");
                sb.Append(contacts["addresses"][i]);
                string str = sb.ToString();

                lstContacts.Items.Add(str);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            lstContacts.Items.Clear();

             contacts = conn.GetAllContacts(textBox1.Text);

            
            for (int i = 0; i < contacts["emails"].Count; i++)
            {
                // builds the string to list contacts.
                StringBuilder sb = new StringBuilder();
                sb.Append(contacts["names"][i] + " " + contacts["surnames"][i] + "/ ");
                //sb.Append(contacts["surnames"][i] + ",");
                sb.Append(contacts["gsms"][i] + "/ ");
                sb.Append(contacts["emails"][i] + "/ ");
                sb.Append(contacts["addresses"][i]);
                string str = sb.ToString();

                lstContacts.Items.Add(str);
            }
        }

        private void btnEditContact_Click(object sender, EventArgs e)
        {
            EditContact frm = new EditContact(selectedContact);

            
            frm.Show();
            
        }

        public Contact PassContact { get { return selectedContact; } }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.DeleteContact(email);

        }
    }
}
