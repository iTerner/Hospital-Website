using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

public partial class GuestHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void LoginSubmit_Click(object sender, EventArgs e)
    {
        UserService us1 = new UserService();
        DataSet ds = us1.Login(LoginIdTB.Text, LoginPasswordTB.Text);
        if (ds.Tables[0].Rows.Count == 1)
        {
            User u = GetAllData.GetAllUserDataById(LoginIdTB.Text);
            Session["user"] = u;
            Label6.Text = "התחברת בהצלחה";
            Response.Redirect("http://localhost:49675/Personal.aspx");

        }
        else
        {
            DoctorService doc1 = new DoctorService();
            DataSet ds1 = doc1.DoctorLogin(LoginIdTB.Text, LoginPasswordTB.Text);
            if (ds1.Tables[0].Rows.Count == 1)
            {
                Doctor d = GetAllData.GetAllDoctorDataById(LoginIdTB.Text);
                Session["doctor"] = d;
                Response.Redirect("http://localhost:49675/DoctorInfo.aspx");
                Label6.Text = "התחברת בהצלחה";
            }
            else
            {
                ManagerService ms = new ManagerService();
                DataSet ds2 = ms.ManagerLogin(LoginIdTB.Text, LoginPasswordTB.Text);
                if (ds2.Tables[0].Rows.Count == 1)
                {
                    Manager m = GetAllData.GetAllManagerDataById(LoginIdTB.Text);
                    Session["manager"] = m;
                    Response.Redirect("http://localhost:49675/ManagerHome.aspx");
                }
                else
                {
                    Label6.Text = "תעודת זהות או סיסמא אינם נכונים";
                }
            }
        }
    }

    protected void ForgotPassword_Click(object sender, EventArgs e)//need to add forgot password for manager and doctor unless i changed my "forgot password" method
    {
        UserService us1 = new UserService();
        DataSet ds = us1.GetPasswordByIdLogin(LoginIdTB.Text);
        if (ds.Tables[0].Rows.Count == 1)
        {
            if (Label6.Text == "")
            {
                Label6.Text = "הסיסמא שלך היא: " + Convert.ToString(ds.Tables[0].Rows[0]["UserPassword"]);
            }
            else
            {
                Label6.Text = "";
            }
        }
        else
        {
            Label6.Text = "משתמש לא קיים";
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/Registration.aspx");
    }
}