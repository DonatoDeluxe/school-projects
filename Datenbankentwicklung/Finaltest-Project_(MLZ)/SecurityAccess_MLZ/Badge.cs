using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecurityAccess_MLZ
{
    public class Badge
    {
        public int BadgeId { get; set; }
        public string Badgetyp { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime GueltigBis { get; set; }
        public string PINCode { get; set; }
        public int ErrorCounter { get; set; }

        public override string ToString()
        {
            return String.Format($"ID:{BadgeId}) {Badgetyp}-Benutzer: {Vorname} {Nachname} (PIN-{PINCode})");
        }

        public static BindingList<Badge> SelectBadgesFromDB()
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand command = new SqlCommand(
                    @"SELECT b.BadgeId, bt.Title, b.Vorname, b.Nachname, b.GueltigBis, b.PINCode, b.ErrorCounter
                    FROM Badge b INNER JOIN Badgetypen bt ON b.BadgetypId = bt.BadgetypId", connection
                );
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                command.ExecuteNonQuery();

                BindingList<Badge> BadgesList = new BindingList<Badge>();
                using (SqlDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        BadgesList.Add(new Badge()
                        {
                            BadgeId = Int32.Parse(sqlReader["BadgeId"].ToString()),
                            Badgetyp = sqlReader["Title"].ToString(),
                            Vorname = sqlReader["Vorname"].ToString(),
                            Nachname = sqlReader["Nachname"].ToString(),
                            GueltigBis = DateTime.Parse(sqlReader["GueltigBis"].ToString()),
                            PINCode = sqlReader["PINCode"].ToString(),
                            ErrorCounter = Int32.Parse(sqlReader["ErrorCounter"].ToString()),
                        });
                    }
                }

                return BadgesList;
            }
        }

        public static int CreateBadgeInDB(int BadgetypId, string Vorname, string Nachname, DateTime GueltigBis, string PINCode)
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand cmnd = new SqlCommand("dbo.createBadge", connection);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@BadgetypId", SqlDbType.Int).Value = BadgetypId;
                cmnd.Parameters.Add("@Vorname", SqlDbType.VarChar).Value = Vorname;
                cmnd.Parameters.Add("@Nachname", SqlDbType.VarChar, 6).Value = Nachname;
                cmnd.Parameters.Add("@GueltigBis", SqlDbType.Date).Value = GueltigBis;
                cmnd.Parameters.Add("@PINCode", SqlDbType.VarChar, 6).Value = PINCode;
                cmnd.Parameters.Add("@BadgeId", SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                connection.Open();
                cmnd.ExecuteNonQuery();

                return int.Parse(cmnd.Parameters["@BadgeId"].Value.ToString());
            }
        }

        public static void CreateBadgeDoorRelationsInDB(int BadgeId, string IDsString)
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand cmnd = new SqlCommand("dbo.createBadgeDoorRelations", connection);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@BadgeId", SqlDbType.Int).Value = BadgeId;
                cmnd.Parameters.Add("@IDsString", SqlDbType.VarChar).Value = IDsString.Replace(" ", "");
                cmnd.Parameters.Add("@ErrorCode", SqlDbType.Int, 100).Direction = ParameterDirection.Output;
                connection.Open();
                cmnd.ExecuteNonQuery();

                Console.WriteLine(int.Parse(cmnd.Parameters["@ErrorCode"].Value.ToString()));
                switch (int.Parse(cmnd.Parameters["@ErrorCode"].Value.ToString()))
                {
                    case 0:
                        MessageBox.Show("Badge wurde erstellt.");
                        break;
                    case 1:
                        MessageBox.Show("Es ist leider ein Fehler aufgetreten. Versuchen Sie es noch einmal.");
                        break;

                }
            }
        }
    }
}
