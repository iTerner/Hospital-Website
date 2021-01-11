<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorAppointment.aspx.cs" Inherits="DoctorAppointment" %>

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
        <div><center><h1>
            <asp:Label ID="Label1" runat="server" Text="לוח עבודה" Font-Bold="true"></asp:Label></h1></center>
        </div><br />
        <div>
            <asp:DropDownList ID="SortAppointmentDDL" runat="server" style="float:right; margin-right:30px;" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="SortAppointmentDDL_SelectedIndexChanged" class="form-control">
                <asp:ListItem>בחר</asp:ListItem>
                <asp:ListItem Value="0">יומי</asp:ListItem>
                <asp:ListItem Value="1">שבועי</asp:ListItem>
                <asp:ListItem Value="2">חודשי</asp:ListItem>
                <asp:ListItem Value="3">שנתי</asp:ListItem>
            </asp:DropDownList><br /><br /><br />
            <center>
                <asp:GridView ID="ShowAppointment" runat="server" AutoGenerateColumns="False" OnRowDataBound="ShowAppointment_RowDataBound" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="ShowAppointment_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="ApointmentId" HeaderText="מספר תור" SortExpression="ApointmentId" />
                        <asp:BoundField DataField="ApointmentUserId" HeaderText="תעודת זהות" SortExpression="ApointmentUserId" />
                        <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                        <asp:BoundField DataField="ApointmentDate" HeaderText="תאריך" SortExpression="ApointmentDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                        <asp:BoundField DataField="ApointmentHour" SortExpression="ApointmentHour" />
                        <asp:BoundField DataField="DayName" HeaderText="יום" SortExpression="DayName" />
                        <asp:BoundField DataField="HourStartTime" HeaderText="שעת התחלה" SortExpression="HourStartTime" />
                        <asp:BoundField DataField="HourEndTime" HeaderText="שעת סיום" SortExpression="HourEndTime" />
                        <asp:ButtonField ButtonType="Button" CommandName="DeleteAppointment" Text="מחק" />
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
