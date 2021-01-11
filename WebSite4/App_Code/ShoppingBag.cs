using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingBag
/// </summary>
public class ShoppingBag
{
    private List<MedicineInBag> ListMedicine;
    public ShoppingBag()
    {
        ListMedicine = new List<MedicineInBag>();
    }
    public List<MedicineInBag> GetProducts()
    {
        return this.ListMedicine;
    }
    public int GetTotalPrice()
    {
        int sum = 0;
        foreach (MedicineInBag m in ListMedicine.ToList())
        {
            sum += m.CMedicineInBagMedicinePrice * m.CMedicineInBagMedicineCount;
        }
        return sum;
    }
    public void AddMedicine(MedicineInBag newMed)
    {
        bool found = false;
        foreach (MedicineInBag m in ListMedicine.ToList())
        {
            if (newMed.CMedicineId == m.CMedicineId)
            {
                m.CMedicineInBagMedicineCount++;
                found = true;
            }
        }
        if (!found)
        {
            ListMedicine.Add(newMed);
        }
    }
    public void DeleteMedicineFromList(MedicineInBag detMed)
    {
        bool found = false;
        if (ListMedicine != null)
        {
            foreach (MedicineInBag m in ListMedicine.ToList())
            {
                if (m.CMedicineId == detMed.CMedicineId && !found)
                {
                    ListMedicine.Remove(m);
                    found = true;
                }
            }
        }
    }
    public void UpdateMedicineLisr(MedicineInBag newMed)
    {
        if (ListMedicine != null)
        {
            foreach (MedicineInBag m in ListMedicine.ToList())
            {
                if (newMed.CMedicineId == m.CMedicineId)
                {
                    m.CMedicineInBagMedicineCount = newMed.CMedicineInBagMedicineCount;
                }
            }
        }
    }
    public int GetMedicineCount (int medId)
    {
        if (ListMedicine != null)
        {
            foreach (MedicineInBag m in ListMedicine.ToList())
            {
                //we know that medicineId is a number(automatic number)
                if (Convert.ToInt32(m.CMedicineId) == medId)
                {
                    return m.CMedicineInBagMedicineCount;
                }
            }
        }
        return 0;
    }

    public bool isEmpty()
    {
        int count = 0;
        foreach (MedicineInBag m in this.ListMedicine)
        {
            count++;
        }
        if (count == 0)
            return true;
        return false;
    }
    public int getSize()
    {
        int count = 0;
        foreach (MedicineInBag m in this.ListMedicine)
        {
            count++;
        }
        return count;
    }
    public void setList(List<MedicineInBag> list)
    {
        this.ListMedicine = list;
    }
}