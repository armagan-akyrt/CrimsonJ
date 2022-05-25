using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonJ.Classes
{
    class Appointment
    {
        private string entry;
        private DateTime createdFor;
        private DateTime createdAt;
        private Contact contact;

        public Appointment(string entry, DateTime createdFor, Contact contact)
        {
            this.entry = entry;
            this.createdFor = createdFor;
            this.contact = contact;
            this.createdAt = DateTime.Today;
        }


    }
}
