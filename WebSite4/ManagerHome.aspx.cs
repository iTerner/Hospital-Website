using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class ManagerHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
        }
    }


    protected void ShowGrid_Click(object sender, EventArgs e)
    {
        ShowDataGridForDoctor.Visible = false;
        ShowDataGridForUser.Visible = false;
        //get the selected index in dropdownlist
        int x = ShowAllData.SelectedIndex;
        //write query in DoctorService and UserService I DID IT

        //if index is 1 Doctor, 2 for user, if the index is 0 print Choose who do you want to see
        DataSet ds;
        if (x==1)
        {
            DoctorService docSer = new DoctorService();
            string where = " where CityId=DoctorCity and SpecialityId=DoctorSpecailty";
            ds = docSer.ShowDoctorForManager(where);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ShowDataGridForDoctor.Visible = true;
                ShowDataGridForUser.Visible = false;
                ShowDataGridForDoctor.DataSource = ds;
                ShowDataGridForDoctor.DataBind();
                CloseGrid.Visible = true;
            }
        }
        else if(x==2)
        {
            UserService userSer = new UserService();
            ds = userSer.ShowUserForManager();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ShowDataGridForDoctor.Visible = false;
                ShowDataGridForUser.Visible = true;
                ShowDataGridForUser.DataSource = ds;
                ShowDataGridForUser.DataBind();
                CloseGrid.Visible = true;
            }
        }
        else
        {
            //tell the manager that he need to choose between doctor and user
            Response.Write("<script>alert('עליך לבחור בין רופאים ללקוחות')</script>");
        }

        //make the close button visible true
        //check if dataset is empty
        //write Delete query in DoctorService and UserService
        //add labels and textbox under the grid view in order to contect
        //check if the content is valid
        //add to message service the manegar ID as a doctor
        //when you show data in one grid the other one is visible false

    }

    protected void ShowDataGridForDoctor_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteDoctor")
        {
            DoctorService ds = new DoctorService();
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            string docId = ShowDataGridForDoctor.Rows[rowNumber].Cells[11].Text; //because there is no rtl mode
            ds.DeleteDoctorFromDateBase(docId);
            string where = " where CityId=DoctorCity and SpecialityId=DoctorSpecailty";
            DataSet data = ds.ShowDoctorForManager(where);
            ShowDataGridForDoctor.Visible = true;
            ShowDataGridForUser.Visible = false;
            ShowDataGridForDoctor.DataSource = data;
            ShowDataGridForDoctor.DataBind();

        }
        if (e.CommandName == "ContactWithDoctor")
        {
            //revil label and buttons to send the message
            Label4.Visible = true;
            ThemeTB.Visible = true;
            Label2.Visible = true;
            MessageContent.Visible = true;
            CloseMessage.Visible = true;
            ResetMessage.Visible = true;
            SendMessage.Visible = true;
            MessageContent.Text = "";
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            string id = ShowDataGridForDoctor.Rows[rowNumber].Cells[0].Text;
            Session["adress"] = "doctor";
            Session["id"] = id;
        }
        if (e.CommandName == "DoctorVacation")
        {
        }
    }

    protected void ShowDataGridForUser_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUser")
        {
            UserService us = new UserService();
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            string userId = ShowDataGridForUser.Rows[rowNumber].Cells[8].Text; //because there is no rtl mode
            Label1.Text = userId;
            us.DeleteUserFromDateBase(userId);
            DataSet data = us.ShowUserForManager();
            ShowDataGridForDoctor.Visible = false;
            ShowDataGridForUser.Visible = true;
            ShowDataGridForUser.DataSource = data;
            ShowDataGridForUser.DataBind();
        }
        if (e.CommandName == "ContactWithUser")
        {
            //revil label and buttons to send the message
            Label4.Visible = true;
            ThemeTB.Visible = true;
            Label2.Visible = true;
            MessageContent.Visible = true;
            CloseMessage.Visible = true;
            ResetMessage.Visible = true;
            SendMessage.Visible = true;
            MessageContent.Text = "";
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            string id = ShowDataGridForUser.Rows[rowNumber].Cells[0].Text;
            Session["adress"] = "user";
            Session["id"] = id;
        }
    }

    protected void CloseGrid_Click(object sender, EventArgs e)
    {
        ShowDataGridForDoctor.Visible = false;
        ShowDataGridForUser.Visible = false;
        CloseGrid.Visible = false;
    }

    protected void CloseMessage_Click(object sender, EventArgs e)
    {
        MessageContent.Visible = false;
        SendMessage.Visible = false;
        CloseMessage.Visible = false;
        ResetMessage.Visible = false;
        Label2.Visible = false;
        Label4.Visible = false;
        ThemeTB.Visible = false;
    }
    
    protected void ResetMessage_Click(object sender, EventArgs e)
    {
        MessageContent.Text = "";
        ThemeTB.Text = "";
    }

    protected void SendMessage_Click(object sender, EventArgs e)
    {
        string s;
        if (ThemeTB.Text == "")
        {
            Response.Write("<script>alert('לא כתבת את נושא ההודעה')</script>");
            return;
        }
        if (MessageContent.Text == "")
        {
            Response.Write("<script>alert('לא כתבת את תוכן ההודעה')</script>");
            return;
        }

        Message m = new Message();
        string adress = (string)Session["adress"];
        m.CMessageContent = MessageContent.Text;
        m.CMessageTheme = ThemeTB.Text;
        Manager man = (Manager)Session["manager"];
        m.CMessageManagerId = man.CManagerId;
        m.CMessageSendDate = DateTime.Now;
        m.CMessageWhoSent = "manager";
        if (adress == "user")
        {
            m.CMessageUserId = (string)Session["id"];
            //m.CMessageDoctorId = null;
            s = "INSERT INTO Messages(MessageUserId,MessageManagerId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageUserId + "','" + m.CMessageManagerId + "','" + m.CMessageTheme + "','" + m.CMessageContent + "',#" + m.CMessageSendDate + "#,'" + m.CMessageWhoSent + "')";
        }
        else
        {
            m.CMessageDoctorId = (string)Session["id"];
            //m.CMessageUserId = null;
            s = "INSERT INTO Messages(MessageDoctorId,MessageManagerId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + m.CMessageDoctorId + "','" + m.CMessageManagerId + "','" + m.CMessageTheme + "','" + m.CMessageContent + "',#" + m.CMessageSendDate + "#,'" + m.CMessageWhoSent + "')";
        }
        MessageService ms = new MessageService();
        ms.InseartMessageToDatabase(s);
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
        CloseMessage_Click(sender, e);
    }

    protected void ShowDataGridForUser_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        ShowDataGridForUser.EditIndex = e.NewEditIndex;
        ShowGrid_Click(sender, e);
    }

    protected void ShowDataGridForDoctor_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        ShowDataGridForDoctor.EditIndex = e.NewEditIndex;
        ShowGrid_Click(sender, e);
    }

    protected void ShowDataGridForDoctor_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        ShowDataGridForDoctor.EditIndex = -1;
        ShowGrid_Click(sender, e);
    }

    protected void ShowDataGridForDoctor_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        try
        {
            Vacation v = new Vacation();
            //validation
            DateTime start = Convert.ToDateTime(((TextBox)(ShowDataGridForDoctor.Rows[e.RowIndex].Cells[9].FindControl("StartVac"))).Text);
            DateTime end = Convert.ToDateTime(((TextBox)(ShowDataGridForDoctor.Rows[e.RowIndex].Cells[9].FindControl("EndVac"))).Text);
            if (start == null || end == null)
            {
                Response.Write("<script>alert('בחירת תאריך לא תקינה')</script>");
                return;
            }
            if (start < DateTime.Now || end < DateTime.Now || end < start)
            {
                Response.Write("<script>alert('בחירת תאריך לא תקינה')</script>");
                return;
            }
            v.CVacationStartDate = start;
            v.CVacationEndDate = end;
            Manager m = (Manager)Session["manager"];
            v.CVacationManagerId = m.CManagerId;
            v.CVacationDoctorId = ShowDataGridForDoctor.Rows[e.RowIndex].Cells[0].Text;
            VacationService vs = new VacationService();
            vs.InsertVacation(v);
            GetAllData.VacationsForDoctor();
            Response.Write("<script>alert('חופשה התקבלה')</script>");
            ShowDataGridForDoctor.EditIndex = -1;
            ShowGrid_Click(sender, e);
        }
        catch
        {
            Response.Write("<script>alert('בחירת תאריך לא תקינה')</script>");
            return;
        }
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