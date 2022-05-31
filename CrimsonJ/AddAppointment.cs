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
    public partial class AddAppointment : Form
    {

        string entry = "";
        string email = "";
        Connection conn;
        Contact selectedContact;
        Dictionary<string, List<string>> contacts = new Dictionary<string, List<string>>();
        public AddAppointment(string entry)
        {
            InitializeComponent();
            this.entry = entry;
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {
            cldAppointment.MaxSelectionCount = 1;
            cldAppointment.SelectionStart = DateTime.Today;

            List<string> contact = new List<string>();
            conn = new Connection();
            conn.Connect();

            contacts = conn.GetAllContacts();

            for (int i = 0; i < contacts["emails"].Count; i++)
            {
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            lstContacts.Items.Clear();

            contacts = conn.GetAllContacts(txtSearch.Text);


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

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            email = lstContacts.Text;

            if (email.Length == 0) ;
            else
            {
                Regex rx = new Regex("(.*/\\s)(.+@.+\\.[A-z]+)(/.*)");
                Match match = rx.Match(email);

                email = match.Groups[2].Value;

                Dictionary<string, string> cnt = new Dictionary<string, string>();
                cnt = conn.GetContact(email);
                selectedContact = new Contact(cnt["name"], cnt["surname"], cnt["address"], cnt["gsm"], cnt["email"]);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DateTime createdFor = cldAppointment.SelectionStart;
            
            conn.InsertAppointment(entry, DateTime.Today, createdFor, txtAppointmentName.Text, email);
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditContact frm = new EditContact(selectedContact);
            frm.ShowDialog();
        }


        /// <summary>
        /// Adds a new contact to the contacts list via add appointment form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> </param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddContact frm = new AddContact();
            frm.ShowDialog();
            
        }
    }
}
