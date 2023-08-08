using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

//using DevExpress.XtraEditors;
//using HMS.Classes.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
//
//using HMS.Classes.Common;
using System.Globalization;
using System.Diagnostics;
using System.Reflection;
using System.Management;
//using DevExpress.XtraGrid.Views.Grid;
//using DevExpress.XtraGrid.Columns;
//using DevExpress.XtraSplashScreen;
using System.Net.NetworkInformation;
using System.Web.UI.WebControls;
namespace MySiteNew
{
    public class Clas_main
    {







        
            #region GLOBL PREFERENCES

            public static string Product_Name = "HMS_UNANI";
            public static string Config_Licence_File = "CONFIG_LICENCE.txt";
            public static string Config_Date_File = "CONFIG_DATE.txt";
            public static string Config_Licence_To_File = "CONFIG_LICENCE_TO.txt";
            public static string Config_Verion_File = "CONFIG_VERSION.txt";
            public static string Config_Online_Method_File = "CONFIG_ONLINE_METHOD.txt";

            public static string Report_Footer = "Software Generated Report Developed By SHARIZ TECH. PVT. LTD. ✆9145140097,✆9028131796, ☎02554-294005";

            public static string Config_Online_Method = "OFFLINE";

            public static string EncryptionKey = "بِسْمِ اللَّهِ الرَّحْمَنِ الرَّحِيم";
            public static string Config_Path = @"C:\HMS\";
            public static string Licence_To = "SHARIZ";
            public static bool Backup_Online = true;
            public static string Licence_Key = "";
            public static string Activation_Key = "";
            public static DateTime Valid_Upto;
            public static bool _32_Bit = false;
            public static string Report_Path = @"C:\HMS\Reports\";

            public static string Version = "";

            public static bool Hospital_Module = true;
            public static bool ERP_Module = true;
            public static bool Billing_Module = true;
            public static bool Group_Module = true;
            public static bool Production_Module = true;
            public static bool Banking_Module = true;

            #endregion

            #region LOGIN DETAIL
            public static string User_Initial = "ADM";
            public static string User_Password = "secure";
            public static string User_Name = "Mohammad Shafeeque";
            public static long User_Id = 000000000;
            public static bool Is_Power_User = true;
            public static string User_Machine_Name = "WIN7PC";
            public static string User_Ip_Adress = "192.168.10.253";
            public static string User_Mac_Address = "A3:B1:C1:F5:C5:B3";
            #endregion

            #region SMS API 

            public static bool SMS_Module = false;
            public static string SMS_API_Provider = "Nimbus";
            public static string SMS_API_Entity_ID = "1201160025284505389";
            public static string SMS_API_Sender_ID = "SHARIZ";
            public static string SMS_API_Template_ID = "1207161865547584813";

            public static string SMS_API_User_ID = "t1SHARIZTECH";
            public static string SMS_API_Password = "Shariztech@7033";
            public static int SMS_API_Balance = 0;
            public static string SMS_API_Date = "31/03/2021";

            #endregion

            #region SQL Server Name
            public static string SQL_Server_Name = ".";
            public static string DB_Name = "MashrooMart_db";
            public static string SQL_Server_User_Name = "sa";
            public static string SQL_Server_Password = "admin@123";
            #endregion

            private static readonly DateTimeFormatInfo UkDtfi = new CultureInfo("en-GB", false).DateTimeFormat;

            private static SqlCommand Cmd;


            public static string Conn_String = "Data Source=" + SQL_Server_Name + ";Initial Catalog=" + DB_Name + ";User ID=" + SQL_Server_User_Name + ";password=" + SQL_Server_Password + "; ";



            public static SqlConnection Conn = new SqlConnection(Conn_String);

            public static bool ValidateAdmin(string username)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_Admin where username=" + username + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }

            public static bool ValidateAdmin(string username, string pass)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_Admin where username=" + username + " and password=" + pass + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public static bool ValidateAdminKey(string username, string key)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_Admin where username=" + username + " and key=" + key + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public static bool ValidateUser(string username)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_User where username=" + username + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public static bool ValidateUser(string username, string pass)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_User where username=" + username + " and password=" + pass + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            public static bool ValidateUserKey(string username, string key)
            {
                try
                {
                    Open_Connection();
                    DataTable dt = Read_Table("select username from nil_User where username=" + username + " and key=" + key + "");
                    if (dt.Rows.Count == 1)
                    {
                        return true;
                    }
                    Close_Connection();
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }

            }
            internal static bool Open_Connection()
            {
                try
                {
                    if (Conn.State == ConnectionState.Closed || Conn.State == ConnectionState.Broken)
                    {
                        Conn.Open();
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }

            internal static void Close_Connection()
            {
                try
                {
                    Conn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            internal static void Set_Connections()
            {
                Conn = new SqlConnection(Conn_String);
            }

            internal static void Get_Global_Preferences()
            {
                DataRow[] result;

                DataTable DT_Preferences = Read_Table("SELECT * FROM CM_PREFERENCES ");

                result = DT_Preferences.Select("Key_Name = 'SMS_API'");
                foreach (DataRow row in result)
                {
                    string SMS = Decrypt(row["string_value"].ToString());
                    if (SMS == "TRUE")
                    {
                        SMS_Module = true;
                    }
                    else
                    {
                        SMS_Module = false;
                    }

                    break;
                }

                result = DT_Preferences.Select("Key_Name = 'SMS_API_BALANCE'");
                foreach (DataRow row in result)
                {
                    SMS_API_Balance = Convert.ToInt32(Decrypt(row["string_value"].ToString()));
                    break;
                }

                result = DT_Preferences.Select("Key_Name = 'SMS_API_DATE'");
                foreach (DataRow row in result)
                {
                    SMS_API_Date = Decrypt(row["string_value"].ToString());
                    break;
                }

            }

            internal static bool Get_Module_Preferences(string Function_Type)
            {
                SqlDataReader Drd;
                Cmd = new SqlCommand("SELECT * FROM LM_SOFTWARE_PREFRENCES WHERE function_name = '" + Encrypt(Function_Type) + "' AND function_type = '" + Encrypt(Function_Type) + "' AND is_selected ='" + Encrypt("TRUE") + "'", Conn);

                Drd = Cmd.ExecuteReader();
                if (Drd.Read())
                {
                    Drd.Close();
                    return true;
                }
                else
                {
                    Drd.Close();
                    return false;
                }
            }

            internal static string Encrypt(string Clear_Text)
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(Clear_Text);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        Clear_Text = Convert.ToBase64String(ms.ToArray());
                    }
                }
                return Clear_Text;
            }

            internal static string Decrypt(string Cipher_Text)
            {
                byte[] cipherBytes = Convert.FromBase64String(Cipher_Text);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        Cipher_Text = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
                return Cipher_Text;
            }


            public static bool Is_Internet_Connected()
            {
                try
                {
                    IPHostEntry ipHe = Dns.GetHostEntry("www.google.com");
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            internal static string Get_Config_Path()
            {
                if (!Debugger.IsAttached)
                {
                    var Path = new Uri(Assembly.GetEntryAssembly().GetName().CodeBase);
                    return new FileInfo(Path.AbsolutePath).Directory.FullName;
                }
                else
                {
                    return "";
                }
            }

            internal static string Encode(string Text)
            {
                if (string.IsNullOrEmpty(Text))
                {
                    return Text;
                }

                byte[] textBytes = Encoding.UTF8.GetBytes(Text);
                return Convert.ToBase64String(textBytes);
            }





            internal static bool Check_Rights(string Function_Name, string Function_Type)
            {
                bool return_value = false;

                if (Open_Connection())
                {
                    Cmd = new SqlCommand("SELECT * FROM CM_USER_RIGHTS WHERE function_name = '" + Function_Name + "' AND function_type = '" + Function_Type + "' AND user_initial = '" + Clas_main.User_Initial + "'", Conn);

                    var Drd = Cmd.ExecuteReader();

                    switch (Function_Type)
                    {
                        case "SECTION":
                        case "MODULE":
                        case "FUNCTION":
                            if (Drd.Read())
                            {
                                Drd.Close();
                                return_value = true;
                            }
                            else
                            {
                                Drd.Close();
                                return_value = false;
                            }
                            break;

                        case "VIEW":
                        case "ADD":
                        case "EDIT":
                        case "DELETE":
                        case "PRINT":
                        case "PREVIEW":

                            if (Drd.Read())
                            {
                                Drd.Close();
                                return_value = false;
                            }
                            else
                            {
                                Drd.Close();
                                return_value = true;
                            }
                            break;

                        default:
                            Drd.Close();
                            return_value = false;
                            break;
                    }
                }

                return return_value;
            }

            internal static DataTable Read_Table(string Query)
            {
                try
                {
                    DataTable Dt = new DataTable();
                    Cmd = new SqlCommand(Query, Conn);
                    Cmd.CommandTimeout = 0;
                    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                    Da.Fill(Dt);
                    return Dt;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            internal static DataTable Read_Table(string Query, SqlTransaction Trans)
            {
                try
                {
                    DataTable Dt = new DataTable();
                    Cmd = new SqlCommand(Query, Conn, Trans);
                    SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                    Da.Fill(Dt);
                    return Dt;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            internal static DataTable Read_Table_With_Dates(string Query, DateTime Date_Upto)
            {
                var Dt = new DataTable();
                Cmd = new SqlCommand(Query, Conn) { CommandTimeout = 0 };
                Cmd.Parameters.AddWithValue("@date", Date_Upto);
                var Da = new SqlDataAdapter(Cmd);
                Da.Fill(Dt);
                return Dt;
            }

            internal static dynamic Read_Single_Value(string Query, SqlTransaction Trans)
            {
                Cmd = new SqlCommand(Query, Conn, Trans)
                {
                    CommandTimeout = 0
                };

                dynamic Return_Value = (dynamic)Cmd.ExecuteScalar();

                if (Return_Value == null)
                {
                    Return_Value = 0;
                }

                return Return_Value;
            }

            internal static dynamic Read_Single_Value(string Query)
            {
                Open_Connection();

                Cmd = new SqlCommand(Query, Conn)
                {
                    CommandTimeout = 0
                };

                dynamic Return_Value = (dynamic)Cmd.ExecuteScalar();

                if (Return_Value == null)
                {
                    Return_Value = 0;
                }

                return Return_Value;
            }

            internal static dynamic Read_Single_Value(string Query, DateTime Date_Upto)
            {
                Open_Connection();

                Cmd = new SqlCommand(Query, Conn) { CommandTimeout = 0 };
                Cmd.Parameters.AddWithValue("@date", Date_Upto);

                dynamic Return_Value = (dynamic)Cmd.ExecuteScalar();

                if (Return_Value == null)
                {
                    Return_Value = 0;
                }

                return Return_Value;
            }

            internal static string Number_To_Words_Rupees(int Number)
            {
                if (Number == 0)
                    return "Zero";

                if (Number < 0)
                    return "Minus " + Number_To_Words_Rupees(Math.Abs(Number));

                string Words = "";

                if ((Number / 1000000) > 0)
                {
                    Words += Number_To_Words_Rupees(Number / 1000000) + " Million ";
                    Number %= 1000000;
                }

                if ((Number / 100000) > 0)
                {
                    Words += Number_To_Words_Rupees(Number / 100000) + " Lakh ";
                    Number %= 100000;
                }
                if ((Number / 1000) > 0)
                {
                    Words += Number_To_Words_Rupees(Number / 1000) + " Thousand ";
                    Number %= 1000;
                }

                if ((Number / 100) > 0)
                {
                    Words += Number_To_Words_Rupees(Number / 100) + " Hundred ";
                    Number %= 100;
                }

                if (Number > 0)
                {
                    if (Words != "")
                        Words += "and ";

                    var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                    var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                    if (Number < 20)
                        Words += unitsMap[Number];
                    else
                    {
                        Words += tensMap[Number / 10];
                        if ((Number % 10) > 0)
                            Words += "-" + unitsMap[Number % 10];
                    }
                }

                return Words;
            }

            internal static string Number_To_Words_Rupees(string Number)
            {
                String Val = "", Whole_No = Number, Points = "", And_Str = "", Point_Str = "";
                String End_Str = ("Rupees Only.");

                try
                {
                    int Decimal_Place = Number.IndexOf(".");

                    if (Decimal_Place > 0)
                    {
                        Whole_No = Number.Substring(0, Decimal_Place);
                        Points = Number.Substring(Decimal_Place + 1);
                        if (Convert.ToInt32(Points) > 0)
                        {
                            And_Str = (" and ");// just to separate whole numbers from points/Rupees                  

                            And_Str += Translate_Whole_Number(Points).Trim() + " Paise";
                        }
                    }
                    Val = string.Format("{0} {1}{2} {3}", Translate_Whole_Number(Whole_No).Trim(), And_Str, Point_Str, End_Str);
                }
                catch
                {
                    ;
                }
                return Val;
            }

            internal static string Translate_Whole_Number(string Number)
            {
                string Word = "";
                try
                {
                    bool Begins_Zero = false;//tests for 0XX
                    bool Is_Done = false;//test if already translated
                    double Dbl_Amt = (Convert.ToDouble(Number));

                    if (Dbl_Amt > 0)

                    {//test for zero or digit zero in a nuemric
                        Begins_Zero = Number.StartsWith("0");
                        int Num_Digits = Number.Length;
                        int Pos = 0;//store digit grouping
                        String Place = "";//digit grouping name:hundres,thousand,etc...
                        switch (Num_Digits)
                        {
                            case 1://ones' range
                                Word = Transalte_Ones(Number);
                                Is_Done = true;
                                break;
                            case 2://tens' range
                                Word = Translate_Tens(Number);
                                Is_Done = true;
                                break;
                            case 3://hundreds' range
                                Pos = (Num_Digits % 3) + 1;
                                Place = " Hundred ";
                                break;
                            case 4://thousands' range
                            case 5:
                                Pos = (Num_Digits % 4) + 1;
                                Place = " Thousand ";
                                break;
                            case 6:
                            case 7://millions' range
                                Pos = (Num_Digits % 6) + 1;
                                // place = " Million ";
                                Place = " Lakh ";

                                break;
                            case 8:
                            case 9:
                            case 10://Billions's range
                                Pos = (Num_Digits % 8) + 1;
                                Place = " Core ";
                                break;
                            //add extra case options for anything above Billion...
                            default:
                                Is_Done = true;
                                break;
                        }
                        if (!Is_Done)
                        {//if transalation is not done, continue...(Recursion comes in now!!)
                            if (Begins_Zero) Place = "";
                            Word = Translate_Whole_Number(Number.Substring(0, Pos)) + Place + Translate_Whole_Number(Number.Substring(Pos));
                            //check for trailing zeros
                            if (Begins_Zero) Word = " and " + Word.Trim();
                        }
                        //ignore digit grouping names
                        if (Word.Trim().Equals(Place.Trim())) Word = "";
                    }
                }

                catch
                {
                    ;
                }
                return Word.Trim();
            }

            internal static string Translate_Tens(string Digit)
            {
                int Digt = Convert.ToInt32(Digit);

                String name = null;

                switch (Digt)
                {
                    case 10:
                        name = "Ten";
                        break;
                    case 11:
                        name = "Eleven";
                        break;
                    case 12:
                        name = "Twelve";
                        break;
                    case 13:
                        name = "Thirteen";
                        break;
                    case 14:
                        name = "Fourteen";
                        break;
                    case 15:
                        name = "Fifteen";
                        break;
                    case 16:
                        name = "Sixteen";
                        break;
                    case 17:
                        name = "Seventeen";
                        break;
                    case 18:
                        name = "Eighteen";
                        break;
                    case 19:
                        name = "Nineteen";
                        break;
                    case 20:
                        name = "Twenty";
                        break;
                    case 30:
                        name = "Thirty";
                        break;
                    case 40:
                        name = "Fourty";
                        break;
                    case 50:
                        name = "Fifty";
                        break;
                    case 60:
                        name = "Sixty";
                        break;
                    case 70:
                        name = "Seventy";
                        break;
                    case 80:
                        name = "Eighty";
                        break;
                    case 90:
                        name = "Ninety";
                        break;
                    default:
                        if (Digt > 0)
                        {
                            name = Translate_Tens(Digit.Substring(0, 1) + "0") + " " + Transalte_Ones(Digit.Substring(1));
                        }

                        break;
                }
                return name;
            }

            internal static string Transalte_Ones(string Digit)
            {
                int digt = Convert.ToInt32(Digit);
                String name = "";
                switch (digt)
                {
                    case 1:
                        name = "One";
                        break;
                    case 2:
                        name = "Two";
                        break;
                    case 3:
                        name = "Three";
                        break;
                    case 4:
                        name = "Four";
                        break;
                    case 5:
                        name = "Five";
                        break;
                    case 6:
                        name = "Six";
                        break;
                    case 7:
                        name = "Seven";
                        break;
                    case 8:
                        name = "Eight";
                        break;
                    case 9:
                        name = "Nine";
                        break;
                }

                return name;

            }



            public static void Get_Local_Machine_Info(out string Machine_Name, out string IP_Address, out string Mac_Address)
            {
                // Machine Name
                Machine_Name = Environment.MachineName;
                IP_Address = "0.0.0.0";
                Mac_Address = string.Empty;

                // IP Address
                string strHostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

                foreach (IPAddress ipAddress in ipEntry.AddressList)
                {
                    if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP_Address = ipAddress.ToString();
                    }
                }

                // MAC Address
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                {
                    if (Mac_Address == String.Empty) // only return MAC Address from first card
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        Mac_Address = adapter.GetPhysicalAddress().ToString();
                    }
                }
            }

            //internal static DataTable Convert_Grid_To_DataTable(GridView Param_Grid)
            //{
            //    DataTable DT_Grid = new DataTable();
            //    foreach (GridColumn column in Param_Grid.Columns)
            //    {
            //        DT_Grid.Columns.Add(column.FieldName, column.ColumnType);
            //    }
            //    for (int i = 0; i < Param_Grid.DataRowCount; i++)
            //    {
            //        DataRow row = DT_Grid.NewRow();
            //        foreach (GridColumn column in Param_Grid.Columns)
            //        {
            //            row[column.FieldName] = Param_Grid.GetRowCellValue(i, column);
            //        }
            //        DT_Grid.Rows.Add(row);
            //    }

            //    return DT_Grid;
            //}

            //internal static int Count_Checked_Records(GridView Grid, string Column_Name)
            //{
            //    int Count = 0;
            //    for (int i = 0; i < Grid.DataRowCount; i++)
            //    {
            //        if ((bool)Grid.GetRowCellValue(i, Column_Name))
            //        {
            //            Count++;
            //        }
            //    }
            //    return Count;
            //}

            internal static void TDS_Calculation(decimal _Total, decimal _TDS_Rate, out decimal _Total_TDS, out decimal _Total_Exc_TDS)
            {
                if (_TDS_Rate > 0)
                {

                    _Total_TDS = Math.Round(_Total * Convert.ToDecimal(_TDS_Rate) / 100);
                    _Total_Exc_TDS = _Total - _Total_TDS;
                }
                else
                {

                    _Total_TDS = 0;
                    _Total_Exc_TDS = _Total - _Total_TDS;
                }
            }

            internal static DataTable Read_Table(object p)
            {
                throw new NotImplementedException();
            }

            internal static bool ValidateAdmin(string text1, object text2)
            {
                throw new NotImplementedException();
            }
  



}
}