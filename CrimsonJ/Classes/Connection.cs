using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace CrimsonJ.Classes
{
    class Connection
    {
        #region Variables
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataReader dr;
        private string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CrimsonJ\\CrimsonJ.sqlite";
        #endregion

        public Connection()
        {
        }

        /// <summary>
        /// Connects to the database, if doesn't exists, creates one.
        /// </summary>
        public void Connect()
        {
            if (!File.Exists(temp))
            {
                SQLiteConnection.CreateFile(temp);

                // Querries to create necessary tables.
                string sql = @"CREATE TABLE IF NOT EXISTS Appointment(
	                                appointmentName TEXT PRIMARY KEY,
	                                entry TEXT,
	                                createdAt TEXT NOT NULL, 
	                                createdFor TEXT NOT NULL
                                );

                                CREATE TABLE IF NOT EXISTS Contacts (
	                                name TEXT NOT NULL,
	                                surname TEXT,
	                                address TEXT,
	                                gsm TEXT,
	                                email TEXT PRIMARY KEY
                                );

                                CREATE TABLE IF NOT EXISTS Contain (
	                                appointmentName TEXT,
	                                contactEmail TEXT,
	                                PRIMARY KEY (appointmentName, contactEmail),
	                                CONSTRAINT fkAppointment
		                                FOREIGN KEY (appointmentName)
		                                REFERENCES Appointment(appointmentName)
                                        ON UPDATE CASCADE,
	                                CONSTRAINT fkContact
		                                FOREIGN KEY (contactEmail)
		                                REFERENCES Contacts(email)
                                        ON UPDATE CASCADE
                                );

                                CREATE TABLE IF NOT EXISTS Journal (
	                                entry TEXT,
	                                createdAt TEXT PRIMARY KEY
                                );";
                con = new SQLiteConnection("Data Source="+temp+";Version=3;");
                con.Open();
                cmd = new SQLiteCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            else
            {
                con = new SQLiteConnection("Data Source=" + temp + ";Version=3;");
            }
            //ListAppointments();
        }


        

        /// <summary>
        /// Extracts the specified entry from the journal table.
        /// </summary>
        /// <param name="createdAt">date of the entry</param>
        /// <returns></returns>
        public string GetFromJournal(DateTime createdAt)
        {
            var ret = "";
            string date = createdAt.ToShortDateString(); // convert date to string
            string sql = "SELECT entry FROM Journal WHERE createdAt = @createdAt;"; // querry to insert entry to journal

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@createdAt", date));

            try
            {
               ret = cmd.ExecuteScalar().ToString();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The entry does not exist.");
                con.Close();
                return "";
            }
            
            con.Close();
            
            return ret;
        }

        /// <summary>
        /// Creates a new row for the specified date and entry
        /// </summary>
        /// <param name="createdAt"> date of the entry</param>
        /// <param name="entry"> entry string</param>
        public void InsertToJournal(DateTime createdAt, string entry)
        {
            string date = createdAt.ToShortDateString(); // convert date to string
            
            


            string sql = "INSERT INTO Journal (entry, createdAt) VALUES (@entry, @createdAt);"; // querry to insert entry to journal
            
            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@entry", entry));
            cmd.Parameters.Add(new SQLiteParameter("@createdAt", date));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException e) // exception, if entry exists, simply updates the journal
            {
                con.Close();
                UpdateJournal(createdAt, entry);
            }
            
            con.Close();
        }

        /// <summary>
        /// Updates the specified journal based on the provided entry
        /// </summary>
        /// <param name="createdAt"> date of entry</param>
        /// <param name="newEntry"> updated entry</param>
        public void UpdateJournal(DateTime createdAt, string newEntry)
        {
            string date = createdAt.ToShortDateString(); // convert date to string
            string sql = @"UPDATE Journal SET entry = @entry WHERE createdAt = @createdAt;"; // querry to edit journal values.
            
            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@entry", newEntry));
            cmd.Parameters.Add(new SQLiteParameter("@createdAt", date));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Retrieves every appointment from db
        /// </summary>
        /// <returns> every appointment in dictionary format</returns>
        public Dictionary<string, List<string>> GetAppointments(DateTime dueDate)
        {

            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            List<string> name = new List<string>();
            List<string> entry = new List<string>();
            List<string> createdAt = new List<string>();
            List<string> createdFor = new List<string>();
            List<string> email = new List<string>();
            string date = dueDate.ToShortDateString();

            string sql = @"SELECT Appointment.appointmentName, Appointment.entry, Appointment.createdAt, Appointment.createdFor, Contacts.email FROM Appointment
                            INNER JOIN Contain
                            ON appointment.AppointmentName = Contain.appointmentName
                            INNER JOIN Contacts
                            ON Contain.contactEmail = Contacts.email
							WHERE Appointment.createdFor = @createdFor";

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@createdFor", date));

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                name.Add(dr["appointmentName"].ToString());
                entry.Add(dr["entry"].ToString());
                createdAt.Add(dr["createdAt"].ToString());
                createdFor.Add(dr["createdFor"].ToString());
                email.Add(dr["email"].ToString());
            }

            ret.Add("names", name);
            ret.Add("entries", entry);
            ret.Add("createdAt", createdAt);
            ret.Add("createdFor", createdFor);
            ret.Add("emails", email);

            con.Close();

            return ret;


        }

        /// <summary>
        /// Creates an appointment accordingly by the provided values
        /// </summary>
        /// <param name="entry"> appointment notes</param>
        /// <param name="createdAt"> creation date of appointment (today)</param>
        /// <param name="createdFor"> appointment date & time</param>
        public void InsertAppointment(string entry, DateTime createdAt, DateTime createdFor, string apName, string email) 
        {
            string strCrAt = createdAt.ToShortDateString();
            string strCrFor = createdFor.ToShortDateString();

            string sql = @"INSERT INTO Appointment (appointmentName, entry, createdAt, createdFor) VALUES (@apName, @entry, @createdAt, @createdFor)";

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@apName", apName));
            cmd.Parameters.Add(new SQLiteParameter("@entry", entry));
            cmd.Parameters.Add(new SQLiteParameter("@createdAt", strCrAt));
            cmd.Parameters.Add(new SQLiteParameter("@createdFor", strCrFor));

            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();
            // querry to link appointment and provided contact 
            sql = "INSERT INTO Contain (appointmentName, contactEmail) VALUES (@name, @email)";

            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@name", apName));
            cmd.Parameters.Add(new SQLiteParameter("@email", email));
            cmd.ExecuteNonQuery();

            con.Close();
            

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="appointmentName"></param>
        /// <param name="newAppointment"></param>
        public void UpdateAppointment(string oldName, string appointmentName, Appointment newAppointment)
        {
            string sql = @"UPDATE Appointment 
                            SET appointmentName = @name, entry = @entry, createdFor = @createdFor
                            WHERE appointmentName = @oldName;";

            con.Open();

            cmd = new SQLiteCommand(sql,con);
            cmd.Parameters.Add(new SQLiteParameter("@name", appointmentName));
            cmd.Parameters.Add(new SQLiteParameter("@entry", newAppointment.entry));
            cmd.Parameters.Add(new SQLiteParameter("@createdFor", newAppointment.createdFor.ToShortDateString()));
            cmd.Parameters.Add(new SQLiteParameter("@oldName", oldName));

            con.Close();

        }

        /// <summary>
        /// Inserts contact to the database
        /// </summary>
        /// <param name="contact"> contact to insert</param>
        public void InsertContact(Contact contact)
        {
            
            string sql = "INSERT INTO Contacts (name, surname, address, gsm, email) VALUES (@name,  @surname, @address, @gsm, @email);"; // querry to insert entry to journal

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@name", contact.name));
            cmd.Parameters.Add(new SQLiteParameter("@surname", contact.surname));
            cmd.Parameters.Add(new SQLiteParameter("@address", contact.address));
            cmd.Parameters.Add(new SQLiteParameter("@gsm", contact.gsm));
            cmd.Parameters.Add(new SQLiteParameter("@email", contact.email));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SQLite.SQLiteException e) // exception, if entry exists, simply updates the journal
            {
                con.Close();
                //UpdateJournal(createdAt, entry);
            }

            con.Close();
        }


        /// <summary>
        /// Returns the specified contact via email.
        /// </summary>
        /// <param name="email"> contact's email </param>
        /// <returns></returns>
        public Dictionary<string, string> GetContact(string email)
        {

            Dictionary<string, string> ret = new Dictionary<string, string>(); // dictionary for contact elements
            string sql = @"SELECT name, surname, address, gsm, email FROM Contacts
                            WHERE email = @email"; // necessart querry

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@email", email));

            try
            {
                dr = cmd.ExecuteReader(); // reads results
                while (dr.Read())
                {
                    ret.Add("name", dr["name"].ToString());
                    ret.Add("surname", dr["surname"].ToString());
                    ret.Add("gsm", dr["gsm"].ToString());
                    ret.Add("email", dr["email"].ToString());
                    ret.Add("address", dr["address"].ToString());
                }
            }
            catch(NullReferenceException e) // null pointer exception
            {
                Console.WriteLine("The contact does not exists");
                con.Close();
                return null;
            }

            con.Close();

            return ret;
        }

        /// <summary>
        /// Returns all contacts in the table
        /// </summary>
        /// <returns>All contacts in the table</returns>
        public Dictionary<string, List<string>> GetAllContacts()
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>(); // dictionary for all the contacts
            // lists for all the contacts
            List<string> names = new List<string>();
            List<string> surnames = new List<string>();
            List<string> gsms = new List<string>();
            List<string> emails = new List<string>();
            List<string> addresses = new List<string>();
            string sql = @"SELECT * FROM Contacts";

            con.Open();
            cmd = new SQLiteCommand(sql, con);

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read()) // read untill the last row
                {
                    names.Add(dr["name"].ToString());
                    surnames.Add(dr["surname"].ToString());
                    gsms.Add(dr["gsm"].ToString());
                    emails.Add(dr["email"].ToString());
                    addresses.Add(dr["address"].ToString());

                }
                ret.Add("names", names);
                ret.Add("surnames", surnames);
                ret.Add("gsms", gsms);
                ret.Add("emails", emails);
                ret.Add("addresses", addresses);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The contact does not exists");
                con.Close();
                return null;
            }


            con.Close();
            return ret;
        }

        /// <summary>
        /// Get all contacts similar to that name
        /// </summary>
        /// <param name="name"> Case sensitive input string that look like the name</param>
        /// <returns>all the contacts that have similiar name to input</returns>
        public Dictionary<string, List<string>> GetAllContacts(string name)
        {
            Dictionary<string, List<string>> ret = new Dictionary<string, List<string>>();
            List<string> names = new List<string>();
            List<string> surnames = new List<string>();
            List<string> gsms = new List<string>();
            List<string> emails = new List<string>();
            List<string> addresses = new List<string>();
            string sql = @"SELECT * FROM Contacts WHERE name LIKE @name";

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@name", "%"+name+"%"));

            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    names.Add(dr["name"].ToString());
                    surnames.Add(dr["surname"].ToString());
                    gsms.Add(dr["gsm"].ToString());
                    emails.Add(dr["email"].ToString());
                    addresses.Add(dr["address"].ToString());

                }
                ret.Add("names", names);
                ret.Add("surnames", surnames);
                ret.Add("gsms", gsms);
                ret.Add("emails", emails);
                ret.Add("addresses", addresses);
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The contact does not exists");
                con.Close();
                return null;
            }


            con.Close();
            return ret;
        }

        /// <summary>
        /// Updates the contact with new values.
        /// </summary>
        /// <param name="contact"> updated contact</param>
        public void UpdateContact(Contact contact, string oldEmail)
        {
            string sql = @"UPDATE CONTACTS
                           SET name = @name, surname = @surname, gsm = @gsm, address = @address, email = @email
                           WHERE email= @oldEmail";

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            cmd.Parameters.Add(new SQLiteParameter("@name", contact.name));
            cmd.Parameters.Add(new SQLiteParameter("@surname", contact.surname));
            cmd.Parameters.Add(new SQLiteParameter("@gsm", contact.gsm));
            cmd.Parameters.Add(new SQLiteParameter("@address", contact.address));
            cmd.Parameters.Add(new SQLiteParameter("@email", contact.email));
            cmd.Parameters.Add(new SQLiteParameter("@oldEmail", oldEmail));


            cmd.ExecuteNonQuery();

            con.Close();


        }   

    }
}
