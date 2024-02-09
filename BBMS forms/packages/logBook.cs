using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class logBook
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

        public void newLogEntry(string staffID = "", string description = "", string createdDay = "", string createdMonth = "", string createdYear = "", string createdHour = "", string createdMinute = "")
        {
            createConnection();
            command.CommandText = "insert into logBook (staffID, description, createdDay, createdMonth, createdYear, createdHour, createdMinute) values ('" + staffID + "', '" + description + "', '" + createdDay + "', '" + createdMonth + "', '" + createdYear + "', '" + createdHour + "', '" + createdMinute + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
