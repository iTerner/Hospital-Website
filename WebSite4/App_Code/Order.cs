using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
    private int OrderId;
    private string OrderUserId;
    private DateTime OrderDate;
    private int OrderTotalMoney;
    private bool OrderIsSupplied;
    private ShoppingBag OrderMedicines;
    public Order(ShoppingBag orederMedicine)
    {
        OrderMedicines = new ShoppingBag();
        OrderMedicines = orederMedicine;
    }

    public ShoppingBag GetShopingBag()
    {
        return this.OrderMedicines;
    }

    public int COrderId
    {
        get
        {
            return this.OrderId;
        }
        set
        {
            this.OrderId = value;
        }
    }
    public string COrderUserId
    {
        get
        {
            return this.OrderUserId;
        }
        set
        {
            this.OrderUserId = value;
        }
    }
    public DateTime COrderDate
    {
        get
        {
            return this.OrderDate;
        }
        set
        {
            this.OrderDate = value;
        }
    }
    public int COrderTotalMoney
    {
        get
        {
            return this.OrderTotalMoney;
        }
        set
        {
            this.OrderTotalMoney = value;
        }
    }
    public bool COrderIsSupplied
    {
        get
        {
            return this.OrderIsSupplied;
        }
        set
        {
            this.OrderIsSupplied = value;
        }
    }
}