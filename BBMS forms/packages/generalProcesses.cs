using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data;

namespace BBMS_forms.packages
{
    public static class GlobalAcceass
    {
        public static string companyName = "BBMS";
    }

    public static class globalStorage
    {
        public static List<List<string>> acessoryReservation = new List<List<string>>();
    }

    public static class HistoryPages
    {
        public static List<string> stack = new List<string>();
        public static string currentPage = "";
        public static int top = 0;

        public static void add(string page)
        {
            if(currentPage == stack[top])
            {
                currentPage = page;
            }
            else if(currentPage != "" && currentPage != stack[top])
            {
                stack.Add(currentPage);
                currentPage = page;
                top++;
            }
            else
            {
                currentPage = page;
            }
        }
        
        public static void getMeBack()
        {
            string lastPage = stack[top];
            currentPage = "";
            stack.Remove(stack[top--]);
            new generalProcesses().getBackProcess(lastPage);
        }
    }

    class generalProcesses
    {
        public int getPercentage(int numenator, int denomenator)
        {
            return (numenator / denomenator) * 100;
        }

        public DataTable ListToTable(List<List<string>> convertingValues, List<string> columnValues)
        {
            DataTable returningValue = new DataTable();

            for(int i = 0; i < columnValues.Count; i++)
            {
                returningValue.Columns.Add(columnValues[i]);
            }

            for(int i = 0; i < convertingValues.Count; i++)
            {
                List<string> tempList = convertingValues[i];
                DataRow row = returningValue.NewRow();
                for(int j = 0; j < tempList.Count; j++)
                {
                    row[j] = tempList[j];
                }
                returningValue.Rows.Add(row);
            }

            return returningValue;
        }
        public string formalizeNumbers(string number)
        {
            int sentNumber = int.Parse(number), multiplier = 1, count = 0;
            string formalizedVersion = "";
            
            while(sentNumber / 10 != 0)
            {
                if(sentNumber == 0)
                {
                    break;
                }
                if(count == 2)
                {
                    formalizedVersion = "," + formalizedVersion;
                    count = 0;
                    continue;
                }
                formalizedVersion = (sentNumber % 10).ToString() + formalizedVersion;
                sentNumber /= 10;
                count++;
            }

            return formalizedVersion;
        }

        public bool checkDateWithMonth(string month, string day)
        {
            int integerMonth = int.Parse(month), integerDay = int.Parse(day);

            switch (integerMonth)
            {
                case 1: return (integerDay < 32 ? true : false);
                case 2: return (int.Parse(DateTime.Now.ToString("yyyy")) % 4 == 0 ? (integerDay < 30 ? true : false) : (integerDay < 29 ? true : false));
                case 3: return (integerDay < 32 ? true : false);
                case 4: return (integerDay < 31 ? true : false);
                case 5: return (integerDay < 32 ? true : false);
                case 6: return (integerDay < 31 ? true : false);
                case 7: return (integerDay < 32 ? true : false);
                case 8: return (integerDay < 32 ? true : false);
                case 9: return (integerDay < 31 ? true : false);
                case 10: return (integerDay < 32 ? true : false);
                case 11: return (integerDay < 31 ? true : false);
                case 12: return (integerDay < 32 ? true : false);
                default: return false;
            }
        }
        public int endDayOfMonth()
        {
            int month = int.Parse(DateTime.Now.ToString("MM"));

            switch (month)
            {
                case 01: return 31;
                case 02: return (int.Parse(DateTime.Now.ToString("yyyy")) % 4 == 0) ? (29) : (28);
                case 03: return 31;
                case 04: return 30;
                case 05: return 31;
                case 06: return 30;
                case 07: return 31;
                case 08: return 31;
                case 09: return 30;
                case 10: return 31;
                case 11: return 30;
                default: return 31;
            }
        }
        public string[] availablePositions()
        {
            string[] positions = {
                "Manager", 
                "Head - PHI", 
                "PHI", 
                "Doctor", 
                "Lab specialist", 
                "Head - Nurse", 
                "Nurse", 
                "Cleaner"
            };
            return positions;
        }

        public void pastingFiles(string filePath, string savingPath)
        {
            File.Copy(savingPath, filePath + "//" + Path.GetFileName(savingPath));
        }

        public void signInMove(string position)
        {
            if(position == "manager")
            {
                ManagerDashboard dashboard = new ManagerDashboard();
                dashboard.Show();
            }
            else if(position == "phi")
            {
                PHI phi = new PHI();
                phi.Show();
            }
            else if(position == "nurse")
            {
                Nurse nurse = new Nurse();
                nurse.Show();
            }
            else if(position == "headnurse")
            {
                Main_Nurse nurse = new Main_Nurse();
                nurse.Show();
            }
            else if(position == "doctor")
            {
                Doctor doctor = new Doctor();
                doctor.Show();
            }
        }

        public void getBackProcess(string form)
        {
            //all available forms
            //Doctor Donorhome frm_acessoryDetails frm_acessoryRegistration frm_applyLeave frm_attendanceRegistry frm_bloodCategorizationReport frm_bloodRequest frm_bloodRequestAcceptance frm_bloodStock frm_DoctorSettings frm_donorList frm_generalHomePage 

            if(form == "Doctor")
            {
                Doctor doctor = new Doctor();
                doctor.Show();
            }
            else if (form == "frm_acessoryDetails")
            {
                frm_acessoryDetails doctor = new frm_acessoryDetails();
                doctor.Show();
            }
            else if (form == "frm_acessoryRegistration")
            {
                frm_acessoryRegistration doctor = new frm_acessoryRegistration();
                doctor.Show();
            }
            else if (form == "frm_applyLeave")
            {
                frm_applyLeave doctor = new frm_applyLeave();
                doctor.Show();
            }
            else if (form == "frm_attendanceRegistry")
            {
                frm_attendanceRegistry doctor = new frm_attendanceRegistry();
                doctor.Show();
            }
            else if (form == "frm_bloodCategorizationReport")
            {
                frm_bloodCategorizationReport doctor = new frm_bloodCategorizationReport();
                doctor.Show();
            }
            else if (form == "frm_bloodRequest")
            {
                frm_bloodRequest doctor = new frm_bloodRequest();
                doctor.Show();
            }
            else if (form == "frm_bloodRequestAcceptance")
            {
                frm_bloodRequestAcceptance doctor = new frm_bloodRequestAcceptance();
                doctor.Show();
            }
            else if (form == "frm_bloodStock")
            {
                frm_bloodStock doctor = new frm_bloodStock();
                doctor.Show();
            }
            else if (form == "frm_DoctorSettings")
            {
                frm_DoctorSettings doctor = new frm_DoctorSettings();
                doctor.Show();
            }
            else if (form == "frm_donorList")
            {
                frm_donorList doctor = new frm_donorList();
                doctor.Show();
            }
            else if (form == "frm_generalHomePage")
            {
                frm_generalHomePage doctor = new frm_generalHomePage();
                doctor.Show();
            }
            //frm_logHistory frm_mainNurseSettings frm_managerMeetings frm_managerSettings frm_meetingArrangements frm_messages frm_newBloodGroupRegistration frm_newCampOrganization frm_newDonorRegistration 
            else if (form == "frm_logHistory")
            {
                frm_logHistory doctor = new frm_logHistory();
                doctor.Show();
            }
            else if (form == "frm_mainNurseSettings")
            {
                frm_mainNurseSettings doctor = new frm_mainNurseSettings();
                doctor.Show();
            }
            else if (form == "frm_managerMeetings")
            {
                frm_managerMeetings doctor = new frm_managerMeetings();
                doctor.Show();
            }
            else if (form == "frm_managerSettings")
            {
                frm_managerSettings doctor = new frm_managerSettings();
                doctor.Show();
            }
            else if (form == "frm_meetingArrangements")
            {
                frm_meetingArrangements doctor = new frm_meetingArrangements();
                doctor.Show();
            }
            else if (form == "frm_messages")
            {
                frm_messages doctor = new frm_messages();
                doctor.Show();
            }
            else if (form == "frm_newBloodGroupRegistration")
            {
                frm_newBloodGroupRegistration doctor = new frm_newBloodGroupRegistration();
                doctor.Show();
            }
            else if (form == "frm_newCampOrganization")
            {
                frm_newCampOrganization doctor = new frm_newCampOrganization();
                doctor.Show();
            }
            else if (form == "frm_newDonorRegistration")
            {
                frm_newDonorRegistration doctor = new frm_newDonorRegistration();
                doctor.Show();
            }

            //frm_nurseSettings frm_outsideContancts frm_packetHistory frm_packetProcessing frm_phiSettings frm_phoneRegistry frm_registerNewBloodReport frm_reminders frm_requestCamp 
            else if (form == "frm_nurseSettings")
            {
                frm_nurseSettings doctor = new frm_nurseSettings();
                doctor.Show();
            }
            else if (form == "frm_outsideContancts")
            {
                frm_outsideContancts doctor = new frm_outsideContancts();
                doctor.Show();
            }
            else if (form == "frm_packetHistory")
            {
                frm_packetHistory doctor = new frm_packetHistory();
                doctor.Show();
            }
            else if (form == "frm_packetProcessing")
            {
                frm_packetProcessing doctor = new frm_packetProcessing();
                doctor.Show();
            }
            else if (form == "frm_phiSettings")
            {
                frm_phiSettings doctor = new frm_phiSettings();
                doctor.Show();
            }
            else if (form == "frm_phoneRegistry")
            {
                frm_phoneRegistry doctor = new frm_phoneRegistry();
                doctor.Show();
            }
            else if (form == "frm_registerNewBloodReport")
            {
                frm_registerNewBloodReport doctor = new frm_registerNewBloodReport();
                doctor.Show();
            }
            else if (form == "frm_reminders")
            {
                frm_reminders doctor = new frm_reminders();
                doctor.Show();
            }
            else if (form == "frm_requestCamp")
            {
                frm_requestCamp doctor = new frm_requestCamp();
                doctor.Show();
            }
            //frm_signLevel3 frm_signUpLevel2 frm_signUpLevel4 frm_signUpLevel5 frm_staffAllocation frm_timeTable frm_todoList Login 
            else if (form == "frm_signLevel3")
            {
                frm_signLevel3 doctor = new frm_signLevel3();
                doctor.Show();
            }
            else if (form == "frm_signUpLevel2")
            {
                frm_signUpLevel2 doctor = new frm_signUpLevel2();
                doctor.Show();
            }
            else if (form == "frm_signUpLevel4")
            {
                frm_signUpLevel4 doctor = new frm_signUpLevel4();
                doctor.Show();
            }
            else if (form == "frm_signUpLevel5")
            {
                frm_signUpLevel5 doctor = new frm_signUpLevel5();
                doctor.Show();
            }
            else if (form == "frm_staffAllocation")
            {
                frm_staffAllocation doctor = new frm_staffAllocation();
                doctor.Show();
            }
            else if (form == "frm_todoList")
            {
                frm_todoList doctor = new frm_todoList();
                doctor.Show();
            }
            else if (form == "Login")
            {
                Login doctor = new Login();
                doctor.Show();
            }
            //Main Nurse ManagerDashboard Nurse PHI Program SignUp
            else if (form == "Main")
            {
                Doctor doctor = new Doctor();
                doctor.Show();
            }
            else if (form == "Nurse")
            {
                Nurse doctor = new Nurse();
                doctor.Show();
            }
            else if (form == "ManagerDashboard")
            {
                ManagerDashboard doctor = new ManagerDashboard();
                doctor.Show();
            }
            else if (form == "Nurse")
            {
                Nurse doctor = new Nurse();
                doctor.Show();
            }
            else if (form == "Program")
            {
                Doctor doctor = new Doctor();
                doctor.Show();
            }
            else if (form == "SignUp")
            {
                SignUp doctor = new SignUp();
                doctor.Show();
            }
        }

        public string Encrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(getSingleHash()));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        public string Decrypt(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(getSingleHash()));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        private string getSingleHash()
        {
            return "@DIURH_2F0I2V3E08#A_S_S_I_G_N_M_E_N_T";
        }
    }
}
