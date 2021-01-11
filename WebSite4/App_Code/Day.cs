using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Day
/// </summary>
public class Day
{
    private int DayId;
    private string DayName;
    public Day()
    {
    }
    public int CDayId
    {
        get
        {
            return this.DayId;
        }
        set
        {
            this.DayId = value;
        }
    }
    public string CDayName
    {
        get
        {
            return this.DayName;
        }
        set
        {
            this.DayName = value;
        }
    }
}