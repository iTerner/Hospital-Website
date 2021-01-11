using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Vacation
/// </summary>
public class Vacation
{
    private int VacationId;
    private string VacationDoctorId;
    private string VacationManagerId;
    private DateTime VacationStartDate;
    private DateTime VacationEndDate;
    public Vacation()
    {
    }
    public int CVacationId
    {
        get
        {
            return this.VacationId;
        }
        set
        {
            this.VacationId = value;
        }
    }
    public string CVacationDoctorId
    {
        get
        {
            return this.VacationDoctorId;
        }
        set
        {
            this.VacationDoctorId = value;
        }
    }
    public string CVacationManagerId
    {
        get
        {
            return this.VacationManagerId;
        }
        set
        {
            this.VacationManagerId = value;
        }
    }
    public DateTime CVacationStartDate
    {
        get
        {
            return this.VacationStartDate;
        }
        set
        {
            this.VacationStartDate = value;
        }
    }
    public DateTime CVacationEndDate
    {
        get
        {
            return this.VacationEndDate;
        }
        set
        {
            this.VacationEndDate = value;
        }
    }
}