using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class UserPrescription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            User u = (User)Session["user"];
            HelloLabel.Text = u.CUserName;
            PrescriptioService ps = new PrescriptioService();
            string whereClout = " where PrescriptionUserId='" + u.CUserId + "'";
            DataSet ds = ps.SortPrescription(whereClout);
            if (ds.Tables[0].Rows.Count != 0)
            {
                ClosePrescription.Visible = true;
                ShowPrescriptionGrid.Visible = true;
                ShowPrescriptionGrid.DataSource = ds;
                ShowPrescriptionGrid.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו מרשמים')</script>");
            }
        }
    }

    protected void ClosePrescription_Click(object sender, EventArgs e)
    {
        ShowPrescriptionGrid.Visible = false;
        ClosePrescription.Visible = false;
    }

    protected void ShowPrescriptionGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "UsePrescription")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int presId = Convert.ToInt32(ShowPrescriptionGrid.Rows[rowNumber].Cells[0].Text);
            int medId = Convert.ToInt32(ShowPrescriptionGrid.Rows[rowNumber].Cells[3].Text);
            int medCount = Convert.ToInt32(ShowPrescriptionGrid.Rows[rowNumber].Cells[5].Text);
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            int medStock = webser.GetMedicineStock(medId);
            if (medCount > medStock)
            {
                Response.Write("<script>alert('אין מספיק תרופות במלאי')</script>");
                return;
            }
            webser.UpdateMedCount(medStock - medCount, medId);
            PrescriptioService ps = new PrescriptioService();
            //get the total price of the prescription
            int medPrice = webser.GetMedicinePrice(medId);
            int totalPrice = medPrice * medCount;
            ps.DeletePrescription(presId);
            Response.Write("<script>alert('המרשם מומש בהצלחה, עלות ההזמנה היא: " + totalPrice + " שקלים')</script>");
            SortPrescription_SelectedIndexChanged(sender, e);
            //need to put this unfinished code in the page of PAYMENT

            //get a redirect to the page of PAYMENT

            //put in the basket the prescription items and wait for premition to check out
            //there is no PAYMENT WEBSITE in this PROJECT
            //or just do a POP UP that says the prescription has been used and the deatails of the order
            //like in the APPOINTMENT PAGE for the USER

            //delete the prescription from database
        }
        if (e.CommandName == "ShowMedicinePrice")
        {
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            int medId = Convert.ToInt32(ShowPrescriptionGrid.Rows[rowNumber].Cells[3].Text);
            string medName = ShowPrescriptionGrid.Rows[rowNumber].Cells[4].Text;
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            int medPrice = webser.GetMedicinePrice(medId);
            Response.Write("<script>alert('מחיר חבילת " + medName + " הוא " + medPrice + " שקלים')</script>");
        }
    }

    protected void ShowPrescriptionGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[3].Visible = false;
    }

    protected void SortPrescription_SelectedIndexChanged(object sender, EventArgs e)
    {
        //init the visible of the gridview and the close button
        ShowPrescriptionGrid.Visible = false;
        ClosePrescription.Visible = false;
        int x = SortPrescription.SelectedIndex;
        DataSet ds;
        PrescriptioService ps = new PrescriptioService();
        User u = (User)Session["user"];
        string whereClout = " where PrescriptionUserId='" + u.CUserId + "'";
        //write every thing is 1 query
        //in the query put the PrescriptionId in cell 0 because this cell is visiable in the gridview
        if (x == 1)
        {
            whereClout += " ORDER BY PrescriptionDate";
            //use query that sort by PrescriptionDate, show all the data
        }
        else if (x == 2)
        {
            whereClout += " ORDER BY PrescriptionDoctorId";
            //use query that sort by PrescriptionDoctorId, show all the data
        }
        ds = ps.SortPrescription(whereClout);


        //DataSet temp = webser.GetCatagoryName()
        //check if ds is empty
        //if he is empty send popup that there is no prescription
        //else, shoe the date in the grid view

        if (ds.Tables[0].Rows.Count != 0)
        {
            ClosePrescription.Visible = true;
            ShowPrescriptionGrid.Visible = true;
            ShowPrescriptionGrid.DataSource = ds;
            ShowPrescriptionGrid.DataBind();
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו מרשמים')</script>");
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