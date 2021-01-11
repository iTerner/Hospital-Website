using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void SortButton_Click(object sender, EventArgs e)
    {
        CloseButton_Click(sender, e);
        DataSet ds;
        string sex;
        DoctorService docs = new DoctorService();
        int spec = DropDownListSpec.SelectedIndex + 1;
        int gen = DropDownListGen.SelectedIndex + 1;
        int city = DropDownListCity.SelectedIndex + 1;
        string manual = ManualSearch.Text;
        string wherestate = "";
        if (spec > 1)
        {
            if (wherestate != "")
            {
                wherestate = wherestate + " and ";
            }
            else
            {
                wherestate = " where ";
            }

            wherestate = wherestate + "DoctorSpecailty = " + spec;
        }
        if (gen > 1)
        {
            if (gen == 2)
                sex = "זכר";
            else
                sex = "נקבה";

            if (wherestate != "") 
            {
                wherestate =wherestate + " and ";
            }
            else
            {
                wherestate = " where ";
            }
            wherestate = wherestate + "DoctorGender='" + sex + "'";
        }
        if (city > 1)
        {
            if (wherestate != "")
            {
                wherestate = wherestate + " and ";
            }
            else
            {
                wherestate = " where ";
            }
            wherestate = wherestate + "DoctorCity=" + city;
        }
        if (wherestate == "")
        {
            wherestate = " where CityId=DoctorCity and SpecialityId=DoctorSpecailty";
        }
        else
        {
            wherestate = wherestate + " and CityId=DoctorCity and SpecialityId=DoctorSpecailty";
        }
        if (manual != "")
        {
            if (wherestate != "")
            {
                wherestate = wherestate + " and ";
            }
            else
            {
                wherestate = " where ";
            }
            wherestate = wherestate + "(DoctorName LIKE '%" + manual + "%')";
        }
        ds = docs.SortDoctor(wherestate);
        if (ds.Tables[0].Rows.Count != 0)
        {
            SearchReasultGrid.Visible = true;
            SearchReasultGrid.DataSource = ds;
            SearchReasultGrid.DataBind();
            CloseButton.Visible = true;
        }
        else
        {
            Response.Write("<script>alert('לא נמצאו רופאים')</script>");
        }
    }

    protected void SearchReasultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Contact")
        {
            User u = (User)Session["user"];
            if (u == null)
            {
                Response.Write("<script>alert('עליך להיות רשום לאתר כדי ליצור קשר')</script>");
            }
            else
            {
                Response.Redirect("http://localhost:49675/UserWriteMessage.aspx");
            }
        }
    }

    protected void CloseButton_Click(object sender, EventArgs e)
    {
        CloseButton.Visible = false;
        SearchReasultGrid.Visible = false;
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        ManualSearch.Text = "";
        DropDownListSpec.SelectedIndex = 0;
        DropDownListGen.SelectedIndex = 0;
        DropDownListCity.SelectedIndex = 0;
        CloseButton_Click(sender, e);
    }
}