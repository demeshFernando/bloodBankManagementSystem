using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class messages
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

        public void newMessage(string message = "", string to = "", string from = "", string status = "", string sentDay = "", string sentMonth = "", string sentYear = "", string sentHour = "", string sentMinute = "", string recievedDay = "", string recievedMonth = "", string recievedYear = "", string recievedHour = "", string recievedMinute = "", string replyID = "")
        {
            createConnection();
            command.CommandText = "insert into messages (message, sendingTo, recievedFrom, status, sentDay, sentMonth, sentYear, sentHour, sentMinute, recievedDay, recievedMonth, recievedYear, recievedHour, recievedMinute, replyID) values ('" + message + "', '" + to + "', '" + from + "', '" + status + "', '" + sentDay + "', '" + sentMonth + "', '" + sentYear + "', '" + sentHour + "', '" + sentMinute + "', '" + recievedDay + "', '" + recievedMonth + "', '" + recievedYear + "', '" + recievedHour + "', '" + recievedMinute + "', '" + replyID + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
