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
using System.Text.RegularExpressions;
namespace CrimsonJ
{

    public partial class ShowAppointments : Form
    {

        Dictionary<string, List<string>> val = new Dictionary<string, List<string>>();
        Connection conn;
        Appointment oldAppointment;
        string oldName = "";

        public ShowAppointments()
        {
            InitializeComponent();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowAppointments_Load(object sender, EventArgs e)
        {
            conn = new Connection();
            conn.Connect();

            cldAppointments.MaxSelectionCount = 1;
            cldAppointments.SelectionStart = DateTime.Today;

            changeList();




        }

        private void cldAppointments_DateChanged(object sender, DateRangeEventArgs e)
        {
            changeList();
        }



        public void changeList()
        {
            val = conn.GetAppointments(cldAppointments.SelectionStart);

            // lists appointments in selected dates
            lstAppointments.Items.Clear();

            string str;

            for (int i = 0; i < val["createdAt"].Count; i++)
            {
                str = val["names"][i];

                lstAppointments.Items.Add(str);
            }
        }

        private void lstAppointments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = lstAppointments.SelectedIndex;

            txtAppointment.Text = val["names"][x];
            txtContact.Text = val["emails"][x];
            rtxEntry.Text = val["entries"][x];
            dtpMeetingDate.Value = Convert.ToDateTime(val["createdFor"][x]);

            Dictionary<string, string> cnt = new Dictionary<string, string>();
            cnt = conn.GetContact(txtContact.Text);
            Contact contact = new Contact(cnt["name"], cnt["surname"], cnt["address"], cnt["gsm"], cnt["email"]);
            oldAppointment = new Appointment(rtxEntry.Text, dtpMeetingDate.Value, contact);

            oldName = txtAppointment.Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> cnt = new Dictionary<string, string>();
            cnt = conn.GetContact(txtContact.Text);
            Contact contact = new Contact(cnt["name"], cnt["surname"], cnt["address"], cnt["gsm"], cnt["email"]);
            Appointment appointment = new Appointment(rtxEntry.Text, dtpMeetingDate.Value, contact);

            conn.UpdateAppointment(oldName, txtAppointment.Text, appointment);
        }
    }
}
