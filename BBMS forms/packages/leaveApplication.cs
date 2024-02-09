using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class leaveApplication
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

        public void registerNewLeaveApplication(string userID = "", string Reason = "", string NIC = "", string regDay = "", string regMonth = "", string regyear = "", string wantedDay = "", string wantedMonth = "", string wantedYear = "", string leaveType = "", string dayOfPeriod = "", string status = "")
        {
            createConnection();
            command.CommandText = "insert into leaveApplication (userID, Reason, NIC, regDay, regMonth, regyear, wantedDay, wantedMonth, wantedYear, leaveType, dayOfPeriod, status) values ('" + userID + "', '" + Reason + "', '" + NIC + "', '" + regDay + "', '" + regMonth + "', '" + regyear + "', '" + wantedDay + "', '" + wantedMonth + "', '" + wantedYear + "', '" + leaveType + "', '" + dayOfPeriod + "', '" + status + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
