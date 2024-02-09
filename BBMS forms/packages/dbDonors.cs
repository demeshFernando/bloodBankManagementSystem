using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class dbDonors
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

        public void registerDonor(string nic = "", string firstName = "", string lastname = "", string othernames = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeland = "", string gender = "", string email = "", string beginDay = "", string beginMonth = "", string beginyear = "", string bloodgroup = "")
        {
            createConnection();
            command.CommandText = "insert into donors values ('" + nic + "', '" + firstName + "', '" + lastname + "', '" + othernames + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeland + "', '" + gender + "', '" + email + "', '" + beginDay + "', '" + beginMonth + "', '" + beginyear + "', '" + bloodgroup + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public void cardStatus(string nic, string status)
        {
            createConnection();
            command.CommandText = "update donors set cardStatus = '" + status + "' where = '" + nic + "'";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
