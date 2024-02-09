using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class medicineDetails
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

        public void addNewMedicine(string name = "", string description = "", string regDay = "", string regMonth = "", string regYear = "")
        {
            createConnection();
            command.CommandText = "insert into medicineDetails  (name, description, regDay, regMonth, regYear) values ('" + name + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
