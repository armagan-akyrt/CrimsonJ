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

        /// <summary>
        /// Create  an appointment
        /// </summary>
        /// <param name="entry">appointment entry</param>
        /// <param name="createdFor"> appointment date</param>
        /// <param name="contact"> person to meet</param>
        public Appointment(string entry, DateTime createdFor, Contact contact)
        {
            this.entry = entry;
            this.createdFor = createdFor;
            this.contact = contact;
            this.createdAt = DateTime.Today;
        }


    }
}
