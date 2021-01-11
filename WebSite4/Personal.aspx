<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Personal.aspx.cs" Inherits="Personal" %>

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
          <a class="navbar-brand" href="http://localhost:49675/Personal.aspx"><img src="Picture/userlogo.png" style="width:20px; height:20px;" /><asp:Label runat="server" ID="HelloLabel" style="margin-right:5px;"></asp:Label></a>
  
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
                <a class="nav-link" href=""><asp:Button ID="OpenSetAppointment" runat="server" Text="קביעת תורים" CssClass="btn btn-dark" style="float:right;" OnClick="OpenSetAppointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="OpenUserAppointment" runat="server" Text="התורים שלי" CssClass="btn btn-dark" style="float:right;" OnClick="OpenUserAppointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href="#">
                  <asp:Button ID="OpenContact" runat="server" Text="צור קשר" CssClass="btn btn-dark" style="float:right;" OnClick="OpenContact_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
                <a class="nav-link" href=""><asp:Button ID="OpenSearchDoctor" runat="server" Text="חיפוש רופאים" CssClass="btn btn-dark" style="float:right;" OnClick="OpenSearchDoctor_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="OpenPharmacy" runat="server" Text="בית מרקחת" CssClass="btn btn-dark" style="float:right;" OnClick="OpenPharmacy_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href="#">
                  <asp:Button ID="OpenUserOrders" runat="server" Text="ההזמנות שלי" CssClass="btn btn-dark" style="float:right;" OnClick="OpenUserOrders_Click"/></a>
            </li>
            <li class="nav-item float-left">
              <a class="nav-link float-left" href="#"><asp:Button ID="UserLogOut" runat="server" Text="התנתקות" CssClass="btn btn-dark" OnClick="UserLogOut_Click"/></a>
            </li>
            </ul>
        </nav><br /><br />


        <div>
            <center><h1><asp:Label ID="Label1" runat="server" Text="פרטים אישיים" Width="100%" style="direction:rtl;"></asp:Label></h1></center>
        </div><br /><br /><br />
        <div width="75%" align="right">
            <table width="70%">
                <tr>
                    <td rowspan="12" width="5%"></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label2" runat="server" Text="תעודת זהות"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowId" runat="server" Text=""></asp:Label></td>
                    <td colspan ="2">
                        <asp:Label ID="Label4" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label5" runat="server" Text="שם"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowName" runat="server" Text=""></asp:Label></td>
                    <td colspan="2"><label width="100%"></label></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label11" runat="server" Text="מין"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowGender" runat="server" Text=""></asp:Label></td>
                    <td colspan ="2">
                        <asp:Label ID="Label13" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="15%" class="auto-style2">
                        <asp:Label ID="Label14" runat="server" Text="תאריך לידה"></asp:Label></td>
                    <td width="25%" class="auto-style2">
                        <asp:Label ID="ShowBirthday" runat="server" Text="" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"></asp:Label></td>
                    <td colspan ="2" class="auto-style2">
                        <asp:Label ID="Label16" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label17" runat="server" Text="עיר"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowCity" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" CssClass="form-control" Width="150px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="NewCityValid" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label20" runat="server" Text="כתובת"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowAdress" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewAdress" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewAdressValid" runat="server" Text="" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label23" runat="server" Text="מספר בית"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowHouseNumber" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewHouseNumber" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewHouseNumberValid" runat="server" Text="" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label26" runat="server" Text="מספר טלפון"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowPhone" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewPhone" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewPhoneValid" runat="server" Text="" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label29" runat="server" Text="אימייל"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowEmail" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewEmail" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewEmailValid" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label33" runat="server" Text="סיסמא"></asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="ShowPassword" runat="server" Text=""></asp:Label></td>
                    <td width="25%">
                        <asp:TextBox ID="NewPassword" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewPasswordValid" runat="server" Text="" Width="100%"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="15%">
                        <asp:Label ID="Label3" runat="server" Text="תאריך התחברות אחרון"></asp:Label></td>
                    <td width="15%">
                        <asp:Label ID="ShowLastLoginDate" runat="server" Text=""></asp:Label></td>
                    <td colspan="2"><label Width="100%"></label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="EditInfo" runat="server" Text="ערוך" style="float:left; margin-right:25px;" OnClick="EditInfo_Click" class="btn btn-outline-info form-control" Width="70px"/>
                        <asp:Button ID="SubmitEdit" runat="server" Text="שנה" Visible="false" style="float:left;" OnClick="SubmitEdit_Click" class="btn btn-outline-success form-control" Width="70px"/>
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
