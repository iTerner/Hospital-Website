<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserAppointment.aspx.cs" Inherits="UserAppointment" %>

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
            <h1><center><asp:Label runat="server" Text="תורים"></asp:Label></center></h1><br />
            <asp:DropDownList ID="SortDDL" runat="server" style="float:right; margin-right:30px" Visible="false" AutoPostBack="true" Width="150px" OnSelectedIndexChanged="SortDDL_SelectedIndexChanged" CssClass="form-control">
                <asp:ListItem Value="0">מיין לפי</asp:ListItem>
                <asp:ListItem Value="1">רופא</asp:ListItem>
                <asp:ListItem Value="2">סוג התור</asp:ListItem>
                <asp:ListItem Value="3">תאריך</asp:ListItem>
                <asp:ListItem>שעה</asp:ListItem>
            </asp:DropDownList><asp:Button ID="CloseApointment" runat="server" Text="סגור" style="float:right; margin-right:20px;" Visible="false" OnClick="CloseApointment_Click" CssClass="form-control btn-outline-danger" Width="60px"/><br /><br /><br />
            <center>
                <asp:GridView ID="ApointmentGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="ApointmentGrid_RowCommand" OnRowDataBound="ApointmentGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ApointmentId" HeaderText="מספר תור" SortExpression="ApointmentId" />
                        <asp:BoundField DataField="DoctorName" HeaderText="שם הרופא" SortExpression="DoctorName" />
                        <asp:BoundField DataField="SpecialityName" HeaderText="סוג התור" SortExpression="SpecialityName" />
                        <asp:BoundField DataField="ApointmentDate" HeaderText="תאריך" SortExpression="ApointmentDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                        <asp:BoundField DataField="ApointmentHour" SortExpression="ApointmentHour" />
                        <asp:BoundField DataField="DayName" HeaderText="יום" SortExpression="DayName" />
                        <asp:BoundField DataField="HourStartTime" HeaderText="שעת התחלה" SortExpression="HourStartTime" />
                        <asp:BoundField DataField="HourEndTime" HeaderText="שעת סיום" SortExpression="HourEndTime" />
                        <asp:ButtonField ButtonType="Button" CommandName="DeleteAppointment" Text="ביטול" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </center>
       </div>
    </form>
</body>
</html>
