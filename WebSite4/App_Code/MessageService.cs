using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MessageService
/// </summary>
public class MessageService
{
    OleDbConnection myConnection;
    public MessageService()
    {
        string connectionString = Connect.getConnectionString();
        myConnection = new OleDbConnection(connectionString);
    }
    public DataSet SortMessage (string s, string tabels)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = s;
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
    public DataSet GetMessageData(string s)
    {
        DataSet dataset = new DataSet();
        try
        {
            myConnection.Open();
            string sSql = s;
            OleDbCommand myCmd = new OleDbCommand(sSql, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = myCmd;
            adapter.Fill(dataset, "Messages,Users,Doctors,Managers");
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
    public void InseartMessageToDatabase(string s)
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
    public void DeleteMessage(int messageId)
    {
        try
        {

            myConnection.Open();
            string sSql = "DELETE from Messages WHERE MessageId=" + messageId;
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