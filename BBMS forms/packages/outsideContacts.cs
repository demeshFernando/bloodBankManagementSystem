using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class outsideContacts
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

        public void newOutSideContacts(string NIC = "", string name = "", string reason = "", string company = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeLand = "")
        {
            createConnection();
            command.CommandText = "insert into outsideContacts values ('" + NIC + "', '" + name + "', '" + reason + "', '" + company + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
