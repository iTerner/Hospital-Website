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

public partial class UserAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User u = (User)Session["user"];
        HelloLabel.Text = u.CUserName;
        GetAllData.VacationsForDoctor();
        GetAllData.Appointment();
        AppointmentService appser = new AppointmentService();
        string s = "", tables = "Apointment,Doctors,Speciality,Hours,Days";
        s = "SELECT ApointmentId,ApointmentDate,ApointmentHour,DoctorName,HourStartTime,HourEndTime,SpecialityName,DayName FROM " + tables;
        s += " WHERE ApointmentHour=HourNumber and ApointmentDoctorId=DoctorId and SpecialityId=DoctorSpecailty and ApointmentDay=DayId and ApointmentUserId='" + u.CUserId + "'";
        Session["s"] = s;
        Session["tabels"] = tables;
        DataSet ds = appser.GetApointmentAndSort(s, tables, "");
        if (ds.Tables[0].Rows.Count != 0)
        {
            CloseApointment.Visible = true;
            SortDDL.Visible = true;
            ApointmentGrid.Visible = true;
            ApointmentGrid.DataSource = ds;
            ApointmentGrid.DataBind();
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו תורים')</script>");
        }
    }

    protected void CloseApointment_Click(object sender, EventArgs e)
    {
        CloseApointment.Visible = false;
        ApointmentGrid.Visible = false;
        SortDDL.SelectedIndex = 0;
    }

    protected void SortDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        int x = SortDDL.SelectedIndex;
        string s = (string)Session["s"], tabels = (string)Session["tabels"];
        string order = "";
        switch (x)
        {
            case 0:
                {
                    Response.Write("<script>alert('עליך לבחור דרך סינון')</script>");
                    break;
                }
            case 1:
                {
                    order = " ORDER BY DoctorName";
                    break;
                }
            case 2:
                {
                    order = " ORDER BY SpecialityName";
                    break;
                }
            case 3:
                {
                    order = " ORDER BY ApointmentDate";
                    break;
                }
            case 4:
                {
                    order = " ORDER BY ApointmentHour,ApointmentDate";
                    break;
                }
        }
        AppointmentService appser = new AppointmentService();
        DataSet ds = appser.GetApointmentAndSort(s, tabels, order);
        ApointmentGrid.DataSource = ds;
        ApointmentGrid.DataBind();

    }


    protected void ApointmentGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[4].Visible = false;
    }

    protected void ApointmentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAppointment")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int ApointmentId = Convert.ToInt32(ApointmentGrid.Rows[rowNumber].Cells[0].Text);
            AppointmentService appser = new AppointmentService();
            appser.DeleteAppointment(ApointmentId);
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