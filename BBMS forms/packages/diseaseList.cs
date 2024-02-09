using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class diseaseList
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

        public void newDicease(string diseaceName = "", string description = "", string registeredDay = "", string registeredMonth = "", string registeredYear = "")
        {
            createConnection();
            command.CommandText = "insert into diseaseList  (diseaceName, description, registeredDay, registeredMonth, registeredYear) values ('" + diseaceName + "', '" + description + "', '" + registeredDay + "', '" + registeredMonth + "', '" + registeredYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
