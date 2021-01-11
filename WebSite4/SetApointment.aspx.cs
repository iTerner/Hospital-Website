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


public partial class SetApointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            User u = (User)Session["user"];
            HelloLabel.Text = u.CUserName;
            DoctorService docser = new DoctorService();
            DataSet ds = docser.GetSpecailty();
            List<ListItem> list = GetAllData.getListItemsForDDL(ds, "Speciality");
            SpecailtyDropDownList.Items.Clear();
            foreach (ListItem l in list)
            {
                SpecailtyDropDownList.Items.Add(l);
            }
            SpecailtyDropDownList.DataBind();
            GetAllData.VacationsForDoctor();
        }

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        Appointment a = (Appointment)Session["newAppointment"];
        AppointmentService appser = new AppointmentService();
        a.CApointmentDay = (int)Session["dayNumber"];
        string s = "INSERT INTO Apointment(ApointmentUserId,ApointmentDoctorId,ApointmentDate,ApointmentHour,ApointmentDay) VALUES('" + a.CApointmentUserId + "','" + a.CApointmentDoctorId + "',#" + a.CApointmentDate + "#," + a.CApointmentHour + "," + a.CApointmentDay + ")";
        appser.InsertAppointment(s);

        //init everything
        ResetButton_Click(sender, e);

        //make the alert of the appointment
        DateTime d = (DateTime)Session["ApDate"];
        Response.Write("<script>alert('נקבע עבורך תור לרופא " + (string)Session["doctorName"] + " בתאריך " + d.Date + " משעה " + (string)Session["sh"] + " עד שעה " + (string)Session["eh"] + "')</script>");

    }

    protected void DateTB_TextChanged(object sender, EventArgs e)
    {
        HoursGridView.Visible = false;

        /*
         * ברגע שהמשתמש בוחר איזה תאריך הוא רוצה יופיעו ברשימה הנגללת למטה
         * כל השעות שהוא יכול לבחור לעשות את התור, כל עוד התור לא תפוס
         * אם המשתמש בחר תאריך שבו לרופא הספציפי שהוא בחר אין תורים פנויים
         * בלייבל למטה יהיה כתוב "ביום זה לרופא (שם הרופא) אין תורים, אנא בחר תאריך אחר
         */

        DateValid.Text = "";

        if (DateTB.Text == "")
        {
            Response.Write("<script>alert('תאריך לא תקין')</script>");
            AppHour.Visible = false;
            SubmitButton.Visible = false;
            ResetButton.Visible = false;
            return;
        }

        DateTime selectedDate = Convert.ToDateTime(DateTB.Text);

        if (selectedDate < DateTime.Now.Date)
        {

            Response.Write("<script>alert('תאריך לא תקין')</script>");
            AppHour.Visible = false;
            SubmitButton.Visible = false;
            ResetButton.Visible = false;
            return;
        }

        string day = Convert.ToString(Convert.ToDateTime(DateTB.Text).DayOfWeek);
        int dayNumber = 0;
        if (day == "Sunday")
        {

            dayNumber = 1;
        }
        else if (day == "Monday")
        {
            dayNumber = 2;
        }
        else if (day == "Tuesday")
        {
            dayNumber = 3;
        }
        else if (day == "Wednesday")
        {
            dayNumber = 4;
        }
        else if (day == "Thursday")
        {
            dayNumber = 5;
        }
        else if (day == "Friday")
        {
            dayNumber = 6;
        }
        Session["dayNumber"] = dayNumber;

        ////////////////////////////////////////////////////////

        string doctorId = (string)Session["doctorId"];
        WorkDaysService wds = new WorkDaysService();
        DataSet ds = wds.GetAllWorkingDaysForDoctor(doctorId);
        int count = 0;
        //put all the days the doctor works in a list
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (Convert.ToInt32(ds.Tables[0].Rows[i]["WorkDay"]) == dayNumber)
                break;
            count++;
        }
        if (count >= ds.Tables[0].Rows.Count)
        {
            Response.Write("<script>alert('הרופא שבחרת לא עובד ביום זה אנא בחר רופא אחר או יום אחר')</script>");
            AppHour.Visible = false;
            SubmitButton.Visible = false;
            ResetButton.Visible = false;
            return;
        }
        /*
         * להציג ברשימה הנגללת את כל השעות הפנויות של הרופא ביום הנבחר
         * לרשום שאילתה שעוברת על הטבלה של תורים בדאטאבייס ובודקת האם יש תור כזה כבר
         * אם יש היא לא מציגה את התור ברישמה הנגללת
         * אם לא קיים היא מציגה אותו ברשימה הנגללת
         */

        ds = wds.GetStartAndEndHour(doctorId, dayNumber);
        int StartTime = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorStartTime"].ToString());
        int EndTime = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorEndTime"].ToString());

        /*
         * לעשות שאילתה בשעות שמקבלת שעת התחלה וסיום ומחזירה את כל התורים האפשריים
         * לעשות קודם בדיקות תקינות פשוטות למרות שאין כל כך צורך
         * לשים את כל הנתונים בגריד וויו
         */
        HourService hs = new HourService();
        ds = hs.GetApointmentTime(StartTime, EndTime);
        Appointment a = new Appointment();

        //הלולאה מוחקת את כל השעות שבהם לרופא זה כבר יש תורים

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            a.CApointmentDate = selectedDate;
            a.CApointmentHour = Convert.ToInt32(ds.Tables[0].Rows[i]["HourNumber"].ToString());
            a.CApointmentDoctorId = DoctorDropDownList.SelectedValue;
            //לרשום שאילתה שבודקת האם תור כזה קיים
            AppointmentService ap = new AppointmentService();
            DataSet temp = ap.IsAppointmentExist(a.CApointmentDoctorId, a.CApointmentDate, a.CApointmentHour);
            if (temp.Tables[0].Rows.Count != 0)
            {
                //delete the line i from the dataset
                ds.Tables[0].Rows[i].Delete();
            }
        }
        //שם את השעות הפנויות בגריד וויו

        HoursGridView.Visible = true;
        HoursGridView.DataSource = ds;
        HoursGridView.DataBind();

        AppHour.Visible = true;

        Session["ApDate"] = selectedDate;

    }

    protected void HoursGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        /*
         * ליצור משתנה שמכיל את כל הנתונים על התור
         * שעת התחלה, שעת סיום, תעודת זהות רופא, יום וכולי
         * לעשות בדיקה האם התור כבר קיים במערכת או לא
         */

        //init
        SubmitButton.Visible = false;
        ResetButton.Visible = false;

        //unbold all the rows
        for (int i = 0; i < HoursGridView.Rows.Count; i++)
        {
            HoursGridView.Rows[i].Font.Bold = false;
        }

        if (e.CommandName == "SetApointment")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int hourNumber = Convert.ToInt32(HoursGridView.Rows[rowNumber].Cells[0].Text);

            //bold the selected hour
            HoursGridView.Rows[rowNumber].Font.Bold = true;

            //create the appointment and add him to the database
            Appointment a = new Appointment();
            a.CApointmentDate = (DateTime)Session["ApDate"];
            a.CApointmentDoctorId = (string)Session["doctorId"];
            a.CApointmentHour = hourNumber;
            User u = (User)Session["user"];
            a.CApointmentUserId = u.CUserId;
            Session["newAppointment"] = a;

            string docName = (string)Session["doctorName"];
            string startHour = HoursGridView.Rows[rowNumber].Cells[1].Text;
            string EndHour = HoursGridView.Rows[rowNumber].Cells[2].Text;

            SubmitButton.Visible = true;
            ResetButton.Visible = true;

            Session["sh"] = startHour;
            Session["eh"] = EndHour;
        }

    }

    protected void SpecailtyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
         * לעשות שאילתה שלפי הקטגוריה שנבחרה מציגה את הרופאים
         * לעשות feedback
         * לשמור בענן את הקטגוריה שנבחרה
         */

        //init

        int docSpec = Convert.ToInt32(SpecailtyDropDownList.SelectedValue);
        string s = " where DoctorIsOnVacation=false and DoctorSpecailty=" + docSpec;

        DoctorService docser = new DoctorService();
        DataSet ds = docser.GetDoctorName(s);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DoctorDropDownList.Visible = true;
            Label4.Visible = true;
            List<ListItem> list = GetAllData.getListItemsForDDL(ds, "Doctor");
            DoctorDropDownList.Items.Clear();
            foreach (ListItem l in list)
            {
                DoctorDropDownList.Items.Add(l);
            }
            DoctorDropDownList.DataBind();
            Session["Spec"] = docSpec;
        }
        else
        {
            SpecalityValid.Visible = true;
            AppHour.Visible = false;
            SubmitButton.Visible = false;
            ResetButton.Visible = false;
            DateTB.Visible = false;
            Label6.Visible = false;
            Response.Write("<script>alert('אין רופאים תחת התמחות זו')</script>");
        }

    }

    protected void DoctorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
         * להציג את הלוח שנה 
         * רק עבור הרופא הספיפי שנבחר
         * לשמור את התעודת זהות של הרופא בענן
         */
        DateTB.Visible = true;
        Label6.Visible = true;
        DateTB.Text = "";
        AppHour.Visible = false;
        ResetButton.Visible = false;
        SubmitButton.Visible = false;
        DateValid.Text = "";
        Session["doctorId"] = DoctorDropDownList.SelectedValue;
        Session["doctorName"] = DoctorDropDownList.SelectedItem.Text;
    }

    protected void HoursGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void HoursGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        HoursGridView.PageIndex = e.NewPageIndex;
        DateTB_TextChanged(sender, e);
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        DoctorDropDownList.Visible = false;
        Label4.Visible = false;
        DateTB.Visible = false;
        Label6.Visible = false;
        Label8.Visible = false;
        HoursGridView.Visible = false;
        SubmitButton.Visible = false;
        AppHour.Visible = false;
        DateTB.Text = "";
        ResetButton.Visible = false;
        SpecailtyDropDownList.SelectedIndex = 0;
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        Session["user"] = null;
        Session["myShoppingBag"] = null;
        Response.Redirect("http://localhost:49675/GuestHome.aspx");
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