using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityAccess_MLZ
{
    class Doorlocksystem
    {
        public int ObjektId { get; set; }
        public string Statustyp { get; set; }
        public string Bezeichnung { get; set; }

        public override string ToString()
        {
            return String.Format($"ID:{ObjektId}) {Bezeichnung} ({Statustyp})");
        }

        public static BindingList<Doorlocksystem> SelectDoorsFromDB()
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand command = new SqlCommand(
                    @"SELECT tss.ObjektId, st.Title, tss.Bezeichnung
                    FROM Tuerschliesssysteme tss INNER JOIN Statustypen st ON tss.StatusId= st.StatusId", connection
                );
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                command.ExecuteNonQuery();

                BindingList<Doorlocksystem> DoorsList = new BindingList<Doorlocksystem>();
                using (SqlDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        DoorsList.Add(new Doorlocksystem()
                        {
                            ObjektId = Int32.Parse(sqlReader["ObjektId"].ToString()),
                            Statustyp = sqlReader["Title"].ToString(),
                            Bezeichnung = sqlReader["Bezeichnung"].ToString(),
                        });
                    }
                }

                return DoorsList;
            }
        }

        public static ValidationResponse checkBadgeAccess(int BadgeId, int ObjektId, string PINCode)
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand cmnd = new SqlCommand("dbo.pc_checkBadgeAccess", connection);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@BadgeId", SqlDbType.Int).Value = BadgeId;
                cmnd.Parameters.Add("@ObjektId", SqlDbType.Int).Value = ObjektId;
                cmnd.Parameters.Add("@PINCode", SqlDbType.VarChar, 6).Value = PINCode;
                cmnd.Parameters.Add("@Result", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmnd.Parameters.Add("@SysMessage", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                connection.Open();
                cmnd.ExecuteNonQuery();

                return new ValidationResponse()
                {
                    Successful = bool.Parse(cmnd.Parameters["@Result"].Value.ToString()),
                    Message = cmnd.Parameters["@SysMessage"].Value.ToString()
                };
            }
        }

        public static void openDoor(int ObjektId)
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand cmnd = new SqlCommand("dbo.openDoor", connection);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@ObjektId", SqlDbType.Int).Value = ObjektId;
                connection.Open();
                cmnd.ExecuteNonQuery();
            }
        }

        public static void closeDoor(int ObjektId)
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand cmnd = new SqlCommand("dbo.closeDoor", connection);
                cmnd.CommandType = CommandType.StoredProcedure;

                cmnd.Parameters.Add("@ObjektId", SqlDbType.Int).Value = ObjektId;
                connection.Open();
                cmnd.ExecuteNonQuery();
            }
        }
    }
}
