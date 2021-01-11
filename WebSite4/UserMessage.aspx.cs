using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

public partial class UserMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            User u = (User)Session["user"];
            HelloLabel.Text = u.CUserName;
        }
    }
    //@param x is the selected index of the ChooseNewMessage DDL
    public void seeNewMessages(int x)
    {
        ShowMessage.Visible = false;
        ShowMessageManagerGrid.Visible = false;
        if (x == 0)
            return;
        User u = (User)Session["user"];
        string tabels = "", s = "";
        if (x == 1)
        {
            //doctor
            s = "SELECT MessageId,MessageUserId,MessageDoctorId,MessageAnswerDate,MessageTheme,MessageContent,MessageAnswer,DoctorName FROM Messages,Doctors";
            s += " where MessageUserId='" + u.CUserId + "' and MessageAnswer IS NOT NULL and MessageManagerId IS NULL and DoctorId=MessageDoctorId";
            tabels = "Messages,Doctors";
        }
        else
        {
            //manager
            s = "SELECT MessageId,MessageUserId,MessageManagerId,MessageAnswerDate,MessageTheme,MessageContent,MessageAnswer,ManagerName FROM Messages,Managers";
            s += " where MessageUserId='" + u.CUserId + "' and MessageAnswer IS NOT NULL and MessageDoctorId IS NULL and ManagerId=MessageManagerId";
            tabels = "Messages,Managers";
        }
        MessageService ms = new MessageService();
        DataSet ds = ms.SortMessage(s, tabels);
        if (ds.Tables[0].Rows.Count != 0)
        {
            if (x == 1)
            {
                ShowMessage.Visible = true;
                ShowMessage.DataSource = ds;
                ShowMessage.DataBind();
            }
            else
            {
                ShowMessageManagerGrid.Visible = true;
                ShowMessageManagerGrid.DataSource = ds;
                ShowMessageManagerGrid.DataBind();
            }
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו הודעות')</script>");
        }
    }
    //@param x is the selected index of the ChooseNewMessage DDL
    public void seeMessages(int x)
    {
        CloseMessages.Visible = false;
        ShowNewMessageDoctorGrid.Visible = false;
        ShowNewMessageManagerGrid.Visible = false;
        User u = (User)Session["user"];
        string tabels = "", s = "";
        if (x == 2)
        {
            //manager
            s = "SELECT MessageId,MessageUserId,MessageManagerId,MessageSendDate,MessageTheme,MessageContent,MessageAnswer,ManagerName FROM Messages,Managers";
            s = s + " WHERE MessageUserId='" + u.CUserId + "' and MessageAnswer IS NULL and MessageDoctorId IS NULL and MessageManagerId=ManagerId";
            tabels = "Messages,Managers";
        }
        else
        {
            //doctor
            s = "SELECT MessageId,MessageUserId,MessageDoctorId,MessageSendDate,MessageTheme,MessageContent,MessageAnswer,DoctorName FROM Messages,Doctors";
            s = s + " WHERE MessageUserId='" + u.CUserId + "' and MessageAnswer IS NULL and MessageManagerId IS NULL and MessageDoctorId=DoctorId";
            tabels = "Messages,Doctors";
        }
        MessageService ms = new MessageService();
        DataSet ds = ms.SortMessage(s, tabels);
        if (ds.Tables[0].Rows.Count != 0)
        {
            if (x == 2)
            {
                //manager
                ShowNewMessageManagerGrid.Visible = true;
                ShowNewMessageManagerGrid.DataSource = ds;
                ShowNewMessageManagerGrid.DataBind();
            }
            else
            {
                //doctor
                ShowNewMessageDoctorGrid.Visible = true;
                ShowNewMessageDoctorGrid.DataSource = ds;
                ShowNewMessageDoctorGrid.DataBind();
            }
            CloseMessages.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו הודעות')</script>");
        }
    }

    protected void ShowMessage_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessage.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            ChooseNewMessage_SelectedIndexChanged(sender, e);
        }
    }

    protected void ShowMessage_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowMessageManagerGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessageManagerGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            ChooseNewMessage_SelectedIndexChanged(sender, e);
        }
    }

    protected void ShowMessageManagerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowNewMessageManagerGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowNewMessageManagerGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AnswerManager")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowNewMessageManagerGrid.Rows[rowNumber].Cells[0].Text);
            Message m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "user");
            m.CMessageManagerId = ShowNewMessageManagerGrid.Rows[rowNumber].Cells[1].Text;
            Session["newMessage"] = m;
            UserAnswerL.Visible = true;
            UserAnswerO.Visible = true;
            UserAnswerTB.Visible = true;
            UserAnswerTB.Text = "";
            UndoMessageButton.Visible = true;
            ResetMessageButton.Visible = true;
            SendMessageButton.Visible = true;
            UserAnswerO.Text = "";
        }
        if (e.CommandName == "DeleteManagerMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowNewMessageManagerGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            ChooseNewMessage_SelectedIndexChanged(sender, e);
        }
    }

    protected void UndoMessageButton_Click(object sender, EventArgs e)
    {
        UserAnswerL.Visible = false;
        UserAnswerO.Visible = false;
        UserAnswerTB.Visible = false;
        UserAnswerTB.Text = "";
        UndoMessageButton.Visible = false;
        ResetMessageButton.Visible = false;
        SendMessageButton.Visible = false;
        UserAnswerO.Text = "";
    }

    protected void ResetMessageButton_Click(object sender, EventArgs e)
    {
        UserAnswerTB.Text = "";
        UserAnswerO.Text = "";
        UserAnswerO.Visible = false;
    }

    protected void SendMessageButton_Click(object sender, EventArgs e)
    {
        Message m = (Message)Session["newMessage"];
        if (UserAnswerTB.Text == "")
        {
            UserAnswerO.Visible = true;
            UserAnswerO.Text = "לא כתבת כלום";
            return;
        }
        //need to be changed, now you cn answer to doctor aswell
        m.CMessageAnswer = UserAnswerTB.Text;
        m.CMessageAnswerDate = DateTime.Now;
        MessageService ms = new MessageService();
        ms.DeleteMessage(m.CMessageId);
        string s = "";
        if (ShowNewMessageDoctorGrid.Visible == true)
        {
            //doctor
            s = "INSERT INTO Messages(MessageDoctorId,MessageUserId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageDoctorId + "','" + m.CMessageUserId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        else
        {
            //manager
            s = "INSERT INTO Messages(MessageManagerId,MessageUserId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageManagerId + "','" + m.CMessageUserId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        ms.InseartMessageToDatabase(s);
        ChooseNewMessage_SelectedIndexChanged(sender, e);
    }

    protected void ShowNewMessageDoctorGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowNewMessageDoctorGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AnswerDoctor")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowNewMessageDoctorGrid.Rows[rowNumber].Cells[0].Text);
            Message m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "user");
            m.CMessageDoctorId = ShowNewMessageDoctorGrid.Rows[rowNumber].Cells[1].Text;
            Session["newMessage"] = m;
            UserAnswerL.Visible = true;
            UserAnswerO.Visible = true;
            UserAnswerTB.Visible = true;
            UserAnswerTB.Text = "";
            UndoMessageButton.Visible = true;
            ResetMessageButton.Visible = true;
            SendMessageButton.Visible = true;
            UserAnswerO.Text = "";
        }
        if (e.CommandName == "DeleteDoctorMessage")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowNewMessageDoctorGrid.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            ChooseNewMessage_SelectedIndexChanged(sender, e);
        }
    }

    protected void ChooseNewMessage_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowMessage.Visible = false;
        ShowMessageManagerGrid.Visible = false;
        ShowNewMessageDoctorGrid.Visible = false;
        ShowNewMessageManagerGrid.Visible = false;
        int x = ChooseNewMessage.SelectedIndex;
        int messageKind = (int)Session["messageKind"];
        if (x == 0)
        {
            return;
        }
        else if (x == 1 && messageKind == 0)
        {
            seeMessages(1);
        }
        else if (x == 1 && messageKind == 1)
        {
            seeNewMessages(1);
        }
        else if (x == 2 && messageKind == 0)
        {
            seeMessages(2);
        }   
        else
        {
            seeNewMessages(2);
        }
    }

    protected void SortMessageDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //saving in the session 0 if we want to see the messages people send to us
        //saving in the session 1 if we want to see the messages we sent
        int x = SortMessageDDL.SelectedIndex;
        if (x == 0)
        {
            return;
        }
        else if (x == 1)
        {
            Session["messageKind"] = 0;
        }
        else
        {
            Session["messageKind"] = 1;
        }
        ChooseNewMessage.Visible = true;
        ChooseNewMessage.SelectedIndex = 0;
    }

    protected void CloseMessages_Click(object sender, EventArgs e)
    {
        CloseMessages.Visible = false;
        ChooseNewMessage.Visible = false;
        ShowMessage.Visible = false;
        ShowMessageManagerGrid.Visible = false;
        ShowNewMessageDoctorGrid.Visible = false;
        ShowNewMessageManagerGrid.Visible = false;
    }

    protected void OpenMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/UserMessage.aspx");
    }

    protected void OpenPrescription_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/UserPrescription.aspx");
    }

    protected void OpenSetAppointment_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/SetApointment.aspx");
    }

    protected void OpenUserAppointment_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/UserAppointment.aspx");
    }

    protected void OpenContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/UserWriteMessage.aspx");
    }

    protected void OpenSearchDoctor_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('http://localhost:49675/DoctorSearch.aspx','_blank');</script>");
    }

    protected void OpenPharmacy_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('http://localhost:49675/MedicineSearch.aspx','_blank');</script>");
    }

    protected void OpenUserOrders_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/UserOrders.aspx");
    }

    protected void UserLogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["myShoppingBag"] = null;
        Response.Redirect("http://localhost:49675/HomePage.aspx");
    }
}