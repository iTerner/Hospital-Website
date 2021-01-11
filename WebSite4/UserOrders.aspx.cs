using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class UserOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            User u = (User)Session["user"];
            HelloLabel.Text = u.CUserName;
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            Session["userId"] = u.CUserId;
            DataSet ds = webser.GetUserOrders(u.CUserId, "");
            if (ds.Tables[0].Rows.Count != 0)
            {
                CloseOrders.Visible = true;
                ShowOrder.Visible = true;
                ShowOrder.DataSource = ds;
                ShowOrder.DataBind();
            }
            else
            {
                Response.Write("<script>alert('לא נמצאו הזמנות')</script>");
            }
        }
    }

    protected void ShowDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Close")
        {
            ShowDetails.Visible = false;
            //unbold all the rows in ShowOrders
            for (int i = 0; i < ShowOrder.Rows.Count; i++)
            {
                ShowOrder.Rows[i].Font.Bold = false;
            }
        }
    }

    protected void ShowOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }

    protected void ShowOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int rowNumber = Convert.ToInt32(e.CommandArgument);
        int orderId = Convert.ToInt32(ShowOrder.Rows[rowNumber].Cells[0].Text);
        Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
        if (e.CommandName == "SeeDetails")
        {
            DataSet ds = webser.GetDetailsAboutOrder(orderId);
            ShowDetails.Visible = true;
            ShowDetails.DataSource = ds;
            ShowDetails.DataBind();
            for (int i = 0; i < ShowOrder.Rows.Count; i++)
            {
                ShowOrder.Rows[i].Font.Bold = false;
            }
            ShowOrder.Rows[rowNumber].Font.Bold = true;
        }
        if (e.CommandName == "DeleteOrder")
        {
            DateTime orderDate = Convert.ToDateTime(ShowOrder.Rows[rowNumber].Cells[2].ToString());
            if (orderDate.AddDays(2) < DateTime.Now)
            {
                webser.DeleteOrder(orderId);
                SortDDL_SelectedIndexChanged(sender, e);
            }
            else
            {
                Response.Write("<script>alert('לא ניתן לבטל את ההזמנה')</script>");
            }
        }
    }

    protected void SortDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        int x = SortDDL.SelectedIndex;
        string order = "";
        switch (x)
        {
            case 1:
                {
                    order = " ORDER BY OrderTotalMoney DESC";
                    break;
                }
            case 3:
                {
                    order = " ORDER BY OrderIsSupplied";
                    break;
                }
            case 2:
                {
                    order = " ORDER BY OrderDate";
                    break;
                }
        }
        Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
        DataSet ds = webser.GetUserOrders((string)Session["userId"], order);
        if (ds.Tables[0].Rows.Count != 0)
        {
            ShowOrder.Visible = true;
            ShowDetails.Visible = false;
            CloseOrders.Visible = true;
            ShowOrder.DataSource = ds;
            ShowOrder.DataBind();
        }
        else
        {
            CloseOrders_Click(sender, e);
            Response.Write("<script>alert('לא נמצאו הזמנות')</script>");
        }
    }

    protected void CloseOrders_Click(object sender, EventArgs e)
    {
        ShowDetails.Visible = false;
        ShowOrder.Visible = false;
        CloseOrders.Visible = false;
        SortDDL.SelectedIndex = 0;
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