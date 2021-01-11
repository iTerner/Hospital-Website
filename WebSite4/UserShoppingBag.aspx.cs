using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class UserShoppingBag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShoppingBag sb = (ShoppingBag)Session["myShoppingBag"];
            showShoppingBag(sb);
        }
    }

    public void showShoppingBag (ShoppingBag sb)
    {
        if (sb == null || sb.GetProducts().Count == 0)
        {
            ShowShoppingbag.Visible = false;
            Response.Write("<script>alert('הסל ריק')</script>");
        }
        else
        {
            ShowShoppingbag.Visible = true;
            ShowShoppingbag.DataSource = sb.GetProducts();
            ShowShoppingbag.DataBind();
        }
    }

    protected void ShowShoppingbag_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteMedicineFromShoppingBag")
        {
            ShoppingBag sb = (ShoppingBag)Session["myShoppingBag"];
            int rowNumber = Convert.ToInt32(e.CommandArgument);
            MedicineInBag MIB = new MedicineInBag();
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            MIB.CMedicineId = ShowShoppingbag.Rows[rowNumber].Cells[0].Text;
            MIB.CMedicineNeedPrescription = webser.GetMedicineNeedPres(Convert.ToInt32(MIB.CMedicineId));
            if (MIB.CMedicineNeedPrescription)
            {
                List<DataSet> presList = (List<DataSet>)Session["presList"];
                foreach (DataSet d in presList)
                {
                    if (d.Tables[0].Rows[0]["PrescriptionMedicineId"].ToString() == MIB.CMedicineId)
                    {
                        presList.Remove(d);
                        Session["presList"] = presList;
                        break;
                    }
                }
            }
            sb.DeleteMedicineFromList(MIB);
            Session["myShoppingBag"] = sb;
            Response.Write("<script>alert('המוצר נמחק בהצלחה')</script>");
            showShoppingBag(sb);
        }
    }

    protected void ShowShoppingbag_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
    }
}