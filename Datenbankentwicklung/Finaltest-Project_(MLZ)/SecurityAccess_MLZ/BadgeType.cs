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
    class BadgeType
    {
        public int BadgetypeId { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return String.Format($"ID:{BadgetypeId}) {Title}");
        }

        public static BindingList<BadgeType> SelectBadgeTypesFromDB()
        {
            using (SqlConnection connection = new SqlConnection(MainWindow.connectionString))
            {
                SqlCommand command = new SqlCommand(@"SELECT BadgetypId, Title FROM Badgetypen", connection);
                command.CommandType = CommandType.Text;
                command.Connection.Open();
                command.ExecuteNonQuery();

                BindingList<BadgeType> BadgeTypesList = new BindingList<BadgeType>();
                using (SqlDataReader sqlReader = command.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        BadgeTypesList.Add(new BadgeType()
                        {
                            BadgetypeId = int.Parse(sqlReader["BadgetypId"].ToString()),
                            Title = sqlReader["Title"].ToString()
                        });
                    }
                }

                return BadgeTypesList;
            }
        }
    }
}
