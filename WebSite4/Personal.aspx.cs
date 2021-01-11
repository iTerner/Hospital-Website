using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class Personal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        User u = (User)Session["user"];
        UserService us = new UserService();
        DataSet ds = us.GetUserCityName(u.CUserId);
        ShowCity.Text = Convert.ToString(ds.Tables[0].Rows[0]["CityName"]);
        ShowId.Text = u.CUserId;
        ShowName.Text = u.CUserName;
        ShowGender.Text = u.CUserGender;
        ShowBirthday.Text = Convert.ToString(u.CUserBirthDay);
        ShowAdress.Text = u.CUserAdress;
        ShowHouseNumber.Text = Convert.ToString(u.CUserHouseNumber);
        ShowPassword.Text = u.CUserPassword;
        ShowEmail.Text = u.CUserEmail;
        ShowPhone.Text = u.CUserPhone;
        ShowLastLoginDate.Text = u.CUserDateLogin.ToString();
        HelloLabel.Text = u.CUserName;
        if (!Page.IsPostBack)
        {
            string cityname = "";
            int cityid;
            ds = us.GetCity();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cityid = Convert.ToInt32(ds.Tables[0].Rows[i]["CityId"].ToString()) - 1;
                cityname = ds.Tables[0].Rows[i]["CityName"].ToString();
                DropDownList1.Items.Insert(cityid, cityname);
            }
        }
    }


    protected void EditInfo_Click(object sender, EventArgs e)
    {
        User u = (User)Session["user"];
        if (NewAdress.Visible == false)
        {
            NewAdress.Visible = true;
            NewHouseNumber.Visible = true;
            NewEmail.Visible = true;
            NewPhone.Visible = true;
            NewPassword.Visible = true;
            DropDownList1.Visible = true;
            EditInfo.Text = "סגור";
            NewAdress.Text = u.CUserAdress;
            NewEmail.Text = u.CUserEmail;
            NewPassword.Text = u.CUserPassword;
            NewPhone.Text = u.CUserPhone;
            NewHouseNumber.Text = Convert.ToString(u.CUserHouseNumber);
            SubmitEdit.Visible = true;
            string cityname = ShowCity.Text;
            DropDownList1.SelectedValue = cityname;
        }
        else
        {
            EditInfo.Text = "ערוך";
            NewAdress.Visible = false;
            NewHouseNumber.Visible = false;
            NewEmail.Visible = false;
            NewPhone.Visible = false;
            NewPassword.Visible = false;
            DropDownList1.Visible = false;
            SubmitEdit.Visible = false;
            NewHouseNumberValid.Visible = false;
            NewHouseNumberValid.Text = "";
            NewAdressValid.Text = "";
            NewCityValid.Text = "";
            NewEmailValid.Text = "";
            NewPhoneValid.Text = "";
            NewEmailValid.Text = "";
            NewPasswordValid.Text = "";
            NewAdress.Text = "";
            NewHouseNumber.Text = "";
            NewPassword.Text = "";
            NewPhone.Text = "";
            NewEmail.Text = "";
        }
    }

    protected void SubmitEdit_Click(object sender, EventArgs e)
    {
        NewAdressValid.Text = "";
        NewCityValid.Text = "";
        NewEmailValid.Text = "";
        NewPhoneValid.Text = "";
        NewEmailValid.Text = "";
        NewPasswordValid.Text = "";
        int x = DropDownList1.SelectedIndex;
        if (!(x >= 0 && x < 8))
            NewCityValid.Text = "עיר לא תקינה";
        //add update for city when you send the index and ID of user
        if (!Validation.IsAdressValid(NewAdress.Text))
        {
            NewAdressValid.Text = "כתובת לא תקינה";
        }
        if (!Validation.IsHouseNumberValid(NewHouseNumber.Text))
        {
            NewHouseNumberValid.Text = "מספר בית לא תקין";
        }
        if (!Validation.IsPhoneValid(NewPhone.Text))
        {
            NewPhoneValid.Text = "מספר טלפון לא תקין";
        }
        if (!Validation.IsEMailValid(NewEmail.Text))
        {
            NewEmailValid.Text = "אימייל לא תקין";
        }
        if (!Validation.IsPasswordValid(NewPassword.Text))
        {
            NewPasswordValid.Text = "סיסמא לא עונה על הדרישות";
        }
        //temp
        if (DropDownList1.SelectedIndex == 0)
        {
            NewCityValid.Text = "עיר לא תקינה";
        }
        if (NewCityValid.Text == "" && NewAdressValid.Text == "" && NewCityValid.Text == "" && NewEmailValid.Text == "" && NewPhoneValid.Text == "" && NewEmailValid.Text == "" && NewPasswordValid.Text == "")
        {
            UserService us1 = new UserService();
            us1.UpdateUserCity(ShowId.Text, x + 1);//לבדוק האם צריך להוסיף + 1
            us1.UpdateUserAdress(ShowId.Text, NewAdress.Text);
            us1.UpdateUserHouseNumber(ShowId.Text, Convert.ToInt32(NewHouseNumber.Text));
            us1.UpdateUserPhone(ShowId.Text, NewPhone.Text);
            us1.UpdateUserEmail(ShowId.Text, NewEmail.Text);
            us1.UpdateUserPassword(ShowId.Text, NewPassword.Text);
            NewAdress.Visible = false;
            NewHouseNumber.Visible = false;
            NewEmail.Visible = false;
            NewPhone.Visible = false;
            NewPassword.Visible = false;
            DropDownList1.Visible = false;
            NewAdressValid.Text = "";
            NewCityValid.Text = "";
            NewEmailValid.Text = "";
            NewPhoneValid.Text = "";
            NewEmailValid.Text = "";
            NewPasswordValid.Text = "";
            SubmitEdit.Visible = false;
            User u = GetAllData.GetAllUserDataById(ShowId.Text);
            Session["user"] = u;
            NewAdress.Text = "";
            NewHouseNumber.Text = "";
            NewPassword.Text = "";
            NewPhone.Text = "";
            NewEmail.Text = "";
            Page_Load(sender, e);
            EditInfo.Text = "ערוך";
            System.Threading.Thread.Sleep(1000);
        }

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