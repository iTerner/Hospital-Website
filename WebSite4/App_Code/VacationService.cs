using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
/// <summary>
/// Summary description for VacationService
/// </summary>
public class VacationService
{
    OleDbConnection myConnection;
    public VacationService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet IsDoctorOnVacation(string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Vacation where VacationDoctorId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Vacation");
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
    public void DeleteVacation(int vacId)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Vacation WHERE VacationId=" + vacId;
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
    public DataSet SortVacation(string str)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select VacationId,VacationDoctorId,VacationManagerId,VacationStartDate,VacationEndDate,DoctorName,ManagerName from Vacation,Doctors,Managers" + str;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Vacation,Doctors,Managers");
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
    public void InsertVacation(Vacation v)
    {
        try
        {

            myConnection.Open();
            string sSql = "INSERT INTO Vacation(VacationDoctorId,VacationManagerId,VacationStartDate,VacationEndDate) VALUES('" + v.CVacationDoctorId + "','" + v.CVacationManagerId + "',#" + v.CVacationStartDate + "#,#" + v.CVacationEndDate + "#)";
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
}