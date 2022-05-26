using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Text.RegularExpressions;

namespace CrimsonJ.Classes
{
    class Connection
    {
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataReader dr;
        private string temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CrimsonJ\\CrimsonJ.sqlite";

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
	                                appointmentId INTEGER PRIMARY KEY AUTOINCREMENT,
	                                entry TEXT,
	                                createdAt TEXT NOT NULL, 
	                                createdFor TEXT NOT NULL
                                );

                                CREATE TABLE IF NOT EXISTS Contacts (
	                                contactId INTEGER PRIMARY KEY AUTOINCREMENT,
	                                name TEXT NOT NULL,
	                                surname TEXT,
	                                address TEXT,
	                                gsm TEXT,
	                                email TEXT
                                );

                                CREATE TABLE IF NOT EXISTS Contain (
	                                appointmentId INTEGER,
	                                contactId INTEGER,
	                                PRIMARY KEY (appointmentId, contactId),
	                                CONSTRAINT fkAppointment
		                                FOREIGN KEY (appointmentId)
		                                REFERENCES Appointment(appointmentId),
	                                CONSTRAINT fkContact
		                                FOREIGN KEY (contactId)
		                                REFERENCES Contact(contactId)
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
        /// Gets the all appointment values from the appointment table.
        /// </summary>
        /// <param name="appointmentId"> appointment id</param>
        /// <returns></returns>
        public string GetFromAppointment(int appointmentId)
        {
            string sql = "SELECT entry FROM Appointment WHERE appointmnetId = @appointmentID;"; //404
            return sql  ; //404
        }

        /// <summary>
        /// Creates an appointment accordingly by the provided values
        /// </summary>
        /// <param name="entry"> appointment notes</param>
        /// <param name="createdAt"> creation date of appointment (today)</param>
        /// <param name="createdFor"> appointment date & time</param>
        public void InsertAppointment(string entry, DateTime createdAt, DateTime createdFor)
        {
            string sql = " INSERT INTO Appointment(entry, createdAt, createdFor) VALUES(@entry, @createdAt, createdFor);"; //404  
        }

        /// <summary>
        /// Postpones the appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="newDate"></param>
        public void ChangeDateAppointment(int appointmentId, DateTime newDate)
        {
            string date = newDate.ToShortDateString(); // convert date to string //404
            string sql = @"UPDATE Appointmnet SET createdFor = date WHERE appointmentID = @appointmentID;";  //404 
        }

        /// <summary>
        /// Changes the appointment entry.
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="newEntry"></param>
        public void ChangeEntryAppointment(int appointmentId, string newEntry)
        {
            string sql = @"UPDATE Appointment SET entry = @newEntry WHERE appointmentId = @appointmentID;"; // 404

            con.Open();
            cmd = new SQLiteCommand(sql, con);
            //cmd.Parameters.Add(new SQLiteParameter("@entry", newEntry)); // not sure about these 
            //cmd.Parameters.Add(new SQLiteParameter("@createdAt", date));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Inserts contact to the database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="address"></param>
        /// <param name="gsm"></param>
        /// <param name="email"></param>
        public void InsertContact(string name, string surname, string address, string gsm, string email)
        {
            string sql = "INSERT INTO Contacts (name, surname, address, gsm, email) VALUES (@name, @surname, @address, @gsm, @email);"; //404
        }

    }
}
