using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DoctorWorkDay
/// </summary>
public class DoctorWorkDay
{
    private int DoctorWorkDayId;
    private string DoctorWorkDayDoctorId;
    private int WorkDay;
    private int DoctorStartTime;
    private int DoctorEndTime;
    public DoctorWorkDay()
    {
    }
    public int CDoctorWorkDayId
    {
        get
        {
            return this.DoctorWorkDayId;
        }
        set
        {
            this.DoctorWorkDayId = value;
        }
    }
    public string CDoctorWorkDayDoctorId
    {
        get
        {
            return this.DoctorWorkDayDoctorId;
        }
        set
        {
            this.DoctorWorkDayDoctorId = value;
        }
    }
    public int CWorkDay
    {
        get
        {
            return this.WorkDay;
        }
        set
        {
            this.WorkDay = value;
        }
    }
    public int CDoctorStartTime
    {
        get
        {
            return this.DoctorStartTime;
        }
        set
        {
            this.DoctorStartTime = value;
        }
    }
    public int CDoctorEndTime
    {
        get
        {
            return this.DoctorEndTime;
        }
        set
        {
            this.DoctorEndTime = value;
        }
    }
}