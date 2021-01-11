using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



public class MedicineInBag:Medicine
{
    protected int MedicineInBagMedicineCount;
    protected int MedicineInBagMedicinePrice;
    //for the catagory and producer name
    protected string MedicineInBagCatagoryName;
    protected string MedicineInBagProducerName;
    public MedicineInBag()
    {
        
    }

    public int CMedicineInBagMedicineCount
    {
        get
        {
            return this.MedicineInBagMedicineCount;
        }
        set
        {
            this.MedicineInBagMedicineCount = value;
        }
    }
    public int CMedicineInBagMedicinePrice
    {
        get
        {
            return this.MedicineInBagMedicinePrice;
        }
        set
        {
            this.MedicineInBagMedicinePrice = value;
        }
    }
    public string CMedicineInBagCatagoryName
    {
        get
        {
            return this.MedicineInBagCatagoryName;
        }
        set
        {
            this.MedicineInBagCatagoryName = value;
        }
    }
    public string CMedicineInBagProducerName
    {
        get
        {
            return this.MedicineInBagProducerName;
        }
        set
        {
            this.MedicineInBagProducerName = value;
        }
    }
}