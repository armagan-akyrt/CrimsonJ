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
    public partial class AddContact : Form
    {

        Connection conn;
        bool checkEmail = false;
        public AddContact()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
      
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddContact_Load(object sender, EventArgs e)
        {
            conn = new Connection();
            conn.Connect();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact(txtName.Text, txtSurname.Text, txtAddress.Text, txtGsm.Text, txtEmail.Text);
            Regex rx = new Regex(".+@.+\\.[A-z]+"); // to match email
            checkEmail = rx.IsMatch(txtEmail.Text);
            
            if (checkEmail) // If email is valid, inserts into db, if not, waits for correct email.
            {
                conn.InsertContact(contact);
                this.Close();
            }
            else
            {
                txtEmail.Text = "please enter a valid email.";
            }
        }

        private void getContact_Click(object sender, EventArgs e)
        {
            conn.GetAllContacts(); // list all contacts.
        }
    }
}
