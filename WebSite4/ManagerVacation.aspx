<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerVacation.aspx.cs" Inherits="ManagerVacation" %>

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
                <h1><center><asp:Label ID="Label1" runat="server" Text="חופשות"></asp:Label></center></h1><br />
        <div align="center">
            <table width="100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="SortDDL" runat="server" style="float:right; margin-right:50px; direction:rtl;" Width="150px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="SortDDL_SelectedIndexChanged">
                            <asp:ListItem>מיין</asp:ListItem>
                            <asp:ListItem>רופא</asp:ListItem>
                            <asp:ListItem>מנהל</asp:ListItem>
                            <asp:ListItem>תאריך</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseVac" runat="server" Text="סגור" style="float:right; margin-right:30px; direction:rtl;" Width="60px" Visible="false" CssClass="btn btn-outline-danger form-control" OnClick="CloseVac_Click"/></td>
                </tr>
                <tr>
                    <td><label width="100%"></label></td>
                </tr>
                <tr>
                    <td>
                        <center>
                            <div style="overflow-x:auto; overflow-y:auto; height:300px; width:70%;">
                        <asp:GridView ID="ShowVac" runat="server" style="direction:rtl;" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="ShowVac_RowCommand" OnRowDataBound="ShowVac_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="VacationId" HeaderText="מספר חופשה" SortExpression="VacationId" />
                                <asp:BoundField DataField="VacationDoctorId" HeaderText="רופא" SortExpression="VacationDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם הרופא" SortExpression="DoctorName" />
                                <asp:BoundField DataField="VacationManagerId" HeaderText="מנהל" SortExpression="VacationManagerId" />
                                <asp:BoundField DataField="ManagerName" HeaderText="שם מנהל" SortExpression="ManagerName" />
                                <asp:BoundField DataField="VacationStartDate" HeaderText="תאריך תחילת חופשה" SortExpression="VacationStartDate"/>
                                <asp:BoundField DataField="VacationEndDate" HeaderText="תאריך סיום חופשה" SortExpression="VacationEndDate"/>
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteVac" Text="מחק" />
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
                                </div>
                        </center>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
