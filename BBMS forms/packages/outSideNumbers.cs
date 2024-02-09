using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class outSideNumbers
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

        public void newOutSideNumber(string phoneNumber = "", string NIC = "", string status = "")
        {
            createConnection();
            command.CommandText = "insert into outSideNumbers values ('" + phoneNumber + "', '" + NIC + "', '" + status + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
