<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorInfo.aspx.cs" Inherits="DoctorInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link href="css/bootstrap.css" rel="stylesheet" />
<body dir="rtl">
    <form id="form1" runat="server">
           <nav class="navbar navbar-expand-sm bg-dark navbar-dark" style="direction:rtl;">
          <!-- Brand/logo -->
          <a class="navbar-brand" href="http://localhost:49675/DoctorInfo.aspx"><img src="Picture/doctorlogo.jpg" style="width:40px; height:40px;" /><asp:Label runat="server" ID="HelloLabel" style="margin-right:5px;"></asp:Label></a>
  
          <!-- Links -->
          <ul class="nav navbar-nav" style="direction:rtl;">
            <li class="nav-item" style="float:right;" >
              <a class="nav-link" href="#"><asp:Button ID="OpenMessage" runat="server" Text="הודעות" CssClass="btn btn-dark" style="float:right;" OnClick="OpenMessage_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href="#">
                  <asp:Button ID="OpenPrescription" runat="server" Text="מרשמים" CssClass="btn btn-dark" style="float:right;" OnClick="OpenPrescription_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
                <a class="nav-link" href=""><asp:Button ID="Appointment" runat="server" Text="לוח עבודה" CssClass="btn btn-dark" style="float:right;" OnClick="Appointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Contact" runat="server" Text="צור קשר" CssClass="btn btn-dark" style="float:right;" OnClick="Contact_Click"/></a>
            </li>
            <li class="nav-item float-left">
              <a class="nav-link float-left" href="#"><asp:Button ID="DoctorLogOut" runat="server" Text="התנתקות" CssClass="btn btn-dark" OnClick="DoctorLogOut_Click"/></a>
            </li>
            </ul>
        </nav><br /><br />
        <div><center>
            <h1><asp:Label ID="Label1" runat="server" Text="פרטים אישיים" Width="100%" Font-Bold="true"></asp:Label></h1></center>
        </div><br /><br /><br />
        <div width="90%" align="right">
            <table width="70%">
                <tr>
                    <td rowspan="12" width="5%"></td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label2" runat="server" Text="תעודת זהות"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowId" runat="server" Text=""></asp:Label></td>
                    <td colspan ="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label5" runat="server" Text="שם"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowName" runat="server" Text=""></asp:Label></td>
                    <td colspan="2"><label width="100%"></label></td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label11" runat="server" Text="מין"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowGender" runat="server" Text=""></asp:Label></td>
                    <td colspan ="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="25%" class="auto-style2">
                        <asp:Label ID="Label14" runat="server" Text="תאריך לידה"></asp:Label></td>
                    <td width="25%" class="auto-style2">
                        <asp:Label ID="ShowBirthday" runat="server" Text=""></asp:Label></td>
                    <td colspan ="2" class="auto-style2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label17" runat="server" Text="עיר"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowCity" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" Width="150px" class="form-control">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="NewCityValid" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label20" runat="server" Text="התמחות"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowSpecailty" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:DropDownList ID="SpecDDL" runat="server" Width="150px" Visible="false" class="form-control"></asp:DropDownList></td>
                    <td>
                        <asp:Label ID="NewSpecValid" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label23" runat="server" Text="שנים כרופא"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowLice" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewLice" runat="server" Visible="false" class="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewLiceValid" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label3" runat="server" Text="אוניברסיטה"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowUni" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewUni" runat="server" Visible="false" class="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewUniValid" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label26" runat="server" Text="מספר טלפון"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowPhone" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewPhone" runat="server" Visible="false" class="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewPhoneValid" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label29" runat="server" Text="חופשה"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="showVacation" runat="server" Text=""></asp:Label>
                        <asp:Button ID="AskForVacation" runat="server" Text="בקשת חופשה" style="margin-right:25px;" OnClick="AskForVacation_Click" CssClass="btn btn-outline-primary btn-lg"/>


                    </td>
                    <td width="50%" colspan="2">
                        <asp:Label ID="Label7" runat="server" Text="מתאריך:" style="float:right;" Visible="false"></asp:Label>
                        <asp:TextBox ID="FromDate" runat="server" TextMode="Date" style="float:right; margin-right:25px;" Visible="false" Width="200px" class="form-control"></asp:TextBox><br /><br />
                        <asp:Label ID="Label8" runat="server" Text="לתאריך:" style="float:right;" Visible="false"></asp:Label>
                        <asp:TextBox ID="ToDate" runat="server" TextMode="Date" style="float:right; margin-right:25px;" Visible="false" Width="200px" class="form-control"></asp:TextBox><br /><br />
                        <asp:Label ID="Label9" runat="server" Text="סיבה:" style="float:right;" Visible="false"></asp:Label>
                        <asp:TextBox ID="CauseForVacation" runat="server" style="float:right; margin-right:25px;" Visible="false" Width="200px" class="form-control" TextMode="MultiLine"></asp:TextBox>
                        <asp:Button ID="SetVacation" runat="server" Text="אשר" style="float:right; margin-right:25px;" Visible="false" OnClick="SetVacation_Click" CssClass="btn btn-outline-success"/>
                    </td>
                </tr>
                <tr>
                    <td width="25%">
                        <asp:Label ID="Label33" runat="server" Text="סיסמא"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowPassword" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewPassword" runat="server" Visible="false" class="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewPasswordValid" runat="server" Text="" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="EditInfo" runat="server" Text="ערוך" style="float:left; margin-right:25px;" OnClick="EditInfo_Click" class="btn btn-outline-primary"/>
                        <asp:Button ID="SubmitEdit" runat="server" Text="שנה" Visible="false" style="float:left;" OnClick="SubmitEdit_Click" class="btn btn-outline-success"/>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table><br /><br />
        </div><br /><br />

        <br />
    </form>
</body>
</html>
