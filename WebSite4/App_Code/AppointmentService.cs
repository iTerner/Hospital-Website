using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AppointmentService
/// </summary>
public class AppointmentService
{
    OleDbConnection myConnection;
    public AppointmentService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }
    public DataSet IsAppointmentExist(string doctorId, DateTime date, int startHour)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Apointment where ApointmentDoctorId='" + doctorId + "' and ApointmentDate=#" + date + "# and ApointmentHour=" + startHour;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Apointment");
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
    public DataSet GetApointmentAndSort(string s, string tabels, string order)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = s + order;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, tabels);
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
    public void InsertAppointment(string s)
    {
        try
        {
            myConnection.Open();
            string sSql = s;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            myCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
    public void DeleteAppointment(int appId)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Apointment WHERE ApointmentId=" + appId;
            OleDbCommand cmd = new OleDbCommand(sSql, myConnection);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            myConnection.Close();
        }
    }
}