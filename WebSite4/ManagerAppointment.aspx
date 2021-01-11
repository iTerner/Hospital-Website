<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerAppointment.aspx.cs" Inherits="ManagerAppointment" %>

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
          <a class="navbar-brand" href="http://localhost:49675/ManagerHome.aspx"><img src="Picture/managerlogo.png" style="width:40px; height:40px;" /><asp:Label runat="server" ID="HelloLabel" style="margin-right:5px;"></asp:Label></a>
  
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
                <a class="nav-link" href=""><asp:Button ID="Appointment" runat="server" Text="תורים" CssClass="btn btn-dark" style="float:right;" OnClick="Appointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Orders" runat="server" Text="הזמנות" CssClass="btn btn-dark" style="float:right;" OnClick="Orders_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Vacation" runat="server" Text="חופשות" CssClass="btn btn-dark" style="float:right;" OnClick="Vacation_Click"/></a>
            </li>
            <li class="nav-item float-left">
              <a class="nav-link float-left" href="#"><asp:Button ID="ManagerLogOut" runat="server" Text="התנתקות" CssClass="btn btn-dark" OnClick="ManagerLogOut_Click"/></a>
            </li>
            </ul>
        </nav><br /><br />
        <h1><center><asp:Label ID="Label1" runat="server" Text="תורים"></asp:Label></center></h1><br />
        <div align="center">
            <table width="100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="SortDDL" runat="server" style="float:right; direction:rtl; margin-right:50px" Width="150px" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="SortDDL_SelectedIndexChanged">
                            <asp:ListItem>מיין</asp:ListItem>
                            <asp:ListItem Value="1">רופא</asp:ListItem>
                            <asp:ListItem Value="2">לקוח</asp:ListItem>
                            <asp:ListItem Value="3">תאריך</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseAppointment" runat="server" Text="סגור" Style="float:right; direction:rtl; margin-right:30px" Visible="false" Width="60px" CssClass="btn btn-outline-danger form-control" OnClick="CloseAppointment_Click" /></td>
                </tr>
                <tr>
                    <td><label width="100%"></label></td>
                </tr>
                <tr>
                    <td><center>
                        <asp:GridView ID="ShowAppointment" runat="server" style="direction:rtl;" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="ShowAppointment_RowCommand" OnRowDataBound="ShowAppointment_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="ApointmentId" HeaderText="מספר תור" SortExpression="ApointmentId" />
                                <asp:BoundField DataField="ApointmentUserId" HeaderText="לקוח" SortExpression="ApointmentUserId" />
                                <asp:BoundField DataField="UserName" HeaderText="שם הלקוח" SortExpression="UserName" />
                                <asp:BoundField DataField="ApointmentDoctorId" HeaderText="רופא" SortExpression="ApointmentDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם הרופא" SortExpression="DoctorName" />
                                <asp:BoundField DataField="ApointmentDate" HeaderText="תאריך" SortExpression="ApointmentDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}"/>
                                <asp:BoundField DataField="DayName" HeaderText="יום" SortExpression="DayName" />
                                <asp:BoundField DataField="ApointmentHour" HeaderText="מספר שעה" SortExpression="ApointmentHour" />
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
                        </center></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
