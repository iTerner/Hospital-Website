<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserWriteMessage.aspx.cs" Inherits="UserWriteMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
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
            <h1><asp:Label ID="Label1" runat="server" Text="צור קשר" align="center" Width="100%"></asp:Label></h1>
        </div><br />
        <div align="right" width="60%" height="60%">
            <label width="5%" align="rignt"></label>
            <h3><asp:Label ID="Label2" runat="server" Text="פרטי הודעה" align="right" Width="95%"></asp:Label></h3><br />
            <table width="60%" dir="rtl" align="right" height="45%">
                <tr>
                    <td width="30%">
                        <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                    <td width="20%">
                        <asp:DropDownList ID="WhoDDL" runat="server" Width="200px" style="margin-left:30px;" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="WhoDDL_SelectedIndexChanged">
                            <asp:ListItem Value="0">בחר</asp:ListItem>
                            <asp:ListItem Value="1">רופא</asp:ListItem>
                            <asp:ListItem Value="2">מנהל</asp:ListItem>
                        </asp:DropDownList></td>
                    <td width="20%"></td>
                    <td width="30%">
                        <asp:Label ID="WhoValid" runat="server" Text="" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4"><label width="100%"></label></td>
                </tr>
                <tr>
                    <td width="30%>
                        <asp:Label ID="DoctorIdL" Width="100%" runat="server" Text="תעודת זהות רופא" style="margin-right:30px; margin-top:5px; margin-bottom:5px;" Font-Bold="true" Visible="false"></asp:Label></td>
                    <td width="20%">
                        <asp:DropDownList ID="DoctorNameDropDownList" runat="server" Width="200px" style="margin-left:30px;" CssClass="form-control" Visible="false"></asp:DropDownList>
                          
                    </td>
                    <td width="20%"></td>
                    <td width="30%">
                        <asp:Label ID="DoctorIdO" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="MessageThemeL" runat="server" Text="נושא ההודעה" style="margin-right:30px; margin-top:5px; margin-bottom:5px;" Font-Bold="true"></asp:Label></td>
                    <td colspan="2">
                        <asp:TextBox ID="MessageThemeTB" runat="server" Width="300px" style="margin-top:5px; margin-bottom:5px;" Height="30px" CssClass="form-control"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="MessageThemeO" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td width="30%">
                        <asp:Label ID="MessageContentL" runat="server" Text="תוכן הודעה" style="margin-right:30px; margin-top:5px; margin-bottom:5px;" Font-Bold="true"></asp:Label></td>
                    <td width="40%" colspan="2">
                        <asp:TextBox ID="MessageContentTB" runat="server" Width="300px" Height="60px" TextMode="MultiLine" style="margin-top:5px; margin-bottom:5px;" CssClass="form-control"></asp:TextBox></td>
                    <td width="30%">
                        <asp:Label ID="MessageContentO" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label3" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="SendMessage" runat="server" Text="שלח" style="margin-right:25px;" align="center" CssClass="btn btn-outline-success form-control" OnClick="SendMessage_Click" Width="100px"/>
                        <asp:Button ID="ResstButton" runat="server" Text="נקה" align="center" CssClass="btn btn-outline-danger form-control" style="margin-right:20px;" OnClick="ResstButton_Click" Width="100px"/>
                    </td>
                </tr>
            </table>
            </div>

    </form>
</body>
</html>
