using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class staffList
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string tableName = "staffList";

        public void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void registerNewStaff(string NIC = "", string firstName = "", string lastName = "", string otherName = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeLand = "", string gender = "", string email = "", string beginDay = "", string beginMonth = "", string beginYear = "", string position = "", string employeeLevel = "", string applicableLeaves = "", string accountActivation = "")
        {
            createConnection();
            command.CommandText = "insert into " + tableName + " values ('" + NIC + "', '" + firstName + "', '" + lastName + "', '" + otherName + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "', '" + gender + "', '" + email + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + position + "', '" + employeeLevel + "', '" + applicableLeaves + "', '" + accountActivation + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public void updateStaffListforProfessionalDetails(string NIC, string position = "", string email = "")
        {
            createConnection();
            command.CommandText = "update " + tableName + " set position = '" + position + "', email = '" + email + "' where nic = '" + NIC + "'";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public string getActivationDetails(string NIC)
        {
            createConnection();
            command.CommandText = "select * from " + tableName + "where NIC = '" + NIC + "'";
            int count = 0;
            string status = "";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                status = reader.GetString("accountActivation");
            }
            connection.Close();
            if(count == 1)
            {
                return status;
            }
            else if(count == 0)
            {
                return "not_found";
            }
            else
            {
                return "many_found";
            }
        }

        public string getPosition(string NIC)
        {
            createConnection();
            command.CommandText = "select * from " + tableName + "where NIC = '" + NIC + "'";
            int count = 0;
            string position = "";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
                position = reader.GetString("position");
            }
            connection.Close();
            if (count == 1)
            {
                return position;
            }
            else if (count == 0)
            {
                return "not_found";
            }
            else
            {
                return "many_found";
            }
        }
    }
}
