using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class meetings
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

        public void arrangeNewMeeting(string regBy = "", string managerAcceptance = "", string PHIAcceptance = "", string nurseAcceptance = "", string doctorAcceptance = "", string heldingDay = "", string heldingMonth = "", string heldingYear = "", string heldingHour = "", string heldingMinute = "", string reqDay = "", string reqMonth = "", string reqYear = "", string reqHour = "", string reqMinute = "", string reason = "", string nurseApproval = "", string PHIApproval = "", string doctorApproval = "", string managerApproval = "", string campID = "")
        {
            createConnection();
            command.CommandText = "insert into meetings (regBy, managerAcceptance, PHIAcceptance, nurseAcceptance, nurseAcceptance, doctorAcceptance,  heldingDay, heldingMonth, heldingYear, heldingHour, heldingMinute, reqDay, reqMonth, reqYear, reqHour, reqMinute, reason, nurseApproval, PHIApproval, doctorApproval, managerApproval, campID) values ('" + regBy + "', '" + managerAcceptance + "', '" + PHIAcceptance + "', '" + nurseAcceptance + "', '" + doctorAcceptance + "', '" + heldingDay + "', '" + heldingMonth + "', '" + heldingYear + "', '" + heldingHour + "', '" + heldingMinute + "', '" + reqDay + "', '" + reqMonth + "', '" + reqYear + "', '" + reqHour + "', '" + reqMinute + "', '" + reason + "', '" + nurseApproval + "', '" + PHIApproval + "', '" + doctorApproval + "', '" + managerApproval + "', '" + campID + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
