using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class bloodRequest
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

        public void requestNewBloodRequest(string name = "", string reqBy = "", string reqDay = "", string reqMonth = "", string reqYear = "", string wantDay = "", string wantMonth = "", string wantYear = "", string reason = "", string status = "", string statusUpdatedBy = "", string decReason = "")
        {
            createConnection();
            command.CommandText = "insert into bloodRequest (name, reqBy, reqDay, reqMonth, reqYear, wantDay, wantMonth, wantYear, reason, status, statusUpdatedBy, decReason) values ('" + name + "', '" + reqBy + "', '" + reqDay + "', '" + reqMonth + "', '" + reqYear + "', '" + wantDay + "', '" + wantMonth + "', '" + wantYear + "', '" + reason + "', '" + status + "', '" + statusUpdatedBy + "', '" + decReason + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
