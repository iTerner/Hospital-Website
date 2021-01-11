using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Validation
/// </summary>
public static class Validation
{

    public static bool IsNameValid(string name) // for first and last name and doctor university
    {
        string str = "0.1234546+789/*-~!@#$%^&*()_-={}[]'|:;?\'<>";
        for (int i = 0; i < str.Length; i++)
        {
            if (name.IndexOf(str[i]) != -1)
                return false;
        }
        return name.Length >= 2;
    }
    public static bool IsAdressValid(string adress) // for adress
    {
        if (adress.Length == 0)
            return false;
        string str = "0.1234546+789/*-~!@#$%^&*()_-={}[]'|:;?\'<>";
        for (int i = 0; i < str.Length; i++)
        {
            if (adress.IndexOf(str[i]) != -1)
                return false;
        }
        return true;
    }
    public static bool IsHouseNumberValid(string housenumber) // for house number
    {
        if (housenumber.Length == 0)
            return false;
        string str = "qwertyuiopasdfghjkl;zxcvbnm|,./'[]{}\\`!@#$%^&*()_-+=*.<>QWERTYUIOPASDFGHJKLZXCVBNM";
        for (int i = 0; i < str.Length; i++)
        {
            if (housenumber.IndexOf(str[i]) != -1)
                return false;
        }
        return true;
    }
    public static bool IsPostalCodeValid(string postalcode) // for postal code
    {
        string str = "qwertyuiopasdfghjkl;zxcvbnm|,./'[]{}\\`!@#$%^&*()_-+=*.<>QWERTYUIOPASDFGHJKLZXCVBNM";
        if (postalcode.Length == 5)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (postalcode.IndexOf(str[i]) != -1)
                    return false;
            }
            return true;
        }
        return false;
    }
    public static bool IsPhoneValid(string phone)// for phone number
    {
        string str = "qwertyuiopasdfghjkl;zxcvbnm|,./'[]{}\\`!@#$%^&*()_-+=*.<>QWERTYUIOPASDFGHJKLZXCVBNM";
        if (phone.Length == 10)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (phone.IndexOf(str[i]) != -1)
                    return false;
            }
            return true;
        }
        return false;
    }
    public static bool IsEMailValid(string e1) // for e-mail
    {
        if (e1.Length < 11)
            return false;
        if (e1.IndexOf('@') != e1.LastIndexOf('@'))
            return false;
        int x = e1.IndexOf('@');
        string something1 = e1.Substring(0, x);
        int sumofdots1 = 0, sumofdots2 = 0;
        char dot = '.';
        for (int i = 0; i < e1.Length; i++)
        {
            if (e1[i] == dot)
                sumofdots1++;
        }
        for (int i = 0; i < something1.Length; i++)
        {
            if (something1[i] == dot)
                sumofdots2++;
        }
        string str2 = "", str3 = "";
        int y;
        if (sumofdots1 - sumofdots2 == 1)
        {
            y = e1.LastIndexOf('.');
            str2 = e1.Substring(x + 1, y - x - 1);
            str3 = e1.Substring(y + 1);
        }
        else
            return false;
        string[] arr1 = new string[3];
        arr1[0] = something1;
        arr1[1] = str2;
        arr1[2] = str3;
        string str = "+-*/!#$%^&*(){}[]|\\,'?><";
        for (int i = 0; i < arr1.Length; i++)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (arr1[i].IndexOf(str[j]) != -1)
                    return false;
            }
        }
        return true;
    }
    public static bool IsPasswordValid(string password) // for password
    {
        int count = 0;
        string[] arr = new string[2];
        arr[0] = "QWERTYUIOPASDFGHJKLZXCVBNM";
        arr[1] = "1234567890";
        if (password.Length < 8)
            return false;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (password.IndexOf(arr[i][j]) == -1)
                    count++;
            }
            if (count == arr[i].Length)
                return false;
            count = 0;
        }
        return true;
    }
    public static bool IsImutPasswordValid(string password1, string password2) // for imut password
    {
        return password1 == password2;
    }
    public static bool IsIdNumberValid(string strID) // for id number
    {
        if (strID.Length == 0)
            return false;
        int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
        int count = 0;

        if (strID == null)
            return false;

        strID = strID.PadLeft(9, '0');

        for (int i = 0; i < 9; i++)
        {
            int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

            if (num > 9)
                num = (num / 10) + (num % 10);

            count += num;
        }

        return (count % 10 == 0);
    }
    public static bool IsGenderValid(bool male, bool female) // for gender
    {
        if (male == true && female == true)
            return false;
        if (male == false && female == false)
            return false;
        return true;
    }
    public static bool IsDateValid(DateTime d)
    {
        DateTime today = DateTime.Today;
        return today > d;

    }
    public static bool IsLiccenceValid(string lic) // for doctor liccence
    {
        string str = "qwertyuiopasdfghjkl;zxcvbnm|,./'[]{}\\`!@#$%^&*()_-+=*.<>QWERTYUIOPASDFGHJKLZXCVBNM";
        for (int i = 0; i < str.Length; i++)
        {
            if (lic.IndexOf(str[i]) != -1)
                return false;
        }
        if (lic.Length == 0)
            return false;
        return true;
    }
    public static bool isPriceValid(string s)
    {
        if (!Validation.IsHouseNumberValid(s))
            return false;
        int price = Convert.ToInt32(s);
        if (price <= 0)
            return false;
        return true;
    }
}

