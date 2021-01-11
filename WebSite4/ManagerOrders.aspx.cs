using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ManagerOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Manager m = (Manager)Session["manager"];
            HelloLabel.Text = m.CManagerName;
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            DataSet ds = webser.GetAllOrders("");
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

    protected void CloseOrders_Click(object sender, EventArgs e)
    {
        ShowDetails.Visible = false;
        ShowOrder.Visible = false;
        CloseOrders.Visible = false;
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
        if (e.CommandName == "SendOrder")
        {
            webser.UpdateOrderSupplied(orderId);
            //show all the orders
            SortButton_Click(sender, e);
        }
        if (e.CommandName == "DeleteOrder")
        {
            webser.DeleteOrder(orderId);
            //show all the orders
            SortButton_Click(sender, e);
        }
        if (e.CommandName == "SeeDetails")
        {
            if (ShowDetails.Visible == false)
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

    protected void HighToLow_CheckedChanged(object sender, EventArgs e)
    {
        if (HighToLow.Checked)
        {
            LowToHigh.Checked = false;
        }
    }

    protected void LowToHigh_CheckedChanged(object sender, EventArgs e)
    {
        if (LowToHigh.Checked)
        {
            HighToLow.Checked = false;
        }
    }

    protected void SortButton_Click(object sender, EventArgs e)
    {
        string order = " ORDER BY ", temp = order;
        if (HighToLow.Checked)
        {
            if (order.Equals(temp))
            {
                order += "OrderTotalMoney DESC";
            }
            else
            {
                order += ",OrderTotalMoney DESC";
            }
        }
        if (LowToHigh.Checked)
        {
            if (order.Equals(temp))
            {
                order += "OrderTotalMoney ASC";
            }
            else
            {
                order += ",OrderTotalMoney ASC";
            }
        }
        if (SortUser.Checked)
        {
            if (order.Equals(temp))
            {
                order += "OrderUserId ASC";
            }
            else
            {
                order += ",OrderUserId ASC";
            }
        }
        if (SortDate.Checked)
        {
            if (order.Equals(temp))
            {
                order += "OrderDate";
            }
            else
            {
                order += ",OrderDate";
            }
        }
        if (IsSupplied.Checked)
        {
            if (order.Equals(temp))
            {
                order += "OrderIsSupplied";
            }
            else
            {
                order += ",OrderIsSupplied";
            }
        }
        if (order.Equals(temp))
        {
            order = "";
        }
        Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
        //sort the orders
        DataSet ds = webser.GetAllOrders(order);
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

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        LowToHigh.Checked = false;
        HighToLow.Checked = false;
        SortDate.Checked = false;
        SortUser.Checked = false;
        IsSupplied.Checked = false;
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