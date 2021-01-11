using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class DoctorPrescription : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Doctor d = (Doctor)Session["doctor"];
            HelloLabel.Text = d.CDoctorName;
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            DataSet ds = webser.GetMedinceNameAndId();
            List<ListItem> LI = GetAllData.getListItemsForDDL(ds, "Medicine");
            foreach (ListItem l in LI)
            {
                MedicineNameDDL.Items.Add(l);
            }
            MedicineNameDDL.DataBind();

            UserService us = new UserService();
            ds = us.GetUserNameAndId();
            LI = GetAllData.getListItemsForDDL(ds, "User");
            foreach (ListItem l in LI)
            {
                UserNameDDL.Items.Add(l);
            }
            UserNameDDL.DataBind();

        }
    }

    protected void SendPrescription_Click(object sender, EventArgs e)
    {
        UserIdO.Text = "";
        MedicineNameO.Text = "";
        MedicineCountO.Text = "";
        Doctor d = (Doctor)Session["doctor"];
        bool isValid = true;
        if (MedicineNameDDL.SelectedIndex == 0)
        {
            isValid = false;
            MedicineNameO.Text = "לא בחרת תרופה";
        }
        if (UserNameDDL.SelectedIndex == 0)
        {
            isValid = false;
            UserIdO.Text = "לא בחרת לקוח";
        }
        if (MedicineCountTB.Text != "" && Validation.IsHouseNumberValid(MedicineCountTB.Text))
        {
            if (Convert.ToInt32(MedicineCountTB.Text) <= 0)
            {
                isValid = false;
                MedicineCountO.Text = "כמות לא תקינה";
            }
        }
        else
        {
            isValid = false;
            MedicineCountO.Text = "כמות לא תקינה";
        }
        if (isValid)
        {
            int count = Convert.ToInt32(MedicineCountTB.Text);
            Pharmcy.PharmcyWS webser = new Pharmcy.PharmcyWS();
            Prescription newp = new Prescription();
            PrescriptioService ps = new PrescriptioService();
            newp.CPrescriptionMedicineId = Convert.ToInt32(MedicineNameDDL.SelectedValue);
            DataSet ds = ps.IsPresAlreadyExist(newp.CPrescriptionMedicineId);
            if (ds.Tables[0].Rows.Count != 0)
            {
                int currentCount = Convert.ToInt32(ds.Tables[0].Rows[0]["PrescriptionMedicineCount"].ToString());
                ps.UpdatePresMedCount(newp.CPrescriptionMedicineId, (currentCount + count));
                ResetData_Click(sender, e);
                Response.Write("<script>alert('המרשם נשלח בהצלחה')</script>");
                return;
            }
            newp.CPrescriptionUserId = UserNameDDL.SelectedValue;
            newp.CPrescriptionDoctorId = d.CDoctorId;
            newp.CPrescriptionDate = DateTime.Now;
            newp.CPrescriptionMedicineCount = count;
            newp.CPrescriptionMedicineName = MedicineNameDDL.SelectedItem.Text;
            newp.CPrescriptionMedicineCatagory = webser.GetMedicineCatagory(newp.CPrescriptionMedicineId);
            ps.InsertPrescriptionToDataBase(newp);
            ResetData_Click(sender, e);
            //say the prescription send succesfully
            Response.Write("<script>alert('המרשם נשלח בהצלחה')</script>");
        }
    }

    protected void ResetData_Click(object sender, EventArgs e)
    {
        UserIdO.Text = "";
        UserNameDDL.SelectedIndex = 0;
        MedicineCountO.Text = "";
        MedicineCountTB.Text = "";
        MedicineNameDDL.SelectedIndex = 0;
        MedicineNameO.Text = "";
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