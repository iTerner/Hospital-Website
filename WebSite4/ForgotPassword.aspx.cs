using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangePassword_Click(object sender, EventArgs e)
    {
        ConfirmPasswordO.Text = "";
        IdO.Text = "";
        NewPasswordO.Text = "";
        bool isValid = true;
        string who = "";
        string id = IdTB.Text, pass = NewPasswordTB.Text, conf = ConfirmPasswordTB.Text;
        UserService us = new UserService();
        DoctorService ds = new DoctorService();
        ManagerService ms = new ManagerService();
        if (id == "")
        {
            IdO.Text = "תעודת זהות זאת לא נמצאת במערכת";
            isValid = false;
        }
        if (us.IsUserAlreadyExsist(id).Tables[0].Rows.Count == 0)
        {
            if (ds.IsDoctorAlreadyExsist(id).Tables[0].Rows.Count == 0)
            {
                if (ms.IsManagerExsist(id).Tables[0].Rows.Count == 0)
                {
                    IdO.Text = "תעודת זהות זאת לא נמצאת במערכת";
                    isValid = false;
                }
                else
                {
                    who = "manager";
                }
            }
            else
            {
                who = "doctor";
            }
        }
        else
        {
            who = "user";
        }
        if (!Validation.IsPasswordValid(pass))
        {
            NewPasswordO.Text = "סיסמא לא עונה על הדרישות";
            isValid = false;
        }
        if (!pass.Equals(conf))
        {
            ConfirmPasswordO.Text = "הסיסמא לא זהה";
            isValid = false;
        }
        if (isValid)
        {
            if (who == "user")
            {
                us.UpdateUserPassword(id, pass);
            }
            else if (who == "doctor")
            {
                ds.UpdateDoctorsPassword(id, pass);
            }
            else
            {
                ms.UpdateManagerPassword(id, pass);
            }
        Response.Write("<script>alert('הסיסמא שונתה בהצלחה')</script>");
        ResetButton_Click(sender, e);
        }
    }

    protected void ResetButton_Click(object sender, EventArgs e)
    {
        ConfirmPasswordTB.Text = "";
        IdTB.Text = "";
        NewPasswordTB.Text = "";
        ConfirmPasswordO.Text = "";
        IdO.Text = "";
        NewPasswordO.Text = "";
    }
}