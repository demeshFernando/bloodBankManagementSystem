using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class donorDiseaceRates
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

        public void newdiseacerate(string nic = "", string currentstatus = "", string beginDay = "", string beginMonth = "", string beginYear = "", string endday = "", string endMonth = "", string endyear = "")
        {
            createConnection();
            command.CommandText = "insert into donorDiseaceRates (NIC, currentStatus, beginDay, beginMonth, beginYear, endDay, endMonth, endYear) values ('" + nic + "', '" + currentstatus + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + endday + "', '" + endMonth + "', '" + endyear + "'";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
