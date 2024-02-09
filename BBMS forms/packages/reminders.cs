using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class reminders
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string tableName = "reminders";

        public void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void addNewReminder(string heading = "", string description = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string remMonth = "", string remYear = "", string remHour = "", string remMinute = "", string priorityLevel = "", string seenStatus = "", string addedBy = "")
        {
            createConnection();
            command.CommandText = "insert into " + tableName + " (heading, description, regDay, regMonth, regYear, regHour, regMinute, remMonth, remYear, remHour, remMinute, priorityLevel, seenStatus, addedBy) values ('" + heading + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + remMonth + "', '" + remYear + "', '" + remHour + "', '" + remMinute + "', '" + priorityLevel + "', '" + seenStatus + "', '" + addedBy + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public int unseenReminders()
        {
            createConnection();
            command.CommandText = "select * from " + tableName + " where seenStatus = notseen";
            int count = 0;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            connection.Close();
            return count;
        }

        public string getTheReminder()
        {
            createConnection();
            command.CommandText = "select * from " + tableName + " where seenStatus = notseen";
            int count = 0;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            connection.Close();
            return count;
        }
    }
}
