using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BBMS_forms.packages
{
    class DBManipulation
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private MySqlCommand command;

        private int year = int.Parse(DateTime.Now.ToString("yyyy"));
        private int month = int.Parse(DateTime.Now.ToString("MM"));
        private int day = int.Parse(DateTime.Now.ToString("dd"));
        private int hour = int.Parse(DateTime.Now.ToString("hh"));
        private int minute = int.Parse(DateTime.Now.ToString("mm"));
        private string period = DateTime.Now.ToString("tt");

        public static CRUD createConnection(string connection)
        {
            return new dbDonors();
        }

        private void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
        }

        public void createLog(string message, string ownerID)
        {
            string hour = DateTime.Now.ToString("hh");
            string minute = DateTime.Now.ToString("mm");
            createConnection();
            string query = "insert into logbook values ('" + getID("logbook") + "', '" + ownerID + "', '" + message + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + period + "')";
            command = new MySqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public void insertIntoDb(string tableName, string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8, string text9, string text10, string text11, string text12, string text13, string text14, string text15, string text16, string text17, string text18, string text19, string text20, string text21)
        {
            string query = "";

            if(tableName == "donors")
            {
                //NIC - <int> - <primary key> | firstName - <varchar(15)> | lastName - <varchar(15)> | otherName <varchar(15)> | line1 - <varchar(15)> | line2 - <varchar(15)> | line3 - <varchar(15)> | city - <varchar(15)> | homeLand - <varchar(20)> | gender - <varchar(7) | email - <varchar(100)> | beginDay <int> | beginMonth <int> | beginYear <int> | bloodGroup <varchar(15)>
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + text2 + "', '" + text3 + "', '" + text4 + "', '" + text5 + "', '" + text6 + "', '" + text7 + "', '" + text8 + "', '" + text9 + "', '" + text10 + "', '" + text11 + "', '" + day + "', '" + month + "', '" + year + "', '" + text12 + "')";
            }
            else if (tableName == "donorphonenumbers")
            {
                //phoneNumber<int> < primary key > | NIC<int> < foreign key >
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "')";
            }
            else if (tableName == "donorstatus")
            {
                //NIC <int> <primary key> | status <varchar(10) | description <varchar(100)> | lastDonationDay <int> | lastDonationMonth <int> | lastDonationYear <int> | beginDay <int> | beginMonth <int> | beginYear <int> | regby <int>
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + text2 + "', '" + text3 + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + text7 + "', '" + day + "', '" + month + "', '" + year + "', '" + int.Parse(text8) + "')";
            }
            else if (tableName == "donordiseacerates")
            {
                //diseaceID <int> | NIC <int> | currentStatus <varchar(20)> | beginDay <int> | beginMonth <int> | beginYear <int> | endDay <int> | endMonth<int> | endYear <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + text2 + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "'";
            }
            else if (tableName == "donorrelativedetails")
            {
                //relativeName <varchar(20)> | NIC <int> | phoneNumber <int>
                query = "insert into " + tableName + " values ('" + text1 + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "'";
            }
            else if (tableName == "bloodgroups")
            {
                //bloodID <int> <primary key> | bloodName <varchar(100)> | description <varchar(200)> | beginDay <int> | beginMonth <int> | beginYear <int> | availableContities <int> | measurement <varchar(10)> 
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + text2 + "', '" + day + "', '" + month + "', '" + year + "', '" + int.Parse(text3) + "', '" + text4 + "'";
            }
            else if (tableName == "medicinedetails")
            {
                //ID <int> <primary key> | name <varchar(100)> | description <varchar(100)> | regDay <int> | regMonth <int> | regYear <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + text2 + "', '" + day + "', '" + month + "', '" + year + "'";
            }
            else if (tableName == "prescribedmedicine")
            {
                //medicineID <int> | NIC <int> | description <varchar(100)> | regDay <int> | regMonth <int> | regyear <int>
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + int.Parse(text2) + "', '" + text3 + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "'";
            }
            else if (tableName == "prescribedmedicine")
            {
                //medicineID <int> | NIC <int> | description <varchar(100)> | regDay <int> | regMonth <int> | regyear <int>
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + int.Parse(text2) + "', '" + text3 + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "'";
            }
            else if (tableName == "stafflist")
            {
                //ID - <int> - <primary key> | NIC <int> | firstName - <varchar(15)> | lastName - <varchar(15)> | otherName <varchar(15)> | line1 - <varchar(15)> | line2 - <varchar(15)> | line3 - <varchar(15)> | city - <varchar(15)> | homeLand - <varchar(20)> | gender - <varchar(7) | email - <varchar(100)> | beginDay <int> | beginMonth <int> | beginYear <int> | position <varchar(50)> | employeeLevel <varchar(10)> | applicableLeaves <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + text2 + "', '" + text3 + "', '" + text4 + "', '" + text5 + "', '" + text6 + "', '" + text7 + "', '" + text8 + "', '" + text9 + "', '" + text10 + "', '" + text11 + "', '" + day + "', '" + month + "', '" + year + "', '" + text12 + "', '" + text13 + "', , '" + text14 + "', '" + text15 + "'";
            }

            else if (tableName == "messages")
            {
                //ID <int> <primary key> | message <varchar(400)> | to <int> | from <int> | status <varchar(10)> | sentDay <int> | sentMonth <int> | sentYear <int> | sentHour <int> | sentMinute <int> | recievedDay <int> | recievedMonth <int> | recievedDay <int> | recievedHour <int> | recievedMinute <int> | replyID <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "', '" + text4 + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + 00 + "', '" + 00 + "', '" + 0000 + "', '" + 00 + "', '" + 00 + "', '" + int.Parse(text5) + "')";
            }
            else if (tableName == "attendanceregistry")
            {
                //ID <int> <primary key> | NIC <int> | day <int> | month <int> | year <int> | hour <int> | minute <int> | regDay <int> | regMonth <int> | regYear <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "')";
            }
            else if (tableName == "bloodcamps")
            {
                //id <int> <primary key> | reqName <varchar(40)> | heading <varchar(50)> | description <varchar(50)> | expectedDonors <int> | regDay <int> | regMonth <int> | regYear <int> | regHour <int> | regMinute <int> | expectingDay <int> | expectingMonth <int> | expectingYear <int> | expectingHour<int> | expectingMinute<int> | meetingArrangement <varchar(20) | approvalStatus <varchar(10)> 
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + text2 + "', '" + text3 + "', '" + int.Parse(text4) + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "', '" + int.Parse(text9) + "', '" + text10 + "', '" + text11 + "')";
            }

            else if (tableName == "leaveapplication")
            {
                //id <int> <primary key> | userID <int> <foreign key> | Reason <varchar(50)> | regDay <int> | regMonth <int> | regyear <int> | wantedDay <int> | wantedMonth <int> | wantedYear <int> | leaveType <varchar(10)> | dayOfPeriod <varchar(10)>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + text2 + "', '" + day + "', '" + month + "', '" + year + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + text6 + "', '" + text7 + "')";
            }
            else if (tableName == "meetings")
            {
                //id <int> <primary key> | regBy <int> | managerAcceptance <int> | PHIAcceptance <int> | nurseAcceptance <int> | doctorAcceptance <int> | heldingDay <int> | heldingMonth <int> | heldingYear <int> | heldingHour <int> | heldingMinute <int> | reqDay <int> | reqMonth <int> | reqYear <int> | reqHour <int> | reqMinute <int> | reason <varchar(50)> | nurseApproval <varchar(10)> | PHIApproval <varchar(10)> | doctorApproval <varchar(10)> | managerApproval <varchar(10)> | campID <int>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "', '" + int.Parse(text9) + "', '" + int.Parse(text10) + "', '" + int.Parse(text11) + "', '" + int.Parse(text12) + "', '" + int.Parse(text13) + "', '" + int.Parse(text14) + "', '" + int.Parse(text15) + "', '" + text16 + "', '" + text17 + "', '" + text18 + "', '" + text19 + "', '" + int.Parse(text20) + "')";
            }
            else if (tableName == "reminders")
            {
                //id <int> <primary key> | heading <varchar(10)> | description <varchar(50)> | regDay <int> | regMonth <int> | regYear <int> | regHour <int> | regMinute <int> | remDay <int> | remMonth <int> | remYear <int> | remHour <int> | remMinute <int> | priorityLevel <int> | seenStatus <varchar(10)>
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + text2 + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "', '" + text9 + "', '" + int.Parse(text8) + "')";
            }
            else if (tableName == "outsidecontacts")
            {
                //id <int> <primary key> | NIC <int> | reason <varchar(10)> | company <varchar(10)> | line1 <varchar(10)> | line2 <varchar(10)> | line3 <varchar(10)> | city <varchar(10)> | homeLand <varchar(10)> |
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + int.Parse(text1) + "', '" + text2 + "', '" + text13 + "', '" + text4 + "', '" + text5 + "', '" + text6 + "', '" + text7 + "', '" + text8 + "', '" + text9 + "')";
            }
            else if (tableName == "outSidenumbers")
            {
                //phoneNumber <int> <primary key> | NIC <int> | status <varchar(10)>
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + int.Parse(text2) + "', '" + text3 + "')";
            }
            else if (tableName == "bloodLog")
            {
                //id <int> <primary key> | name <varchar(10)> | regDay <int> | regMonth <int> | regYear <int> | regHour <int> | regMinute <int> | regBy <int> | packetOwner <int> | donDay <int> | donMonth <int> | donYear <int> | donHour <int> | donMinute <int> | campID <int> | takenBy <int> | 
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "', '" + int.Parse(text9) + "', '" + int.Parse(text10) + "', '" + int.Parse(text11) + "', '" + text12 + "', '" + int.Parse(text13) + "', '" + int.Parse(text14) + "', '" + int.Parse(text15) + "')";
            }
            else if (tableName == "bloodrequest")
            {
                //id<int> < primary key > | name < varchar(10) > | reqBy < varchar(10) > | reqDay<int> | reqMonth<int> | reqYear<Int> | wantDay<int> | wantMonth<int> | wantYear<int> | reason < varchar(50) > | status < varchar(10) > | statusUpdatedBy<int> | decReason < varchar(10) >
                query = "insert into " + tableName + " values ('" + getID(tableName) + "', '" + text1 + "', '" + text2 + "', '" + day + "', '" + month + "', '" + year + "', '" + int.Parse(text3) + "', '" + int.Parse(text4) + "', '" + int.Parse(text5) + "', '" + text6 + "', '" + int.Parse(text7) + "', '" + text8 + "', '" + text9 + "')";
            }
            else if (tableName == "acessorydetails")
            {
                //id <int> <primary key> | name <varchar(50)> | contitiy <int> | sellerID <int> <foreign key> | description <varchar(50)> | regby <int> <foreign key> | regDay <int> | regMonth <int> | regYear <int> | expDay <int> | expMonth <int> | expYear <int> 
                query = "insert into " + tableName + " values ('" + int.Parse(text1) + "', '" + text1 + "', '" + int.Parse(text2) + "', '" + int.Parse(text3) + "', '" + text4 + "', '" + int.Parse(text5) + "', '" + day + "', '" + month + "', '" + year + "', '" + int.Parse(text6) + "', '" + int.Parse(text7) + "', '" + int.Parse(text8) + "')";
            }
            else if(tableName == "staffcredentials")
            {
                //username <varchar(100)> <primary key> | password <varchar(100)> | NIC <int> <foreign key> |
                query = "insert into " + tableName + " values ('" + text1 + "', '" + text2 + "', '" + int.Parse(text3) + "')";
            }
            command = new MySqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }

        public string getEntry(string tableName, string requestingField, string fieldName, string fieldEntry, string requestingFieldName)
        {
            string entry = "";
            string query = "select * from " + tableName + " where " + fieldName + " = " + fieldEntry;
            createConnection();
            command = new MySqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                entry = reader.GetString(requestingFieldName);
            }
            connection.Close();
            
            return entry;
        }

        public int getID(string tableName)
        {
            int count = 0;
            createConnection();
            string query = "select * from " + tableName;
            command = new MySqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                count++;
            }
            connection.Close();
            return count + 1;
        }

        public bool checkStaffActivation(string NIC)
        {
            string status = "";
            createConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from stafflist where id = '" + NIC + "'";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                status = reader.GetString("accountActivation");
            }
            connection.Close();

            if(status == "active")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string checkStaffAvailability(string username, string password)
        {
            bool isAvailable;
            int count = 0;
            string NIC = "";
            createConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from staffCredentials where username = '" + username + "'and password = '" + password + "'";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                NIC = reader.GetString("nic");
                count++;
            }
            connection.Close();

            if(count == 1)
            {
                return NIC;
            }
            else
            {
                return null;
            }
        }

        public string getStaffPosition(string NIC)
        {
            string position = "";
            createConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from staffList where nic = '" + NIC + "'";
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                position = reader.GetString("position");
            }
            connection.Close();
            return position;
        }

        public void markAttendance(string nic)
        {
            createConnection();
            command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into attendanceregistry values ('" + getID("attendanceregistry") + "', '" + nic + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + day + "', '" + month + "', '" + year + "')";
            connection.Open();
            reader = command.ExecuteReader();
            connection.Close();
        }
    }
}
