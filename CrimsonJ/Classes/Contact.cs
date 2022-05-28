using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonJ.Classes
{
    public class Contact
    {
        #region Variables
        public string name;
        public string surname;
        public string address;
        public string gsm;
        public string email;
        #endregion

        public Contact(string name, string surname, string address, string gsm, string email)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.gsm = gsm;
            this.email = email;
        }

        public void EditContact (string name, string surname, string address, string gsm, string email)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.gsm = gsm;
            this.email = email;
        }


    }
}
