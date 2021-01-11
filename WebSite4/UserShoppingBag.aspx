<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserShoppingBag.aspx.cs" Inherits="UserShoppingBag" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body dir="rtl">
    <form id="form1" runat="server">
        <table width="100%">
            <tr>
                <td colspan="3">
                    <center><h1><asp:Label ID="Label1" runat="server" Text="סל קניות" Font-Bold="true"></asp:Label></h1></center>
                </td>
            </tr>
            <tr>
                <td colspan="3"><asp:Label runat="server" Width="100%" Height="10%"></asp:Label></td>
            </tr>
            <tr>
                <td width="20%">
                    <label></label>
                </td>
                <td>
                    <center>
                        <div style="overflow-x:auto; overflow-y:auto; width:100%; height: 250px;" align="center">
                    <asp:GridView ID="ShowShoppingbag" runat="server" AutoGenerateColumns="False" style="direction:rtl;" OnRowCommand="ShowShoppingbag_RowCommand" OnRowDataBound="ShowShoppingbag_RowDataBound" Width="669px" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="CMedicineId" HeaderText="מספר תרופה" />
                            <asp:BoundField DataField="CMedicineName" HeaderText="שם תרופה" />
                            <asp:BoundField DataField="CMedicineInBagMedicineCount" HeaderText="כמות" />
                            <asp:BoundField DataField="CMedicineInBagMedicinePrice" HeaderText="מחיר ליחידה" />
                            <asp:BoundField DataField="CMedicineInBagProducerName" HeaderText="חברה" />
                            <asp:BoundField DataField="CMedicineInBagCatagoryName" HeaderText="קטגוריה" />
                            <asp:ButtonField ButtonType="Button" CommandName="DeleteMedicineFromShoppingBag" Text="מחק" />
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
                <td width="33%">

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
