using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ManagerAppointment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
            GetAllData.Appointment();
            AppointmentService ap = new AppointmentService();
            string whereclout = " WHERE DoctorId=ApointmentDoctorId and UserId=ApointmentUserId and HourNumber=ApointmentHour and ApointmentDay=DayId";
            string order = "";
            string tabels = "Apointment,Users,Hours,Doctors,Days";
            string s = "SELECT ApointmentId,ApointmentDoctorId,ApointmentUserId,ApointmentHour,ApointmentDate,UserName,HourNumber,HourStartTime,HourEndTime,DoctorName,DayName FROM " + tabels;
            s += whereclout;
            DataSet ds = ap.GetApointmentAndSort(s, tabels, order);
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
    }

    protected void SortDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //init the visible of the gridview and the close button
        CloseAppointment.Visible = false;
        ShowAppointment.Visible = false;
        int x = SortDDL.SelectedIndex;
        DataSet ds;
        AppointmentService ap = new AppointmentService();
        //create the SQL query
        string whereclout = " WHERE DoctorId=ApointmentDoctorId and UserId=ApointmentUserId and HourNumber=ApointmentHour and ApointmentDay=DayId";
        string order = "";
        switch (x)
        {
            case 1:
                {
                    order = " ORDER BY ApointmentDoctorId";
                    break;
                }
            case 2:
                {
                    order = " ORDER BY ApointmentUserId";
                    break;
                }
            case 3:
                {
                    order = " ORDER BY ApointmentDate";
                    break;
                }
        }
        string tabels = "Apointment,Users,Hours,Doctors,Days";
        string s = "SELECT ApointmentId,ApointmentDoctorId,ApointmentUserId,ApointmentHour,ApointmentDate,UserName,HourNumber,HourStartTime,HourEndTime,DoctorName,DayName FROM " + tabels;
        s += whereclout;
        ds = ap.GetApointmentAndSort(s, tabels, order);
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

    protected void CloseAppointment_Click(object sender, EventArgs e)
    {
        CloseAppointment.Visible = false;
        ShowAppointment.Visible = false;
        SortDDL.SelectedIndex = 0;
    }

    protected void ShowAppointment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[7].Visible = false;
    }

    protected void ShowAppointment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteAppointment")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int appId = Convert.ToInt32(ShowAppointment.Rows[rowNumber].Cells[0].Text);
            AppointmentService ap = new AppointmentService();
            ap.DeleteAppointment(appId);
            SortDDL_SelectedIndexChanged(sender, e);
        }
    }

    protected void OpenMessage_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerMessage.aspx");
    }

    protected void OpenPrescription_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerPrescription.aspx");
    }

    protected void Appointment_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerAppointment.aspx");
    }

    protected void Orders_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerOrders.aspx");
    }

    protected void Vacation_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://localhost:49675/ManagerVacation.aspx");
    }

    protected void ManagerLogOut_Click(object sender, EventArgs e)
    {
        Session["manager"] = null;
        Response.Redirect("http://localhost:49675/HomePage.aspx");
    }
}