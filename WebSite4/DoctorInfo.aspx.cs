using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class DoctorInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Doctor d = (Doctor)Session["doctor"];
        HelloLabel.Text = d.CDoctorName;
        DoctorService docser = new DoctorService();
        DataSet ds = docser.GetDoctorCityName(d.CDoctorId);
        ShowCity.Text = ds.Tables[0].Rows[0]["CityName"].ToString();
        ShowId.Text = d.CDoctorId;
        ShowName.Text = d.CDoctorName;
        ShowGender.Text = d.CDoctorGender;
        ShowBirthday.Text = Convert.ToString(d.CDoctorBirthday);
        ShowSpecailty.Text = ds.Tables[0].Rows[0]["SpecialityName"].ToString();
        ShowLice.Text = Convert.ToString(d.CDoctorLicense);
        ShowPassword.Text = d.CDoctorPassword;
        if (d.CDoctorIsOnVacation == true)
        {
            showVacation.Text = "כן";
        }
        else
        {
            showVacation.Text = "לא";
        }
        ShowPhone.Text = d.CDoctorPhone;
        ShowUni.Text = d.CDoctorUniversity;
        if (!Page.IsPostBack)
        {
            string cityname = "", specName = "";
            int cityid;
            DataSet temp = docser.GetSpec();
            UserService us = new UserService();
            ds = us.GetCity();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cityid = Convert.ToInt32(ds.Tables[0].Rows[i]["CityId"].ToString()) - 1;
                cityname = ds.Tables[0].Rows[i]["CityName"].ToString();
                DropDownList1.Items.Insert(cityid, cityname);
            }
            for (int i = 0; i < temp.Tables[0].Rows.Count; i++)
            {
                cityid = Convert.ToInt32(temp.Tables[0].Rows[i]["SpecialityId"].ToString()) - 1;
                specName = temp.Tables[0].Rows[i]["SpecialityName"].ToString();
                SpecDDL.Items.Insert(cityid, specName);
            }
            //check the vacation for the doctors
            GetAllData.VacationsForDoctor();
        }
    }

    protected void SubmitEdit_Click(object sender, EventArgs e)
    {
        NewSpecValid.Text = "";
        NewCityValid.Text = "";
        NewUniValid.Text = "";
        NewPhoneValid.Text = "";
        NewLiceValid.Text = "";
        NewPasswordValid.Text = "";
        int spec = SpecDDL.SelectedIndex, city = DropDownList1.SelectedIndex;
        if (!Validation.IsPasswordValid(NewPassword.Text))
        {
            NewPasswordValid.Text = "סיסמא לא עונה על הדרישות";
        }
        if (!Validation.IsPhoneValid(NewPhone.Text))
        {
            NewPhoneValid.Text = "מספר טלפון לא תקין";
        }
        //temp
        if (DropDownList1.SelectedIndex == 0)
        {
            NewCityValid.Text = "עיר לא תקינה";
        }
        if (SpecDDL.SelectedIndex == 0)
        {
            NewSpecValid.Text = "התמחות לא תקינה";
        }
        if (!Validation.IsHouseNumberValid(NewLice.Text))
        {
            NewLiceValid.Text = "מספר שנים במקצוע לא תקין";
        }
        if (!Validation.IsNameValid(NewUni.Text))
        {
            NewUniValid.Text = "אוניברסיטה לא תקינה";
        }
        if (NewUniValid.Text == "" && NewLiceValid.Text == "" && NewSpecValid.Text == "" && NewCityValid.Text == "" && NewPhoneValid.Text == "" && NewPasswordValid.Text == "")
        {
            //update all the data
            string s = "DoctorCity=" + (DropDownList1.SelectedIndex + 1) + ",DoctorSpecailty=" + (SpecDDL.SelectedIndex + 1) + ",DoctorLicense=" + Convert.ToInt32(NewLice.Text) + ",DoctorUniversity='" + NewUni.Text + "',DoctorPhone='" + NewPhone.Text + "',DoctorPassword='" + NewPassword.Text + "'";
            s = s + " WHERE DoctorId ='" + ShowId.Text + "'";
            DoctorService docser = new DoctorService();
            docser.UpdateDoctorInfo(s);
            NewLice.Visible = false;
            NewUni.Visible = false;
            SpecDDL.Visible = false;
            NewPhone.Visible = false;
            NewPassword.Visible = false;
            DropDownList1.Visible = false;
            NewLiceValid.Text = "";
            NewCityValid.Text = "";
            NewUniValid.Text = "";
            NewPhoneValid.Text = "";
            NewSpecValid.Text = "";
            NewPasswordValid.Text = "";
            SubmitEdit.Visible = false;
            Doctor d = GetAllData.GetAllDoctorDataById(ShowId.Text);
            Session["doctor"] = d;
            NewLice.Text = "";
            NewUni.Text = "";
            NewPassword.Text = "";
            NewPhone.Text = "";
            Page_Load(sender, e);
            EditInfo.Text = "ערוך";
            System.Threading.Thread.Sleep(1000);
        }
    }

    protected void EditInfo_Click(object sender, EventArgs e)
    {
        Doctor d = (Doctor)Session["doctor"];
        if (NewLice.Visible == false)
        {
            if (Label7.Visible == true)
            {
                Response.Write("<script>alert('אתה קודם חייב לסיים את בקשת החופשה או לסגור אותה')</script>");
                return;
            }
            NewLice.Visible = true;
            NewUni.Visible = true;
            SpecDDL.Visible = true;
            NewPhone.Visible = true;
            NewPassword.Visible = true;
            DropDownList1.Visible = true;
            EditInfo.Text = "סגור";
            NewUni.Text = d.CDoctorUniversity;
            NewPassword.Text = d.CDoctorPassword;
            NewPhone.Text = d.CDoctorPhone;
            NewLice.Text = Convert.ToString(d.CDoctorLicense);
            SubmitEdit.Visible = true;
            string cityname = ShowCity.Text;
            DropDownList1.SelectedValue = cityname;
            string specName = ShowSpecailty.Text;
            SpecDDL.SelectedValue = specName;
        }
        else
        {
            EditInfo.Text = "ערוך";
            NewLice.Visible = false;
            NewUni.Visible = false;
            SpecDDL.Visible = false;
            NewPhone.Visible = false;
            NewPassword.Visible = false;
            DropDownList1.Visible = false;
            SubmitEdit.Visible = false;
            NewSpecValid.Text = "";
            NewCityValid.Text = "";
            NewUniValid.Text = "";
            NewPhoneValid.Text = "";
            NewLiceValid.Text = "";
            NewPasswordValid.Text = "";
            NewPassword.Text = "";
            NewPhone.Text = "";
        }
    }

    protected void AskForVacation_Click(object sender, EventArgs e)
    {
        if (AskForVacation.Text == "בקשת חופשה")
        {
            Label7.Visible = true;
            Label8.Visible = true;
            Label9.Visible = true;
            FromDate.Visible = true;
            ToDate.Visible = true;
            SetVacation.Visible = true;
            CauseForVacation.Visible = true;
            AskForVacation.Text = "סגור";
            AskForVacation.CssClass = "btn btn-outline-danger";
        }
        else
        {
            Label7.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            FromDate.Visible = false;
            ToDate.Visible = false;
            SetVacation.Visible = false;
            CauseForVacation.Visible = false;
            ToDate.Text = "";
            FromDate.Text = "";
            CauseForVacation.Text = "";
            AskForVacation.Text = "בקשת חופשה";
            AskForVacation.CssClass = "btn btn-outline-primary";
        }
    }

    protected void SetVacation_Click(object sender, EventArgs e)
    {
        //create a message to the manager

        /*
         *נושא הודעה: בקשה לחופשה
         * תוכן הודעה: שלום 
         * אני (שם הרופא + מספר תעודת זהות) מבקש חופשה מתאריך(תחילת) עד תאריך (תאריך סיום) בעקבות (סיבה)ג
         */
        
        //validation
        if (FromDate.Text == "" || Convert.ToDateTime(FromDate.Text) < DateTime.Now)
        {
            Response.Write("<script>alert('בחירת תאריך לא תקינה')</script>");
            return;
        }
        if (ToDate.Text == "" || Convert.ToDateTime(ToDate.Text) < DateTime.Now || Convert.ToDateTime(ToDate.Text) < Convert.ToDateTime(FromDate.Text))
        {
            Response.Write("<script>alert('בחירת תאריך לא תקינה')</script>");
            return;
        }
        if (CauseForVacation.Text == "")
        {
            Response.Write("<script>alert('לא כתבת סיבה לחופשה')</script>");
            return;
        }

        //there is only one manager. his name is Ido Terner
        DateTime senddate = DateTime.Now;
        string docId = ShowId.Text;
        string theme = "בקשה לחופשה";
        string content = "שלום, " + ShowName.Text + " מספר זהות: " + ShowId.Text + " מבקש חופשה מתאריך: " + Convert.ToDateTime(FromDate.Text) + " עד לתאריך: " + Convert.ToDateTime(ToDate.Text) + " בעקבות: " + CauseForVacation.Text;
        string s = "";
        s = "INSERT INTO Messages(MessageManagerId,MessageDoctorId,MessageContent,MessageTheme,MessageSendDate,MessageWhoSent)";
        s = s + " VALUES('325132850','" + docId + "','" + content + "','" + theme + "',#" + senddate + "#,'doctor')";
        MessageService ms = new MessageService();
        ms.InseartMessageToDatabase(s);
        AskForVacation_Click(sender, e);
        Response.Write("<script>alert('ההודעה נשלחה בהצלחה')</script>");
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