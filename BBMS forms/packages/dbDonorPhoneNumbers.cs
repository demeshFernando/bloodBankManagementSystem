using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class dbDonorPhoneNumbers
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

        public void donorPhoneNumber(string phoneNumber = "", string nic = "")
        {
            createConnection();
            command.CommandText = "insert into donorPhoneNumbers values ('" + phoneNumber + "', '" + nic + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
