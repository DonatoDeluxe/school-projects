using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_2_1
{
    public class PersonDataAdapter
    {
        public string ConnectionString { get; set; }

        public void NewPerson(Person pers)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = GetInsertPersonCommand(pers);
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteScalar();
            }
        }

        public void UpdatePerson(Person pers)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = GetUpdatePersonCommand(pers);
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteScalar();
            }
        }

        public void DeletePerson(Person pers)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = GetDeletePersonCommand(pers.Id);
                conn.Open();
                cmd.Connection = conn;
                cmd.ExecuteScalar();
            }
        }

        public List<Person> SearchPerson(string name)
        {
            List<Person> personList = new List<Person>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string selectStr = @"SELECT Id, Name, Vorname, Strasse, PLZ, Ort, Telefon FROM Persons WHERE Name Like @Name";
                SqlCommand cmd = new SqlCommand(selectStr, conn);
                cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                conn.Open();
                SqlDataReader dbReader = cmd.ExecuteReader();

                while (dbReader.Read())
                {
                    Person pers = new Person();
                    pers.Id = Int32.Parse(dbReader[0].ToString());
                    pers.Lastname = dbReader["Name"].ToString();
                    pers.Firstame = dbReader["Vorname"].ToString();
                    pers.Street = dbReader["Strasse"].ToString();
                    pers.PLZ = dbReader["PLZ"].ToString();
                    pers.City = dbReader["Ort"].ToString();
                    personList.Add(pers);
                }
            }
            return personList;
        }

        private SqlCommand GetPersonCommand(Person pers, string cmdStr)
        {
            SqlCommand cmd = new SqlCommand(cmdStr);
            cmd.Parameters.AddWithValue("@Name", pers.Lastname);
            cmd.Parameters.AddWithValue("@Vorname", pers.Firstame);
            cmd.Parameters.AddWithValue("@Strasse", pers.Street);
            cmd.Parameters.AddWithValue("@PLZ", pers.PLZ);
            cmd.Parameters.AddWithValue("@Ort", pers.City);
            if(cmdStr.Contains("@Id"))
                cmd.Parameters.AddWithValue("@Id", pers.Id);

            return cmd;
        }

        private SqlCommand GetInsertPersonCommand(Person pers)
        {
            string insertStr = @"INSERT INTO Persons (Name, Vorname, Strasse, PLZ, Ort) VALUES (@Name, @Voname, @Strasse, @PLZ, @Ort)";
            SqlCommand cmd = GetPersonCommand(pers, insertStr);
            return cmd;
        }

        private SqlCommand GetUpdatePersonCommand(Person pers)
        {
            string updateStr = @"UPDATE Persons SET Name=@Name, Vorname=@Vorname, Strasse=@Strasse, PLZ=@PLZ, Ort=@Ort WHERE Id=@Id";
            SqlCommand cmd = GetPersonCommand(pers, updateStr);
            return cmd;
        }

        private SqlCommand GetDeletePersonCommand(int persId)
        {
            string deleteStr = @"DELETE FROM Persons WHERE Id=@Id";
            SqlCommand cmd = new SqlCommand(deleteStr);
            cmd.Parameters.AddWithValue("@Id", persId);
            return cmd;
        }
    }
}
