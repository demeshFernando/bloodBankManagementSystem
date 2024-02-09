using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class bloodCamps
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

        public void newBloodCamp(string reqName = "", string heading = "", string description = "", string expectedDonors = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string expectingDay = "", string expectingMonth = "", string expectingYear = "", string expectingHour = "", string expectedMinute = "", string meetingArrangements = "", string approvalStatus = "")
        {
            createConnection();
            command.CommandText = "insert into bloodCamps (reqName, heading, description, expectedDonors, regDay, regMonth, regYear, regHour, regMinute, expectingDay, expectingMonth, expectingYear, expectingHour, expectedMinute, meetingArrangements, approvalStatus) values ('" + reqName + "', '" + heading + "', '" + description + "', '" + expectedDonors + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + expectingDay + "', '" + expectingMonth + "', '" + expectingYear + "', '" + expectingHour + "', '" + expectedMinute + "', '" + meetingArrangements + "', '" + approvalStatus + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
