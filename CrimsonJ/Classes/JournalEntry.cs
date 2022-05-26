using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;


namespace CrimsonJ
{
    public class JournalEntry
    {
        private int id;// id
        private string entry; // journal entry
        private DateTime createdAt; // date created
        private ArrayList formatIdentifiers = new ArrayList(); // hashtable

        public JournalEntry(int id, string entry, DateTime createdAt)
        {
            this.Id = id; 
            this.Entry = entry;
            this.CreatedAt = createdAt;

            // Format identifiers
            formatIdentifiers.Add("(===)(.*)(===)"); // header 1
            formatIdentifiers.Add("(---)(.*)(---)"); // underline
            formatIdentifiers.Add("(~~~)(.*)(~~~)"); // italic
            formatIdentifiers.Add("(#)(.*)(#)"); // score out
            formatIdentifiers.Add("(>>>)(.*)()"); // bullet points

        }

        public int Id { get => id; set => id = value; }
        public string Entry { get => entry; set => entry = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

        /// <summary>
        /// This finds parts of strings to be formatted and formats them accordingly
        /// </summary>
        /// <returns>a list of type, start index, length</returns>
        public List<int[]> format()
        {
            List<int[]> lst = new List<int[]>();

            for (int i = 0; i < formatIdentifiers.Count; i++)
            {
                Regex rx = new Regex((string)formatIdentifiers[i]);
                MatchCollection match = rx.Matches(entry);
                
                if (match.Count > 0)
                {
                    foreach (Match mt in match)
                    {

                        entry = rx.Replace(entry, mt.Groups[2].Value, 1);
                       
                        int start = mt.Groups[2].Index; // start index
                        int length = mt.Groups[2].Length; // length of capture
                        int[] arr = { i, start, length };
                        lst.Add(arr);

                        
                    }
                }
                
            }

            return lst;
        }


    
    }
}
