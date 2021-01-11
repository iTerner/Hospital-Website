using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for WorkDaysService
/// </summary>
public class WorkDaysService
{
    OleDbConnection myConnection;
    public WorkDaysService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }
    public DataSet GetAllWorkingDaysForDoctor(string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select WorkDay from DoctorWorkDays where DoctorWorkDayDoctorId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "DoctorWorkDays");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
        return dataset;
    }
    public DataSet GetStartAndEndHour(string ID, int dayNumber)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorStartTime,DoctorEndTime from DoctorWorkDays where DoctorWorkDayDoctorId='" + ID + "' and WorkDay=" + dayNumber;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "DoctorWorkDays");
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
        return dataset;
    }
}