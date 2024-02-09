using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class dbdonorStatus
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

        public void donorStatus(string nic = "", string status = "", string description = "", string lastDonationDay = "", string lastDonationMonth = "", string lastDonationYear = "", string beginDay = "", string beginMonth = "", string beginYear = "", string regby = "", string lastEditedBy = "")
        {
            createConnection();
            command.CommandText = "insert into donorStatus values ('" + nic + "', '" + status + "', '" + description + "', '" + lastDonationDay + "', '" + lastDonationMonth + "', '" + lastDonationYear + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + regby + "', '" + lastEditedBy + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
