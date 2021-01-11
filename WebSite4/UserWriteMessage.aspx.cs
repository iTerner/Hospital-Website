using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class UserWriteMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            User u = (User)Session["user"];
            HelloLabel.Text = u.CUserName;
            DoctorNameDropDownList.Items.Add(new ListItem("", "0"));
        }
    }

    protected void ResstButton_Click(object sender, EventArgs e)
    {
        WhoDDL.SelectedIndex = 0;
        DoctorIdO.Text = "";
        DoctorNameDropDownList.SelectedIndex = 0;
        MessageContentTB.Text = "";
        MessageContentO.Text = "";
        MessageThemeO.Text = "";
        MessageThemeTB.Text = "";
        DoctorNameDropDownList.Visible = false;
        DoctorIdO.Text = "";
        DoctorIdL.Visible = false;
    }

    protected void SendMessage_Click(object sender, EventArgs e)
    {
        bool valid = true;
        if (DoctorNameDropDownList.SelectedIndex == 0)
        {
            DoctorIdO.Text = "לא בחרת משתמש";
            valid = false;
        }
        string adress = (string)Session["adress"];
        if (MessageThemeTB.Text == "")
        {
            MessageThemeO.Text = "אנא מלא נושא הודעה";
            valid = false;
        }
        string theme = MessageThemeTB.Text;
        if (MessageContentTB.Text == "")
        {
            MessageContentO.Text = "אנא מלא נושא הודעה";
            valid = false;
        }
        if (!valid)
        {
            return;
        }
        string content = MessageContentTB.Text;
        User u = (User)Session["user"];
        MessageService ms = new MessageService();
        string adressId = DoctorNameDropDownList.SelectedValue;
        DateTime senddate = DateTime.Now;
        string s = "", whosent = "user";
        if (adress == "manager")
        {
            s = "INSERT INTO Messages(MessageUserId,MessageManagerId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + u.CUserId + "','" + adressId + "','" + theme + "','" + content + "',#" + senddate + "#,'" + whosent + "')";
        }
        else
        {
            s = "INSERT INTO Messages(MessageUserId,MessageDoctorId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
            s = s + " VALUES('" + u.CUserId + "','" + adressId + "','" + theme + "','" + content + "',#" + senddate + "#,'" + whosent + "')";
        }
        ms.InseartMessageToDatabase(s);
        ResstButton_Click(sender, e);
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
        Session["adress"] = "";
    }

    protected void WhoDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DoctorIdL.Visible = false;
        DoctorNameDropDownList.Visible = false;
        DataSet ds;
        List<ListItem> list = new List<ListItem>();
        int x = WhoDDL.SelectedIndex;
        if (x == 0)
        {
            WhoValid.Text = "לא בחרת";
            return;
        }
        else if(x == 1)
        {
            //doctor
            Session["adress"] = "doctor";
            DoctorService docser = new DoctorService();
            DoctorNameDropDownList.Items.Clear();
            ds = docser.GetDoctorName("");
            list = GetAllData.getListItemsForDDL(ds, "Doctor");

        }
        else if(x == 2)
        {
            //manager
            Session["adress"] = "manager";
            ManagerService ms = new ManagerService();
            ds = ms.GetManager();
            DoctorNameDropDownList.Items.Clear();
            list = GetAllData.getListItemsForDDL(ds, "Manager");
        }
        //add the listitems to the dropdown list
        foreach (ListItem l in list)
        {
            DoctorNameDropDownList.Items.Add(l);
        }
        DoctorNameDropDownList.DataBind();
        DoctorNameDropDownList.Visible = true;
        DoctorIdL.Visible = true;
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