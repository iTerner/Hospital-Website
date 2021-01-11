<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorWriteMessage.aspx.cs" Inherits="DoctorWriteMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
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
        <div>
            <center>
            <h1><asp:Label ID="label1" runat="server" Width="100%" Text="צור קשר" Font-Bold="true"></asp:Label></h1>
            </center>
            <br />
            <table width="50%" dir="rtl" style="margin-right:30px;">
                <tr style="margin-bottom:30px;">
                    <td width="15%">
                        <label width="100%"></label></td>
                    <td>
                        <asp:DropDownList ID="DesrDropDownList" runat="server" style="float:right;" Width="150px" OnSelectedIndexChanged="DesrDropDownList_SelectedIndexChanged" AutoPostBack="true" class="form-control">
                            <asp:ListItem Value="0">בחר</asp:ListItem>
                            <asp:ListItem Value="1">לקוח</asp:ListItem>
                            <asp:ListItem Value="2">מנהל</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        <asp:Label ID="DestO" runat="server" Text="" style="float:right;"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"><label Width="100%"></label></td>
                </tr>
                <tr style="margin-bottom:30px;">
                    <td width="15%">
                        <asp:Label ID="Label3" runat="server" Text="בחר" style="float:right;" Visible="false"></asp:Label></td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="IdDropDownList" runat="server" style="float:right;" Width="150px" OnSelectedIndexChanged="IdDropDownList_SelectedIndexChanged" Visible="false" AutoPostBack="true" class="form-control"></asp:DropDownList></td>
                    <td class="auto-style1">
                        <asp:Label ID="IdO" runat="server" Text="" style="float:right;"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"><label Width="100%"></label></td>
                </tr>
                <tr style="margin-bottom:30px;">
                    <td width="15%">
                        <asp:Label ID="Label4" runat="server" Text="נושא ההודעה" style="float:right;" Visible="false"></asp:Label></td>
                    <td class="auto-style2">
                        <asp:TextBox ID="MessageThemeTB" runat="server" style="float:right;" Width="200px" Visible="false" class="form-control"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <asp:Label ID="MessageThemeO" runat="server" Text="" style="float:right;"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"><label Width="100%"></label></td>
                </tr>
                <tr style="margin-bottom:30px;">
                    <td width="15%">
                        <asp:Label ID="Label5" runat="server" Text="תוכן ההודעה" style="float:right;" Visible="false"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="MessageContentTB" runat="server" style="float:right;" TextMode="MultiLine" Width="200px" Visible="false" class="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="MessageContentO" runat="server" Text="" style="float:right;"></asp:Label></td>
                </tr>
                <tr style="margin-bottom:30px;">
                    <td colspan="3"><label width="100%"></label></td>
                </tr>
                <tr style="margin-bottom:30px;">
                    <td colspan="3"><center>
                        <asp:Button ID="Submit" runat="server" Text="שלח" OnClick="Submit_Click" Visible="false" CssClass="btn btn-outline-success"/>
                        <asp:Button ID="Reset" runat="server" Text="נקה" OnClick="Reset_Click" Visible="false" CssClass="btn btn-outline-danger"/></center>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
