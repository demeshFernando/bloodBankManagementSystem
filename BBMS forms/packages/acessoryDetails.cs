using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class acessoryDetails
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

        public void registerNewAcessoryDetails(string name = "", string contitiy = "", string sellerID = "", string description = "", string regby = "", string regDay = "", string regMonth = "", string expDay = "", string expMonth = "", string expYear = "")
        {
            createConnection();
            command.CommandText = "insert into acessoryDetails (name, contitiy, sellerID, description, regby, regDay, regMonth, expDay, expMonth, expYear) values ('" + name + "', '" + contitiy + "', '" + sellerID + "', '" + description + "', '" + regby + "', '" + regDay + "', '" + regMonth + "', '" + expDay + "', '" + expMonth + "', '" + expYear + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
