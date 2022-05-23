using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;
using System.Text.RegularExpressions;

public class Crypt
{
    public static string EncodeServerName(string serverName)
    {
        try
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
        catch {
            return null;
        }
    }

    public static string DecodeServerName(string encodedServername)
    {
        try
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encodedServername));
        }
        catch
        {
            return null;
        }
    }
    public static string convertToUnSign3(string s)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = s.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
    }
}
