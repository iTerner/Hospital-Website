using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ManagerVacation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
            GetAllData.VacationsForDoctor();
            VacationService vs = new VacationService();
            string whereclout = " WHERE DoctorId=VacationDoctorId and ManagerId=VacationManagerId";
            DataSet ds = vs.SortVacation(whereclout);
            ShowVac.Visible = false;
            if (ds.Tables[0].Rows.Count != 0)
            {
                CloseVac.Visible = true;
                ShowVac.Visible = true;
                ShowVac.DataSource = ds;
                ShowVac.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו חופשות')</script>");
            }
        }
    }

    protected void ShowVac_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowVac_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteVac")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int vacId = Convert.ToInt32(ShowVac.Rows[rowNumber].Cells[0].Text);
            VacationService vs = new VacationService();
            vs.DeleteVacation(vacId);
            SortDDL_SelectedIndexChanged(sender, e);
        }
    }

    protected void SortDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds;
        VacationService vs = new VacationService();
        string whereclout = " WHERE DoctorId=VacationDoctorId and ManagerId=VacationManagerId";
        int x = SortDDL.SelectedIndex;
        switch (x)
        {
            case 1:
                {
                    whereclout += " ORDER BY VacationDoctorId";
                    break;
                }
            case 2:
                {
                    whereclout += " ORDER BY VacationManagerId";
                    break;
                }
            case 3:
                {
                    whereclout += " ORDER BY VacationStartDate";
                    break;
                }
        }
        ds = vs.SortVacation(whereclout);
        if (ds.Tables[0].Rows.Count != 0)
        {
            CloseVac.Visible = true;
            ShowVac.Visible = true;
            ShowVac.DataSource = ds;
            ShowVac.DataBind();
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו חופשות')</script>");
        }
        
    }

    protected void CloseVac_Click(object sender, EventArgs e)
    {
        CloseVac.Visible = false;
        ShowVac.Visible = false;
        SortDDL.SelectedIndex = 0;
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