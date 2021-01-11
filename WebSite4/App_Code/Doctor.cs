using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Doctor
/// </summary>
public class Doctor
{
    private string DoctorId;
    private string DoctorName;
    private string DoctorGender;
    private DateTime DoctorBirthday;
    private int DoctorSpeciality;
    private int DoctorLicense;
    private string DoctorUniversity;
    private string DoctorPassword;
    private int DoctorCity;
    private string DoctorPhone;
    private bool DoctorIsOnVacation;
    private DateTime DoctorDateLogin;
    public Doctor()
    {
    }
    public string CDoctorId
    {
        get
        {
            return this.DoctorId;
        }
        set
        {
            this.DoctorId = value;
        }
    }
    public string CDoctorName
    {
        get
        {
            return this.DoctorName;
        }
        set
        {
            this.DoctorName = value;
        }
    }
    public string CDoctorGender
    {
        get
        {
            return this.DoctorGender;
        }
        set
        {
            this.DoctorGender = value;
        }
    }
    public DateTime CDoctorBirthday
    {
        get
        {
            return this.DoctorBirthday;
        }
        set
        {
            this.DoctorBirthday = value;
        }
    }
    public int CDoctorSpeciality
    {
        get
        {
            return this.DoctorSpeciality;
        }
        set
        {
            this.DoctorSpeciality = value;
        }
    }
    public int CDoctorLicense
    {
        get
        {
            return this.DoctorLicense;
        }
        set
        {
            this.DoctorLicense = value;
        }
    }
    public string CDoctorUniversity
    {
        get
        {
            return this.DoctorUniversity;
        }
        set
        {
            this.DoctorUniversity = value;
        }
    }
    public string CDoctorPassword
    {
        get
        {
            return this.DoctorPassword;
        }
        set
        {
            this.DoctorPassword = value;
        }
    }
    public int CDoctorCity
    {
        get
        {
            return this.DoctorCity;
        }
        set
        {
            this.DoctorCity = value;
        }
    }
    public string CDoctorPhone
    {
        get
        {
            return this.DoctorPhone;
        }
        set
        {
            this.DoctorPhone = value;
        }
    }
    public bool CDoctorIsOnVacation
    {
        get
        {
            return this.DoctorIsOnVacation;
        }
        set
        {
            this.DoctorIsOnVacation = value;
        }
    }
    public DateTime CDoctorDateLogin
    {
        get
        {
            return this.DoctorDateLogin;
        }
        set
        {
            this.DoctorDateLogin = value;
        }
    }
}