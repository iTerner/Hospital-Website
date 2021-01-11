using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;


public class PrescriptioService
{
    OleDbConnection myConnection;
    public PrescriptioService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }
    public void InsertPrescriptionToDataBase(Prescription p)
    {
        string PDI = p.CPrescriptionDoctorId;
        string PUI = p.CPrescriptionUserId;
        DateTime PD = p.CPrescriptionDate;
        string PMN = p.CPrescriptionMedicineName;
        int PMI = p.CPrescriptionMedicineId;
        int PMC = p.CPrescriptionMedicineCount;
        int PMCat = p.CPrescriptionMedicineCatagory;
        try
        {

            myConnection.Open();
            string sSql = "INSERT INTO Prescriptions(PrescriptionDoctorId,PrescriptionUserId,PrescriptionDate,PrescriptionMedicineName,PrescriptionMedicineId,PrescriptionMedicineCount,PrescriptionMedicineCatagory) VALUES('" + PDI + "','" + PUI + "',#" + PD + "#,'" + PMN + "'," + PMI + "," + PMC + "," + PMCat + ")";
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
    public DataSet SortPrescription(string str)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select PrescriptionId,PrescriptionDoctorId,PrescriptionDate,PrescriptionMedicineId,PrescriptionMedicineName,PrescriptionMedicineCount from Prescriptions,Users" + str;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Prescriptions,Users");
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
    public DataSet SortPrescriptionManager(string str)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select PrescriptionId,PrescriptionDoctorId,PrescriptionUserId,PrescriptionDate,PrescriptionMedicineId,PrescriptionMedicineName,PrescriptionMedicineCount,DoctorName,UserName from Prescriptions,Doctors,Users" + str;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Prescriptions,Doctors,Users");
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
    public void DeletePrescription(int Pid)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Prescriptions WHERE PrescriptionId=" + Pid;
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
    public DataSet GetSpecificPrescription(int presId)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Prescriptions where PrescriptionId=" + presId;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Prescriptions");
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
    public DataSet GetPrescriptionByMedicineId(int MedicineId, string userId)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Prescriptions where PrescriptionMedicineId=" + MedicineId + " and PrescriptionUserId='" + userId + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Prescriptions");
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
    public DataSet IsPresAlreadyExist(int MedicineId)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Prescriptions where PrescriptionMedicineId=" + MedicineId;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Prescriptions");
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
    public void UpdatePresMedCount(int medId, int newCount)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Prescriptions SET PrescriptionMedicineCount =" + newCount + " WHERE PrescriptionMedicineId=" + medId;
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