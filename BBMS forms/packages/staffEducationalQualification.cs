using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class staffEducationalQualification
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private string tableName = "staffEducationalQualification";

        public void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void newStaffEducationalQualification(string nic = "", string studies = "", string institute = "", string beginYear = "", string endYear = "", string lastExperiancePostition = "", string businessFirm = "", string experiance = "", string counting = "", string birthCertificateLink = "", string degreeCertificateLink = "", string nicFrontLink = "", string nicBackLink = "")
        {
            createConnection();
            command.CommandText = "insert into " + tableName + " values ('" + nic + "', '" + studies + "', '" + institute + "', '" + beginYear + "', '" + endYear + "', '" + lastExperiancePostition + "', '" + businessFirm + "', '" + experiance + "', '" + counting + "', '" + birthCertificateLink + "', '" + degreeCertificateLink + "', '" + nicFrontLink + "', '" + nicBackLink + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public void signUpEducationalStatusUpdate(string NIC, string birthcertificateLink = "", string degreeCertificateLink = "", string nicFrontLink = "", string nicBackLink = "")
        {
            createConnection();
            command.CommandText = "update staffeducationalqualification set birthCertificateLink = '" + birthcertificateLink + "', degreeCertificateLink = '" + degreeCertificateLink + "', nicFrontLink  = '" + nicFrontLink + "', nicBackLink  = '" + nicBackLink + "' where nic = '" + NIC + "'"; 
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
