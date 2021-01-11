using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for GetAllData
/// </summary>
public static class GetAllData
{
    public static User GetAllUserDataById(string userId)
    {
        User u = new User();
        UserService us = new UserService();
        DataSet ds = us.IsUserAlreadyExsist(userId);
        if (ds.Tables[0].Rows.Count == 1)
        {
            u.CUserId = userId;
            u.CUserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
            u.CUserGender = Convert.ToString(ds.Tables[0].Rows[0]["UserGender"]);
            u.CUserBirthDay = Convert.ToDateTime(ds.Tables[0].Rows[0]["UserBirth"]);
            u.CUserCity = Convert.ToInt32(ds.Tables[0].Rows[0]["UserCity"]);
            u.CUserAdress = Convert.ToString(ds.Tables[0].Rows[0]["UserAdress"]);
            u.CUserHouseNumber = Convert.ToInt32(ds.Tables[0].Rows[0]["UserHouseNumber"]);
            u.CUserPhone = Convert.ToString(ds.Tables[0].Rows[0]["UserPhone"]);
            u.CUserEmail = Convert.ToString(ds.Tables[0].Rows[0]["UserEmail"]);
            u.CUserPassword = Convert.ToString(ds.Tables[0].Rows[0]["UserPassword"]);
            u.CUserDateLogin = Convert.ToDateTime(ds.Tables[0].Rows[0]["UserDateLogin"]);
        }
        return u;
    }
    public static Doctor GetAllDoctorDataById(string doctorId)
    {
        Doctor d = new Doctor();
        DoctorService docser = new DoctorService();
        DataSet ds = docser.IsDoctorAlreadyExsist(doctorId);
        if (ds.Tables[0].Rows.Count == 1)
        {
            d.CDoctorId = doctorId;
            d.CDoctorName = Convert.ToString(ds.Tables[0].Rows[0]["DoctorName"]);
            d.CDoctorGender = Convert.ToString(ds.Tables[0].Rows[0]["DoctorGender"]);
            d.CDoctorSpeciality = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorSpecailty"]);
            d.CDoctorLicense = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorLicense"]);
            d.CDoctorBirthday = Convert.ToDateTime(ds.Tables[0].Rows[0]["DoctorBirthDay"]);
            d.CDoctorUniversity = Convert.ToString(ds.Tables[0].Rows[0]["DoctorUniversity"]);
            d.CDoctorCity = Convert.ToInt32(ds.Tables[0].Rows[0]["DoctorCity"]);
            d.CDoctorPhone = Convert.ToString(ds.Tables[0].Rows[0]["DoctorPhone"]);
            d.CDoctorPassword = Convert.ToString(ds.Tables[0].Rows[0]["DoctorPassword"]);
            d.CDoctorIsOnVacation = Convert.ToBoolean(ds.Tables[0].Rows[0]["DoctorIsOnVacation"]);
        }
        return d;
    }
    public static Manager GetAllManagerDataById(string managerId)
    {
        Manager m = new Manager();
        ManagerService ms = new ManagerService();
        DataSet ds = ms.IsManagerExsist(managerId);
        if (ds.Tables[0].Rows.Count == 1)
        {
            m.CManagerId = managerId;
            m.CManagerName = Convert.ToString(ds.Tables[0].Rows[0]["ManagerName"]);
            m.CManagerPassword = Convert.ToString(ds.Tables[0].Rows[0]["ManagerPassword"]);
        }
        return m;
    }
    public static Message GetAllDataFromMessageForAnswer(int MessageId, string whoSent)
    {
        Message m = new Message();
        MessageService ms = new MessageService();
        DataSet ds;
        string s, ws = whoSent;
        string temp = whoSent.Substring(0, 1);
        temp = temp.ToUpper();
        whoSent = temp + whoSent.Substring(1);
        s = "SELECT MessageId,Message" + whoSent + "Id,MessageTheme,MessageContent,MessageSendDate From Messages," + whoSent + "s";
        s = s + " where MessageId=" + MessageId;
        ds = ms.GetMessageData(s);
        m.CMessageId = MessageId;
        m.CMessageContent = ds.Tables[0].Rows[0]["MessageContent"].ToString();
        m.CMessageTheme = ds.Tables[0].Rows[0]["MessageTheme"].ToString();
        m.CMessageSendDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["MessageSendDate"].ToString());
        m.CMessageWhoSent = ws;
        if (ws == "user")
        {
            m.CMessageUserId = ds.Tables[0].Rows[0]["MessageUserId"].ToString();
            m.CMessageDoctorId = null;
            m.CMessageManagerId = null;
        }
        else if (ws == "doctor")
        {
            m.CMessageUserId = null;
            m.CMessageDoctorId = ds.Tables[0].Rows[0]["MessageDoctorId"].ToString();
            m.CMessageManagerId = null;
        }
        else
        {
            m.CMessageUserId = null;
            m.CMessageDoctorId = null;
            m.CMessageManagerId = ds.Tables[0].Rows[0]["MessageManagerId"].ToString();
        }
        return m;
    }
    public static void VacationsForDoctor ()
    {
        VacationService vs = new VacationService();
        DoctorService docser = new DoctorService();
        DataSet ds = docser.GetDoctors(), temp;
        DateTime start, end;
        string docId = "";
        int vacId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            docId = ds.Tables[0].Rows[i]["DoctorId"].ToString();
            if (Convert.ToBoolean(ds.Tables[0].Rows[i]["DoctorIsOnVacation"].ToString()))
            {
                temp = vs.IsDoctorOnVacation(docId);
                if (temp.Tables[0].Rows.Count != 0)
                {
                    //loop runs on all the doctors possible vacations
                    for (int j = 0; j < temp.Tables[0].Rows.Count; j++)
                    {
                        start = Convert.ToDateTime(temp.Tables[0].Rows[j]["VacationStartDate"].ToString());
                        end = Convert.ToDateTime(temp.Tables[0].Rows[j]["VacationEndDate"].ToString());
                        if (DateTime.Now > end || DateTime.Now < start)
                        {
                            //update doctor
                            docser.UpdateDoctorVacation(false, docId);
                            //delete the vacation from database 
                            if (DateTime.Now > end)
                            {
                                vacId = Convert.ToInt32(temp.Tables[0].Rows[j]["VacationId"].ToString());
                                vs.DeleteVacation(vacId);
                            }
                        }
                        else
                        {
                            docser.UpdateDoctorVacation(true, docId);
                            break;
                        }
                    }
                }
                else
                {
                    //update doctor
                    docser.UpdateDoctorVacation(false, docId);
                }
            }
            else
            {
                //if the doctors have vacations but DoctorIsOnVacation=false
                temp = vs.IsDoctorOnVacation(docId);
                if (temp.Tables[0].Rows.Count != 0)
                {
                    for (int j = 0; j < temp.Tables[0].Rows.Count; j++)
                    {
                        start = Convert.ToDateTime(temp.Tables[0].Rows[j]["VacationStartDate"].ToString());
                        end = Convert.ToDateTime(temp.Tables[0].Rows[j]["VacationEndDate"].ToString());
                        if (DateTime.Now <= end && DateTime.Now >= start)
                        {
                            //update DoctorIsOnVacation=True
                            docser.UpdateDoctorVacation(true, docId);
                        }
                        else
                        {
                            //if the doctor have future vacation
                            if (DateTime.Now > end)
                            {
                                vacId = Convert.ToInt32(temp.Tables[0].Rows[j]["VacationId"].ToString());
                                vs.DeleteVacation(vacId);
                            }
                        }
                    }
                }
            }
        }
    }
    public static void Appointment()
    {
        //look for all the appointments in database
        //check if the date of the appointment has already had, if so, delete the appointment
        //check if the doctor is not in vacation in this day(i think i already did it but check again)

        AppointmentService appser = new AppointmentService();
        VacationService vc = new VacationService();
        MessageService ms = new MessageService();
        string s = "SELECT * from Apointment", whereclout = "";
        string tabels = "Apointment";
        DataSet ds = appser.GetApointmentAndSort(s, tabels, "");
        DataSet vacationDs;
        DateTime timeOfAppointment;
        DateTime startVacDate, endVacDate;
        string doctorId, userId, content = "";
        int AppointmentId;
        Message m = new Message();
        Doctor d;
        if (ds.Tables[0].Rows.Count != 0)
        {
            //check all the Appointments
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                AppointmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["ApointmentId"].ToString());
                timeOfAppointment = Convert.ToDateTime(ds.Tables[0].Rows[i]["ApointmentDate"].ToString());
                doctorId = ds.Tables[0].Rows[i]["ApointmentDoctorId"].ToString();
                userId = ds.Tables[0].Rows[i]["ApointmentUserId"].ToString();
                //if the date has been past, then delete the appointment
                if (timeOfAppointment < DateTime.Now)
                {
                    //delete the appointment
                    appser.DeleteAppointment(AppointmentId);
                    break;
                }
                //check if the doctor is in vacation in this date
                d = GetAllDoctorDataById(doctorId);
                vacationDs = vc.IsDoctorOnVacation(doctorId);
                if (vacationDs.Tables[0].Rows.Count != 0)
                {
                    for (int j = 0; j < vacationDs.Tables[0].Rows.Count; j++)
                    {
                        startVacDate = Convert.ToDateTime(vacationDs.Tables[0].Rows[j]["VacationStartDate"].ToString());
                        endVacDate = Convert.ToDateTime(vacationDs.Tables[0].Rows[j]["VacationEndDate"].ToString());
                        if (startVacDate <= timeOfAppointment && timeOfAppointment <= endVacDate)
                        {
                            //create a message from manager to user that says the appointment is canceled
                            //because the doctor is on vacation
                            m.CMessageUserId = userId;
                            m.CMessageManagerId = "325132850";
                            m.CMessageSendDate = DateTime.Now;
                            m.CMessageTheme = "ביטול תור";
                            content = "התור שהיה אמור להתקיים בתאריך " + timeOfAppointment + " עם הרופא " + d.CDoctorName + " התבטל בעקבות זה שהרופא יצא לחופשה";
                            m.CMessageContent = content;
                            m.CMessageWhoSent = "manager";
                            //Inseart the message to the database
                            whereclout = "INSERT INTO Messages(MessageUserId,MessageManagerId,MessageTheme,MessageContent,MessageSendDate,MessageWhoSent)";
                            whereclout += " VALUES('" + m.CMessageUserId + "','" + m.CMessageManagerId + "','" + m.CMessageTheme + "','" + m.CMessageContent + "',#" + m.CMessageSendDate + "#,'" + m.CMessageWhoSent + "')";
                            ms.InseartMessageToDatabase(whereclout);
                        }
                    }
                }
            }
        }
    }
    public static List<ListItem> getListItemsForDDL (DataSet ds, string type)
    {
        //create the list of listitems for DDL
        List<ListItem> LI = new List<ListItem>();
        LI.Add(new ListItem("בחר", "0"));
        /*
         *in every DDL in this website the text value of the DDL is the TYPE NAME for example UserName
         * and the value of every ListItem is their ID for example UserId
         */
        string id = type + "Id", name = type + "Name";
        string idValue = "", nameValue = "";
        //convert the datast to ListItem variables
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            idValue = ds.Tables[0].Rows[i][id].ToString();
            nameValue = ds.Tables[0].Rows[i][name].ToString();
            LI.Add(new ListItem(nameValue, idValue));
        }
        return LI;
    }
}