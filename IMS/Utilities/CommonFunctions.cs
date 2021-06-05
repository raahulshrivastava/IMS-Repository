using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace IMS.Utilities
{
    public class CommonFunctions
    {
        public static DateTime GetFixDateFormat(string date)
        {
            try
            {
                //  DateTime dt = DateTime.Now;
                if (date != null)
                {
                    return DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    return Convert.ToDateTime(null);
                }

            }
            catch (Exception)
            {
                return Convert.ToDateTime(null);
            }
        }

        public static string GetYesNo(object val)
        {
            if (val.ToString() == "1" || val.ToString().ToUpper() == "YES" || val.ToString().ToUpper() == "TRUE" || val.ToString().ToUpper() == "Y")
                return "Y";
            else
                return "N";
        }
        public static string GetYesNoCom(object val)
        {
            if (val.ToString() == "1" || val.ToString().ToUpper() == "YES" || val.ToString().ToUpper() == "TRUE" || val.ToString().ToUpper() == "Y")
                return "Yes";
            else
                return "No";
        }

        public static int Get1or2(object val)
        {
            if (val.ToString().ToUpper() == "YES" || val.ToString().ToUpper() == "TRUE" || val.ToString().ToUpper() == "Y")
                return 1;
            else
                return 0;
        }

        public static int GetintFromBoll(object val)
        {
            if (val.ToString().ToUpper() == "YES" || val.ToString().ToUpper() == "TRUE" || val.ToString().ToUpper() == "Y")
                return 1;
            else
                return 0;
        }
        public static bool GetBooleanFromYN(object val)
        {
            if (val.ToString() == "Y" || val.ToString() == "1")
                return true;
            else
                return false;
        }
       

        public static String GetRandomNumber(Int32 numberLenght)
        {
            Random random = new Random();
            String randomNumber = "";
            for (Int32 index = 0; index < numberLenght; index++)
            {
                randomNumber = string.Concat(randomNumber, random.Next(9).ToString());
            }
            return randomNumber;
        }

        public static Boolean IsNumeric(String value)
        {
            try
            {
                Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(value.Trim());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean IsDate(String value)
        {
            try
            {
                DateTime dt = Convert.ToDateTime(value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool IsValidEmailAddress(string emailAddress)
        {
            try
            {

                MailAddress m = new MailAddress(emailAddress, emailAddress);
                string MatchEmailPattern =
                            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                     + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                     + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                     + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
                if (emailAddress != null)
                    return Regex.IsMatch(emailAddress, MatchEmailPattern);
                else
                    return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static bool IsValidMobileNumber(string mobileNumber)
        {
            try
            {
                if (mobileNumber.Length == 10)
                {
                    if (!mobileNumber.StartsWith("0"))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string GenerateRandomPassword()
        {
            int length = 8;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static string GetNullCheckString(object txt)
        {
            if (txt != null && txt.ToString().Length > 0)
                return txt.ToString();
            else
                return string.Empty;
        }

        public static Int32 GetNullCheckInteger(object val)
        {
            if (val != null && val.ToString().Length > 0)
                return Convert.ToInt32(val);
            else
                return 0;
        }
        public static char GetNullCheckChar(object txt)
        {
            if (txt != null && txt.ToString().Length > 0)
                return Convert.ToChar(txt);
            else
                return '0';
        }
        public static Decimal GetNullCheckDecimal(object val)
        {
            if (val != null && val.ToString().Length > 0)
                return Convert.ToDecimal(val);
            else
                return 0;
        }

        public static dynamic GetNullCheckLong(object val)
        {
            if (val != null && val.ToString().Length > 0)
                return Convert.ToInt64(val);
            else
                return 0;
        }

        public static DateTime GetNullCheckDate(object val)
        {
            if (val != null && val.ToString().Length > 0)
                return Convert.ToDateTime(val);
            else
                return Convert.ToDateTime(null);
        }
        public static Boolean GetNullCheckBoolean(object val)
        {
            if (val != null && val.ToString().Length > 0)
                return Convert.ToBoolean(Convert.ToInt32(val));
            else
                return false;
        }

        public static dynamic GetNullable(object val)
        {
            if (val != null && val.ToString().Length > 0 && val.ToString() != "0")
                return val;
            else
                return null;

        }

        public static dynamic GetInvoiceDefaults(string ColumnType, dynamic val)
        {
            switch (ColumnType)
            {
                case "varchar":
                    if (val != null && val.ToString().Length > 0)
                        return val.ToString();
                    else
                        return string.Empty;
                case "bigint":
                    if (val != null && val.ToString().Length > 0)
                        return Convert.ToInt64(val);
                    else
                        return 0;
                case "int":
                    if (val != null && val.ToString().Length > 0)
                        return Convert.ToInt32(val);
                    else
                        return 0;
                case "datetime":
                    if (val != null && val.ToString().Length > 0)
                        return DateTime.ParseExact(val, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    else return Convert.ToDateTime(null);
                case "decimal":
                    if (val != null && val.ToString().Length > 0)
                        return Convert.ToDecimal(val);
                    else
                        return 0.00;
                case "bit":
                    if (val is string)
                    {
                        if (val != null && val.ToString().Length > 0)
                        {
                            return ToTrueFalse(val);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (val != null && val.ToString().Length > 0)
                        {
                            return Convert.ToBoolean(Convert.ToInt32(val));
                        }
                        else
                        {
                            return false;
                        }
                    }
                default:
                    return null;
            }
        }

        private static Boolean ToTrueFalse(string val)
        {
            return val.Trim().ToUpper() == "YES" ? true : false;
        }


        public static string RemoveSpecialCharacter(string s)
        {
            StringBuilder sb = new StringBuilder(s);

            sb.Replace(":", "-");
            sb.Replace("\\", "-");
            sb.Replace("/", "-");
            sb.Replace("?", "-");
            sb.Replace("  ", " ");
            sb.Replace("[", "-");
            sb.Replace("]", "-");

            return sb.ToString();
        }


        public static string TrimSpaceConvertToUpper(string s)
        {
            s = s.TrimEnd(' ');
            s = s.TrimStart(' ');
            s = s.ToUpper();
            return s;

        }
    }
}