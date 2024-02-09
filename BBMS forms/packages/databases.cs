using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace BBMS_forms.packages
{
    class databases
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public string callInsertionConnection(string value)
        {
            generalProcesses processes = new generalProcesses();
            return processes.Encrypt(value);
        }

        public string callReturnConnection(string value)
        {
            generalProcesses processes = new generalProcesses();
            return processes.Decrypt(value);
        }

        public void createConnection()
        {
            connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            command = new MySqlCommand();
            command.Connection = connection;
        }

        public void swapListsValues(List<string> stringList, int index1, int index2)
        {
            string temp = stringList[index1];
            stringList[index1] = stringList[index2];
            stringList[index2] = temp;
        }

        //database donors
        public class Donors
        {
            databases db = new databases();
            private string tableName = "donors";

            private string nic = "NIC";
            private string firstName = "firstName";
            private string lastName = "lastName";
            private string otherName = "otherName";
            private string line1 = "line1";
            private string line2 = "line2";
            private string line3 = "line3";
            private string city = "city";
            private string homeLand = "homeLand";
            private string gender = "gender";
            private string email = "email";
            private string beginDay = "beginDay";
            private string beginMonth = "beginMonth";
            private string beginYear = "beginYear";
            private string bloodGroup = "bloodGroup";

            public void registerDonor(string nic = "", string firstName = "", string lastname = "", string othernames = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeland = "", string gender = "", string email = "", string beginDay = "", string beginMonth = "", string beginyear = "", string bloodgroup = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + nic + "', '" + firstName + "', '" + lastname + "', '" + othernames + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeland + "', '" + gender + "', '" + email + "', '" + beginDay + "', '" + beginMonth + "', '" + beginyear + "', '" + bloodgroup + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public bool checkID(string id)
            {
                //creating the bool to check
                bool isIDAvailable = false;
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.nic + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if(count == 1)
                {
                    isIDAvailable = true;
                }

                //returning the id
                return isIDAvailable;
            }

            public bool checkName(string name)
            {
                //creating the bool to check
                bool isNameAvailable = false;
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.firstName + " = '" + db.callInsertionConnection(name) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if (count == 1)
                {
                    isNameAvailable = true;
                }

                //returning the id
                return isNameAvailable;
            }

            public string getID(string name)
            {
                //creating the bool to check
                string ID = "";
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.firstName + " = '" + db.callInsertionConnection(name) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    ID = db.callReturnConnection(db.reader.GetString(this.nic));
                }
                db.connection.Close();

                //returning the id
                return ID;
            }

            public string getEntry(string nic, int returningIndex)
            {
                string entry = "";

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.nic + " = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (returningIndex)
                    {
                        case 0:
                            entry = db.callReturnConnection(db.reader.GetString(this.firstName));
                            break;
                        case 1:
                            entry = db.callReturnConnection(db.reader.GetString(this.lastName));
                            break;
                        case 2:
                            entry = db.callReturnConnection(db.reader.GetString(this.otherName));
                            break;
                        case 3:
                            entry = db.callReturnConnection(db.reader.GetString(this.line1));
                            break;
                        case 4:
                            entry = db.callReturnConnection(db.reader.GetString(this.line2));
                            break;
                        case 5:
                            entry = db.callReturnConnection(db.reader.GetString(this.line3));
                            break;
                        case 6:
                            entry = db.callReturnConnection(db.reader.GetString(this.city));
                            break;
                        case 7:
                            entry = db.callReturnConnection(db.reader.GetString(this.homeLand));
                            break;
                        case 8:
                            entry = db.callReturnConnection(db.reader.GetString(this.gender));
                            break;
                        case 9:
                            entry = db.callReturnConnection(db.reader.GetString(this.email));
                            break;
                        case 10:
                            entry = db.callReturnConnection(db.reader.GetString(this.beginDay));
                            break;
                        case 11:
                            entry = db.callReturnConnection(db.reader.GetString(this.beginMonth));
                            break;
                        case 12:
                            entry = db.callReturnConnection(db.reader.GetString(this.beginYear));
                            break;
                        case 13:
                            entry = db.callReturnConnection(db.reader.GetString(this.bloodGroup));
                            break;
                        default:
                            entry = db.callReturnConnection(db.reader.GetString(this.firstName));
                            break;
                    }
                }
                db.connection.Close();

                return entry;
            }
        }

        //database donorPhoneNumbers
        public class DonorPhoneNumbers
        {
            private string tableName = "donorPhoneNumbers";
            databases db = new databases();

            private string phoneNumber = "phoneNumber";
            private string nic = "NIC";

            public void donorPhoneNumber(string phoneNumber = "", string nic = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + phoneNumber + "', '" + nic + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<string> getPhoneNumber(string id)
            {
                List<string> phoneNumbers = new List<string>();

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.nic + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    phoneNumbers.Add(db.callReturnConnection(db.reader.GetString(this.phoneNumber)));
                }
                db.connection.Close();

                return phoneNumbers;
            }

            public bool entryCheckout(string nic, string phoneNumber)
            {
                bool isAvailable = false;
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.nic + " = '" + db.callInsertionConnection(nic) + "' and " + this.phoneNumber + " = '" + db.callInsertionConnection(phoneNumber) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if(count == 1)
                {
                    isAvailable = true;
                }

                return isAvailable;
            }
        }

        //database donorStatus
        public class DonorStatus
        {
            private string tableName = "donorStatus";
            databases db = new databases();

            public void donorStatus(string nic = "", string status = "", string description = "", string lastDonationDay = "", string lastDonationMonth = "", string lastDonationYear = "", string beginDay = "", string beginMonth = "", string beginYear = "", string regby = "", string lastEditedBy = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + nic + "', '" + status + "', '" + description + "', '" + lastDonationDay + "', '" + lastDonationMonth + "', '" + lastDonationYear + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + regby + "', '" + lastEditedBy + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void cardStatus(string nic, string status)
            {
                db.createConnection();
                db.command.CommandText = "update " + tableName + " set cardStatus = '" + status + "' where = '" + nic + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database donorDiseaceRates
        public class DonorDiseaceRates
        {
            private string tableName = "donorDiseaceRates";
            databases db = new databases();

            public void newdiseacerate(string nic = "", string currentstatus = "", string beginDay = "", string beginMonth = "", string beginYear = "", string endday = "", string endMonth = "", string endyear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + "(NIC, currentStatus, beginDay, beginMonth, beginYear, endDay, endMonth, endYear) values ('" + nic + "', '" + currentstatus + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + endday + "', '" + endMonth + "', '" + endyear + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database donorRelativeDetails
        public class DonorRelativeDetails
        {
            private string tableName = "donorRelativeDetails";
            databases db = new databases();

            public void donorRelative(string relativeName = "", string nic = "", string phoneNumber = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + relativeName + "', '" + nic + "', '" + phoneNumber + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database bloodGroups
        public class BloodGroups
        {
            private string tableName = "bloodGroups";
            databases db = new databases();

            private string bloodId = "bloodID";
            private string bloodName = "bloodName";
            private string description = "description";
            private string beginDay = "beginDay";
            private string beginMonth = "beginMonth";
            private string beginyear = "beginYear";
            private string regBy = "regBy";
            private string contity = "quantity";

            public void bloodGroupRegistration(string bloodName = "", string description = "", string beginDay = "", string beginMonth = "", string beginYear = "", string regBy = "")
            {
                bloodName = db.callInsertionConnection(bloodName);
                description = db.callInsertionConnection(description);
                beginDay = db.callInsertionConnection(beginDay);
                beginMonth = db.callInsertionConnection(beginMonth);
                beginYear = db.callInsertionConnection(beginyear);
                regBy = db.callInsertionConnection(regBy);

                db.createConnection();
                db.command.CommandText = "insert into " + tableName + "  (bloodName, description, beginDay, beginMonth, beginYear, " + this.regBy + ") values ('" + bloodName + "', '" + description + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + regBy + "', '" + db.callInsertionConnection("0") + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<string> getBloodGroups()
            {
                List<string> bloodGroups = new List<string>();

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    bloodGroups.Add(db.callReturnConnection(db.reader.GetString(this.bloodName)));
                }
                db.connection.Close();

                return bloodGroups;
            }

            public string getEntry(string bloodGroup, int requiringIndex)
            {
                string entryValue = "";

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.bloodId + " = '" + db.callInsertionConnection(bloodGroup) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (requiringIndex)
                    {
                        case 0:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.bloodName));
                            break;
                        case 1:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.description));
                            break;
                        case 2:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.beginDay));
                            break;
                        case 3:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.beginMonth));
                            break;
                        case 4:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.beginyear));
                            break;
                        case 5:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.regBy));
                            break;
                        case 6:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.contity));
                            break;
                        default:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.bloodName));
                            break;
                    }
                }
                db.connection.Close();

                return entryValue;
            }

            public string getID(string bloodName)
            {
                string bloodID = "";
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.bloodName + " = '" + db.callInsertionConnection(bloodName) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                    bloodID = db.callReturnConnection(db.reader.GetString(this.bloodId));
                }
                db.connection.Close();
                if(count > 1 || count == 0)
                {
                    bloodID = "";
                }

                return bloodID;
            }

            public bool checkBloodGroup(string bloodGroup)
            {
                int count = 0;
                bool isBloodAvailable = false;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.bloodName + " = '" + db.callInsertionConnection(bloodGroup) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if (count == 1)
                {
                    isBloodAvailable = true;
                }

                return isBloodAvailable;
            }

            public void updateEntry(string bloodID, int changeIndex, string bloodName = "", string description = "", string beginDay = "", string beginMonth = "", string beginYear = "", string regBy = "", string contity = "")
            {
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.bloodName + " = '" + db.callInsertionConnection(bloodName) + "'";
                switch (changeIndex)
                {
                    case 0: 
                        db.command.CommandText = "update " + this.tableName + " set " + this.bloodName + " = '" + db.callInsertionConnection(bloodName) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + this.description + " = '" + db.callInsertionConnection(description) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 2:
                        db.command.CommandText = "update " + this.tableName + " set " + this.beginDay + " = '" + db.callInsertionConnection(beginDay) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 3:
                        db.command.CommandText = "update " + this.tableName + " set " + this.beginMonth + " = '" + db.callInsertionConnection(beginMonth) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 4:
                        db.command.CommandText = "update " + this.tableName + " set " + this.beginyear + " = '" + db.callInsertionConnection(beginyear) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 5:
                        db.command.CommandText = "update " + this.tableName + " set " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    case 6:
                        db.command.CommandText = "update " + this.tableName + " set " + this.contity + " = '" + db.callInsertionConnection(contity) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;

                    default:
                        db.command.CommandText = "update " + this.tableName + " set " + this.bloodName + " = '" + db.callInsertionConnection(bloodName) + "' where " + this.bloodId + " = '" + db.callInsertionConnection(bloodId) + "'";
                        break;
                }
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<List<string>> getValues()
            {
                List<List<string>> items = new List<List<string>>();
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    List<string> tempItems = new List<string>();
                    tempItems.Add(db.callReturnConnection(this.bloodId));
                    tempItems.Add(db.callReturnConnection(this.bloodName));
                    tempItems.Add(db.callReturnConnection(this.beginyear));
                    tempItems.Add(db.callReturnConnection(this.beginMonth));
                    tempItems.Add(db.callReturnConnection(this.beginDay));
                    tempItems.Add(db.callReturnConnection(this.contity));
                    items[count] = tempItems;
                    count++;
                }
                db.connection.Close();
                return items;
            }
        }

        //database diseaseList
        public class DiseaseList
        {
            private string tableName = "diseaseList";
            databases db = new databases();

            public void newDicease(string diseaceName = "", string description = "", string registeredDay = "", string registeredMonth = "", string registeredYear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + "  (diseaceName, description, registeredDay, registeredMonth, registeredYear) values ('" + diseaceName + "', '" + description + "', '" + registeredDay + "', '" + registeredMonth + "', '" + registeredYear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database medicineDetails
        public class MedicineDetails
        {
            private string tableName = "medicineDetails";
            databases db = new databases();

            public void addNewMedicine(string name = "", string description = "", string regDay = "", string regMonth = "", string regYear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (name, description, regDay, regMonth, regYear) values ('" + name + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database prescribedMedicine
        public class PrescribedMedicine
        {
            private string tableName = "prescribedMedicine";
            databases db = new databases();

            public void newMedicine(string medicineID = "", string NIC = "", string description = "", string regDay = "", string regMonth = "", string regyear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + medicineID + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regyear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database staffList
        public class StaffList
        {
            private string tableName = "staffList";
            databases db = new databases();

            //table column names
            private string id = "ID";
            private string nic = "NIC";
            private string fistName = "firstName";
            private string lastName = "lastName";
            private string otherName = "otherName";
            private string line1 = "line1";
            private string line2 = "line2";
            private string line3 = "line3";
            private string cityHomeLand = "cityhomeLand";
            private string gender = "gender";
            private string emailBeginDay = "emailbeginDay";
            private string beginMonth = "beginMonth";
            private string beginYear = "beginYear";
            private string position = "position";
            private string employeeLevel1 = "employeeLevel";
            private string applicableLeaves = "applicableLeaves";
            private string accountActivation = "accountActivation";

            public void registerNewStaff(string NIC = "", string firstName = "", string lastName = "", string otherName = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeLand = "", string gender = "", string email = "", string beginDay = "", string beginMonth = "", string beginYear = "", string position = "", string employeeLevel = "", string applicableLeaves = "", string accountActivation = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + NIC + "', '" + firstName + "', '" + lastName + "', '" + otherName + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "', '" + gender + "', '" + email + "', '" + beginDay + "', '" + beginMonth + "', '" + beginYear + "', '" + position + "', '" + employeeLevel + "', '" + applicableLeaves + "', '" + accountActivation + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void updateStaffListforProfessionalDetails(string NIC, string position = "", string email = "")
            {
                db.createConnection();
                db.command.CommandText = "update " + tableName + " set position = '" + position + "', email = '" + email + "' where nic = '" + NIC + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public int checkID(string id)
            {
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if (count > 1)
                {
                    count = 2;
                }

                return count;
            }

            public string[] getStaffEntry(string nic)
            {
                string[] entryDetails = new string[17];
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where NIC = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    entryDetails[0] = db.callReturnConnection(db.reader.GetString("ID"));
                    entryDetails[1] = db.callReturnConnection(db.reader.GetString("firstName"));
                    entryDetails[2] = db.callReturnConnection(db.reader.GetString("lastName"));
                    entryDetails[3] = db.callReturnConnection(db.reader.GetString("otherName"));
                    entryDetails[4] = db.callReturnConnection(db.reader.GetString("line1"));
                    entryDetails[5] = db.callReturnConnection(db.reader.GetString("line2"));
                    entryDetails[6] = db.callReturnConnection(db.reader.GetString("line3"));
                    entryDetails[7] = db.callReturnConnection(db.reader.GetString("city"));
                    entryDetails[8] = db.callReturnConnection(db.reader.GetString("homeLand"));
                    entryDetails[9] = db.callReturnConnection(db.reader.GetString("gender"));
                    entryDetails[10] = db.callReturnConnection(db.reader.GetString("email"));
                    entryDetails[11] = db.callReturnConnection(db.reader.GetString("beginDay"));
                    entryDetails[12] = db.callReturnConnection(db.reader.GetString("beginMonth"));
                    entryDetails[13] = db.callReturnConnection(db.reader.GetString("beginYear"));
                    entryDetails[14] = db.callReturnConnection(db.reader.GetString("position"));
                    entryDetails[15] = db.callReturnConnection(db.reader.GetString("employeeLevel"));
                    entryDetails[16] = db.callReturnConnection(db.reader.GetString("applicableLeaves"));
                    entryDetails[17] = db.callReturnConnection(db.reader.GetString("accountActivation"));
                }
                db.connection.Close();
                return entryDetails;
            }

            public List<string> getStaffIDBasedOnPosition(string position)
            {
                List<string> staffId = new List<string>();
                db.createConnection();
                db.command.CommandText = "select " + this.id + " from " + this.tableName + " where " + this.position + " = '" + db.callInsertionConnection(position) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    staffId.Add(db.callReturnConnection(db.reader[this.id].ToString()));
                }
                db.connection.Close();
                return staffId;
            }
        }

        //database staffPosition
        public class staffPosition
        {
            private string tableName = "staffPosition";
            databases db = new databases();

            private string ID = "ID";
            private string position = "position";

            public void newPosition()
            {
                db.createConnection();
                db.command.CommandText = "insert into " + this.tableName + "(" + this.position + ") values (" + db.callInsertionConnection(position) + ")";
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public List<string> positionId(string position)
            {
                List<string> positionId = new List<string>();
                db.createConnection();
                db.command.CommandText = "select " + this.ID + " from " + this.tableName + " where " + this.position + " = '" + db.callInsertionConnection(position) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    positionId.Add(db.callReturnConnection(db.reader[this.ID].ToString()));
                }
                db.connection.Close();
                return positionId;
            }
        }

        //database staffCredentials
        public class StaffCredentials
        {
            private string tableName = "staffCredentials";
            databases db = new databases();

            public bool newCredential(string username = "", string password = "", string NIC = "")
            {
                if (checkUserName(username))
                {
                    db.createConnection();
                    db.command.CommandText = "insert into " + tableName + " values ('" + username + "', '" + password + "', '" + NIC + "')";
                    db.connection.Open();
                    db.reader = db.command.ExecuteReader();
                    db.connection.Close();
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
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where username = '" + username + "'and password = '" + password + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                    NIC = db.reader.GetString("nic");
                }
                db.connection.Close();
                if (count == 1)
                {
                    return NIC;
                }
                else if (count == 0)
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
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where username = '" + username + "'";
                int count = 0;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if (count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //database staffContactDetails
        public class StaffContactDetails
        {
            private string tableName = "staffContactDetails";
            databases db = new databases();

            private string phoneNumber = "phoneNumber";
            private string nic = "nic";

            public void newStaffContact(string phoneNumber = "", string NIC = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + phoneNumber + "', '" + NIC + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<string> getContact(string nic)
            {
                List<string> contactNumber = new List<string>();
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select from " + tableName + " where " + this.nic + " = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    contactNumber.Add(db.callReturnConnection(db.reader.GetString(this.phoneNumber)));
                    count++;
                }
                db.connection.Close();
                contactNumber.Insert(0, count.ToString());
                return contactNumber;
            }
        }

        //database staffEducationalQualification
        public class StaffEducationalQualification
        {
            private string tableName = "staffEducationalQualification";
            databases db = new databases();

            public void newStaffEducationalQualification(string nic = "", string studies = "", string institute = "", string beginYear = "", string endYear = "", string lastExperiancePostition = "", string businessFirm = "", string experiance = "", string counting = "", string birthCertificateLink = "", string degreeCertificateLink = "", string nicFrontLink = "", string nicBackLink = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + nic + "', '" + studies + "', '" + institute + "', '" + beginYear + "', '" + endYear + "', '" + lastExperiancePostition + "', '" + businessFirm + "', '" + experiance + "', '" + counting + "', '" + birthCertificateLink + "', '" + degreeCertificateLink + "', '" + nicFrontLink + "', '" + nicBackLink + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void signUpEducationalStatusUpdate(string NIC, string birthcertificateLink = "", string degreeCertificateLink = "", string nicFrontLink = "", string nicBackLink = "")
            {
                db.createConnection();
                db.command.CommandText = "update " + tableName + " set birthCertificateLink = '" + birthcertificateLink + "', degreeCertificateLink = '" + degreeCertificateLink + "', nicFrontLink  = '" + nicFrontLink + "', nicBackLink  = '" + nicBackLink + "' where nic = '" + NIC + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database messages
        public class Messages
        {
            private string tableName = "messages";
            databases db = new databases();

            private string ID = "ID";
            private string message = "message";
            private string sendingTo = "sendingTo";
            private string status = "status";
            private string sentDay = "sentDay";
            private string sentMonth = "sentMonth";
            private string sentYear = "sentYear";
            private string sentHour = "sentHour";
            private string sentMinute = "sentMinute";
            private string recieveDay = "recievedDay";
            private string recievedMonth = "recievedMonth";
            private string recievedYear = "recievedYear";
            private string recievedHour = "recievedHour";
            private string recievedMinute = "recievedMinute";
            private string from = "replyID";

            public void newMessage(string message = "", string to = "", string from = "", string status = "", string sentDay = "", string sentMonth = "", string sentYear = "", string sentHour = "", string sentMinute = "", string recievedDay = "", string recievedMonth = "", string recievedYear = "", string recievedHour = "", string recievedMinute = "", string replyID = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (message, sendingTo, recievedFrom, status, sentDay, sentMonth, sentYear, sentHour, sentMinute, recievedDay, recievedMonth, recievedYear, recievedHour, recievedMinute, replyID) values ('" + db.callInsertionConnection(message) + "', '" + db.callInsertionConnection(to) + "', '" + db.callInsertionConnection(from) + "', '" + db.callInsertionConnection(status) + "', '" + db.callInsertionConnection(sentDay) + "', '" + db.callInsertionConnection(sentMonth) + "', '" + db.callInsertionConnection(sentYear) + "', '" + db.callInsertionConnection(sentHour) + "', '" + db.callInsertionConnection(sentMinute) + "', '" + db.callInsertionConnection(recievedDay) + "', '" + db.callInsertionConnection(recievedMonth) + "', '" + db.callInsertionConnection(recievedYear) + "', '" + db.callInsertionConnection(recievedHour) + "', '" + db.callInsertionConnection(recievedMinute) + "', '" + db.callInsertionConnection(replyID) + "')";
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public int unreadMessagesCount(string nic)
            {
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where ID = '" + db.callInsertionConnection(nic) + "'and status = '" + db.callInsertionConnection("unread") + "'";
                int count = 0;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }

            public string[] lastUnseenMessage(string nic)
            {
                //making an array
                string[] message = new string[2];

                //getting the id and the message from
                //if there only one message
                if (unreadMessagesCount(nic) == 1)
                {
                    db.createConnection();
                    db.command.CommandText = "select from " + tableName + " where ID = '" + db.callInsertionConnection(nic) + "'and status = '" + db.callInsertionConnection("unread") + "'";
                    db.connection.Open();
                    db.reader = db.command.ExecuteReader();
                    while (db.reader.Read())
                    {
                        message[0] = db.callReturnConnection(db.reader.GetString("recievedFrom"));
                        message[1] = db.callReturnConnection(db.reader.GetString("message"));
                    }
                    db.connection.Close();

                    //getting the name of the sending person
                    string name = new StaffList().getStaffEntry(message[0]).GetValue(1).ToString();
                    message[0] = name;
                }

                //returning the array
                return message;
            }

            public List<string> unseenMessages(string nic, string requestingFieldIndex)
            {
                //creating the message
                List<string> entries = new List<string>();

                db.createConnection();
                db.command.CommandText = "select from " + tableName + " where ID = '" + db.callInsertionConnection(nic) + "'and status = '" + db.callInsertionConnection("unread") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (requestingFieldIndex)
                    {
                        case "0":
                            entries.Add(db.callReturnConnection(db.reader.GetString("ID")));
                            break;
                        case "1":
                            entries.Add(db.callReturnConnection(db.reader.GetString("message")));
                            break;
                        case "2":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sendingTo")));
                            break;
                        case "3":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedFrom")));
                            break;
                        case "4":
                            entries.Add(db.callReturnConnection(db.reader.GetString("status")));
                            break;
                        case "5":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sentDay")));
                            break;
                        case "6":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sentMonth")));
                            break;
                        case "7":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sentYear")));
                            break;
                        case "8":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sentHour")));
                            break;
                        case "9":
                            entries.Add(db.callReturnConnection(db.reader.GetString("sentMinute")));
                            break;
                        case "10":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedDay")));
                            break;
                        case "11":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedMonth")));
                            break;
                        case "12":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedYear")));
                            break;
                        case "13":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedHour")));
                            break;
                        case "14":
                            entries.Add(db.callReturnConnection(db.reader.GetString("recievedMinute")));
                            break;
                        case "15":
                            entries.Add(db.callReturnConnection(db.reader.GetString("replyID")));
                            break;
                        default:
                            entries.Add(db.callReturnConnection(db.reader.GetString("message")));
                            break;
                    }
                }
                db.connection.Close();

                //returning the message
                return entries;
            }
        }

        //database logBook
        public class LogBook
        {
            private string tableName = "logBook";
            databases db = new databases();

            public void newLogEntry(string staffID = "", string description = "", string createdDay = "", string createdMonth = "", string createdYear = "", string createdHour = "", string createdMinute = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (staffID, description, createdDay, createdMonth, createdYear, createdHour, createdMinute) values ('" + staffID + "', '" + description + "', '" + createdDay + "', '" + createdMonth + "', '" + createdYear + "', '" + createdHour + "', '" + createdMinute + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }
        }

        //database attendanceRegistry
        public class AttendanceRegistry
        {
            private string tableName = "attendanceRegistry";
            databases db = new databases();

            private string id = "ID";
            private string nic = "NIC";
            private string day = "day";
            private string month = "month";
            private string year = "year";
            private string hour = "hour";
            private string minute = "minute";
            private string regDay = "regDay";
            private string regMonth = "regMonth";
            private string regYear = "regYear";

            public void markAttendance(string NIC = "", string day = "", string month = "", string year = "", string hour = "", string minute = "", string regDay = "", string regMonth = "", string regYear = "")
            {
                NIC = db.callInsertionConnection(NIC);
                day = db.callInsertionConnection(day);
                month = db.callInsertionConnection(month);
                year = db.callInsertionConnection(year);
                hour = db.callInsertionConnection(hour);
                minute = db.callInsertionConnection(minute);
                regDay = db.callInsertionConnection(regDay);
                regMonth = db.callInsertionConnection(regMonth);
                regYear = db.callInsertionConnection(regYear);

                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (ID, NIC, day, month, year, hour, minute, regDay, regMonth, regYear) values ('" + NIC + "', '" + day + "', '" + month + "', '" + year + "', '" + hour + "', '" + minute + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public bool checkAttendance(string nic = "")
            {
                bool attendanceStatus = false;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where NIC = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if ((db.callReturnConnection(db.reader.GetString("day")) == DateTime.Now.ToString("dd")) && (db.callReturnConnection(db.reader.GetString("month")) == DateTime.Now.ToString("MM")) && (db.callReturnConnection(db.reader.GetString("year")) == DateTime.Now.ToString("yyyy")))
                    {
                        attendanceStatus = true;
                    }
                }
                db.connection.Close();
                return attendanceStatus;
            }

            public int attendanceCount(string nic, string lookingMonth)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where NIC = '" + db.callInsertionConnection(nic) + "' and " + this.regMonth + " = '" + db.callInsertionConnection(lookingMonth) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }

            public List<string> getAttendanceDates(string nic, string requiredMonth)
            {
                //creating the list
                List<string> attendanceDates = new List<string>();

                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + nic + "' and " + this.month + " = '" + db.callInsertionConnection(requiredMonth) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    attendanceDates.Add(db.callReturnConnection(db.reader.GetString(this.day)) + db.callReturnConnection(db.reader.GetString(this.month)) + db.callReturnConnection(db.reader.GetString(this.year)));
                }
                db.connection.Close();

                //returning the value
                return attendanceDates;
            }

            public bool checkID(string nic)
            {
                bool isAvailable = false;
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    isAvailable = true;
                }
                db.connection.Close();

                return isAvailable;
            }

            public DataTable loadAttendanceRegistry(string id, int filterIndex)
            {
                db.createConnection();
                //filterindex == 0 => want to see all the logs, 
                if (filterIndex == 0)
                {
                    db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                }
                //filterIndex == 1 => log for this month
                else if (filterIndex == 1)
                {
                    db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "' and " + this.month + " = '" + db.callInsertionConnection(DateTime.Now.ToString("MM")) + "'";
                }
                //filterIndex == 2 => log for this year
                else if (filterIndex == 2)
                {
                    db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "' and " + this.year + " = '" + db.callInsertionConnection(DateTime.Now.ToString("yyyy")) + "'";
                }
                //filterIndex == 3 => log for today
                else
                {
                    db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "', " + this.year + " = '" + db.callInsertionConnection(DateTime.Now.ToString("yyyy")) + "', " + this.month + " = '" + db.callInsertionConnection(DateTime.Now.ToString("MM")) + "' and " + this.day + " = '" + db.callInsertionConnection(DateTime.Now.ToString("dd")) + "'";
                }

                db.connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = db.command;
                DataTable table = new DataTable();
                adapter.Fill(table);
                db.connection.Close();

                return table;
            }
        }

        //database bloodCamps
        public class BloodCamps
        {
            private string tableName = "bloodCamps";
            databases db = new databases();

            private string id = "ID";
            private string reqName = "reqName";
            private string heading = "heading";
            private string description = "description";
            private string expectedDonors = "expectedDonors";
            private string regDay = "regDay";
            private string regMonth = "regMonth";
            private string regYear = "regYear";
            private string regHour = "regHour";
            private string regMinute = "regMinute";
            private string expectingDay = "expectingDay";
            private string expectingMonth = "expectingMonth";
            private string expectingyear = "expectingYear";
            private string expectingHour = "expectingHour";
            private string regBy = "regBy";

            public void newBloodCamp(string reqName = "", string heading = "", string description = "", string expectedDonors = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string expectingDay = "", string expectingMonth = "", string expectingYear = "", string expectingHour = "", string expectedMinute = "", string meetingArrangements = "", string approvalStatus = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (reqName, heading, description, expectedDonors, regDay, regMonth, regYear, regHour, regMinute, expectingDay, expectingMonth, expectingYear, expectingHour, expectedMinute, meetingArrangements, approvalStatus) values ('" + reqName + "', '" + heading + "', '" + description + "', '" + expectedDonors + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + expectingDay + "', '" + expectingMonth + "', '" + expectingYear + "', '" + expectingHour + "', '" + expectedMinute + "', '" + meetingArrangements + "', '" + approvalStatus + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public string getAnEntry(string Id, int requiringIndex)
            {
                string text = "";
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (requiringIndex)
                    {
                        case 0:
                            text = db.callReturnConnection(db.reader[this.id].ToString());
                            break;

                        case 1:
                            text = db.callReturnConnection(db.reader[this.reqName].ToString());
                            break;

                        case 2:
                            text = db.callReturnConnection(db.reader[this.description].ToString());
                            break;

                        case 3:
                            text = db.callReturnConnection(db.reader[this.expectedDonors].ToString());
                            break;

                        case 4:
                            text = db.callReturnConnection(db.reader[this.regDay].ToString());
                            break;

                        case 5:
                            text = db.callReturnConnection(db.reader[this.regMonth].ToString());
                            break;

                        case 6:
                            text = db.callReturnConnection(db.reader[this.regYear].ToString());
                            break;

                        case 7:
                            text = db.callReturnConnection(db.reader[this.regHour].ToString());
                            break;

                        case 8:
                            text = db.callReturnConnection(db.reader[this.regMinute].ToString());
                            break;

                        case 9:
                            text = db.callReturnConnection(db.reader[this.expectingDay].ToString());
                            break;

                        case 10:
                            text = db.callReturnConnection(db.reader[this.expectingMonth].ToString());
                            break;

                        case 11:
                            text = db.callReturnConnection(db.reader[this.expectingyear].ToString());
                            break;

                        case 12:
                            text = db.callReturnConnection(db.reader[this.expectingHour].ToString());
                            break;

                        case 13:
                            text = db.callReturnConnection(db.reader[this.heading].ToString());
                            break;

                        case 14:
                            text = db.callReturnConnection(db.reader[this.regBy].ToString());
                            break;

                        default:
                            text = db.callReturnConnection(db.reader[this.id].ToString());
                            break;
                    }
                }
                db.connection.Close();
                return text;
            }

            public List<List<string>> getRecords(bool id = false, bool reqName = false, bool heading = false, bool description = false, bool expectedDonors = false, bool regDay = false, bool regMonth = false, bool regYear = false, bool regHour = false, bool regMinute = false, bool expectingDay = false, bool expectingMonth = false, bool expectingYear = false, bool expectingHour = false)
            {
                List<List<string>> tempValues = new List<List<string>>();
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    List<string> temp = new List<string>();
                    if(id) { temp.Add(db.callReturnConnection(db.reader[this.id].ToString())); }
                    if (reqName) { temp.Add(db.callReturnConnection(db.reader[this.reqName].ToString())); }
                    if (heading) { temp.Add(db.callReturnConnection(db.reader[this.heading].ToString())); }
                    if (description) { temp.Add(db.callReturnConnection(db.reader[this.description].ToString())); }
                    if (expectedDonors) { temp.Add(db.callReturnConnection(db.reader[this.expectedDonors].ToString())); }
                    if (regDay) { temp.Add(db.callReturnConnection(db.reader[this.regDay].ToString())); }
                    if (regMonth) { temp.Add(db.callReturnConnection(db.reader[this.regMonth].ToString())); }
                    if (regYear) { temp.Add(db.callReturnConnection(db.reader[this.regYear].ToString())); }
                    if (regMinute) { temp.Add(db.callReturnConnection(db.reader[this.regMinute].ToString())); }
                    if (regHour) { temp.Add(db.callReturnConnection(db.reader[this.regHour].ToString())); }
                    if (expectingDay) { temp.Add(db.callReturnConnection(db.reader[this.expectingDay].ToString())); }
                    if (expectingMonth) { temp.Add(db.callReturnConnection(db.reader[this.expectingMonth].ToString())); }
                    if (expectingYear) { temp.Add(db.callReturnConnection(db.reader[this.expectingyear].ToString())); }
                    if (expectingHour) { temp.Add(db.callReturnConnection(db.reader[this.expectingHour].ToString())); }
                    else if(!id && !reqName && !heading && !description && !expectedDonors && !regDay && !regMonth && !regYear && !regHour && !regMinute && !expectingDay && !expectingMonth && !expectingYear && !expectingHour)
                    {
                        temp.Add(db.callReturnConnection(db.reader[this.id].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.reqName].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.description].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.expectedDonors].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regDay].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regMonth].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regYear].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regMinute].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regHour].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.expectingDay].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.expectingMonth].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.expectingyear].ToString()));
                    }

                    tempValues[count] = temp;
                    count++;
                }
                db.connection.Close();

                return tempValues;
            }

            public int checkId(string ID)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select " + this.id + " from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(ID) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();

                if(count == 1)
                {
                    count = 0;
                }
                else if(count == 0)
                {
                    count = -1;
                }
                else
                {
                    count = 2;
                }
                return count;
            }

            public void deleteRecords(string ID, int aquiringIndex)
            {
                db.createConnection();
                switch (aquiringIndex)
                {
                    case 0:
                        db.command.CommandText = "delete from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(ID) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database leaveApplication
        public class LeaveApplication
        {
            private string tableName = "leaveApplication";
            databases db = new databases();

            private string id = "ID";
            private string userid = "userID";
            private string reason = "Reason";
            private string regday = "regDay";
            private string regMonth = "regMonth";
            private string regYear = "regyear";
            private string wantDay = "wantedDay";
            private string wantMonth = "wantedMonth";
            private string wantYear = "wantedYear";
            private string leaveType = "leaveType";
            private string dayOfPeriod = "dayOfPeriod";
            private string approvedStatus = "approveStatus";
            private string approvedBy = "approvedBy";

            public void registerNewLeaveApplication(string userID = "", string Reason = "", string regDay = "", string regMonth = "", string regyear = "", string wantedDay = "", string wantedMonth = "", string wantedYear = "", string leaveType = "", string dayOfPeriod = "", string approvedStatus = "", string spprovedBy = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (userID, Reason, regDay, regMonth, regyear, wantedDay, wantedMonth, wantedYear, leaveType, dayOfPeriod, " + this.approvedStatus + ", " + this.approvedBy + ") values ('" + userID + "', '" + Reason + "', '" + regDay + "', '" + regMonth + "', '" + regyear + "', '" + wantedDay + "', '" + wantedMonth + "', '" + wantedYear + "', '" + leaveType + "', '" + dayOfPeriod + "', '" + approvedStatus + "', '" + approvedBy + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public int countEntries()
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }

            public int leaveApplicationCount(string nic, string lookingMonth)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(nic) + "' and " + this.approvedStatus + " = approved";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if (db.callReturnConnection(db.reader.GetString(this.wantMonth)) == lookingMonth)
                    {
                        count++;
                    }
                }
                db.connection.Close();
                return count;
            }

            public string getEntry(string nic, int requiredIndex = 0)
            {
                string entry = "";
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + nic + "' and " + this.approvedStatus + " = approved";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if (db.callReturnConnection(db.reader.GetString(this.wantMonth)) == DateTime.Now.ToString("MM"))
                    {
                        switch (requiredIndex)
                        {
                            case 0:
                                entry = db.callReturnConnection(db.reader.GetString(this.userid));
                                break;
                            case 1:
                                entry = db.callReturnConnection(db.reader.GetString(this.reason));
                                break;
                            case 2:
                                entry = db.callReturnConnection(db.reader.GetString(this.regday));
                                break;
                            case 3:
                                entry = db.callReturnConnection(db.reader.GetString(this.regMonth));
                                break;
                            case 4:
                                entry = db.callReturnConnection(db.reader.GetString(this.regYear));
                                break;
                            case 5:
                                entry = db.callReturnConnection(db.reader.GetString(this.wantDay));
                                break;
                            case 6:
                                entry = db.callReturnConnection(db.reader.GetString(this.wantMonth));
                                break;
                            case 7:
                                entry = db.callReturnConnection(db.reader.GetString(this.wantYear));
                                break;
                            case 8:
                                entry = db.callReturnConnection(db.reader.GetString(this.leaveType));
                                break;
                            case 9:
                                entry = db.callReturnConnection(db.reader.GetString(this.dayOfPeriod));
                                break;
                            default:
                                entry = db.callReturnConnection(db.reader.GetString(this.userid));
                                break;
                        }
                    }
                }
                db.connection.Close();

                return entry;
            }

            public List<string> getApprovedLeaveDates(string nic, string requiredMonth)
            {
                //creating the list
                List<string> approvedLeaves = new List<string>();

                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + nic + "' and " + this.approvedStatus + " = approved";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if (db.callReturnConnection(db.reader.GetString(this.wantMonth)) == requiredMonth)
                    {
                        approvedLeaves.Add(db.callReturnConnection(db.reader.GetString(this.wantDay)) + db.callReturnConnection(db.reader.GetString(this.wantMonth)) + db.callReturnConnection(db.reader.GetString(this.wantYear)));
                    }
                }
                db.connection.Close();

                //returning the values
                return approvedLeaves;
            }

            public int approvedLeaves(string nic)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(nic) + "' and " + this.approvedStatus + " = approved";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }
        }

        //database meetings
        public class Meetings
        {
            private string tableName = "meetings";
            databases db = new databases();

            private string Id = "ID";
            private string regBy = "regBy";
            private string managerAcceptance = "managerAcceptance";
            private string managerRejectionReson = "managerRejectionReason";
            private string PHIAcceptance = "PHIAcceptance";
            private string PHIRejectionReason = "PHIRejectionReason";
            private string nurseAcceptance = "nurseAcceptance";
            private string nurseRejectionReason = "nurseRejectionReason";
            private string donctorAcceptance = "doctorAcceptance";
            private string doctorRejectionReason = "doctorRejectionReason";
            private string heldingDay = "heldingDay";
            private string heldingMonth = "heldingMonth";
            private string heldingyear = "heldingYear";
            private string heldingHour = "heldingHour";
            private string heldingMinute = "heldingMinute";
            private string reason = "reason";
            private string nurseApproval = "nurseApproval";
            private string nurseCampRejectionReaoson = "nurseCampRejectionReason";
            private string PHIApproval = "PHIApproval";
            private string PHICampRejectionReason = "PHICampRejectionReason";
            private string doctorApproval = "doctorApproval";
            private string doctorCampRejectionReason = "doctorCampRejectionReason";
            private string managerApproval = "managerApproval";
            private string managerCampRejectionReason = "managerCampRejectionReason";
            private string campID = "campID";
            private string createDay = "createdDay ";
            private string createMonth = "createdMonth";
            private string createdYear = "createdYear";
            private string createdHour = "createdHour";
            private string createdMinute = "createdMinute";

            public void arrangeNewMeeting(string regBy = "", string managerAcceptance = "", string PHIAcceptance = "", string nurseAcceptance = "", string doctorAcceptance = "", string heldingDay = "", string heldingMonth = "", string heldingYear = "", string heldingHour = "", string heldingMinute = "", string reqDay = "", string reqMonth = "", string reqYear = "", string reqHour = "", string reqMinute = "", string reason = "", string nurseApproval = "", string PHIApproval = "", string doctorApproval = "", string managerApproval = "", string campID = "", string createdDay = "", string createdMonth = "", string createdYear = "", string createdHour = "", string createdminute = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (regBy, managerAcceptance, PHIAcceptance, nurseAcceptance, nurseAcceptance, doctorAcceptance,  heldingDay, heldingMonth, heldingYear, heldingHour, heldingMinute, reqDay, reqMonth, reqYear, reqHour, reqMinute, reason, nurseApproval, PHIApproval, doctorApproval, managerApproval, campID, " + this.createdYear + ", " + this.createMonth + ", " + this.createDay + ", " + this.createdHour + ", " + this.createdMinute + ") values ('" + db.callInsertionConnection(regBy) + "', '" + db.callInsertionConnection(managerAcceptance) + "', '" + db.callInsertionConnection(PHIAcceptance) + "', '" + db.callInsertionConnection(nurseAcceptance) + "', '" + db.callInsertionConnection(doctorAcceptance) + "', '" + db.callInsertionConnection(heldingDay) + "', '" + db.callInsertionConnection(heldingMonth) + "', '" + db.callInsertionConnection(heldingYear) + "', '" + db.callInsertionConnection(heldingHour) + "', '" + db.callInsertionConnection(heldingMinute) + "', '" + db.callInsertionConnection(reqDay) + "', '" + db.callInsertionConnection(reqMonth) + "', '" + db.callInsertionConnection(reqYear) + "', '" + db.callInsertionConnection(reqHour) + "', '" + db.callInsertionConnection(reqMinute) + "', '" + db.callInsertionConnection(reason) + "', '" + db.callInsertionConnection(nurseApproval) + "', '" + db.callInsertionConnection(PHIApproval) + "', '" + db.callInsertionConnection(doctorApproval) + "', '" + db.callInsertionConnection(managerApproval) + "', '" + db.callInsertionConnection(campID) + "', '" + db.callInsertionConnection(createdYear) + "', '" + db.callInsertionConnection(createMonth) + "', '" + db.callInsertionConnection(createDay) + "', '" + db.callInsertionConnection(createdHour) + "', '" + db.callInsertionConnection(createdminute) + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<List<string>> getLists(bool Id = false, bool regBy = false, bool managerAcceptance = false, bool managerRejectionReason = false, bool PHIAcceptance = false, bool PHIRejectionReason = false, bool nurseAcceptance = false, bool nurseRejectionReason = false, bool doctorAcceptance = false, bool doctorRejectionReason = false, bool heldingDay = false, bool heldingMonth = false, bool heldingYear = false, bool heldingHour = false, bool heldingMinute = false, bool reason = false, bool nurseApproval = false, bool nurseCampRejectionReason = false, bool PHIApproval = false, bool PHICampRejectionReason = false, bool doctorApproval = false, bool doctorCampRejectionReason = false, bool managerApproval = false, bool managerCampRejectionReason = false, bool campID = false)
            {
                List<List<string>> tempList = new List<List<string>>();
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                for (int i = 0; db.reader.Read(); i++)
                {
                    List<string> temp = new List<string>();
                    if (Id) { temp.Add(db.callReturnConnection(db.reader[this.Id].ToString())); }
                    if (regBy) { temp.Add(db.callReturnConnection(db.reader[this.regBy].ToString())); }
                    if (managerAcceptance) { temp.Add(db.callReturnConnection(db.reader[this.managerAcceptance].ToString())); }
                    if (managerRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.managerRejectionReson].ToString())); }
                    if (PHIAcceptance) { temp.Add(db.callReturnConnection(db.reader[this.PHIAcceptance].ToString())); }
                    if (PHIRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.PHIRejectionReason].ToString())); }
                    if (nurseAcceptance) { temp.Add(db.callReturnConnection(db.reader[this.nurseAcceptance].ToString())); }
                    if (nurseRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.nurseRejectionReason].ToString())); }
                    if (doctorAcceptance) { temp.Add(db.callReturnConnection(db.reader[this.doctorApproval].ToString())); }
                    if (doctorRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.doctorRejectionReason].ToString())); }
                    if (heldingDay) { temp.Add(db.callReturnConnection(db.reader[this.heldingDay].ToString())); }
                    if (heldingMonth) { temp.Add(db.callReturnConnection(db.reader[this.heldingMonth].ToString())); }
                    if (heldingYear) { temp.Add(db.callReturnConnection(db.reader[this.heldingyear].ToString())); }
                    if (heldingHour) { temp.Add(db.callReturnConnection(db.reader[this.heldingHour].ToString())); }
                    if (heldingMinute) { temp.Add(db.callReturnConnection(db.reader[this.heldingMinute].ToString())); }
                    if (reason) { temp.Add(db.callReturnConnection(db.reader[this.reason].ToString())); }
                    if (nurseApproval) { temp.Add(db.callReturnConnection(db.reader[this.nurseApproval].ToString())); }
                    if (nurseCampRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.nurseCampRejectionReaoson].ToString())); }
                    if (PHIApproval) { temp.Add(db.callReturnConnection(db.reader[this.PHIApproval].ToString())); }
                    if (PHICampRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.PHICampRejectionReason].ToString())); }
                    if (doctorApproval) { temp.Add(db.callReturnConnection(db.reader[this.doctorApproval].ToString())); }
                    if (doctorCampRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.doctorCampRejectionReason].ToString())); }
                    if (managerApproval) { temp.Add(db.callReturnConnection(db.reader[this.managerApproval].ToString())); }
                    if (managerCampRejectionReason) { temp.Add(db.callReturnConnection(db.reader[this.managerCampRejectionReason].ToString())); }
                    if (campID) { temp.Add(db.callReturnConnection(db.reader[this.campID].ToString())); }

                    else if(!Id && !regBy && !managerAcceptance && !managerRejectionReason && !PHIAcceptance && !PHIRejectionReason && !nurseAcceptance && !nurseRejectionReason && !doctorAcceptance && !doctorRejectionReason && !heldingDay && !heldingMonth && !heldingYear && !heldingHour && !heldingMinute && !reason && !nurseApproval && !nurseCampRejectionReason && !PHIApproval && !PHICampRejectionReason && !PHIApproval && !PHICampRejectionReason && !doctorApproval && !doctorCampRejectionReason && !doctorApproval && !doctorCampRejectionReason && !managerApproval && !managerCampRejectionReason && !campID)
                    {
                        temp.Add(db.callReturnConnection(db.reader[this.Id].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.regBy].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.managerAcceptance].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.managerRejectionReson].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.PHIAcceptance].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.PHIRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.nurseAcceptance].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.nurseRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.doctorApproval].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.doctorRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.heldingDay].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.heldingMonth].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.heldingyear].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.heldingHour].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.heldingMinute].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.reason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.nurseApproval].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.nurseCampRejectionReaoson].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.PHIApproval].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.PHICampRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.doctorApproval].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.doctorCampRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.managerApproval].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.managerCampRejectionReason].ToString()));
                        temp.Add(db.callReturnConnection(db.reader[this.campID].ToString()));
                    }

                    tempList[i] = temp;
                }
                db.connection.Close();
                return tempList;
            }

            public string getAnEntry(string ID, int requestingIndex, bool isConnectionWithCampId = false)
            {
                string value = "";
                db.createConnection();
                db.command.CommandText = !isConnectionWithCampId ? "select * from " + this.tableName + " where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'" : "select * from " + this.tableName + " where " + this.campID + " = '" + db.callInsertionConnection(ID) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (requestingIndex)
                    {
                        case 0:
                            value = db.callReturnConnection(db.reader[this.Id].ToString());
                            break;

                        case 1:
                            value = db.callReturnConnection(db.reader[this.regBy].ToString());
                            break;

                        case 2:
                            value = db.callReturnConnection(db.reader[this.managerAcceptance].ToString());
                            break;

                        case 3:
                            value = db.callReturnConnection(db.reader[this.managerRejectionReson].ToString());
                            break;

                        case 4:
                            value = db.callReturnConnection(db.reader[this.PHIAcceptance].ToString());
                            break;

                        case 5:
                            value = db.callReturnConnection(db.reader[this.PHIRejectionReason].ToString());
                            break;

                        case 6:
                            value = db.callReturnConnection(db.reader[this.nurseAcceptance].ToString());
                            break;

                        case 7:
                            value = db.callReturnConnection(db.reader[this.nurseRejectionReason].ToString());
                            break;

                        case 8:
                            value = db.callReturnConnection(db.reader[this.donctorAcceptance].ToString());
                            break;

                        case 9:
                            value = db.callReturnConnection(db.reader[this.doctorRejectionReason].ToString());
                            break;

                        case 10:
                            value = db.callReturnConnection(db.reader[this.heldingDay].ToString());
                            break;

                        case 11:
                            value = db.callReturnConnection(db.reader[this.heldingMonth].ToString());
                            break;

                        case 12:
                            value = db.callReturnConnection(db.reader[this.heldingyear].ToString());
                            break;

                        case 13:
                            value = db.callReturnConnection(db.reader[this.heldingHour].ToString());
                            break;

                        case 14:
                            value = db.callReturnConnection(db.reader[this.heldingMinute].ToString());
                            break;

                        case 15:
                            value = db.callReturnConnection(db.reader[this.reason].ToString());
                            break;

                        case 16:
                            value = db.callReturnConnection(db.reader[this.nurseApproval].ToString());
                            break;

                        case 17:
                            value = db.callReturnConnection(db.reader[this.nurseCampRejectionReaoson].ToString());
                            break;

                        case 18:
                            value = db.callReturnConnection(db.reader[this.PHIApproval].ToString());
                            break;

                        case 19:
                            value = db.callReturnConnection(db.reader[this.PHICampRejectionReason].ToString());
                            break;

                        case 20:
                            value = db.callReturnConnection(db.reader[this.doctorApproval].ToString());
                            break;

                        case 21:
                            value = db.callReturnConnection(db.reader[this.doctorCampRejectionReason].ToString());
                            break;

                        case 22:
                            value = db.callReturnConnection(db.reader[this.managerApproval].ToString());
                            break;

                        case 23:
                            value = db.callReturnConnection(db.reader[this.managerCampRejectionReason].ToString());
                            break;

                        case 24:
                            value = db.callReturnConnection(db.reader[this.campID].ToString());
                            break;

                        case 25:
                            value = db.callReturnConnection(db.reader[this.createDay].ToString());
                            break;

                        case 26:
                            value = db.callReturnConnection(db.reader[this.createMonth].ToString());
                            break;

                        case 27:
                            value = db.callReturnConnection(db.reader[this.createdYear].ToString());
                            break;

                        case 28:
                            value = db.callReturnConnection(db.reader[this.createdHour].ToString());
                            break;

                        case 29:
                            value = db.callReturnConnection(db.reader[this.createdMinute].ToString());
                            break;

                        default:
                            value = db.callReturnConnection(db.reader[this.campID].ToString());
                            break;
                    }
                }
                db.connection.Close();
                return value;
            }

            public void updateField(string ID, int updatingIndex, int personIdentifier = 0, string regBy = "", string managerAcceptance = "", string managerRejectionReason = "", string PHIAcceptance = "", string PHIRejectionReason = "", string nurseAcceptance = "", string nurseRejectionReason = "", string doctorAcceptance = "", string doctorRejectionReason = "", string heldingDay = "", string heldingMonth = "", string heldingYear = "", string heldingHour = "", string heldingMinute = "", string reason = "", string nurseApproval = "", string nurseCampRejectionReason = "", string PHIApproval = "", string PHICampRejectionReason = "", string doctorApproval = "", string doctorCampRejectionReason = "", string managerApproval = "", string managerCampRejectionReason = "", string campID = "", string createdDay = "", string createdMonth = "", string createdYear = "", string createdHour = "", string createdMinute = "")
            {
                db.createConnection();
                switch (updatingIndex)
                {
                    //update all the entries
                    case 0:
                        db.command.CommandText = "update " + this.tableName + " set " + this.heldingyear + " = '" + db.callInsertionConnection(heldingyear) + "', " + this.heldingMonth + " = '" + db.callInsertionConnection(heldingMonth) + "', " + this.heldingDay + " = '" + db.callReturnConnection(heldingDay) + "', " + this.heldingHour + " = '" + db.callInsertionConnection(heldingHour) + "', " + this.heldingMinute + " = '" + db.callInsertionConnection(heldingMinute) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";
                        break;

                    //update the rejection status of the camp
                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + this.managerRejectionReson + " = '" + db.callInsertionConnection(managerRejectionReson) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";
                        break;

                    //updating all the entries
                    case 2:
                        db.command.CommandText = "update " + this.tableName + " set " + this.heldingyear + " = '" + db.callInsertionConnection(heldingyear) + "', " + this.heldingMonth + " = '" + db.callInsertionConnection(heldingMonth) + "', " + this.heldingDay + " = '" + db.callReturnConnection(heldingDay) + "', " + this.heldingHour + " = '" + db.callInsertionConnection(heldingHour) + "', " + this.heldingMinute + " = '" + db.callInsertionConnection(heldingMinute) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";
                        break;

                    //accepting the camp by the manager
                    //persont identifier = 0 is manager, 1 is doctor, 2 is PHI, 3 is nurse
                    case 3:
                        db.command.CommandText = personIdentifier == 0 ? ("update " + this.tableName + " set " + this.managerApproval + " = '" + db.callInsertionConnection(managerApproval) + "', " + this.managerCampRejectionReason + " = '" + db.callInsertionConnection(managerCampRejectionReason) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'") : (personIdentifier == 1 ? ("update " + this.tableName + " set " + this.doctorApproval + " = '" + db.callInsertionConnection(doctorApproval) + "', " + this.doctorCampRejectionReason + " = '" + db.callInsertionConnection(doctorCampRejectionReason) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'") : (personIdentifier == 2 ? ("update " + this.tableName + " set " + this.PHIApproval + " = '" + db.callInsertionConnection(PHIApproval) + "', " + this.PHICampRejectionReason + " = '" + db.callInsertionConnection(PHICampRejectionReason) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'") : ("update " + this.tableName + " set " + this.nurseApproval + " = '" + db.callInsertionConnection(nurseApproval) + "', " + this.nurseCampRejectionReaoson + " = '" + db.callInsertionConnection(nurseCampRejectionReaoson) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'")));
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public void AcceptMeeting(string ID, int status, bool isCampId = false)
            {
                //meeting status checkup
                // 0 = accepted, 1 = rejected, 2 = hold
                db.createConnection();
                db.command.CommandText = isCampId ? "update " + this.tableName + " set " + this.managerAcceptance + " = '" + db.callInsertionConnection(status.ToString()) + "' where " + this.campID + " = '" + db.callInsertionConnection(ID) + "'" : "Update " + this.tableName + " set " + this.managerAcceptance + " = '" + db.callInsertionConnection(status.ToString()) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";

                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public void acceptCamp(string ID, int status, bool isCampId = false)
            {
                //camp status checkup
                // 0 = accepted, 1 = rejected, 2 = hold
                db.createConnection();
                db.command.CommandText = isCampId ? "update " + this.tableName + " set " + this.managerApproval + " = '" + db.callInsertionConnection(status.ToString()) + "' where " + this.campID + " = '" + db.callInsertionConnection(ID) + "'" : "Update " + this.tableName + " set " + this.managerApproval + " = '" + db.callInsertionConnection(status.ToString()) + "' where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";

                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public int checkId(string ID)
            {
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                if(count > 1)
                {
                    count = 2;
                }
                else if(count == 0)
                {
                    count = -1;
                }
                db.connection.Close();
                return count;
            }

            public void deleteRecords(string ID, int aquiringIndex)
            {
                db.createConnection();
                switch (aquiringIndex)
                {
                    case 0:
                        db.command.CommandText = "delete from " + this.tableName + " where " + this.Id + " = '" + db.callInsertionConnection(ID) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database reminders
        public class Reminders
        {
            private string tableName = "reminders";
            databases db = new databases();

            public void addNewReminder(string nic = "", string heading = "", string description = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string remDay = "", string remMonth = "", string remYear = "", string remHour = "", string remMinute = "", string seenDay = "", string seenMonth = "", string seenYear = "", string seenHour = "", string seenMinute = "", string priorityLevel = "", string seenStatus = "")
            {
                nic = db.callInsertionConnection(nic);
                heading = db.callInsertionConnection(heading);
                description = db.callInsertionConnection(description);
                regDay = db.callInsertionConnection(regDay);
                regMonth = db.callInsertionConnection(regMonth);
                regYear = db.callInsertionConnection(regYear);

                //getting the time period
                if (DateTime.Now.ToString("tt").ToLower() == "am")
                {
                    regHour = db.callInsertionConnection(remHour);
                }
                else
                {
                    regHour = db.callInsertionConnection((int.Parse(regHour + 12)).ToString());
                }


                regMinute = db.callInsertionConnection(regMinute);
                remDay = db.callInsertionConnection(remDay);
                remMonth = db.callInsertionConnection(remMonth);
                remYear = db.callInsertionConnection(remYear);

                //getting the time period
                if (DateTime.Now.ToString("tt").ToLower() == "am")
                {
                    remHour = db.callInsertionConnection(remHour);
                }
                else
                {
                    remHour = db.callInsertionConnection((int.Parse(remHour + 12)).ToString());
                }


                remMinute = db.callInsertionConnection(remMinute);
                seenDay = db.callInsertionConnection(seenDay);
                seenMonth = db.callInsertionConnection(seenMonth);
                seenYear = db.callInsertionConnection(seenYear);

                //getting the time period
                if (DateTime.Now.ToString("tt").ToLower() == "am")
                {
                    seenHour = db.callInsertionConnection(seenHour);
                }
                else
                {
                    seenHour = db.callInsertionConnection((int.Parse(seenHour + 12)).ToString());
                }

                seenMinute = db.callInsertionConnection(seenMinute);
                priorityLevel = db.callInsertionConnection(priorityLevel);
                seenStatus = db.callInsertionConnection(seenStatus);

                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (nic, heading, description, regDay, regMonth, regYear, regHour, regMinute, remDay, remMonth, remYear, remHour, remMinute, seenDay, seenMonth, seenYear, seenHour, seenMinute, priorityLevel, seenStatus, addedBy) values ('" + nic + "', '" + heading + "', '" + description + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + seenDay + "', '" + seenMonth + "', '" + seenYear + "', '" + seenHour + "', '" + seenMinute + "','" + priorityLevel + "', '" + seenStatus + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public string unseenReminders(string NIC)
            {
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(NIC) + "' and seenStatus = '" + db.callInsertionConnection("notseen") + "'";
                int count1 = 0, count2 = 0, count3 = 0;
                string reminder = "";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                    int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                    int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                    int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                    int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                    if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                    {
                        if (month <= int.Parse(DateTime.Now.ToString("MM")))
                        {
                            if (day <= int.Parse(DateTime.Now.ToString("dd")))
                            {
                                if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? int.Parse(DateTime.Now.ToString("hh")) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                {
                                    if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                    {
                                        if (db.callReturnConnection(db.reader.GetString("priorityLevel")) == "1")
                                        {
                                            count1++;
                                        }
                                        else if (db.callReturnConnection(db.reader.GetString("priorityLevel ")) == "2")
                                        {
                                            count2++;
                                        }
                                        else if (db.callReturnConnection(db.reader.GetString("priorityLevel ")) == "3")
                                        {
                                            count3++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                db.connection.Close();

                if (count1 > 0)
                {
                    reminder += "High Priority Reminder(s)";
                }
                else if (count2 > 0)
                {
                    reminder += ", Medium Priority Reminder(s)";
                }
                else if (count2 > 0)
                {
                    reminder += ", Low priority Reminder(s)";
                }
                return reminder;
            }

            public int countUnseenReminders(string nic)
            {
                db.createConnection();
                string status = db.callInsertionConnection("notseen");
                db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(nic) + "' and seenStatus = '" + status + "'";
                int count = 0;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                    int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                    int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                    int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                    int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                    if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                    {
                        if (month <= int.Parse(DateTime.Now.ToString("MM")))
                        {
                            if (day <= int.Parse(DateTime.Now.ToString("dd")))
                            {
                                if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                {
                                    if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
                db.connection.Close();
                return count;
            }

            public string[] getLastUnseenReminder(string nic)
            {
                //declaring a string array to store heading and the description of the last unseen reminder.
                string[] reminder = new string[3];

                //only running the application if there is one reminder in the array
                if (countUnseenReminders(nic) == 1)
                {
                    db.createConnection();
                    db.command.CommandText = "select * from " + tableName + " where nic = '" + nic + "' and seenStatus = '" + db.callInsertionConnection("notseen") + "'";
                    db.connection.Open();
                    db.reader = db.command.ExecuteReader();
                    while (db.reader.Read())
                    {
                        int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                        int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                        int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                        int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                        int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                        if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                        {
                            if (month <= int.Parse(DateTime.Now.ToString("MM")))
                            {
                                if (day <= int.Parse(DateTime.Now.ToString("dd")))
                                {
                                    if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                    {
                                        if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                        {
                                            reminder[0] = db.callReturnConnection(db.reader.GetString("heading"));
                                            reminder[1] = db.callReturnConnection(db.reader.GetString("description"));
                                            reminder[2] = db.callReturnConnection(db.reader.GetString("ID"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    db.connection.Close();
                }

                //returning the reminder.
                return reminder;
            }

            public string[] unseenRemindersList(string nic)
            {
                //making a string and lists to store the reminder
                string[] reminders = new string[3];
                List<string> reminderID = new List<string>();
                List<string> remindDay = new List<string>();
                List<string> remindMonth = new List<string>();
                List<string> remindYear = new List<string>();
                List<string> remindHour = new List<string>();
                List<string> remindMinute = new List<string>();
                List<string> reminderPriorityLevel = new List<string>();
                List<string> reminderDescription = new List<string>();
                List<string> reminderHeading = new List<string>();

                //getting more prioritized entries
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where nic = '" + nic + "' and seenStatus = '" + db.callInsertionConnection("notseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                    int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                    int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                    int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                    int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                    if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                    {
                        if (month <= int.Parse(DateTime.Now.ToString("MM")))
                        {
                            if (day <= int.Parse(DateTime.Now.ToString("dd")))
                            {
                                if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                {
                                    if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                    {
                                        //getting the priority level1 reminders
                                        reminderID.Add(db.callReturnConnection(db.reader.GetString("ID")));
                                        reminderHeading.Add(db.callReturnConnection(db.reader.GetString("heading")));
                                        reminderDescription.Add(db.callReturnConnection(db.reader.GetString("description")));
                                        remindDay.Add(db.callReturnConnection(db.reader.GetString("remDay")));
                                        remindMonth.Add(db.callReturnConnection(db.reader.GetString("remMonth")));
                                        remindYear.Add(db.callReturnConnection(db.reader.GetString("remYear")));
                                        remindHour.Add(db.callReturnConnection(db.reader.GetString("remHour")));
                                        remindMinute.Add(db.callReturnConnection(db.reader.GetString("remMinute")));
                                        reminderPriorityLevel.Add(db.callReturnConnection(db.reader.GetString("priorityLevel")));
                                    }
                                }
                            }
                        }
                    }
                }
                db.connection.Close();

                //sorting the array according to the year
                foreach (string firstEntry in remindYear)
                {
                    int i = 0;
                    int maxIndex = i;
                    foreach (string secondEntry in remindYear)
                    {
                        int j = 0;
                        if (int.Parse(remindYear[maxIndex]) < int.Parse(secondEntry))
                        {
                            maxIndex = j;
                        }
                        j++;
                    }
                    if (i != maxIndex)
                    {
                        db.swapListsValues(remindYear, i, maxIndex);
                        db.swapListsValues(reminderID, i, maxIndex);
                        db.swapListsValues(reminderHeading, i, maxIndex);
                        db.swapListsValues(reminderDescription, i, maxIndex);
                        db.swapListsValues(remindDay, i, maxIndex);
                        db.swapListsValues(remindMonth, i, maxIndex);
                        db.swapListsValues(remindMinute, i, maxIndex);
                        db.swapListsValues(remindHour, i, maxIndex);
                        db.swapListsValues(reminderPriorityLevel, i, maxIndex);
                    }

                    i++;
                }

                //arranging the months which are equal to the year, 
                foreach (string entry1 in remindMonth)
                {
                    int i = 0;
                    int maxIndex = i;

                    foreach (string entr2 in remindMonth)
                    {
                        int j = 0;

                        if ((int.Parse(remindMonth[maxIndex]) < int.Parse(remindMonth[j])) && (remindYear[maxIndex] == remindYear[j]))
                        {
                            maxIndex = j;
                        }
                        else if (remindYear[maxIndex] != remindYear[j])
                        {
                            break;
                        }

                        j++;
                    }
                    if (i != maxIndex)
                    {
                        db.swapListsValues(remindYear, i, maxIndex);
                        db.swapListsValues(reminderID, i, maxIndex);
                        db.swapListsValues(reminderHeading, i, maxIndex);
                        db.swapListsValues(reminderDescription, i, maxIndex);
                        db.swapListsValues(remindDay, i, maxIndex);
                        db.swapListsValues(remindMonth, i, maxIndex);
                        db.swapListsValues(remindMinute, i, maxIndex);
                        db.swapListsValues(remindHour, i, maxIndex);
                        db.swapListsValues(reminderPriorityLevel, i, maxIndex);
                    }

                    i++;
                }

                //arranging linsts according to the day value
                foreach (string entry1 in remindDay)
                {
                    int i = 0;
                    int maxIndex = i;

                    foreach (string entr2 in remindDay)
                    {
                        int j = 0;

                        if ((int.Parse(remindDay[maxIndex]) < int.Parse(remindDay[j])) && (remindMonth[maxIndex] == remindMonth[j]))
                        {
                            maxIndex = j;
                        }
                        else if (remindMonth[maxIndex] != remindMonth[j])
                        {
                            break;
                        }

                        j++;
                    }
                    if (i != maxIndex)
                    {
                        db.swapListsValues(reminderID, i, maxIndex);
                        db.swapListsValues(reminderHeading, i, maxIndex);
                        db.swapListsValues(reminderDescription, i, maxIndex);
                        db.swapListsValues(remindDay, i, maxIndex);
                        db.swapListsValues(remindMinute, i, maxIndex);
                        db.swapListsValues(remindHour, i, maxIndex);
                        db.swapListsValues(reminderPriorityLevel, i, maxIndex);
                    }

                    i++;
                }

                //arranging the lists according to the hour value
                foreach (string entry1 in remindHour)
                {
                    int i = 0;
                    int maxIndex = i;

                    foreach (string entr2 in remindHour)
                    {
                        int j = 0;

                        if ((int.Parse(remindHour[maxIndex]) < int.Parse(remindHour[j])) && (remindDay[maxIndex] == remindDay[j]))
                        {
                            maxIndex = j;
                        }
                        else if (remindDay[maxIndex] != remindDay[j])
                        {
                            break;
                        }

                        j++;
                    }
                    if (i != maxIndex)
                    {
                        db.swapListsValues(reminderID, i, maxIndex);
                        db.swapListsValues(reminderHeading, i, maxIndex);
                        db.swapListsValues(reminderDescription, i, maxIndex);
                        db.swapListsValues(remindMinute, i, maxIndex);
                        db.swapListsValues(remindHour, i, maxIndex);
                        db.swapListsValues(reminderPriorityLevel, i, maxIndex);
                    }

                    i++;
                }

                //checking the values according to the minute value
                foreach (string entry1 in remindMinute)
                {
                    int i = 0;
                    int maxIndex = i;

                    foreach (string entr2 in remindMinute)
                    {
                        int j = 0;

                        if ((int.Parse(remindMinute[maxIndex]) < int.Parse(remindMinute[j])) && (remindHour[maxIndex] == remindHour[j]))
                        {
                            maxIndex = j;
                        }
                        else if (remindHour[maxIndex] != remindHour[j])
                        {
                            break;
                        }

                        j++;
                    }
                    if (i != maxIndex)
                    {
                        db.swapListsValues(reminderID, i, maxIndex);
                        db.swapListsValues(reminderHeading, i, maxIndex);
                        db.swapListsValues(reminderDescription, i, maxIndex);
                        db.swapListsValues(remindMinute, i, maxIndex);
                        db.swapListsValues(reminderPriorityLevel, i, maxIndex);
                    }

                    i++;
                }

                reminders[0] = reminderID[0];
                reminderID[1] = reminderHeading[0];
                reminders[2] = reminderDescription[0];

                //returning the value
                return reminders;
            }

            public string[] getReminderusingID(string ID)
            {
                //declaring a string array to store heading and the description of the last unseen reminder.
                string[] reminder = new string[14];

                //only running the application if there is one reminder in the array
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where ID = '" + db.callInsertionConnection(ID) + "' and seenStatus = '" + db.callInsertionConnection("notseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    reminder[0] = db.callReturnConnection(db.reader.GetString("heading"));
                    reminder[1] = db.callReturnConnection(db.reader.GetString("description"));
                    reminder[2] = db.callReturnConnection(db.reader.GetString("ID"));
                    reminder[3] = db.callReturnConnection(db.reader.GetString("remYear"));
                    reminder[4] = db.callReturnConnection(db.reader.GetString("remMonth"));
                    reminder[5] = db.callReturnConnection(db.reader.GetString("remDay"));
                    reminder[6] = db.callReturnConnection(db.reader.GetString("remHour"));
                    reminder[7] = db.callReturnConnection(db.reader.GetString("remMinute"));
                    reminder[8] = db.callReturnConnection(db.reader.GetString("seenYear"));
                    reminder[9] = db.callReturnConnection(db.reader.GetString("seenMonth"));
                    reminder[10] = db.callReturnConnection(db.reader.GetString("seenDay"));
                    reminder[11] = db.callReturnConnection(db.reader.GetString("seenHour"));
                    reminder[12] = db.callReturnConnection(db.reader.GetString("seenMinute"));
                    reminder[13] = db.callReturnConnection(db.reader.GetString("priorityLevel"));
                }
                db.connection.Close();

                //returning the reminder.
                return reminder;
            }

            public void markAsRead(string reminderID)
            {
                db.createConnection();
                db.command.CommandText = "update " + tableName + " set seenDay = '" + db.callInsertionConnection(DateTime.Now.ToString("dd")) + "', seenMonth = '" + db.callInsertionConnection(DateTime.Now.ToString("MM")) + "', seenYear = '" + db.callInsertionConnection(DateTime.Now.ToString("yyyy")) + "', seenHour = '" + db.callInsertionConnection("hh") + "', seenMinute = '" + db.callInsertionConnection(DateTime.Now.ToString("mm")) + "', seenTimePeriod = '" + db.callInsertionConnection(DateTime.Now.ToString("tt")) + "' where nic = '" + db.callInsertionConnection(reminderID) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public string upcomingReminder(string nic)
            {
                //making the reminderID to return the value
                List<string> IDs = new List<string>();
                List<string> reminderYear = new List<string>();
                List<string> reminderMonth = new List<string>();
                List<string> reminderDay = new List<string>();
                List<string> reminderMinute = new List<string>();
                List<string> remindHour = new List<string>();

                //connecting to the database and getting values
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(nic) + "' and seenStatus = '" + db.callInsertionConnection("notseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if ((int.Parse(DateTime.Now.ToString("yyyy")) < int.Parse(db.callReturnConnection(db.reader.GetString("remYear")))) || (((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remYear")))) && (int.Parse(DateTime.Now.ToString("MM")) < int.Parse(db.callReturnConnection(db.reader.GetString("remMonth"))))) || ((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remYear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")))) && int.Parse(DateTime.Now.ToString("dd")) < int.Parse(db.callReturnConnection(db.reader.GetString("remDay"))))) || ((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remYear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")))) && (int.Parse(DateTime.Now.ToString("dd")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remDay")))) && (((DateTime.Now.ToString("tt") == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)) < (int.Parse(db.callReturnConnection(db.reader.GetString("remHour")))))) || ((int.Parse(DateTime.Now.ToString("mm")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remYear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")))) && (int.Parse(DateTime.Now.ToString("dd")) <= int.Parse(db.callReturnConnection(db.reader.GetString("remDay")))) && (((DateTime.Now.ToString("tt") == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)) <= (int.Parse(db.callReturnConnection(db.reader.GetString("remHour"))))) && (int.Parse(DateTime.Now.ToString("mm")) < int.Parse(db.callReturnConnection(db.reader.GetString("remMinute"))))))
                    {
                        IDs.Add(db.callReturnConnection(db.reader.GetString("ID")));
                        reminderYear.Add(db.callReturnConnection(db.reader.GetString("remYear")));
                        reminderMonth.Add(db.callReturnConnection(db.reader.GetString("remMonth")));
                        reminderDay.Add(db.callReturnConnection(db.reader.GetString("remDay")));
                        remindHour.Add(db.callReturnConnection(db.reader.GetString("remHour")));
                        reminderMinute.Add(db.callReturnConnection(db.reader.GetString("remMinute")));
                    }
                }
                db.connection.Close();

                //comparing the values we got in the list to get the least recent upcoming activity
                //sorting the years
                for (int i = 0; i < reminderYear.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < reminderYear.Count(); j++)
                    {
                        if (int.Parse(reminderYear[minIndex]) > int.Parse(reminderYear[j]))
                        {
                            minIndex = j;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(reminderYear, minIndex, i);
                        db.swapListsValues(reminderMonth, minIndex, i);
                        db.swapListsValues(reminderDay, minIndex, i);
                        db.swapListsValues(remindHour, minIndex, i);
                        db.swapListsValues(reminderMinute, minIndex, i);
                    }
                }

                //sorting months
                for (int i = 0; i < reminderMonth.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < reminderMonth.Count(); j++)
                    {
                        if ((int.Parse(reminderMonth[minIndex]) > int.Parse(reminderMonth[j])) && (reminderYear[minIndex] == reminderYear[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(reminderMonth, minIndex, i);
                        db.swapListsValues(reminderDay, minIndex, i);
                        db.swapListsValues(remindHour, minIndex, i);
                        db.swapListsValues(reminderMinute, minIndex, i);
                    }
                }

                //sorting days
                for (int i = 0; i < reminderDay.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < reminderDay.Count(); j++)
                    {
                        if ((int.Parse(reminderDay[minIndex]) > int.Parse(reminderDay[j])) && (reminderMonth[minIndex] == reminderMonth[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(reminderDay, minIndex, i);
                        db.swapListsValues(remindHour, minIndex, i);
                        db.swapListsValues(reminderMinute, minIndex, i);
                    }
                }

                //sorting hours
                for (int i = 0; i < remindHour.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < remindHour.Count(); j++)
                    {
                        if ((int.Parse(remindHour[minIndex]) > int.Parse(remindHour[j])) && (reminderDay[minIndex] == reminderDay[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(remindHour, minIndex, i);
                        db.swapListsValues(reminderMinute, minIndex, i);
                    }
                }

                //sorting minutes
                for (int i = 0; i < reminderMinute.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < reminderMinute.Count(); j++)
                    {
                        if ((int.Parse(reminderMinute[minIndex]) > int.Parse(reminderMinute[j])) && (remindHour[minIndex] == remindHour[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(reminderMinute, minIndex, i);
                    }
                }

                //returning the founded value
                return IDs[0];
            }
        }

        //database outsideContacts
        public class OutsideContacts
        {
            private string tableName = "outsideContacts";
            databases db = new databases();

            private string id = "ID";
            private string nic = "NIC";
            private string name = "name";
            private string reason = "reason";
            private string company = "company";
            private string regday = "regDay";
            private string regMonth = "regmonth";
            private string regyear = "regYear";
            private string line1 = "line1";
            private string line2 = "line2";
            private string line3 = "line3";
            private string city = "city";
            private string homeland = "homeLand";

            public void newOutSideContacts(string NIC = "", string name = "", string reason = "", string company = "", string regday = "", string regmonth = "", string regYear = "", string line1 = "", string line2 = "", string line3 = "", string city = "", string homeLand = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + NIC + "', '" + name + "', '" + reason + "', '" + company + "', '" + regday + "', '" + regmonth + "', '" + regYear + "', '" + line1 + "', '" + line2 + "', '" + line3 + "', '" + city + "', '" + homeLand + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public int countEntries(string id)
            {
                int countEntries = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                while (db.reader.Read())
                {
                    countEntries++;
                }
                db.connection.Close();
                return countEntries;
            }

            public string getEntry(string id, int returnIndex)
            {
                string entry = "";
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                while (db.reader.Read())
                {
                    switch (returnIndex)
                    {
                        case 0:
                            entry = db.callReturnConnection(db.reader.GetString(this.id));
                            break;

                        case 1:
                            entry = db.callReturnConnection(db.reader.GetString(this.nic));
                            break;

                        case 2:
                            entry = db.callReturnConnection(db.reader.GetString(this.name));
                            break;

                        case 3:
                            entry = db.callReturnConnection(db.reader.GetString(this.reason));
                            break;

                        case 4:
                            entry = db.callReturnConnection(db.reader.GetString(this.company));
                            break;

                        case 5:
                            entry = db.callReturnConnection(db.reader.GetString(this.regday));
                            break;

                        case 6:
                            entry = db.callReturnConnection(db.reader.GetString(this.regMonth));
                            break;

                        case 7:
                            entry = db.callReturnConnection(db.reader.GetString(this.regyear));
                            break;

                        case 8:
                            entry = db.callReturnConnection(db.reader.GetString(this.line1));
                            break;

                        case 9:
                            entry = db.callReturnConnection(db.reader.GetString(this.line2));
                            break;

                        case 10:
                            entry = db.callReturnConnection(db.reader.GetString(this.line3));
                            break;

                        case 11:
                            entry = db.callReturnConnection(db.reader.GetString(this.city));
                            break;

                        case 12:
                            entry = db.callReturnConnection(db.reader.GetString(this.homeland));
                            break;

                        default:
                            entry = db.callReturnConnection(db.reader.GetString(this.id));
                            break;
                    }
                }
                db.connection.Close();
                return entry;
            }
        }

        //database outSideNumbers
        public class OutsideNumbers
        {
            private string tableName = "outSideNumbers";
            databases db = new databases();
            private string phoneNumber = "phoneNumber";
            private string nic = "NIC";
            private string status = "status";

            public void newOutSideNumber(string phoneNumber = "", string NIC = "", string status = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " values ('" + phoneNumber + "', '" + NIC + "', '" + status + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public string getEntry(string nic, int requestingIndex)
            {
                string entry = "";
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.nic + " = '" + db.callInsertionConnection(nic) + "'";
                db.connection.Open();
                while (db.reader.Read())
                {
                    switch (requestingIndex)
                    {
                        case 0:
                            entry = db.callReturnConnection(db.reader.GetString(this.phoneNumber));
                            break;
                        case 1:
                            entry = db.callReturnConnection(db.reader.GetString(this.nic));
                            break;
                        case 2:
                            entry = db.callReturnConnection(db.reader.GetString(this.status));
                            break;
                        default:
                            entry = db.callReturnConnection(db.reader.GetString(this.phoneNumber));
                            break;
                    }
                }
                db.connection.Close();
                return entry;
            }
        }

        //database bloodRequest
        public class BloodRequest
        {
            private string tableName = "bloodRequest";
            databases db = new databases();

            private string id = "ID";
            private string name = "name";
            private string regBy = "reqBy";
            private string reqBloodType = "reqBloodType";
            private string reqDay = "reqDay";
            private string reqMonth = "reqMonth";
            private string requYear = "reqYear";
            private string quantity = "quantity";
            private string wantDay = "wantDay";
            private string wantMonth = "wantMonth";
            private string wantYear = "wantYear";
            private string reason = "reason";
            private string status = "status";
            private string sendingDay = "sendingDay";
            private string sendingMonth = "sendingMonth";
            private string sendingYear = "sendingYear";
            private string statusUpdatedBy = "statusUpdatedBy";
            private string decReason = "decReason";

            public void requestNewBloodRequest(string name = "", string reqBy = "", string reqBloodType = "", string reqDay = "", string reqMonth = "", string reqYear = "", string quantity = "", string wantDay = "", string wantMonth = "", string wantYear = "", string reason = "", string status = "", string statusUpdatedBy = "", string decReason = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (name, reqBy, " + this.reqBloodType + ", reqDay, reqMonth, reqYear, " + this.quantity + ", wantDay, wantMonth, wantYear, reason, status, statusUpdatedBy, decReason) values ('" + name + "', '" + reqBy + "', '" + reqBloodType + "', '" + reqDay + "', '" + reqMonth + "', '" + reqYear + "', '" + quantity + "', '" + wantDay + "', '" + wantMonth + "', '" + wantYear + "', '" + reason + "', '" + status + "', '" + statusUpdatedBy + "', '" + decReason + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }


            public string[] lastRecentRequest(string bloodID)
            {
                //creating the array
                string[] lastRequest = new string[5];

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.reqBloodType + " = '" + db.callInsertionConnection(bloodID) + "' and " + this.status + " = '" + db.callInsertionConnection("0") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    lastRequest[0] = db.callReturnConnection(db.reader.GetString(this.id));
                    lastRequest[1] = db.callReturnConnection(db.reader.GetString(this.wantDay));
                    lastRequest[2] = db.callReturnConnection(db.reader.GetString(this.wantMonth));
                    lastRequest[3] = db.callReturnConnection(db.reader.GetString(this.wantYear));
                    lastRequest[4] = db.callReturnConnection(db.reader.GetString(this.quantity));
                }
                db.connection.Close();

                //returning the value
                return lastRequest;
            }

            public bool checkID(string id)
            {
                bool isIDtrue = false;
                int idCounts = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    idCounts++;
                }
                db.connection.Close();
                if(idCounts == 1)
                {
                    isIDtrue = true;
                }

                return isIDtrue;
            }

            public int entryCount(string name = "empty")
            {
                int count = 0;

                db.createConnection();

                if(name == "empty")
                {
                    db.command.CommandText = "select * from " + this.tableName;
                }
                else
                {
                    db.command.CommandText = "select * from " + this.tableName + "where " + this.name + " = '" + db.callInsertionConnection(name) + "'";
                }
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();

                return count;
            }

            public DataTable datagidviewItems()
            {
                db.createConnection();

                db.command.CommandText = "select " + this.id + ", " + this.name + ", " + this.quantity + " from " + tableName;

                db.connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(db.command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                db.connection.Close();
                return table;
            }
            
            public string getID(string name)
            {
                string ID = "";
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.name + " = '" + db.callInsertionConnection(name) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                    ID = db.reader[this.id].ToString();
                }
                db.connection.Close();
                if(count > 1 || count == 0)
                {
                    ID = "";
                }

                return ID;
            }

            public string getEntry(string id, int requiringIndex)
            {
                string entryValue = "";

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (requiringIndex)
                    {
                        case 0:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.name));
                            break;
                        case 1:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.regBy));
                            break;
                        case 2:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.reqBloodType));
                            break;
                        case 3:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.reqDay));
                            break;
                        case 4:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.reqMonth));
                            break;
                        case 5:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.requYear));
                            break;
                        case 6:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.quantity));
                            break;
                        case 7:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.wantDay));
                            break;
                        case 8:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.wantMonth));
                            break;
                        case 9:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.wantYear));
                            break;
                        case 10:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.reason));
                            break;
                        case 11:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.status));
                            break;
                        case 12:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.sendingDay));
                            break;
                        case 13:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.sendingMonth));
                            break;
                        case 14:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.sendingYear));
                            break;
                        case 15:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.statusUpdatedBy));
                            break;
                        case 16:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.decReason));
                            break;
                        default:
                            entryValue = db.callReturnConnection(db.reader.GetString(this.name));
                            break;
                    }
                }
                db.connection.Close();

                return entryValue;
            }

            public void acceptRequest(string acceptanceId, string id)
            {
                db.createConnection();
                db.command.CommandText = "update " + this.tableName + " set value " + this.status + "= " + db.callInsertionConnection("accepted") + ", " + this.sendingDay + "= '" + db.callInsertionConnection(DateTime.Now.ToString("dd")) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(DateTime.Now.ToString("MM")) + "', " + this.sendingYear + "= '" + db.callInsertionConnection(DateTime.Now.ToString("yyyy")) + "', " + this.statusUpdatedBy + " = '" + id + "', where '" + this.id + "'= '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void declineRequest(string declineId, string id, string reasong = "")
            {
                db.createConnection();
                db.command.CommandText = "update " + this.tableName + " set value " + this.status + "= " + db.callInsertionConnection("declined") + ", " + this.sendingDay + "= '" + db.callInsertionConnection(DateTime.Now.ToString("dd")) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(DateTime.Now.ToString("MM")) + "', " + this.sendingYear + "= '" + db.callInsertionConnection(DateTime.Now.ToString("yyyy")) + "', " + this.statusUpdatedBy + " = '" + id + "', " + this.decReason + "= '" + db.callInsertionConnection(reason) + "', where '" + this.id + "'= '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void updateTable(string Id, int updatingIndex, string name = "", string reqBy = "", string reqBloodType = "", string reqDay = "", string reqMonth = "", string reqYear = "", string quantity = "", string wantDay = "", string wantMonth = "", string wantYear = "", string reason = "", string status = "", string sendingDay = "", string sendingMonth = "", string sendingYear = "", string statusUpdatedBy = "", string decReason = "")
            {
                db.createConnection();
                switch (updatingIndex)
                {
                    case 0:
                        db.command.CommandText = "udpate " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.regBy + " = '" + db.callInsertionConnection(reqBy) + "', " + this.reqBloodType + " = '" + db.callInsertionConnection(reqBloodType) + "', " + this.reqDay + " = '" + db.callInsertionConnection(reqDay) + "', " + this.reqMonth + " = '" + db.callInsertionConnection(reqMonth) + "', " + this.requYear + " = '" + db.callInsertionConnection(reqYear) + "', " + this.quantity + " = '" + db.callInsertionConnection(quantity) + "', " + this .wantDay + " = '" + db.callInsertionConnection(wantDay) + "', " + this.wantMonth + " = '" + db.callInsertionConnection(wantMonth) + "', " + this.wantYear + " = '" + db.callInsertionConnection(wantYear) + "', " + this.reason + " = '" + db.callInsertionConnection(reason) + "', " + this.status + " = '" + db.callInsertionConnection(status) + "', " + this.sendingDay + " = '" + db.callInsertionConnection(sendingDay) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(sendingMonth) + "', " + this.sendingYear + " = '" + db.callInsertionConnection(sendingYear) + "', " + this.statusUpdatedBy + " = '" + db.callInsertionConnection(statusUpdatedBy) + "', " + this.decReason + " = '" + db.callInsertionConnection(decReason) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;

                        //updating the seding date
                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + sendingDay + " = '" + db.callInsertionConnection(sendingDay) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(sendingMonth) + "', " + this.sendingYear + " = '" + db.callInsertionConnection(sendingYear) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;

                    //declining the request
                    case 2:
                        db.command.CommandText = "update " + this.tableName + " set " + this.decReason + " = '" + db.callInsertionConnection(decReason) + "',  " + this.status + " = '" + db.callInsertionConnection("declined") + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;

                    //aceept the request
                    case 3:
                        db.command.CommandText = "update " + this.tableName + " set " + this.status + " = '" + db.callInsertionConnection("accepted") + "', " + this.sendingYear + " = '" + db.callInsertionConnection(sendingYear) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(sendingMonth) + "', " + this.sendingDay + " = '" + db.callInsertionConnection(sendingDay) + "', where " + this.id + " = '" + db.callInsertionConnection(Id) + "'";
                        break;

                    //delete the request
                    case 4:
                        db.command.CommandText = "update " + this.tableName + " set " + this.status + " = '" + db.callInsertionConnection("deleted") + "', where " + this.id + " = '" + db.callInsertionConnection(Id) + "'";
                        break;

                    default:
                        db.command.CommandText = "udpate " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.regBy + " = '" + db.callInsertionConnection(reqBy) + "', " + this.reqBloodType + " = '" + db.callInsertionConnection(reqBloodType) + "', " + this.reqDay + " = '" + db.callInsertionConnection(reqDay) + "', " + this.reqMonth + " = '" + db.callInsertionConnection(reqMonth) + "', " + this.requYear + " = '" + db.callInsertionConnection(reqYear) + "', " + this.quantity + " = '" + db.callInsertionConnection(quantity) + "', " + this.wantDay + " = '" + db.callInsertionConnection(wantDay) + "', " + this.wantMonth + " = '" + db.callInsertionConnection(wantMonth) + "', " + this.wantYear + " = '" + db.callInsertionConnection(wantYear) + "', " + this.reason + " = '" + db.callInsertionConnection(reason) + "', " + this.status + " = '" + db.callInsertionConnection(status) + "', " + this.sendingDay + " = '" + db.callInsertionConnection(sendingDay) + "', " + this.sendingMonth + " = '" + db.callInsertionConnection(sendingMonth) + "', " + this.sendingYear + " = '" + db.callInsertionConnection(sendingYear) + "', " + this.statusUpdatedBy + " = '" + db.callInsertionConnection(statusUpdatedBy) + "', " + this.decReason + " = '" + db.callInsertionConnection(decReason) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database acessoryDetails
        public class AcessoryDetails
        {
            private string tableName = "acessoryDetails";
            databases db = new databases();

            private string id = "ID";
            private string name = "name";
            private string contity = "contitiy";
            private string sellerId = "sellerID";
            private string description = "description";
            private string regBy = "regby";
            private string regDay = "regDay";
            private string regMonth = "regMonth";
            private string regYear = "regyear";
            private string expDay = "expDay";
            private string expMonth = "expMonth";
            private string expYear = "expYear";

            public void registerNewAcessory(string name = "", string contitiy = "", string sellerID = "", string description = "", string regby = "", string regDay = "", string regMonth = "", string regYear = "", string expDay = "", string expMonth = "", string expYear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (" + this.name + ", " + this.contity + ", " + this.sellerId + ", " + this.description + ", " + this.regBy + ", " + this.regDay + ", " + this.regMonth + ", " + this.regYear + ", " + this.expDay + ", " + this.expMonth + ", " + this.expYear + ") values ('" + name + "', '" + contitiy + "', '" + sellerID + "', '" + description + "', '" + regby + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + expDay + "', '" + expMonth + "', '" + expYear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public DataTable datagidviewItems(string id, int requiredParameter)
            {
                db.createConnection();

                //changing the commandtext according to the requriedparameter
                switch (requiredParameter)
                {
                    case 0:
                        db.command.CommandText = "select * from " + tableName + "";
                        break;

                    case 1:
                        db.command.CommandText = "select * from " + tableName + " where " + this.name + " = packet";
                        break;

                    case 2:
                        db.command.CommandText = "select * from " + tableName + " where " + this.name + " = injection";
                        break;

                    case 3:
                        db.command.CommandText = "select * from " + tableName + " where " + this.name + " + papers";
                        break;

                    case 4:
                        db.command.CommandText = "select " + this.name + " from " + this.tableName;
                        break;

                    default:
                        db.command.CommandText = "select * from " + tableName + "";
                        break;
                }

                db.connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(db.command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                db.connection.Close();
                return table;
            }

            public int checkAvailableEntries(string id)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }

            public int countEntries()
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                return count;
            }

            public string getID(string name)
            {
                int count = 0;
                string id = "";
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.name + " = '" + db.callInsertionConnection(name) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                    id = db.callReturnConnection(db.reader.GetString(this.id));
                }
                db.connection.Close();
                if (count > 1)
                {
                    id = "";
                }
                return id;
            }

            public string getAnEntry(string id, int returningIndex)
            {
                int entryCount = checkAvailableEntries(id);
                string entry = "";
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if (entryCount == 1)
                    {
                        switch (returningIndex)
                        {
                            case 0:
                                entry = db.callReturnConnection(db.reader.GetString("name"));
                                break;
                            case 1:
                                entry = db.callReturnConnection(db.reader.GetString("contitiy"));
                                break;
                            case 2:
                                entry = db.callReturnConnection(db.reader.GetString("sellerID"));
                                break;
                            case 3:
                                entry = db.callReturnConnection(db.reader.GetString("description"));
                                break;
                            case 4:
                                entry = db.callReturnConnection(db.reader.GetString("regby"));
                                break;
                            case 5:
                                entry = db.callReturnConnection(db.reader.GetString("regDay"));
                                break;
                            case 6:
                                entry = db.callReturnConnection(db.reader.GetString("regMonth"));
                                break;
                            case 7:
                                entry = db.callReturnConnection(db.reader.GetString("regyear"));
                                break;
                            case 8:
                                entry = db.callReturnConnection(db.reader.GetString("expDay"));
                                break;
                            case 9:
                                entry = db.callReturnConnection(db.reader.GetString("expMonth"));
                                break;
                            case 10:
                                entry = db.callReturnConnection(db.reader.GetString("expYear"));
                                break;
                            case 11:
                                entry = db.callReturnConnection(db.reader.GetString(this.id));
                                break;
                            default:
                                entry = db.callReturnConnection(db.reader.GetString("name"));
                                break;
                        }
                    }
                }
                db.connection.Close();
                return entry;
            }

            public int checkId(string id)
            {
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if(count == 0)
                {
                    count = -1;
                }
                else if(count == 1)
                {
                    count = 0;
                }
                else
                {
                    count = 1;
                }
                return count;
            }

            public void updateAnEntry(string id, int updatingIndex, string name = "", string quantity = "", string sellderId = "", string description = "", string regBy = "", string regMonth = "", string regYear = "", string expDay = "", string expMonth = "", string expYear = "")
            {
                db.createConnection();
                switch (updatingIndex)
                {
                    case 0:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.contity + " = '" + db.callInsertionConnection(quantity) + "', " + this.sellerId + " = '" + db.callInsertionConnection(sellerId) + "', " + this.description + " = '" + db.callInsertionConnection(description) + "', " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "', " + this.expDay + " = '" + db.callInsertionConnection(regMonth) + "', " + this.regYear + " = '" + db.callInsertionConnection(expDay) + "', " + this.expDay + " = '" + db.callInsertionConnection(expMonth) + "', " + this.expYear + " = '" + db.callInsertionConnection(expYear) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;

                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + this.contity + " = '" + db.callInsertionConnection(quantity) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                    default:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.contity + " = '" + db.callInsertionConnection(quantity) + "', " + this.sellerId + " = '" + db.callInsertionConnection(sellerId) + "', " + this.description + " = '" + db.callInsertionConnection(description) + "', " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "', " + this.expDay + " = '" + db.callInsertionConnection(regMonth) + "', " + this.regYear + " = '" + db.callInsertionConnection(expDay) + "', " + this.expDay + " = '" + db.callInsertionConnection(expMonth) + "', " + this.expYear + " = '" + db.callInsertionConnection(expYear) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database bloodLog
        public class BloodLog
        {
            private string tableName = "bloodLog";
            databases db = new databases();

            private string id = "ID";
            private string name = "name";
            private string bloodType = "bloodType";
            private string regDay = "regDay";
            private string regMonth = "regMonth";
            private string regYear = "regYear";
            private string regHour = "regHour";
            private string regMinute = "regMinute";
            private string regBy = "regBy";
            private string packetOwner = "packetOwner";
            private string donDay = "donDay";
            private string donMonth = "donMonth";
            private string donYear = "donYear";
            private string donHour = "donHour";
            private string donMinute = "donMinute";
            private string contitiy = "contity";
            private string campID = "campID";
            private string takenBy = "takenBy";
            private string packetID = "packetID";
            private string city = "city";
            private string resDay = "resDay";
            private string resMonth = "resMonth";
            private string resYear = "resYear";

            public void registerNewBloodLog(string name = "", string bloodType = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string regBy = "", string packetOwner = "", string donDay = "", string donMonth = "", string donYear = "", string donHour = "", string donMinute = "", string contity = "", string campID = "", string takenBy = "", string packetID = "", string city = "", string resDay = "", string resMonth = "", string resYear = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (name, " + this.bloodType + ", regDay, regMonth, regYear, regHour, regMinute, regBy, packetOwner, donDay, donMonth, donYear, donHour, donMinute, " + this.contitiy + ", campID, takenBy, packetID, city, resDay, resMonth, resYear) values ('" + name + "', '" + bloodType + "', '" + regDay + "', '" + regMonth + "', '" + regYear + "', '" + regHour + "', '" + regMinute + "', '" + regBy + "', '" + packetOwner + "', '" + donDay + "', '" + donMonth + "', '" + donYear + "', '" + donHour + "', '" + donMinute + "', '" + contity + "', '" + campID + "', '" + takenBy + "', '" + packetID + "', '" + city + "', '" + resDay + "', '" + resMonth + "', '" + resYear + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public void updateEntries(string id, int updatingIndex, string name = "", string bloodType = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string regBy = "", string packetOwner = "", string donDay = "", string donMonth = "", string donYear = "", string donHour = "", string donMinute = "", string contity = "", string campID = "", string takenBy = "", string packetID = "", string city = "", string resDay = "", string resMonth = "", string resYear = "")
            {
                db.createConnection();

                switch (updatingIndex)
                {
                    //updating all the entries
                    case 0:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.bloodType + " = '" + db.callInsertionConnection(bloodType) + "', " + this.regDay + " = '" + db.callInsertionConnection(regDay) + "', " + this.regMonth + " = '" + db.callInsertionConnection(regMonth) + "', " + this.regYear + " = '" + db.callInsertionConnection(regYear) + "', " + this.regHour + " = '" + db.callInsertionConnection(regHour) + "', " + this.regMinute + " = '" + db.callInsertionConnection(regMinute) + "', " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "', " + this.packetOwner + " = '" + db.callInsertionConnection(packetOwner) + "', " + this.donDay + " = '" + db.callInsertionConnection(donDay) + "', " + this.donMonth + " = '" + db.callInsertionConnection(donMonth) + "', " + this.donYear + " = '" + db.callInsertionConnection(donYear) + "', " + this.donHour + " = '" + db.callInsertionConnection(donHour) + "', " + this.donMinute + " = '" + db.callInsertionConnection(donMinute) + "', " + this.contitiy + " = '" + db.callInsertionConnection(contitiy) + "', " + this.campID + " = '" + db.callInsertionConnection(campID) + "', " + this.takenBy + " = '" + db.callInsertionConnection(takenBy) + "', " + this.packetID + " = '" + db.callInsertionConnection(packetID) + "', " + this.city + " = '" + db.callInsertionConnection(city) + "', " + this.resDay + " = '" + db.callInsertionConnection(resDay) + "', " + this.resMonth + " = '" + db.callInsertionConnection(resMonth) + "', " + this.resYear + " = '" + db.callInsertionConnection(resYear) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the name
                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the blood type
                    case 2:
                        db.command.CommandText = "update " + this.tableName + " set " + this.bloodType + " = '" + db.callInsertionConnection(bloodType) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the registration day
                    case 3:
                        db.command.CommandText = "update " + this.regDay + " = '" + db.callInsertionConnection(regDay) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the regmonth
                    case 4:
                        db.command.CommandText = "update " + this.regMonth + " = '" + db.callInsertionConnection(regMonth) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the reg year
                    case 5:
                        db.command.CommandText = "update " + this.regYear + " = '" + db.callInsertionConnection(regYear) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the reghour
                    case 6:
                        db.command.CommandText = "update " + this.regHour + " = '" + db.callInsertionConnection(regHour) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the regminute
                    case 7:
                        db.command.CommandText = "update " + this.regMinute + " = '" + db.callInsertionConnection(regMinute) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the regby entry
                    case 8:
                        db.command.CommandText = "update " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the packet owner field
                    case 9:
                        db.command.CommandText = "update " + this.packetOwner + " = '" + db.callInsertionConnection(packetOwner) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updatint the donated day
                    case 10:
                        db.command.CommandText = "update " + this.donDay + " = '" + db.callInsertionConnection(donDay) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the donated month
                    case 11:
                        db.command.CommandText = "update " + this.donMonth + " = '" + db.callInsertionConnection(donMonth) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the don year
                    case 12:
                        db.command.CommandText = "update " + this.donYear + " = '" + db.callInsertionConnection(donYear) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the don hour
                    case 13:
                        db.command.CommandText = "update " + this.donHour + " = '" + db.callInsertionConnection(donHour) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the don minute
                    case 14:
                        db.command.CommandText = "update " + this.donMinute + " = '" + db.callInsertionConnection(donMinute) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the contity
                    case 15:
                        db.command.CommandText = "update " + this.contitiy + " = '" + db.callInsertionConnection(contitiy) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the campid
                    case 16:
                        db.command.CommandText = "update " + this.campID + " = '" + db.callInsertionConnection(campID) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the taken by field
                    case 17:
                        db.command.CommandText = "update " + this.takenBy + " = '" + db.callInsertionConnection(takenBy) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the packetID
                    case 18:
                        db.command.CommandText = "update " + this.packetID + " = '" + db.callInsertionConnection(packetID) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the city
                    case 19:
                        db.command.CommandText = "update " + this.city + " = '" + db.callInsertionConnection(city) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the reserved day
                    case 20:
                        db.command.CommandText = "update " + this.resDay + " = '" + db.callInsertionConnection(resDay) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the reserved month
                    case 21:
                        db.command.CommandText = "update " + this.resMonth + " = '" + db.callInsertionConnection(resMonth) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //updating the rserved year
                    case 22:
                        db.command.CommandText = "update " + this.resYear + " = '" + db.callInsertionConnection(resYear) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                        //once again updating all the entires
                    default:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.bloodType + " = '" + db.callInsertionConnection(bloodType) + "', " + this.regDay + " = '" + db.callInsertionConnection(regDay) + "', " + this.regMonth + " = '" + db.callInsertionConnection(regMonth) + "', " + this.regYear + " = '" + db.callInsertionConnection(regYear) + "', " + this.regHour + " = '" + db.callInsertionConnection(regHour) + "', " + this.regMinute + " = '" + db.callInsertionConnection(regMinute) + "', " + this.regBy + " = '" + db.callInsertionConnection(regBy) + "', " + this.packetOwner + " = '" + db.callInsertionConnection(packetOwner) + "', " + this.donDay + " = '" + db.callInsertionConnection(donDay) + "', " + this.donMonth + " = '" + db.callInsertionConnection(donMonth) + "', " + this.donYear + " = '" + db.callInsertionConnection(donYear) + "', " + this.donHour + " = '" + db.callInsertionConnection(donHour) + "', " + this.donMinute + " = '" + db.callInsertionConnection(donMinute) + "', " + this.contitiy + " = '" + db.callInsertionConnection(contitiy) + "', " + this.campID + " = '" + db.callInsertionConnection(campID) + "', " + this.takenBy + " = '" + db.callInsertionConnection(takenBy) + "', " + this.packetID + " = '" + db.callInsertionConnection(packetID) + "', " + this.city + " = '" + db.callInsertionConnection(city) + "', " + this.resDay + " = '" + db.callInsertionConnection(resDay) + "', " + this.resMonth + " = '" + db.callInsertionConnection(resMonth) + "', " + this.resYear + " = '" + db.callInsertionConnection(resYear) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                }
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public bool checkID(string id)
            {
                bool isIdAvailable = false;
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();
                if(count == 1)
                {
                    isIdAvailable = true;
                }

                return isIdAvailable;
            }

            public string getAnEntry(string id, int returnIndex)
            {
                string entry = "";

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    switch (returnIndex)
                    {
                        case 0:
                            entry = db.callReturnConnection(db.reader.GetString(this.name));
                            break;
                        case 1:
                            entry = db.callReturnConnection(db.reader.GetString(this.bloodType));
                            break;
                        case 2:
                            entry = db.callReturnConnection(db.reader.GetString(this.regDay));
                            break;
                        case 3:
                            entry = db.callReturnConnection(db.reader.GetString(this.regMonth));
                            break;
                        case 4:
                            entry = db.callReturnConnection(db.reader.GetString(this.regYear));
                            break;
                        case 5:
                            entry = db.callReturnConnection(db.reader.GetString(this.regHour));
                            break;
                        case 6:
                            entry = db.callReturnConnection(db.reader.GetString(this.regMinute));
                            break;
                        case 7:
                            entry = db.callReturnConnection(db.reader.GetString(this.regBy));
                            break;
                        case 8:
                            entry = db.callReturnConnection(db.reader.GetString(this.packetOwner));
                            break;
                        case 9:
                            entry = db.callReturnConnection(db.reader.GetString(this.donDay));
                            break;
                        case 10:
                            entry = db.callReturnConnection(db.reader.GetString(this.donMonth));
                            break;
                        case 11:
                            entry = db.callReturnConnection(db.reader.GetString(this.donYear));
                            break;
                        case 12:
                            entry = db.callReturnConnection(db.reader.GetString(this.donHour));
                            break;
                        case 13:
                            entry = db.callReturnConnection(db.reader.GetString(this.donMinute));
                            break;
                        case 14:
                            entry = db.callReturnConnection(db.reader.GetString(this.contitiy));
                            break;
                        case 15:
                            entry = db.callReturnConnection(db.reader.GetString(this.campID));
                            break;
                        case 16:
                            entry = db.callReturnConnection(db.reader.GetString(this.takenBy));
                            break;
                        case 17:
                            entry = db.callReturnConnection(db.reader.GetString(this.packetID));
                            break;
                        case 18:
                            entry = db.callReturnConnection(db.reader.GetString(this.city));
                            break;
                        case 19:
                            entry = db.callReturnConnection(db.reader.GetString(this.resDay));
                            break;
                        case 20:
                            entry = db.callReturnConnection(db.reader.GetString(this.resMonth));
                            break;
                        case 21:
                            entry = db.callReturnConnection(db.reader.GetString(this.resYear));
                            break;
                        default:
                            entry = db.callReturnConnection(db.reader.GetString(this.name));
                            break;
                    }
                }
                db.connection.Close();

                return entry;
            }

            public int bloodContityAnalyzer(string bloodID)
            {
                //defining the contity storing variable
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName + " where " + this.bloodType + " = '" + db.callInsertionConnection(bloodID) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if (db.callReturnConnection(db.reader.GetString(this.resYear)) != "0000")
                    {
                        count += int.Parse(db.callReturnConnection(db.reader.GetString(this.contitiy)));
                    }
                }
                db.connection.Close();

                //returning the final stored value
                return count;
            }

            public void deleteRecord(string id)
            {
                db.createConnection();
                db.command.CommandText = "delete from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public DataTable loadData()
            {
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;

                db.connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = db.command;
                DataTable table = new DataTable();
                adapter.Fill(table);
                db.connection.Close();

                return table;
            }

            public List<List<string>> getItems(bool Id = false, bool name = false, bool bloodType = false, bool regDay = false, bool regMonth = false, bool regYear = false, bool regHour = false, bool regMinute = false, bool regBy = false, bool packetOwner = false, bool donDay = false, bool donMonth = false, bool donYear = false, bool donHour = false, bool donMinute = false, bool quantity = false, bool campId = false, bool takenBy = false, bool packetId = false, bool city = false, bool resDay = false, bool resMonth = false, bool resYear = false)
            {
                List<List<string>> values = new List<List<string>>();
                int count = 0;
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    List<string> tempList = new List<string>();
                    if (Id) { tempList.Add(db.callReturnConnection(db.reader[this.id].ToString())); }
                    if (name) { tempList.Add(db.callReturnConnection(db.reader[this.name].ToString())); }
                    if (bloodType) { tempList.Add(db.callReturnConnection(db.reader[this.bloodType].ToString())); }
                    if (regDay) { tempList.Add(db.callReturnConnection(db.reader[this.regDay].ToString())); }
                    if(regMonth) { tempList.Add(db.callReturnConnection(db.reader[this.regMonth].ToString())); }
                    if(regYear) { tempList.Add(db.callReturnConnection(db.reader[this.regYear].ToString())); }
                    if(regHour) { tempList.Add(db.callReturnConnection(db.reader[this.regHour].ToString())); }
                    if(regMinute) { tempList.Add(db.callReturnConnection(db.reader[this.regMinute].ToString())); }
                    if(regBy) { tempList.Add(db.callReturnConnection(db.reader[this.regBy].ToString())); }
                    if (packetOwner) { tempList.Add(db.callReturnConnection(db.reader[this.packetOwner].ToString())); }
                    if (donDay) { tempList.Add(db.callReturnConnection(db.reader[this.donDay].ToString())); }
                    if (donMonth) { tempList.Add(db.callReturnConnection(db.reader[this.donMonth].ToString())); }
                    if (donYear) { tempList.Add(db.callReturnConnection(db.reader[this.donYear].ToString())); }
                    if (donHour) { tempList.Add(db.callReturnConnection(db.reader[this.donHour].ToString())); }
                    if (donMinute) { tempList.Add(db.callReturnConnection(db.reader[this.donMinute].ToString())); }
                    if (quantity) { tempList.Add(db.callReturnConnection(db.reader[this.contitiy].ToString())); }
                    if (campId) { tempList.Add(db.callReturnConnection(db.reader[this.campID].ToString())); }
                    if (takenBy) { tempList.Add(db.callReturnConnection(db.reader[this.takenBy].ToString())); }
                    if (packetId) { tempList.Add(db.callReturnConnection(db.reader[this.packetID].ToString())); }
                    if (city) { tempList.Add(db.callReturnConnection(db.reader[this.city].ToString())); }
                    if (resDay) { tempList.Add(db.callReturnConnection(db.reader[this.resDay].ToString())); }
                    if (resMonth) { tempList.Add(db.callReturnConnection(db.reader[this.resMonth].ToString())); }
                    if (resYear) { tempList.Add(db.callReturnConnection(db.reader[this.resYear].ToString())); }
                    else if(!Id && !name && !bloodType && !regDay && !regMonth && !regYear && !regHour && !regMinute && !regBy && !packetOwner && !donDay && !donMonth && !donYear && !donHour && !donMinute && !quantity && !campId && !takenBy && !packetId && !city && !resDay && !resMonth && !resYear){
                        tempList.Add(db.callReturnConnection(db.reader[this.id].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.name].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.bloodType].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regDay].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regMonth].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regYear].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regHour].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regMinute].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.regBy].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.packetOwner].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.donDay].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.donMonth].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.donYear].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.donHour].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.donMinute].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.contitiy].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.campID].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.takenBy].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.packetID].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.city].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.resDay].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.resMonth].ToString()));
                        tempList.Add(db.callReturnConnection(db.reader[this.resYear].ToString()));
                    }
                    values[count] = tempList;
                    count++;
                }
                db.connection.Close();
                return values;
            }

            public void updateTable(string id, int updateIndex, string name = "", string bloodType = "", string regDay = "", string regMonth = "", string regYear = "", string regHour = "", string regMinute = "", string regBy = "", string packetOwner = "", string donDay = "", string donMonth = "", string donYear = "", string donHour = "", string donMinute = "", string quantity = "", string campId = "", string takenBy = "", string packetId = "", string city = "", string resDay = "", string resMonth = "", string resYear = "")
            {
                db.createConnection();
                switch (updateIndex)
                {
                    case 0:
                        db.command.CommandText = "update " + this.tableName + " set " + this.name + " = '" + db.callInsertionConnection(name) + "', " + this.bloodType + " = '" + db.callInsertionConnection(bloodType) + "', " + this.regDay + " = '" + db.callInsertionConnection(regDay) + "', " + this.regMonth + " = '" + db.callInsertionConnection(regMonth) + "', " + this.regYear + " = '" + db.callInsertionConnection(regYear) + "', " + this.regHour + " = '" + db.callInsertionConnection(regHour) + "', " + this.regMinute + " = '" + db.callInsertionConnection(regMinute) + "', " + this.regBy +  " = '" + db.callInsertionConnection(regBy) + "', " + this.packetOwner + " = '" + db.callInsertionConnection(packetOwner) + "', " + this.donDay + " = '" + db.callInsertionConnection(donDay) + "', " + this.donMonth + " = '" + db.callInsertionConnection(donMonth) + "', " + this.donYear + " = '" + db.callInsertionConnection(donYear) + "', " + this.donHour + " = '" + db.callInsertionConnection(donHour) + "', " + this.donMinute + " = '" + db.callInsertionConnection(donMinute) + "', " + this.contitiy + " = '" + db.callInsertionConnection(quantity) + "', " + this.campID + " = '" + db.callInsertionConnection(campID) + "', " + this.takenBy + " = '" + db.callInsertionConnection(takenBy) + "', " + this.packetID + " = '" + db.callInsertionConnection(packetId) + "', " + this.city + " = '" + db.callInsertionConnection(city) + "', " + this.resDay + " = '" + db.callInsertionConnection(resDay) + "', " + this.resMonth + " = '" + db.callInsertionConnection(resMonth) + "', " + this.resYear + " = '" + db.callInsertionConnection(resYear) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;

                    //udpating the reserved day
                    case 1:
                        db.command.CommandText = "update " + this.tableName + " set " + this.resDay + " = '" + db.callInsertionConnection(resDay) + "', " + this.resMonth + " = '" + db.callInsertionConnection(resMonth) + "', " + this.resYear + " = '" + db.callInsertionConnection(resYear) + "', where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database timetable
        public class Timetable
        {
            private string tableName = "timetable";
            databases db = new databases();

            private string id = "id";
            private string nic = "nic";
            private string heading = "heading";
            private string Event = "event";
            private string regday = "regday";
            private string regmonth = "regmonth";
            private string regyear = "regyear";
            private string reghour = "reghour";
            private string regminute = "regminute";
            private string alertday = "alertday";
            private string alertmonth = "alertmonth";
            private string alertyear = "alertyear";
            private string alertminute = "alertminute";
            private string alerthour = "alerthour";
            private string seenstatus = "seenstatus";

            public void newEvent(string nic, string heading = "", string Event = "", string regDay = "", string regMonth = "", string regyear = "", string regHour = "", string regMinute = "", string alertDay = "", string alertMonth = "", string alertYear = "", string alertHour = "", string alertMinute = "", string seenStatus = "")
            {
                nic = db.callInsertionConnection(nic);
                heading = db.callInsertionConnection(heading);
                Event = db.callReturnConnection(Event);
                regDay = db.callInsertionConnection(regDay);
                regMonth = db.callInsertionConnection(regMonth);
                regyear = db.callInsertionConnection(regyear);
                regHour = (DateTime.Now.ToString("tt").ToLower() == "am") ? (db.callInsertionConnection(regHour)) : (db.callInsertionConnection((int.Parse(regHour) + 12).ToString()));
                regMinute = db.callInsertionConnection(regMinute);
                alertDay = db.callInsertionConnection(alertDay);
                alertMonth = db.callInsertionConnection(alertMonth);
                alertYear = db.callInsertionConnection(alertYear);
                alertHour = (DateTime.Now.ToString("tt").ToLower() == "am") ? (db.callInsertionConnection(alertHour)) : (db.callInsertionConnection((int.Parse(alertHour) + 12).ToString()));
                alertMinute = db.callInsertionConnection(alertMinute);
                seenStatus = db.callInsertionConnection(seenStatus);

                db.createConnection();
                db.command.CommandText = "insert into " + tableName + " (id, nic, heading, event, regday, regmonth, regyear, reghour, regminute, regtimeperiod, alertday, alertmonth, alertyear, alertminute, alerthour, seenstatus) values ('" + nic + "', '" + heading + "', '" + Event + "', '" + regDay + "', '" + regMonth + "', '" + regyear + "', '" + regHour + "', '" + regMinute + "', '" + alertDay + "', '" + alertMonth + "', '" + alertYear + "', '" + alertMinute + "', '" + alertHour + "', '" + seenStatus + "')";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                db.connection.Close();
            }

            public List<string> unseenEvents(string nic, string requiredPrameterIndex)
            {
                //creatinga list to store required parameters
                List<string> entries = new List<string>();

                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(nic) + "' and seenstatus = '" + db.callInsertionConnection("unseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                    int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                    int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                    int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                    int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                    if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                    {
                        if (month <= int.Parse(DateTime.Now.ToString("MM")))
                        {
                            if (day <= int.Parse(DateTime.Now.ToString("dd")))
                            {
                                if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? int.Parse(DateTime.Now.ToString("hh")) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                {
                                    if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                    {
                                        switch (requiredPrameterIndex)
                                        {
                                            case "0":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("ID")));
                                                break;
                                            case "1":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("heading")));
                                                break;
                                            case "2":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("event")));
                                                break;
                                            case "3":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("regday")));
                                                break;
                                            case "4":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("regmonth")));
                                                break;
                                            case "5":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("regyear")));
                                                break;
                                            case "6":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("reghour")));
                                                break;
                                            case "7":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("regminute")));
                                                break;
                                            case "8":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("alertday")));
                                                break;
                                            case "9":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("alertmonth")));
                                                break;
                                            case "10":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("alertyear")));
                                                break;
                                            case "11":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("alertminute")));
                                                break;
                                            case "12":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("alerthour")));
                                                break;
                                            case "13":
                                                entries.Add(db.callReturnConnection(db.reader.GetString("seenstatus")));
                                                break;
                                            default:
                                                entries.Add(db.callReturnConnection(db.reader.GetString("message")));
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                db.connection.Close();

                //returning the list
                return entries;
            }

            public int unseenEventsCount(string nic)
            {
                //creatinga list to store required parameters
                int count = 0;

                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(nic) + "' and seenstatus = '" + db.callInsertionConnection("unseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    count++;
                }
                db.connection.Close();

                //returning the list
                return count;
            }

            public string[] getLastUnseenEvent(string nic)
            {
                //making an entry to store values
                string[] eventDetails = { "", "", "" };

                if (unseenEventsCount(nic) == 1)
                {
                    db.createConnection();
                    db.command.CommandText = "select * from " + tableName + " where nic = '" + db.callInsertionConnection(nic) + "' and seenstatus = '" + db.callInsertionConnection("unseen") + "'";
                    db.connection.Open();
                    db.reader = db.command.ExecuteReader();
                    while (db.reader.Read())
                    {
                        int year = int.Parse(db.callReturnConnection(db.reader.GetString("remYear")));
                        int month = int.Parse(db.callReturnConnection(db.reader.GetString("remMonth")));
                        int day = int.Parse(db.callReturnConnection(db.reader.GetString("remDay")));
                        int hour = int.Parse(db.callReturnConnection(db.reader.GetString("remHour")));
                        int minute = int.Parse(db.callReturnConnection(db.reader.GetString("remMinute")));

                        if (year <= int.Parse(DateTime.Now.ToString("yyyy")))
                        {
                            if (month <= int.Parse(DateTime.Now.ToString("MM")))
                            {
                                if (day <= int.Parse(DateTime.Now.ToString("dd")))
                                {
                                    if (hour <= ((DateTime.Now.ToString("tt").ToLower() == "am") ? int.Parse(DateTime.Now.ToString("hh")) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))
                                    {
                                        if (minute <= int.Parse(DateTime.Now.ToString("mm")))
                                        {
                                            eventDetails[0] = db.callReturnConnection(db.reader.GetString("id"));
                                            eventDetails[1] = db.callReturnConnection(db.reader.GetString("heading"));
                                            eventDetails[2] = db.callReturnConnection(db.reader.GetString("event"));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    db.connection.Close();
                }

                //returning the event
                return eventDetails;
            }

            public string[] getEventUsingID(string eventID)
            {
                //making an entry to store values
                string[] eventDetails = { "", "", "", "", "", "", "", "", "", "", "", "", "" };

                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + id + " = '" + db.callInsertionConnection(eventID) + "' and " + seenstatus + " = '" + db.callInsertionConnection("unseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    eventDetails[0] = db.callReturnConnection(db.reader.GetString(this.id));
                    eventDetails[1] = db.callReturnConnection(db.reader.GetString(this.heading));
                    eventDetails[2] = db.callReturnConnection(db.reader.GetString(this.Event));
                    eventDetails[3] = db.callReturnConnection(db.reader.GetString(this.regday));
                    eventDetails[4] = db.callReturnConnection(db.reader.GetString(this.regmonth));
                    eventDetails[5] = db.callReturnConnection(db.reader.GetString(this.regyear));
                    eventDetails[6] = db.callReturnConnection(db.reader.GetString(this.reghour));
                    eventDetails[7] = db.callReturnConnection(db.reader.GetString(this.regminute));
                    eventDetails[8] = db.callReturnConnection(db.reader.GetString(this.alertday));
                    eventDetails[9] = db.callReturnConnection(db.reader.GetString(this.alertmonth));
                    eventDetails[10] = db.callReturnConnection(db.reader.GetString(this.alertyear));
                    eventDetails[11] = db.callReturnConnection(db.reader.GetString(this.alerthour));
                    eventDetails[12] = db.callReturnConnection(db.reader.GetString(this.alertminute));
                }
                db.connection.Close();

                //returning the event
                return eventDetails;
            }

            public string upcomingEvent(string nic)
            {
                //making the reminderID to return the value
                List<string> IDs = new List<string>();
                List<string> alertYear = new List<string>();
                List<string> alertMonth = new List<string>();
                List<string> alertDay = new List<string>();
                List<string> alertHour = new List<string>();
                List<string> alertMinute = new List<string>();

                //connecting to the database and getting values
                db.createConnection();
                db.command.CommandText = "select * from " + tableName + " where " + id + " = '" + db.callInsertionConnection(nic) + "' and " + seenstatus + " = '" + db.callInsertionConnection("notseen") + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    if ((int.Parse(DateTime.Now.ToString("yyyy")) < int.Parse(db.callReturnConnection(db.reader.GetString("alertyear")))) || (((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertyear")))) && (int.Parse(DateTime.Now.ToString("MM")) < int.Parse(db.callReturnConnection(db.reader.GetString("alertmonth"))))) || ((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertyear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertmonth")))) && int.Parse(DateTime.Now.ToString("dd")) < int.Parse(db.callReturnConnection(db.reader.GetString("alertday"))))) || ((int.Parse(DateTime.Now.ToString("yyyy")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertyear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertmonth")))) && (int.Parse(DateTime.Now.ToString("dd")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertday")))) && (((DateTime.Now.ToString("tt") == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)) < (int.Parse(db.callReturnConnection(db.reader.GetString("alerthour")))))) || ((int.Parse(DateTime.Now.ToString("mm")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertyear")))) && (int.Parse(DateTime.Now.ToString("MM")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertmonth")))) && (int.Parse(DateTime.Now.ToString("dd")) <= int.Parse(db.callReturnConnection(db.reader.GetString("alertday")))) && (((DateTime.Now.ToString("tt") == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)) <= (int.Parse(db.callReturnConnection(db.reader.GetString("alerthour"))))) && (int.Parse(DateTime.Now.ToString("mm")) < int.Parse(db.callReturnConnection(db.reader.GetString("alertminute"))))))
                    {
                        IDs.Add(db.callReturnConnection(db.reader.GetString("id")));
                        alertYear.Add(db.callReturnConnection(db.reader.GetString("alertyear")));
                        alertMonth.Add(db.callReturnConnection(db.reader.GetString("alertmonth")));
                        alertDay.Add(db.callReturnConnection(db.reader.GetString("alertday")));
                        alertHour.Add(db.callReturnConnection(db.reader.GetString("alerthour")));
                        alertMinute.Add(db.callReturnConnection(db.reader.GetString("alertminute")));
                    }
                }
                db.connection.Close();

                //comparing the values we got in the list to get the least recent upcoming activity
                //sorting the years
                for (int i = 0; i < alertYear.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < alertYear.Count(); j++)
                    {
                        if (int.Parse(alertYear[minIndex]) > int.Parse(alertYear[j]))
                        {
                            minIndex = j;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(alertYear, minIndex, i);
                        db.swapListsValues(alertMonth, minIndex, i);
                        db.swapListsValues(alertDay, minIndex, i);
                        db.swapListsValues(alertHour, minIndex, i);
                        db.swapListsValues(alertMinute, minIndex, i);
                    }
                }

                //sorting months
                for (int i = 0; i < alertMonth.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < alertMonth.Count(); j++)
                    {
                        if ((int.Parse(alertMonth[minIndex]) > int.Parse(alertMonth[j])) && (alertYear[minIndex] == alertYear[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(alertMonth, minIndex, i);
                        db.swapListsValues(alertDay, minIndex, i);
                        db.swapListsValues(alertHour, minIndex, i);
                        db.swapListsValues(alertMinute, minIndex, i);
                    }
                }

                //sorting days
                for (int i = 0; i < alertDay.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < alertDay.Count(); j++)
                    {
                        if ((int.Parse(alertDay[minIndex]) > int.Parse(alertDay[j])) && (alertMonth[minIndex] == alertMonth[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(alertDay, minIndex, i);
                        db.swapListsValues(alertHour, minIndex, i);
                        db.swapListsValues(alertMinute, minIndex, i);
                    }
                }

                //sorting hours
                for (int i = 0; i < alertHour.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < alertHour.Count(); j++)
                    {
                        if ((int.Parse(alertHour[minIndex]) > int.Parse(alertHour[j])) && (alertDay[minIndex] == alertDay[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(alertHour, minIndex, i);
                        db.swapListsValues(alertMinute, minIndex, i);
                    }
                }

                //sorting minutes
                for (int i = 0; i < alertMinute.Count() - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < alertMinute.Count(); j++)
                    {
                        if ((int.Parse(alertMinute[minIndex]) > int.Parse(alertMinute[j])) && (alertHour[minIndex] == alertHour[j]))
                        {
                            minIndex = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (minIndex != i)
                    {
                        db.swapListsValues(IDs, minIndex, i);
                        db.swapListsValues(alertMinute, minIndex, i);
                    }
                }

                //returning the founded value
                return IDs[0];
            }
        }

        //database acessoryReservation
        public class AcessoryReservation
        {
            private string tableName = "acessoryReservation";
            databases db = new databases();

            private string id = "id";
            private string acessoryId = "acessoryId";
            private string description = "description";
            private string rservedDay = "resrvedDay";
            private string reservedMonth = "reservedMonth";
            private string reservedYear = "reservedYear";
            private string reservedMinute = "reservedMinute";
            private string reservedHour = "reservedHour";
            private string wantDay = "wantDay";
            private string wantMonth = "wantMonth";
            private string wantYear = "wantYear";
            private string wantMinute = "wantMinute";
            private string wantHour = "wantHour";
            private string reserveddBy = "resrvedBy";
            private string reason = "reason";
            private string quantity = "quantity";

            public void newAcessoryReservation(string acessoryId, string reaservedDay, string reservedMonth, string reservedYear, string reservedMinute, string reservedHour, string wantDay, string wantMonth, string wantYear, string wantMinute, string wantHour, string reservedBy, string reason, string quantity, string description = "")
            {
                db.createConnection();
                db.command.CommandText = "insert into " + this.tableName + " values(" + this.acessoryId + ", " + this.description + ", " + this.rservedDay + ", " + this.reservedMonth + ", " + this.reservedYear + ", " + this.reservedMinute + ", " + this.reservedHour + ", " + this.wantDay + ", " + this.wantMonth + ", " + this.wantYear + ", " + this.wantMinute + ", " + this.wantHour + ", " + this.reserveddBy + ", " + this.reason + ") values(" + db.callInsertionConnection(acessoryId) + ", " + db.callInsertionConnection(description) + ", " + db.callInsertionConnection(reaservedDay) + ", " + db.callInsertionConnection(reservedMonth) + ", " + db.callInsertionConnection(reservedYear) + ", " + db.callInsertionConnection(reservedMinute) + ", " + db.callInsertionConnection(reservedHour) + ", " + db.callInsertionConnection(wantDay) + ", " + db.callInsertionConnection(wantMonth) + ", " + db.callInsertionConnection(wantYear) + ", " + db.callInsertionConnection(wantMinute) + ", " + db.callInsertionConnection(wantHour) + ", " + db.callInsertionConnection(reservedBy) + ", " + db.callInsertionConnection(reason) + ", " + db.callInsertionConnection(quantity) + ")";
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public List<List<string>> getItems()
            {
                List<List<string>> items = new List<List<string>>();
                
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    List<string> tempList = new List<string>();
                    tempList.Add(db.callReturnConnection(db.reader[this.id].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.acessoryId].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.description].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.rservedDay].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reservedMonth].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reservedYear].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reservedMinute].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reservedHour].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.wantDay].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.wantMonth].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.wantYear].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.wantMinute].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.wantHour].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reserveddBy].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.reason].ToString()));
                    tempList.Add(db.callReturnConnection(db.reader[this.quantity].ToString()));
                    items.Add(tempList);
                }
                db.connection.Close();

                return items;
            }

            public List<List<string>> getItemsByAcessoryId(string acessoryId, bool isId = false, bool isacessoryID = false, bool isdescription = false, bool isreservedDay = false, bool isreservedMonth = false, bool isreservedYear = false, bool isreservedMinute = false, bool isreservedHour = false, bool iswantDay = false, bool iswantMonth = false, bool iswantYear = false, bool iswantMinute = false, bool iswantHour = false, bool isreservedBy = false, bool isreason = false, bool isquantity = false)
            {
                List<List<string>> items = new List<List<string>>();
                db.createConnection();
                db.command.CommandText = "select * from " + this.tableName;
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                for (int i = 0;  db.reader.Read(); i++)
                {
                    List<string> tempItems = new List<string>();
                    if (isId) { tempItems.Add(db.callReturnConnection(db.reader[this.id].ToString())); }
                    if (isacessoryID) { tempItems.Add(db.callReturnConnection(db.reader[this.acessoryId].ToString())); }
                    if (isdescription) { tempItems.Add(db.callReturnConnection(db.reader[this.description].ToString())); }
                    if (isreservedDay) { tempItems.Add(db.callReturnConnection(db.reader[this.rservedDay].ToString())); }
                    if (isreservedMonth) { tempItems.Add(db.callReturnConnection(db.reader[this.reservedMonth].ToString())); }
                    if (isreservedYear) { tempItems.Add(db.callReturnConnection(db.reader[this.reservedYear].ToString())); }
                    if (isreservedHour) { tempItems.Add(db.callReturnConnection(db.reader[this.reservedHour].ToString())); }
                    if (isreservedMinute) { tempItems.Add(db.callReturnConnection(db.reader[this.reservedMinute].ToString())); }
                    if (iswantDay) { tempItems.Add(db.callReturnConnection(db.reader[this.wantDay].ToString())); }
                    if (iswantMonth) { tempItems.Add(db.callReturnConnection(db.reader[this.wantMonth].ToString())); }
                    if (iswantYear) { tempItems.Add(db.callReturnConnection(db.reader[this.wantYear].ToString())); }
                    if (iswantHour) { tempItems.Add(db.callReturnConnection(db.reader[this.wantHour].ToString())); }
                    if (iswantMinute) { tempItems.Add(db.callReturnConnection(db.reader[this.wantMinute].ToString())); }
                    if (isreservedBy) { tempItems.Add(db.callReturnConnection(db.reader[this.reserveddBy].ToString())); }
                    if (isreason) { tempItems.Add(db.callReturnConnection(db.reader[this.reason].ToString())); }
                    if (isquantity) { tempItems.Add(db.callReturnConnection(db.reader[this.quantity].ToString())); }
                    else if(!isId && !isacessoryID && !isdescription && !isreservedDay && !!isreservedMonth &&!isreservedYear && !isreservedHour && !isreservedMinute && !iswantDay && !iswantMonth && !iswantYear && !iswantHour && !iswantMinute && !isreservedBy && !isreason && !isquantity)
                    {
                        tempItems.Add(db.callReturnConnection(db.reader[this.id].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.acessoryId].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.description].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.rservedDay].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reservedMonth].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reservedYear].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reservedHour].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reservedMinute].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.wantDay].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.wantMonth].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.wantYear].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.wantHour].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.wantMinute].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reserveddBy].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.reason].ToString()));
                        tempItems.Add(db.callReturnConnection(db.reader[this.quantity].ToString()));
                    }
                    items[i] = tempItems; 
                }
                db.connection.Close();
                return items;
            }

            public void updateTable(string id, int queryIndex, string acessoryId = "", string description = "", string reservedDay = "", string reservedMonth = "", string reservedYear = "", string reservedHour = "", string reservedMinute = "", string wantDay = "", string wantMonth = "", string wantYear = "", string wantHour = "", string wantMinute = "", string reservedBy = "", string reason = "", string quantity = "")
            {
                db.createConnection();
                switch (queryIndex)
                {
                    case 0:
                        db.command.CommandText = "udpate " + this.tableName + " set " + this.description + " = '" + db.callInsertionConnection(description) + "', " + this.wantDay + " = '" + db.callInsertionConnection(wantDay) + "', " + this.wantMonth + " = '" + db.callInsertionConnection(wantMonth) + "', " + this.wantYear + " = '" + db.callInsertionConnection(wantYear) + "', " + this.wantHour + " = '" + db.callInsertionConnection(wantHour) + "', " + this.wantMinute + " = '" + db.callInsertionConnection(wantMinute) + "', " + this.reason + " = '" + db.callInsertionConnection(reason) + "', " + this.quantity + " = '" + db.callInsertionConnection(quantity) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                    default:
                        db.command.CommandText = "udpate " + this.tableName + " set " + this.description + " = '" + db.callInsertionConnection(description) + "', " + this.wantDay + " = '" + db.callInsertionConnection(wantDay) + "', " + this.wantMonth + " = '" + db.callInsertionConnection(wantMonth) + "', " + this.wantYear + " = '" + db.callInsertionConnection(wantYear) + "', " + this.wantHour + " = '" + db.callInsertionConnection(wantHour) + "', " + this.wantMinute + " = '" + db.callInsertionConnection(wantMinute) + "', " + this.reason + " = '" + db.callInsertionConnection(reason) + "', " + this.quantity + " = '" + db.callInsertionConnection(quantity) + "' where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                        break;
                }
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public void deleteItem(string id)
            {
                db.createConnection();
                db.command.CommandText = "delete from " + this.tableName + " where " + this.id + " = '" + db.callInsertionConnection(id) + "'";
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }
        }

        //database acessorySellersDetails
        public class AcessorySellersDetails
        {
            private string tableName = "acessorySellersDetails";
            databases db = new databases();

            private string id = "id";
            private string sellerId = "sellerId";
            private string acessoryId = "acessoryId";
            private string rate = "rate";

            public void newAcessorySellerRegistration(string sellerId, string acessoryId)
            {
                db.createConnection();
                db.command.CommandText = "insert into " + this.tableName + " (" + this.sellerId + ", " + this.acessoryId + ", " + this.rate + ") values ('" + db.callInsertionConnection(sellerId) + "', '" + db.callInsertionConnection(acessoryId) + "')";
                db.connection.Open();
                db.command.ExecuteNonQuery();
                db.connection.Close();
            }

            public List<List<string>> getSellerIdWithPrice(string acessoryId)
            {
                List<List<string>> sellerIds = new List<List<string>>();
                db.createConnection();
                db.command.CommandText = "select " + this.sellerId + " from " + this.tableName + " where " + this.acessoryId + " = '" + db.callInsertionConnection(acessoryId) + "'";
                db.connection.Open();
                db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                    List<string> newList = new List<string>();
                    newList.Add(db.callReturnConnection(db.reader[this.sellerId].ToString()));
                    newList.Add(db.callReturnConnection(db.reader[this.rate].ToString()));
                    sellerIds.Add(newList);
                }
                db.connection.Close();

                return sellerIds;
            }
        }
    }

}
