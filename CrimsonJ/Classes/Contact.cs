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

        /// <summary>
        /// Create a contact.
        /// </summary>
        /// <param name="name"> contact name</param>
        /// <param name="surname"> contact last name</param>
        /// <param name="address"> contact address</param>
        /// <param name="gsm"> contact phone number</param>
        /// <param name="email"> contact e-mail</param>
        public Contact(string name, string surname, string address, string gsm, string email)
        {
            this.name = name;
            this.surname = surname;
            this.address = address;
            this.gsm = gsm;
            this.email = email;
        }



    }
}
