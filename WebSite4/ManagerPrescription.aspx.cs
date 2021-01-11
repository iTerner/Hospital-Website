using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ManagerPrescription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
            string whereclout = " where DoctorId=PrescriptionDoctorId and UserId=PrescriptionUserId";
            PrescriptioService ps = new PrescriptioService();
            DataSet ds = ps.SortPrescriptionManager(whereclout);
            ShowPrescription.Visible = false;
            if (ds.Tables[0].Rows.Count != 0)
            {
                ClosePrescription.Visible = true;
                ShowPrescription.Visible = true;
                ShowPrescription.DataSource = ds;
                ShowPrescription.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו מרשמים')</script>");
            }
        }
    }

    protected void ShowPrescription_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[6].Visible = false;
    }

    protected void ShowPrescription_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeletePrescription")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int presId = Convert.ToInt32(ShowPrescription.Rows[rowNumber].Cells[0].Text);
            PrescriptioService ps = new PrescriptioService();
            ps.DeletePrescription(presId);
            SortDDL_SelectedIndexChanged(sender, e);
        }
    }

    protected void ClosePrescription_Click(object sender, EventArgs e)
    {
        ClosePrescription.Visible = false;
        ShowPrescription.Visible = false;
        SortDDL.SelectedIndex = 0;
    }

    protected void SortDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        //init the visible of the gridview and the close button
        ClosePrescription.Visible = false;
        ShowPrescription.Visible = false;
        int x = SortDDL.SelectedIndex;
        DataSet ds;
        PrescriptioService ps = new PrescriptioService();
        //create the SQL query
        string whereclout = " WHERE DoctorId=PrescriptionDoctorId and UserId=PrescriptionUserId";
        switch (x)
        {
            case 1:
                {
                    whereclout += " ORDER BY PrescriptionDoctorId";
                    break;
                }
            case 2:
                {
                    whereclout += " ORDER BY PrescriptionUserId";
                    break;
                }
            case 3:
                {
                    whereclout += " ORDER BY PrescriptionMedicineId";
                    break;
                }
            case 4:
                {
                    whereclout += " ORDER BY PrescriptionDate";
                    break;
                }
        }
        ds = ps.SortPrescriptionManager(whereclout);
        if (ds.Tables[0].Rows.Count != 0)
        {
            ClosePrescription.Visible = true;
            ShowPrescription.Visible = true;
            ShowPrescription.DataSource = ds;
            ShowPrescription.DataBind();
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו מרשמים')</script>");
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