using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string UserId;
    private string UserName;
    private string UserGender;
    private DateTime UserBirthDay;
    private string UserAdress;
    private int UserCity;
    private int HouseNumber;
    private string UserEmail;
    private string UserPassword;
    private string UserPhone;
    private DateTime UserDateLogin;
    public User()
    {
    }
    public DateTime CUserBirthDay
    {
        get
        {
            return this.UserBirthDay;
        }
        set
        {
            this.UserBirthDay = value;
        }
    }
    public string CUserId
    {
        get
        {
            return this.UserId;
        }
        set
        {
            this.UserId = value;
        }
    }
    public string CUserName
    {
        get
        {
            return this.UserName;
        }
        set
        {
            this.UserName = value;
        }
    }
    public string CUserGender
    {
        get
        {
            return this.UserGender;
        }
        set
        {
            this.UserGender = value;
        }
    }
    public string CUserAdress
    {
        get
        {
            return this.UserAdress;
        }
        set
        {
            this.UserAdress = value;
        }
    }
    public int CUserCity
    {
        get
        {
            return this.UserCity;
        }
        set
        {
            this.UserCity = value;
        }
    }
    public int CUserHouseNumber
    {
        get
        {
            return this.HouseNumber;
        }
        set
        {
            this.HouseNumber = value;
        }
    }
    public string CUserEmail
    {
        get
        {
            return this.UserEmail;
        }
        set
        {
            this.UserEmail = value;
        }
    }
    public string CUserPassword
    {
        get
        {
            return this.UserPassword;
        }
        set
        {
            this.UserPassword = value;
        }
    }
    public string CUserPhone
    {
        get
        {
            return this.UserPhone;
        }
        set
        {
            this.UserPhone = value;
        }
    }
    public DateTime CUserDateLogin
    {
        get
        {
            return this.UserDateLogin;
        }
        set
        {
            this.UserDateLogin = value;
        }
    }
}