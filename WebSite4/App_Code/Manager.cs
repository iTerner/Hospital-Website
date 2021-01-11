using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Manager
/// </summary>
public class Manager
{
    private string ManagerId;
    private string ManagerName;
    private string ManagerPassword;
    public Manager()
    {
    }
    public string CManagerId
    {
        get
        {
            return this.ManagerId;
        }
        set
        {
            this.ManagerId = value;
        }
    }
    public string CManagerName
    {
        get
        {
            return this.ManagerName;
        }
        set
        {
            this.ManagerName = value;
        }
    }
    public string CManagerPassword
    {
        get
        {
            return this.ManagerPassword;
        }
        set
        {
            this.ManagerPassword = value;
        }
    }
}