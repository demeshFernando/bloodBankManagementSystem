using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class bloodGroups
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

        public void bloodGroupRegistration(string bloodName = "", string description = "", string beginDay = "", string beginMonth = "", string beginYear = "")
        {
            createConnection();
            command.CommandText = "insert into bloodGroups  (bloodName, description, beginDay, beginMonth, beginYear) values ('" + bloodName + "', '" + description + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
