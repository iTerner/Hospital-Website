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


public partial class DoctorWriteMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Doctor d = (Doctor)Session["doctor"];
            HelloLabel.Text = d.CDoctorName;
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        //init
        MessageContentO.Text = "";
        MessageThemeO.Text = "";


        string theme = MessageThemeTB.Text;
        string content = MessageContentTB.Text;
        bool valid = true;
        if (theme == "")
        {
            MessageThemeO.Text = "לא כתבת את נושא ההודעה";
            valid = false;
        }
        if (content == "")
        {
            MessageContentO.Text = "לא כתבת תוכן הודעה";
            valid = false;
        }
        if (!valid)
        {
            return;
        }
        string dest = (String)Session["dest"];
        string id = (String)Session["id"];
        DateTime sendDate = DateTime.Now;
        string whosent = "doctor";
        Doctor d = (Doctor)Session["doctor"];

        //write the SQL query
        MessageService ms = new MessageService();
        string s = "";
        if (dest == "manager")
        {
            s = "INSERT INTO Messages(MessageDoctorId,MessageManagerId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + d.CDoctorId + "','" + id + "','" + theme + "','" + content + "',#" + sendDate + "#,'" + whosent + "')";
        }
        if (dest == "user")
        {
            s = "INSERT INTO Messages(MessageDoctorId,MessageUserId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + d.CDoctorId + "','" + id + "','" + theme + "','" + content + "',#" + sendDate + "#,'" + whosent + "')";
        }
        //inseart to database
        ms.InseartMessageToDatabase(s);
        //reset all
        Reset_Click(sender, e);
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
    }

    protected void DesrDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //init
        DestO.Text = "";
        IdDropDownList.Visible = false;
        Label3.Visible = false;

        DataSet ds;
        int x = DesrDropDownList.SelectedIndex;
        List<ListItem> LI;
        switch(x)
        {
            case 0:
                {
                    DestO.Text = "לא בחר סוג";
                    return;
                }
            case 1:
                {
                    //put in the IdDropDownList the name of the User, the value will be their id
                    UserService us = new UserService();
                    ds = us.GetUserNameAndId();
                    LI = GetAllData.getListItemsForDDL(ds, "User");
                    foreach (ListItem l in LI)
                    {
                        IdDropDownList.Items.Add(l);
                    }
                    IdDropDownList.DataBind();
                    //wait until i change it in the database
                    IdDropDownList.Visible = true;
                    Label3.Visible = true;
                    break;
                }
            case 2:
                {
                    //put in the IdDropDownList the name of the Manager, the value will be their id
                    ManagerService ms = new ManagerService();
                    ds = ms.GetManager();
                    LI = GetAllData.getListItemsForDDL(ds, "Manager");
                    foreach (ListItem l in LI)
                    {
                        IdDropDownList.Items.Add(l);
                    }
                    IdDropDownList.DataBind();
                    IdDropDownList.Visible = true;
                    Label3.Visible = true;
                    break;
                }
        }
        
    }

    protected void IdDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //init
        MessageContentTB.Visible = true;
        MessageThemeTB.Visible = true;
        Label4.Visible = true;
        Label5.Visible = true;

        int type = DesrDropDownList.SelectedIndex;
        //dest is who we want to sent the message to (manager or user)
        IdO.Text = "";
        IdO.Visible = false;
        string dest;
        if (type == 1)
            dest = "user";
        else
            dest = "manager";

        if (IdDropDownList.SelectedIndex == 0)
        {
            IdO.Visible = true;
            IdO.Text = "לא בחרת משתמש";
            return;
        }
        //save the id and dest in session
        if (IdO.Text == "" && IdO.Visible == false)
        {
            Session["id"] = IdDropDownList.SelectedValue;
            Session["dest"] = dest;
            Submit.Visible = true;
            Reset.Visible = true;
        }
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        DesrDropDownList.SelectedIndex = 0;
        IdDropDownList.SelectedIndex = 0;
        MessageThemeTB.Text = "";
        MessageContentTB.Text = "";
        Reset.Visible = false;
        Submit.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        Label5.Visible = false;
        MessageContentTB.Visible = false;
        MessageThemeTB.Visible = false;
        IdDropDownList.Visible = false;
        MessageContentO.Text = "";
        MessageThemeO.Text = "";
        DestO.Text = "";
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