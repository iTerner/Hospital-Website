<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerOrders.aspx.cs" Inherits="ManagerOrders" %>

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
                <h1><center><asp:Label ID="Label1" runat="server" Text="הזמנות"></asp:Label></center></h1><br />
        <div align="center">
            <table width="100%">
                <tr>
                    <td>
                        <asp:CheckBox ID="HighToLow" runat="server" style="float:right; margin-right:30px; direction:rtl;" AutoPostBack="true" OnCheckedChanged="HighToLow_CheckedChanged"/>
                        <asp:Label ID="Label2" runat="server" Text="מהגבוה לנמוך" Style="float:right; direction:rtl; margin-right:5px;"></asp:Label><br />
                        <asp:CheckBox ID="LowToHigh" runat="server" style="float:right; margin-right:30px; direction:rtl;" AutoPostBack="true" OnCheckedChanged="LowToHigh_CheckedChanged"/>
                        <asp:Label ID="Label5" runat="server" Text="מהנמוך לגבוה" Style="float:right; direction:rtl; margin-right:5px;"></asp:Label><br />
                        <asp:CheckBox ID="SortUser" runat="server" style="margin-right:30px; direction:rtl; float:right;" />
                        <asp:Label ID="Label4" runat="server" Text="לקוח" Style="float:right; direction:rtl; margin-right:5px;"></asp:Label><br />
                        <asp:CheckBox ID="SortDate" runat="server" style="float:right; margin-right:30px; direction:rtl;"/>
                        <asp:Label ID="Label3" runat="server" Text="תאריך" Style="float:right; direction:rtl; margin-right:5px;"></asp:Label><br />
                        <asp:CheckBox ID="IsSupplied" runat="server" style="float:right; margin-right:30px; direction:rtl;"/>
                        <asp:Label ID="Label6" runat="server" Text="האם סופק" Style="float:right; direction:rtl; margin-right:5px;"></asp:Label>
                        <asp:Button ID="SortButton" runat="server" Text="מיין" style="float:right; margin-right:50px; direction:rtl;" Width="60px" CssClass="btn btn-outline-primary form-control" OnClick="SortButton_Click"/>
                        <asp:Button ID="CloseOrders" runat="server" Text="סגור" style="float:right; margin-right:10px; direction:rtl;" Width="60px" Visible="false" CssClass="btn btn-outline-danger form-control" OnClick="CloseOrders_Click"/>
                        <asp:Button ID="ResetButton" runat="server" Text="אפס" style="float:right; margin-right:10px; direction:rtl;" Width="60px" CssClass="btn btn-outline-info form-control" OnClick="ResetButton_Click"/>
                    </td>
                </tr>
                <tr>
                    <td><label width="100%"></label><br /><br /></td>
                </tr>
                <tr>
                    <td>
                        <div style="overflow-x:auto; overflow-y:auto; float:right; margin-right:100px;">
                        <asp:GridView ID="ShowOrder" runat="server" style="direction:rtl; float:right; margin-right:50px;" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="ShowOrder_RowCommand" OnRowDataBound="ShowOrder_RowDataBound" Visible="False">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="OrderId" HeaderText="מספר הזמנה" SortExpression="OrderId" />
                                <asp:BoundField DataField="OrderUserId" HeaderText="לקוח" SortExpression="OrderUserId" />
                                <asp:BoundField DataField="OrderDate" HeaderText="תאריך" SortExpression="OrderDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="OrderTotalMoney" HeaderText="סכום ההזמנה" SortExpression="OrderTotalMoney" />
                                <asp:BoundField DataField="OrderIsSupplied" HeaderText="האם סופק" SortExpression="OrderIsSupplied" />
                                <asp:ButtonField ButtonType="Button" CommandName="SeeDetails" Text="פרטים" />
                                <asp:ButtonField ButtonType="Button" CommandName="SendOrder" Text="שלח הזמנה" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteOrder" Text="מחק" />
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
                            <div style="overflow-x:auto; overflow-y:auto; float:right; margin-right:50px;">
                            <asp:GridView ID="ShowDetails" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="direction:rtl; float:right; margin-right:50px;" AutoGenerateColumns="False" Visible="False" OnRowCommand="ShowDetails_RowCommand">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="MedicineName" HeaderText="שם התרופה" SortExpression="MedicineName" />
                                    <asp:BoundField DataField="OrderDetailsMedicinePrice" HeaderText="כמות" SortExpression="OrderDetailsMedicinePrice" />
                                    <asp:BoundField DataField="OrderDetailsMedicineCount" HeaderText="מחיר" SortExpression="OrderDetailsMedicineCount" />
                                    <asp:ButtonField ButtonType="Button" CommandName="Close" Text="סגור" />
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
                                </div></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
