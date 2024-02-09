using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class bloodLog
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void registerNewBloodLog(string name = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string regBy = "", string packetOwner = "", string donDay = "", string donMonth = "", string donYear = "", string donHour = "", string donMinute = "", string campID = "", string takenBy = "", string packetID = "", string city = "", string resDay = "", string resMonth = "", string resYear = "")
        {
            createConnection();
            command.CommandText = "insert into bloodLog (name, regDay, regMonth, regYear, regHour, regMinute, regBy, packetOwner, donDay, donMonth, donYear, donHour, donMinute, campID, takenBy, packetID, city, resDay, resMonth, resYear) values ('" + name + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + regBy + "', '" + packetOwner + "', '" + donDay + "', '" + donMonth + "', '" + donYear + "', '" + donHour + "', '" + donMinute + "', '" + campID + "', '" + takenBy + "', '" + packetID + "', '" + city + "', '" + resDay + "', '" + resMonth + "', '" + resYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
