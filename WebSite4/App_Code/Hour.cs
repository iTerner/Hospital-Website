using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Hour
/// </summary>
public class Hour
{
    private int HourId;
    private string HourStartTime;
    private string HourEndTime;
    public Hour()
    {
    }
    public int CHourId
    {
        get
        {
            return this.HourId;
        }
        set
        {
            this.HourId = value;
        }
    }
    public string CHourStartTime
    {
        get
        {
            return this.HourStartTime;
        }
        set
        {
            this.HourStartTime = value;
        }
    }
    public string CHourEndTime
    {
        get
        {
            return this.HourEndTime;
        }
        set
        {
            this.HourEndTime = value;
        }
    }
}