using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrimsonJ.Classes;

namespace CrimsonJ
{
    public partial class AddContact : Form
    {

        Connection conn;
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
            conn.InsertContact(contact);
            this.Close();
        }

        private void getContact_Click(object sender, EventArgs e)
        {
            conn.GetAllContacts();
        }
    }
}
