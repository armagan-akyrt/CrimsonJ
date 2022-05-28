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
    public partial class EditContact : Form
    {
        string oldEmail = "";
        private static Contact contact = new Contact("", "", "", "", "");
        Connection conn;
        

        public static Contact PassContact { set => contact = value; }

        public EditContact(Contact cont)
        {
            InitializeComponent();
            contact = cont;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditContact_Load(object sender, EventArgs e)
        {
            conn = new Connection();
            conn.Connect();
            MaximizeBox = false;
            MinimizeBox = false;

            oldEmail = contact.email; // old email of the contact. If changes, this value will be used in sql


            txtName.Text = contact.name;
            txtSurname.Text = contact.surname;
            txtGsm.Text = contact.gsm;
            txtEmail.Text = oldEmail;
            txtAddress.Text = contact.address;
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            // updates the contact information.
            Contact updContact = new Contact(txtName.Text, txtSurname.Text, txtAddress.Text, txtGsm.Text, txtEmail.Text);
            conn.UpdateContact(updContact, oldEmail);
        }
    }
}
