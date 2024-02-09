using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class donorRelativeDetails
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

        public void donorRelative(string relativeName = "", string nic = "", string phoneNumber = "")
        {
            createConnection();
            command.CommandText = "insert into donorRelativeDetails values ('" + relativeName + "', '" + nic + "', '" + phoneNumber + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
