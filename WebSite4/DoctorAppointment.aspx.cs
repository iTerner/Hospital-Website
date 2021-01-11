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

public partial class DoctorAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Doctor d = (Doctor)Session["doctor"];
            HelloLabel.Text = d.CDoctorName;
            GetAllData.VacationsForDoctor();
            GetAllData.Appointment();
        }
    }

    protected void ShowAppointment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //hide ApointmentId, ApointmentHour
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[4].Visible = false;
    }

    protected void SortAppointmentDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowAppointment.Visible = false;
        int x = SortAppointmentDDL.SelectedIndex;
        if (x == 0)
        {
            return;
        }
        string s = "", tabels = "Apointment,Users,Hours,Days", order = " ORDER BY ApointmentDate,ApointmentHour";
        string whereclout = "";
        Doctor doc = (Doctor)Session["doctor"];
        DateTime d;
        //set the SQL query
        switch (x)
        {
            case 1:
                {
                    whereclout = "and ApointmentDate<=#" + DateTime.Now.AddDays(1) + "#";
                    break;
                }
            case 2:
                {
                    d = DateTime.Now.AddDays(7);
                    whereclout = "and ApointmentDate<=#" + d + "#";
                    break;
                }
            case 3:
                {
                    d = DateTime.Now.AddMonths(1);
                    whereclout = "and ApointmentDate<=#" + d + "#";
                    break;
                }
            case 4:
                {
                    d = DateTime.Now.AddYears(1);
                    whereclout = "and ApointmentDate<=#" + d + "#";
                    break;
                }
        }
        s = "SELECT ApointmentId,ApointmentUserId,ApointmentHour,ApointmentDate,UserName,HourStartTime,HourEndTime,DayName FROM " + tabels;
        s += " WHERE ApointmentHour=HourNumber and ApointmentDoctorId='" + doc.CDoctorId + "' and ApointmentUserId=UserId and ApointmentDay=DayId " + whereclout;
        //get the data from the database
        AppointmentService appser = new AppointmentService();
        DataSet ds = appser.GetApointmentAndSort(s, tabels, order);
        //check if the dayaset isnt empty, if so, put the data in the gridview
        if (ds.Tables[0].Rows.Count != 0)
        {
            ShowAppointment.Visible = true;
            ShowAppointment.DataSource = ds;
            ShowAppointment.DataBind();
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו תורים')</script>");
        }
    }

    protected void ShowAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAppointment")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int appId = Convert.ToInt32(ShowAppointment.Rows[rowNumber].Cells[0].Text);
            DateTime appDate = Convert.ToDateTime(ShowAppointment.Rows[rowNumber].Cells[3].Text);
            if (DateTime.Now.AddDays(1) < appDate)
            {
                AppointmentService appser = new AppointmentService();
                appser.DeleteAppointment(appId);
                SortAppointmentDDL_SelectedIndexChanged(sender, e);
            }
            else
            {
                Response.Write("<script>alert('לא ניתן לבטל את התור מכיוון שהתור עוד פחות מיום')</script>");
            }
        }
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