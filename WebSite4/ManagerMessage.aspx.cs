using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ManagerMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
        }
    }
    //@param x is the selected index of the WhoDDL
    public void seeNewMessages(int option)
    {
        CloseMessages.Visible = false;
        ShowMessageDoctorGrid.Visible = false;
        ShowMessageUserGrid.Visible = false;
        Manager m = (Manager)Session["manager"];
        MessageService ms = new MessageService();
        DataSet ds;
        string items = "", whereclout = "", s, tables;
        switch (option)
        {
            case 0: break;
            case 2:
                {
                    //user
                    items = "SELECT MessageId,MessageUserId,MessageSendDate,MessageTheme,MessageContent,UserName FROM Messages,Users";
                    whereclout = " where MessageManagerId='" + m.CManagerId + "' and MessageAnswer IS NULL and MessageDoctorId IS NULL  and MessageWhoSent='user' and MessageUserId=UserId";
                    s = items + whereclout;
                    tables = "Messages,Users";
                    ds = ms.SortMessage(s, tables);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ShowMessageUserGrid.Visible = true;
                        ShowMessageUserGrid.DataSource = ds;
                        ShowMessageUserGrid.DataBind();
                        CloseMessages.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('לא נמצאו הודעות')</script>");
                    }
                    break;
                }
            case 1:
                {
                    //doctor
                    items = "SELECT MessageId,MessageDoctorId,MessageSendDate,MessageTheme,MessageContent,DoctorName FROM Messages,Doctors";
                    whereclout = " where MessageManagerId='" + m.CManagerId + "' and MessageAnswer IS NULL and MessageUserId IS NULL and MessageWhoSent='doctor' and MessageDoctorId=DoctorId";
                    s = items + whereclout;
                    tables = "Messages,Doctors";
                    ds = ms.SortMessage(s, tables);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ShowMessageDoctorGrid.Visible = true;
                        ShowMessageDoctorGrid.DataSource = ds;
                        ShowMessageDoctorGrid.DataBind();
                        CloseMessages.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('לא נמצאו הודעות')</script>");
                    }
                    break;
                }
        }
    }

    protected void ShowMessageUserGrid_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AnswerUser")
        {
            Label4.Visible = true;
            AnswerTB.Visible = true;
            ResetMessageAnswer.Visible = true;
            SendMessageAnswer.Visible = true;
            UndoMessageAnswer.Visible = true;
            Message m = new Message();
            Manager man = (Manager)Session["manager"];
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessageUserGrid.Rows[rowNumber].Cells[0].Text);
            m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "user");
            m.CMessageManagerId = man.CManagerId;
            Session["newMessage"] = m;
            Session["adress"] = "user";
        }
    }

    protected void ShowMessageUserGrid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowMessageDoctorGrid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowMessageDoctorGrid_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AnswerDoctor")
        {
            Label4.Visible = true;
            AnswerTB.Visible = true;
            ResetMessageAnswer.Visible = true;
            SendMessageAnswer.Visible = true;
            UndoMessageAnswer.Visible = true;
            Message m = new Message();
            Manager man = (Manager)Session["manager"];
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessageDoctorGrid.Rows[rowNumber].Cells[0].Text);
            m = GetAllData.GetAllDataFromMessageForAnswer(MessageId, "doctor");
            m.CMessageManagerId = man.CManagerId;
            Session["newMessage"] = m;
            Session["adress"] = "doctor";
        }
    }

    protected void SendMessageAnswer_Click(object sender, EventArgs e)
    {
        AnswerO.Visible = false;
        AnswerO.Text = "";
        Message m = (Message)Session["newMessage"];
        if (AnswerTB.Text == "")
        {
            AnswerO.Visible = true;
            AnswerO.Text = "לא כתבת תשובה";
            return;
        }
        m.CMessageAnswer = AnswerTB.Text;
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
            s = "INSERT INTO Messages(MessageManagerId,MessageUserId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageManagerId + "','" + m.CMessageUserId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        else
        {
            //doctor
            s = "INSERT INTO Messages(MessageManagerId,MessageDoctorId,MessageContent,MessageTheme,MessageAnswer,MessageSendDate,MessageAnswerDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageManagerId + "','" + m.CMessageDoctorId + "','" + m.CMessageContent + "','" + m.CMessageTheme + "','" + m.CMessageAnswer + "','" + m.CMessageSendDate + "','" + m.CMessageAnswerDate + "','" + m.CMessageWhoSent + "')";
        }
        ms.InseartMessageToDatabase(s);

        //maybe do popup
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
        ResetMessageAnswer_Click(sender, e);
        WhoDDL_SelectedIndexChanged(sender, e);
    }

    protected void ResetMessageAnswer_Click(object sender, EventArgs e)
    {
        AnswerO.Text = "";
    }

    protected void UndoMessageAnswer_Click(object sender, EventArgs e)
    {
        AnswerO.Visible = false;
        SendMessageAnswer.Visible = false;
        UndoMessageAnswer.Visible = false;
        ResetMessageAnswer.Visible = false;
        AnswerTB.Visible = false;
        Label4.Visible = false;
        AnswerO.Text = "";
    }

    public void seeMessages(int option)
    {
        CloseMessages.Visible = false;
        ShowMessageSendUser.Visible = false;
        ShowMessageSendDoctor.Visible = false;
        Manager m = (Manager)Session["manager"];
        MessageService ms = new MessageService();
        DataSet ds;
        string s = "", items = "", whereclout = "", tables = "";
        switch (option)
        { 
            case 0: break;
            case 2:
                {
                    //user
                    items = "SELECT MessageId,MessageUserId,MessageAnswerDate,MessageTheme,MessageContent,MessageAnswer,UserName FROM Messages,Users";
                    whereclout = " where MessageManagerId='" + m.CManagerId + "' and MessageAnswer IS NOT NULL and MessageUserId=UserId";
                    s = items + whereclout;
                    tables = "Messages,Users";
                    ds = ms.SortMessage(s, tables);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ShowMessageSendUser.Visible = true;
                        ShowMessageSendUser.DataSource = ds;
                        ShowMessageSendUser.DataBind();
                        CloseMessages.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('לא נמצאו הודעות')</script>");
                    }
                    break;
                }
            case 1:
                {
                    //dcctor
                    items = "SELECT MessageId,MessageDoctorId,MessageSendDate,MessageTheme,MessageContent,DoctorName FROM Messages,Doctors";
                    whereclout = " where MessageManagerId='" + m.CManagerId + "' and MessageAnswer IS NOT NULL and MessageDoctorId=DoctorId";
                    s = items + whereclout;
                    tables = "Messages,Doctors";
                    ds = ms.SortMessage(s, tables);
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        ShowMessageSendDoctor.Visible = true;
                        ShowMessageSendDoctor.DataSource = ds;
                        ShowMessageSendDoctor.DataBind();
                        CloseMessages.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('לא נמצאו הודעות')</script>");
                    }
                    break;
                }
        }
    }

    protected void ShowMessageSendUser_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowMessageSendUser_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessageUser")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessageSendUser.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            WhoDDL_SelectedIndexChanged(sender, e);
        }
    }

    protected void ShowMessageSendDoctor_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowMessageSendDoctor_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMessageDoctor")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int MessageId = Convert.ToInt32(ShowMessageSendDoctor.Rows[rowNumber].Cells[0].Text);
            MessageService ms = new MessageService();
            ms.DeleteMessage(MessageId);
            WhoDDL_SelectedIndexChanged(sender, e);
        }
    }

    protected void MessageTypeDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //saving in the session 0 if we want to see the messages people send to us
        //saving in the session 1 if we want to see the messages we sent
        WhoDDL.SelectedIndex = 0;
        CloseMessages_Click(sender, e);
        CloseMessages.Visible = false;
        int x = MessageTypeDDL.SelectedIndex;
        if (x == 0)
        {
            WhoDDL.Visible = false;
            return;
        }
        else if (x == 1)
        {
            Session["messageKind"] = 0;
            WhoDDL.Visible = true;
        }
        else
        {
            Session["messageKind"] = 1;
            WhoDDL.Visible = true;
        }
    }

    protected void WhoDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //put all the grid on visible false
        ShowMessageDoctorGrid.Visible = false;
        ShowMessageUserGrid.Visible = false;
        ShowMessageSendUser.Visible = false;
        ShowMessageSendDoctor.Visible = false;
        int x = WhoDDL.SelectedIndex;
        int messageKind = (int)Session["messageKind"];
        if (x == 0)
        {
            return;
        }
        else if (x == 1 && messageKind == 0)
        {
            seeNewMessages(1);
        }
        else if (x == 1 && messageKind == 1)
        {
            seeMessages(1);
        }
        else if (x == 2 && messageKind == 0)
        {
            seeNewMessages(2);
        }
        else
        {
            seeMessages(2);
        }
    }

    protected void CloseMessages_Click(object sender, EventArgs e)
    {
        ShowMessageDoctorGrid.Visible = false;
        ShowMessageUserGrid.Visible = false;
        ShowMessageSendUser.Visible = false;
        ShowMessageSendDoctor.Visible = false;
        MessageTypeDDL.SelectedIndex = 0;
        WhoDDL.SelectedIndex = 0;
    }


    protected void OpenMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerMessage.aspx");
    }

    protected void OpenPrescription_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerPrescription.aspx");
    }

    protected void Appointment_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerAppointment.aspx");
    }

    protected void Orders_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerOrders.aspx");
    }

    protected void Vacation_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerVacation.aspx");
    }

    protected void ManagerLogOut_Click(object sender, EventArgs e)
    {
        Session["manager"] = null;
        Response.Redirect("http://localhost:49675/HomePage.aspx");
    }
}