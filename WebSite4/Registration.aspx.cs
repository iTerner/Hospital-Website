using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        NameTB.Text = "";
        IdTB.Text = "";
        GenderFemale.Checked = false;
        GenderMale.Checked = false;
        Calander.Text = "";
        CityList.SelectedIndex = 0;
        AdressTB.Text = "";
        HouseNumberTB.Text = "";
        PhoneTB.Text = "";
        EmailTB.Text = "";
        PasswordTB.Text = "";
        ImutPasswordTB.Text = "";
        NameO.Text = "";
        IdO.Text = "";
        GenderO.Text = "";
        DateO.Text = "";
        CityO.Text = "";
        AdressO.Text = "";
        HouseNumberO.Text = "";
        PhoneO.Text = "";
        EmailO.Text = "";
        PasswordO.Text = "";
        ImutPasswordO.Text = "";
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {

        NameO.Text = "";
        IdO.Text = "";
        GenderO.Text = "";
        DateO.Text = "";
        CityO.Text = "";
        AdressO.Text = "";
        HouseNumberO.Text = "";
        PhoneO.Text = "";
        EmailO.Text = "";
        PasswordO.Text = "";
        ImutPasswordO.Text = "";
       if (!Validation.IsNameValid(NameTB.Text))
            NameO.Text = "שם פרטי לא תקין";
        if (!Validation.IsIdNumberValid(IdTB.Text))
            IdO.Text = "תעודת זהות לא תקינה";
        if (!Validation.IsGenderValid(GenderMale.Checked, GenderFemale.Checked))
            GenderO.Text = "בחירת המין לא תקינה";
        if (!Validation.IsAdressValid(AdressTB.Text))
            AdressO.Text = "כתבות לא תקינה";
        if (CityList.SelectedIndex == 0)
            CityO.Text = "לא בחרת עיר";
        //CityL.Text = Convert.ToString(CityList.SelectedIndex);
        if (!Validation.IsHouseNumberValid(HouseNumberTB.Text))
            HouseNumberO.Text = "מספר בית לא תקין";
        if (!Validation.IsPhoneValid(PhoneTB.Text))
            PhoneO.Text = "מספר טלפון לא תקין";
        if (!Validation.IsEMailValid(EmailTB.Text))
            EmailO.Text = "כתבות מייל לא תקינה";
        if (!Validation.IsPasswordValid(PasswordTB.Text))
            PasswordO.Text = "הסיסמא לא עונה על הדרישות";
        if (!Validation.IsImutPasswordValid(ImutPasswordTB.Text, PasswordTB.Text))
            ImutPasswordO.Text = "אימות הסיסמא לא זהה לסיסמא";
        if (Calander.Text == "")
            DateO.Text = "תאריך לידה לא תקין";
        else
        {
            DateTime dt = Convert.ToDateTime(Calander.Text);
            if (!Validation.IsDateValid(dt))
                DateO.Text = "תאריך לידה לא תקין";
        }
        if (NameO.Text == "" && IdO.Text == "" && GenderO.Text == "" && AdressO.Text == "" && CityO.Text == "" && HouseNumberO.Text == "" &&  PhoneO.Text == "" && EmailO.Text == "" && ImutPasswordO.Text == "" && DateO.Text == "" && (PasswordO.Text == "" || PasswordO.Text == "הסיסמא חייבת להכיל לפחות 8 תווים ולפחות אות גדולה אחת ומספר אחד"))
        {
            User u = new User();
            u.CUserId = IdTB.Text;
            u.CUserName = NameTB.Text;
            if (GenderMale.Checked == true)
                u.CUserGender = "male";
            else
                u.CUserGender = "female";
            u.CUserBirthDay = Convert.ToDateTime(Calander.Text);
            u.CUserCity = CityList.SelectedIndex+1;//צריך להוסיף ברשימת ערים --בחר--
            u.CUserAdress = AdressTB.Text;
            u.CUserHouseNumber = Convert.ToInt32(HouseNumberTB.Text);
            u.CUserEmail = EmailTB.Text;
            u.CUserPassword = PasswordTB.Text;
            u.CUserPhone = PhoneTB.Text;
            UserService US1 = new UserService();
            DataSet ds1 = US1.IsUserAlreadyExsist(IdTB.Text);
            if (ds1.Tables[0].Rows.Count == 0)
            {
                US1.InsertUserToDataBase(u);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                //Response.Redirect("http://he.symbolab.com/solver/equation-calculator");

            }
        }
    }

    protected void PasswordIns_Click(object sender, ImageClickEventArgs e)
    {
        if (PasswordO.Text == "הסיסמא חייבת להכיל לפחות 8 תווים ולפחות אות גדולה אחת ומספר אחד")
        {
            PasswordO.Text = "";
        }
        else
            PasswordO.Text = "הסיסמא חייבת להכיל לפחות 8 תווים ולפחות אות גדולה אחת ומספר אחד";
    }


}