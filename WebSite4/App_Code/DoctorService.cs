using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DoctorService
/// </summary>
public class DoctorService
{
    OleDbConnection myConnection;
    public DoctorService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet GetDoctors()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Doctors";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public DataSet IsDoctorAlreadyExsist(string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Doctors where DoctorId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public DataSet GetDoctorNameById(string ID)// use in message, add in message class and data base the name of the doctor.
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorName from Doctors where DoctorId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public DataSet GetDoctorIdFirstNameLastName()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorId,DoctorName from Doctors";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public void InsertDoctorToDataBase (Doctor d)
    {
        string id = d.CDoctorId;
        string n = d.CDoctorName;
        int sp = d.CDoctorSpeciality;
        int lic = d.CDoctorLicense;
        string gen = d.CDoctorGender;
        DateTime bd = d.CDoctorBirthday;
        string uni = d.CDoctorUniversity;
        string pas = d.CDoctorPassword;
        int ad = d.CDoctorCity;
        string ph = d.CDoctorPhone;
        try
        {
            myConnection.Open();
            string sSql = "INSERT INTO Doctors(DoctorId,DoctorName,DoctorSpecailty,DoctorLicense,DoctorGender,DoctorBirthDay,DoctorUniversity,DoctorPassword,DoctorCity,DoctorPhone) VALUES('" + id + "','" + n + "'," + sp + "," + lic + ",'" + gen + "','" + bd + "','" + uni + "','" + pas + "'," + ad + ",'" + ph + "')";
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
    public DataSet DoctorLogin(string ID, string pass)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Doctors where DoctorId='" + ID + "' and DoctorPassword='" + pass + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public DataSet SearchDoctorManualy(string str)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorName,DoctorGender,DoctorPhone,CityName,SpecialityName from Doctors,Citys,Speciality where (DoctorName LIKE '%" + str + "%') and CityId=DoctorCity and SpecialityId=DoctorSpecailty";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors,Citys,Speciality");
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
    public DataSet SortDoctor(string str)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorName,DoctorGender,DoctorPhone,CityName,SpecialityName from Doctors,Citys,Speciality" + str;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors,Citys,Speciality");
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
    public DataSet ShowDoctorForManager(string s)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorId,DoctorName,DoctorGender,DoctorBirthDay,CityName,DoctorPhone,SpecialityName,DoctorLicense,DoctorUniversity,DoctorIsOnVacation from Doctors,Citys,Speciality" + s;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors,Citys,Speciality");
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
    public void DeleteDoctorFromDateBase(string docId)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Doctors WHERE DoctorId='" + docId + "'";
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
    public DataSet GetSpec()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Speciality";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Speciality");
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
    public DataSet GetDoctorName(string s)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorId,DoctorName from Doctors" + s;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors");
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
    public DataSet GetSpecailty()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select SpecialityName,SpecialityId from Speciality where SpecialityId > 1";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Speciality");
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
    public void UpdateDoctorVacation(bool vac, string docId)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Doctors SET DoctorIsOnVacation =" + vac + " WHERE DoctorId='" + docId + "'";
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
    public DataSet GetDoctorCityName(string id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select DoctorName,CityName,SpecialityName from Doctors,Citys,Speciality where CityId=DoctorCity and SpecialityId=DoctorSpecailty and DoctorId='" + id + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Doctors,Citys,Speciality");
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
    public void UpdateDoctorInfo(string whereclout)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Doctors SET " + whereclout;
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
    public void UpdateDoctorsPassword(string id1, string pass)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Doctors SET DoctorPassword ='" + pass + "' WHERE DoctorId='" + id1 + "'";
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