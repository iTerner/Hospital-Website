using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class DoctorMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Doctor d = (Doctor)Session["doctor"];
            HelloLabel.Text = d.CDoctorName;
        }
    }

    public void SeeMessages (string adress)
    {
        UserMessageGrid.Visible = false;
        ManagerMessageGrid.Visible = false;
        Doctor d = (Doctor)Session["doctor"];
        //int x = DropDownListSort.SelectedIndex;
        MessageService ms = new MessageService();
        DataSet ds;
        string items = "", whereclout = "", s, tables;

        if (adress == "user")
        {
            items = "SELECT MessageId,MessageUserId,MessageSendDate,MessageTheme,MessageContent,UserName FROM Messages,Users";
            whereclout = " where MessageDoctorId='" + d.CDoctorId + "' and MessageAnswer IS NULL and MessageManagerId IS NULL and UserId=MessageUserId";
            s = items + whereclout;
            tables = "Messages,Users";
            ds = ms.SortMessage(s, tables);
            if (ds.Tables[0].Rows.Count != 0)
            {
                UserMessageGrid.Visible = true;
                UserMessageGrid.DataSource = ds;
                UserMessageGrid.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו הודעות')</script>");
            }
        }
        else
        {
            items = "SELECT MessageId,MessageManagerId,MessageSendDate,MessageTheme,MessageContent,ManagerName FROM Messages,Managers";
            whereclout = " where MessageDoctorId='" + d.CDoctorId + "' and MessageAnswer IS NULL and MessageUserId IS NULL and ManagerId=MessageManagerId";
            s = items + whereclout;
            tables = "Messages,Managers";
            ds = ms.SortMessage(s, tables);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ManagerMessageGrid.Visible = true;
                ManagerMessageGrid.DataSource = ds;
                ManagerMessageGrid.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו הודעות')</script>");
            }
        }
    }

    protected void SendMessage_Click(object sender, EventArgs e)
    {
        Message m = (Message)Session["newMessage"];
        if (DoctorMessageAnswer.Text == "")
        {
            Response.Write("<script>alert('לא כתבת תשובה')</script>");
            return;
        }
        m.CMessageAnswer = DoctorMessageAnswer.Text;
        m.CMessageAnswerDate = DateTime.Now;
        MessageService ms = new MessageService();
        ms.DeleteMessage(m.CMessageId);
        string whoSent = m.CMessageWhoSent;
        string temp = whoSent.Substring(0, 1);
        temp = temp.ToUpper();
        whoSent = temp + whoSent.Substring(1);

        string adress = Session["adress"].ToString(), s;
        if (adress == "user")
        {
            s = "INSERT INTO Messages(MessageDoctorId,MessageUserId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageDoctorId + "','" + m.CMessageUserId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        else
        {
            //manager
            s = "INSERT INTO Messages(MessageManagerId,MessageDoctorId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageManagerId + "','" + m.CMessageDoctorId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        ms.InseartMessageToDatabase(s);

        //maybe do popup
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
        Undo_Click(sender, e);
        DropDownListSort_SelectedIndexChanged(sender, e);
    }

    protected void ResetMessage_Click(object sender, EventArgs e)
    {
        DoctorMessageAnswer.Text = "";
    }

    protected void Undo_Click(object sender, EventArgs e)
    {
        DoctorMessageAnswer.Text = "";
        Label2.Visible = false;
        DoctorMessageAnswer.Visible = false;
        Undo.Visible = false;
        ResetMessage.Visible = false;
        SendMessage.Visible = false;
    }

    protected void CloseMessages_Click(object sender, EventArgs e)
    {
        UserMessageGrid.Visible = false;
        ManagerMessageGrid.Visible = false;
        CloseMessages.Visible = false;
        Label2.Visible = false;
        DoctorMessageAnswer.Visible = false;
        DoctorMessageAnswer.Text = "";
        SendMessage.Visible = false;
        Undo.Visible = false;
        ResetMessage.Visible = false;
        UserSendMessageGrid.Visible = false;
        ManagerSendMessageGrid.Visible = false;
    }

    protected void UserMessageGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AnswerUser")
        {
            Doctor d = (Doctor)Session["doctor"];
            Message m = new Message();
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(UserMessageGrid.Rows[rowNumber].Cells[0].Text);
            m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "user");
            m.CMessageDoctorId = d.CDoctorId;
            Label2.Visible = true;
            DoctorMessageAnswer.Visible = true;
            Undo.Visible = true;
            ResetMessage.Visible = true;
            SendMessage.Visible = true;
            Session["newMessage"] = m;
            Session["adress"] = "user";
        }
        if (e.CommandName == "DeletUserMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(UserMessageGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
        }
    }

    protected void UserMessageGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ManagerMessageGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Answer")
        {
            Doctor d = (Doctor)Session["doctor"];
            Message m = new Message();
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ManagerMessageGrid.Rows[rowNumber].Cells[0].Text);
            m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "manager");
            m.CMessageDoctorId = d.CDoctorId;
            Label2.Visible = true;
            DoctorMessageAnswer.Visible = true;
            Undo.Visible = true;
            ResetMessage.Visible = true;
            SendMessage.Visible = true;
            Session["newMessage"] = m;
            Session["adress"] = "manager";
        }
        if (e.CommandName == "DeleteManagerMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ManagerMessageGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
        }
    }

    protected void ManagerMessageGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }


    protected void ManagerSendMessageGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ManagerSendMessageGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ManagerSendMessageGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            DropDownListSort_SelectedIndexChanged(sender, e);
        }
    }

    public void SeeNewMessage(string adress)
    {
        ManagerSendMessageGrid.Visible = false;
        UserSendMessageGrid.Visible = false;
        Doctor d = (Doctor)Session["doctor"];
        MessageService ms = new MessageService();
        DataSet ds;
        string s = "";
        string tabels = "";
        if (adress == "user")
        {
            tabels = "Messages,Users";
            s = "SELECT MessageId,MessageUserId,MessageAnswerDate,MessageTheme,MessageAnswer,MessageContent,UserName FROM Messages,Users";
            s = s + " WHERE MessageDoctorId='" + d.CDoctorId + "' and MessageAnswer IS NOT NULL and MessageManagerId IS NULL and UserId=MessageUserId";
        }
        else
        {
            //manager
            tabels = "Messages,Managers";
            s = "SELECT MessageId,MessageManagerId,MessageAnswerDate,MessageTheme,MessageAnswer,MessageContent,ManagerName FROM Messages,Managers";
            s = s + " WHERE MessageDoctorId='" + d.CDoctorId + "' and MessageAnswer IS NOT NULL and MessageUserId IS NULL and MessageManagerId=ManagerId";
        }
        ds = ms.SortMessage(s, tabels);
        if (ds.Tables[0].Rows.Count != 0)
        {
            if (adress == "user")
            {
                UserSendMessageGrid.Visible = true;
                UserSendMessageGrid.DataSource = ds;
                UserSendMessageGrid.DataBind();
            }
            else
            {
                //manager
                ManagerSendMessageGrid.Visible = true;
                ManagerSendMessageGrid.DataSource = ds;
                ManagerSendMessageGrid.DataBind();

            }
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו הודעות')</script>");
        }
    }

    protected void UserSendMessageGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void UserSendMessageGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUserMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(UserSendMessageGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            DropDownListSort_SelectedIndexChanged(sender, e);
        }
    }

    protected void ShowMessageDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        int x = ShowMessageDDL.SelectedIndex;
        //saving in the session 0 if we want to see the messages people send to us
        //saving in the session 1 if we want to see the messages we sent
        if (x == 0)
        {
            return;
        }
        else if (x == 1)
        {
            Session["Messagekind"] = 0;
        }
        else
        {
            Session["MessageKind"] = 1;
        }
        DropDownListSort.Visible = true;
        DropDownListSort.SelectedIndex = 0;
    }

    protected void DropDownListSort_SelectedIndexChanged(object sender, EventArgs e)
    {
        UserMessageGrid.Visible = false;
        ManagerMessageGrid.Visible = false;
        UserSendMessageGrid.Visible = false;
        ManagerSendMessageGrid.Visible = false;           
        int x = DropDownListSort.SelectedIndex;
        int messageKind = (int)Session["MessageKind"];
        if (x == 0)
        {
            return;
        }
        else if(x == 1 && messageKind == 0)
        {
            SeeMessages("user");
        }
        else if (x == 1 && messageKind == 1)
        {
            SeeNewMessage("user");
        }
        else if (x == 2 && messageKind == 0)
        {
            SeeMessages("manager");
        }
        else
        {
            SeeNewMessage("manager");
        }
    }

    protected void OpenMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/DoctorMessage.aspx");
    }

    protected void OpenPrescription_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/DoctorPrescription.aspx");
    }

    protected void Appointment_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/DoctorAppointment.aspx");
    }

    protected void Contact_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/DoctorWriteMessage.aspx");
    }

    protected void DoctorLogOut_Click(object sender, EventArgs e)
    {
        Session["doctor"] = null;
        Response.Redirect("http://localhost:49675/HomePage.aspx");
    }
}