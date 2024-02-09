using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class prescribedMedicine
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

        public void newMedicine(string medicineID = "", string NIC = "", string description = "", string regDay = "", string regMonth = "", string regyear = "")
        {
            createConnection();
            command.CommandText = "insert into prescribedMedicine values ('" + medicineID + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regyear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
