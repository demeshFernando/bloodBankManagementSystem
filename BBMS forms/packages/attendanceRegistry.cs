using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class attendanceRegistry
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

        public void markAttendance(string NIC = "", string day = "", string month = "", string year = "", string hour = "", string minute = "", string regDay = "", string regMonth = "", string regYear = "")
        {
            createConnection();
            command.CommandText = "insert into attendanceRegistry (ID, NIC, day, month, year, hour, minute, regDay, regMonth, regYear) values ('" + NIC + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
