using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Prescription
/// </summary>

public class Prescription
{
    private int PrescriptionId;
    private string PrescriptionUserId;
    private string PrescriptionDoctorId;
    private int PrescriptionMedicineId;
    private int PrescriptionMedicineCount;
    private DateTime PrescriptionDate;
    private string PrescriptionMedicineName;
    private int PrescriptionMedicineCatagory;
    public Prescription()
    {

    }
    public int CPrescriptionId
    {
        get
        {
            return this.PrescriptionId;
        }
        set
        {
            this.PrescriptionId = value;
        }
    }
    public string CPrescriptionDoctorId
    {
        get
        {
            return this.PrescriptionDoctorId;
        }
        set
        {
            this.PrescriptionDoctorId = value;
        }
    }
    public string CPrescriptionUserId
    {
        get
        {
            return this.PrescriptionUserId;
        }
        set
        {
            this.PrescriptionUserId = value;
        }
    }
    public int CPrescriptionMedicineId
    {
        get
        {
            return this.PrescriptionMedicineId;
        }
        set
        {
            this.PrescriptionMedicineId = value;
        }
    }
    public int CPrescriptionMedicineCount
    {
        get
        {
            return this.PrescriptionMedicineCount;
        }
        set
        {
            this.PrescriptionMedicineCount = value;
        }
    }
    public DateTime CPrescriptionDate
    {
        get
        {
            return this.PrescriptionDate;
        }
        set
        {
            this.PrescriptionDate = value;
        }
    }
    public string CPrescriptionMedicineName
    {
        get
        {
            return this.PrescriptionMedicineName;
        }
        set
        {
            this.PrescriptionMedicineName = value;
        }
    }
    public int CPrescriptionMedicineCatagory
    {
        get
        {
            return this.PrescriptionMedicineCatagory;
        }
        set
        {
            this.PrescriptionMedicineCatagory = value;
        }
    }
}