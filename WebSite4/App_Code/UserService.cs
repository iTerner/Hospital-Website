using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserService
/// </summary>
public class UserService
{
    OleDbConnection myConnection;
    public UserService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet IsUserAlreadyExsist(string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Users where UserId='"+ID+"'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users");
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
    public DataSet GetEmailAndPassword(string email, string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select UserEmail,UserPassword from Users where UserId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users");
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
    public DataSet GetUserNameAndId()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select UserId,UserName from Users";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users");
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
    public DataSet Login(string ID, string pass)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Users where UserId='" + ID + "' and UserPassword='" + pass + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users");
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
    public void InsertUserToDataBase(User u)
    {
        string un = u.CUserName;
        string cid = u.CUserId;
        DateTime bd = u.CUserBirthDay;
        string ad = u.CUserAdress;
        int hn = u.CUserHouseNumber;
        int ci = u.CUserCity;
        string ph = u.CUserPhone;
        string ge = u.CUserGender;
        string em = u.CUserEmail;
        string pas = u.CUserPassword;
        try
        {
            
            myConnection.Open();
            string sSql = "INSERT INTO Users(UserId,UserName,UserGender,UserBirth,UserCity,UserAdress,UserHouseNumber,UserPhone,UserEmail,UserPassword) VALUES(" + cid + " ,'" + un + "','" + ge + "','" + bd + "','" + ci + "','" + ad + "','" + hn + "','" + ph + "','" + em + "','" + pas +"')";
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
    public void UpdateUserCity(string id1, int city)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserCity ='" + city + "' WHERE UserId='" + id1 + "'";
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
    public void UpdateUserAdress(string id1, string ad)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserAdress ='" + ad + "' WHERE UserId='" + id1 + "'";
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
    public void UpdateUserHouseNumber(string id1, int hn)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserHouseNumber ='" + hn + "' WHERE UserId='" + id1 + "'";
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
    public void UpdateUserEmail(string id1, string email)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserEmail ='" + email + "' WHERE UserId='" + id1 + "'";
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
    public void UpdateUserPhone(string id1, string phone)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserPhone ='" + phone + "' WHERE UserId='" + id1 + "'";
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
    public void UpdateUserPassword(string id1, string pass)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserPassword ='" + pass + "' WHERE UserId='" + id1 + "'";
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
    public DataSet GetPasswordByIdLogin (string ID)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Users where UserId='" + ID + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users");
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
    public DataSet GetUserCityName(string id)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select UserName,CityName from Users,Citys where CityId=UserCity and UserId='" + id + "'";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users,Citys");
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
    public DataSet ShowUserForManager()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select UserId,UserName,UserGender,UserBirth,UserPhone,UserDateLogin,UserPassword,UserEmail,UserPhone,CityName from Users,Citys where CityId=UserCity";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Users,Citys");
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
    public void DeleteUserFromDateBase(string userId)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Users WHERE UserId='" + userId + "'";
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
    public DataSet GetCity()
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = "select * from Citys ORDER BY CityId";
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Citys");
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
    public void UpdateLastLoginDate(string id1, DateTime login)
    {
        try
        {
            myConnection.Open();
            string sSql = "UPDATE Users SET UserDateLogin ='" + login + "' WHERE UserId='" + id1 + "'";
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