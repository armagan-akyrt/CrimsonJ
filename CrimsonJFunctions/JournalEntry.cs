using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;


namespace CrimsonJFunctions
{
    class JournalEntry
    {
        private int id;// id
        private string entry; // journal entry
        private DateTime createdAt; // date created
        private ArrayList formatIdentifiers = new ArrayList(); // hashtable
        public JournalEntry(int id, string entry)
        {
            this.Id = id;
            this.Entry = entry;
            this.CreatedAt = DateTime.Now;

            // Format identifiers
            formatIdentifiers.Add("(===)(.*)(===)"); // header
            formatIdentifiers.Add("(---)(.*)(---)"); // underline
            formatIdentifiers.Add("(***)(.*)(***)"); // italic
            formatIdentifiers.Add("(#)(.*)(#)"); // score out

        }

        public int Id { get => id; set => id = value; }
        public string Entry { get => entry; set => entry = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        private string format()
        {

            for (int i = 0; i < formatIdentifiers.Count; i++)
            {
                Regex rx = new Regex((string)formatIdentifiers[i]);
                rx.Match(entry);
                string[] strArr = { "x", "y" };
            }

            return "x";
        }

        


    }
}
