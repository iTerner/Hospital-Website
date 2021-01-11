using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Appointment
{
    private int ApointmentId;
    private string ApointmentUserId;
    private string ApointmentDoctorId;
    private DateTime ApointmentDate;
    private int ApointmentHour;
    private int ApointmentDay;
    public Appointment()
    {
    }
    public int CApointmentId
    {
        get
        {
            return this.ApointmentId;
        }
        set
        {
            this.ApointmentId = value;
        }
    }
    public string CApointmentUserId
    {
        get
        {
            return this.ApointmentUserId;
        }
        set
        {
            this.ApointmentUserId = value;
        }
    }
    public string CApointmentDoctorId
    {
        get
        {
            return this.ApointmentDoctorId;
        }
        set
        {
            this.ApointmentDoctorId = value;
        }
    }
    public DateTime CApointmentDate
    {
        get
        {
            return this.ApointmentDate;
        }
        set
        {
            this.ApointmentDate = value;
        }
    }
    public int CApointmentHour
    {
        get
        {
            return this.ApointmentHour;
        }
        set
        {
            this.ApointmentHour = value;
        }
    }
    public int CApointmentDay
    {
        get
        {
            return this.ApointmentDay;
        }
        set
        {
            this.ApointmentDay = value;
        }
    }

}