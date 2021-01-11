using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for medicine
/// </summary>
public class Medicine
{
    private string MedicineId;
    private string MedicineName;
    private int MedicinePrice;
    private int MedicineStock;
    private int Medicineproducer;
    private int MedicineCatagory;
    private bool MedicineNeedPrescription;
    public Medicine()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string CMedicineId
    {
        get
        {
            return this.MedicineId;
        }
        set
        {
            this.MedicineId = value;
        }
    }
    public string CMedicineName
    {
        get
        {
            return this.MedicineName;
        }
        set
        {
            this.MedicineName = value;
        }
    }
    public int CMedicinePrice
    {
        get
        {
            return this.MedicinePrice;
        }
        set
        {
            this.MedicinePrice = value;
        }
    }
    public int CMedicineStock
    {
        get
        {
            return this.MedicineStock;
        }
        set
        {
            this.MedicineStock = value;
        }
    }
    public int CMedicineProducer
    {
        get
        {
            return this.Medicineproducer;
        }
        set
        {
            this.Medicineproducer = value;
        }
    }
    public int CMedicineCatagory
    {
        get
        {
            return this.MedicineCatagory;
        }
        set
        {
            this.MedicineCatagory = value;
        }
    }
    public bool CMedicineNeedPrescription
    {
        get
        {
            return this.MedicineNeedPrescription;
        }
        set
        {
            this.MedicineNeedPrescription = value;
        }
    }
}