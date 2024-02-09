using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class staffCredentials
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

        public bool newCredential(string username = "", string password = "", string NIC = "")
        {
            if (checkUserName(username))
            {
                createConnection();
                command.CommandText = "insert into staffCredentials values ('" + username + "', '" + password + "', '" + NIC + "')";
                connection.Open();
                reader = command.ExecuteReader();
                connection.Close();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string credentialMatching(string username, string password)
        {
            int count = 0;
            string NIC = "";
            createConnection();
            command.CommandText = "select * from staffCredentials where username = '" + username + "'and password = '" + password + "'";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                NIC = reader.GetString("nic");
            }
            connection.Close();
            if(count == 1)
            {
                return NIC;
            }
            else if(count == 0)
            {
                return "no";
            }
            else
            {
                return "duplicates";
            }
        }

        private bool checkUserName(string username)
        {
            createConnection();
            command.CommandText = "select * from staffCredentials where username = '" + username + "'";
            int count = 0;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            connection.Close();
            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
