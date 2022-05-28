using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonJ.Classes
{
    class Appointment
    {
        #region Variables
        public string entry;
        public DateTime createdFor;
        public DateTime createdAt;
        public Contact contact;
        #endregion

        public Appointment(string entry, DateTime createdFor, Contact contact)
        {
            this.entry = entry;
            this.createdFor = createdFor;
            this.contact = contact;
            this.createdAt = DateTime.Today;
        }


    }
}
