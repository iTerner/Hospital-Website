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

public partial class HomePage : System.Web.UI.Page
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
            Label6.Text = "התחברת בהצלחה";
            UserService us = new UserService();
            us.UpdateLastLoginDate(LoginIdTB.Text, DateTime.Now);
            User u = GetAllData.GetAllUserDataById(LoginIdTB.Text);
            Session["user"] = u;
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

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('http://localhost:49675/SignUp.aspx');</script>");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/MedicineSearch.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/DoctorSearch.aspx");
    }


    protected void CalcBMI_Click(object sender, EventArgs e)
    {
        double w = Convert.ToDouble(WeightTB.Text);
        double h = Convert.ToDouble(HeightTB.Text) / 100.0;
        if (h == 0 || h <= 0 || w <= 0)
        {
            return;
        }
        double m = Math.Pow(h, 2);
        double BMI = w / m;
        BMI = Math.Round(BMI, 1);
        string text = "הBMI שלך הוא " + BMI, feed = "";
        if (BMI < 18.5)
        {
            feed = ", אתה בתת משקל";
        }
        else if (BMI >= 18.5 && BMI < 25)
        {
            feed = ", אתה במשקל תקין";
        }
        else if (BMI >= 25 && BMI <= 29.9)
        {
            feed = ", אתה בעל משקל עודף";
        }
        else if (BMI >= 30 && BMI <= 34.9)
        {
            feed = ", אתה בהשמנה דרגה 1";
        }
        else if (BMI >= 35 && BMI < 39.9)
        {
            feed = ", אתה בהשמנה דרגה 2";
        }
        else
        {
            feed = ", אתה בהשמנה דרגה 3";
        }
        string ans = text + feed;
        Response.Write("<script>alert('" + ans + "')</script>");
    }

    protected void ForgotPassword_Click(object sender, EventArgs e)
    {
        Response.Write("<script>window.open('http://localhost:49675/ForgotPassword.aspx','_blank');</script>");
    }
}