<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserOrders.aspx.cs" Inherits="UserOrders" %>

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
            <center><h1><asp:Label ID="Label1" runat="server" Text="ההזמנות שלי" Style="direction:rtl;"></asp:Label></h1></center><br />
            <table width="100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="SortDDL" runat="server" Width="150px" AutoPostBack="true" style="margin-right:50px; float:right; direction:rtl;" CssClass="form-control" OnSelectedIndexChanged="SortDDL_SelectedIndexChanged">
                            <asp:ListItem>מיין</asp:ListItem>
                            <asp:ListItem>סכום</asp:ListItem>
                            <asp:ListItem>תאריך</asp:ListItem>
                            <asp:ListItem>האם סופק</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseOrders" runat="server" Text="סגור" Visible="false" Width="60px" Style="float:right; margin-right:30px; direction:rtl;" CssClass="btn btn-outline-danger form-control" OnClick="CloseOrders_Click"/></td>
                </tr>
                <tr>
                    <td><label width="100%"></label></td>
                </tr>
                <tr>
                    <td>
                        <div style="width: 40%; height: 400px; overflow-x:auto; overflow-y:auto; float:right; margin-right:50px;">
                            <asp:GridView ID="ShowOrder" runat="server" style="direction:rtl; float:right; margin-right:50px;" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Visible="False" OnRowCommand="ShowOrder_RowCommand" OnRowDataBound="ShowOrder_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="OrderId" HeaderText="מספר הזמנה" SortExpression="OrderId" />
                                <asp:BoundField DataField="OrderUserId" HeaderText="לקוח" SortExpression="OrderUserId" />
                                <asp:BoundField DataField="OrderDate" HeaderText="תאריך" SortExpression="OrderDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="OrderTotalMoney" HeaderText="סכום ההזמנה" SortExpression="OrderTotalMoney" />
                                <asp:BoundField DataField="OrderIsSupplied" HeaderText="האם סופק" SortExpression="OrderIsSupplied" />
                                <asp:ButtonField ButtonType="Button" CommandName="SeeDetails" Text="פרטים" />
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
                        <div style="width: 30%; height: 400px; overflow-x:auto; overflow-y:auto; float:right; margin-right:50px;">
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
                            </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
