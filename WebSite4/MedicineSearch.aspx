<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MedicineSearch.aspx.cs" Inherits="MedicineSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link href="css/bootstrap.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center"><asp:Label ID="Label1" runat="server" Text="חיפוש תרופות"></asp:Label></h1></div><br />
                <div>
            <center>
            <p>תוכלו לחפש תרופות לפי מלל חופשי</p><br />
            <p>או באמצעות הסננים שלנו</p>
            </center>
            <table width="50%" align="center" dir="rtl">
                <tr>
                    <td colspan="3">   
                         <asp:Label ID="Label7" runat="server" Text="חיפוש מילולי" style="float:right;" Font-Bold="true"></asp:Label><br />

                        <asp:TextBox ID="ManualSearch" runat="server" Width="65%" style="float:right;" CssClass="form-control"></asp:TextBox></td>

                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label2" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:Label ID="Label8" runat="server" Text="ממחיר" style="float:right;" Font-Bold="true"></asp:Label>

                    </td>
                    <td width="34%">
                        <asp:Label ID="Label9" runat="server" Text="עד מחיר" style="float:right;" Font-Bold="true"></asp:Label>
                    </td>
                    <td width="33%">
                        <asp:Label ID="Label3" runat="server" Text="יצרן" style="float:right;" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="33%"><asp:TextBox ID="MoneyFrom" runat="server" style="float:right;" CssClass="form-control" Width="95%"></asp:TextBox></td>
                    <td width="34%"><asp:TextBox ID="MoneyTo" runat="server" style="float:right;" CssClass="form-control" Width="95%"></asp:TextBox></td>
                    <td width="33%">
                        <asp:DropDownList ID="ProducerDDL" runat="server" style="float:right;" Width="75%" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="33%">
                        &nbsp;</td>
                    <td width="34%">
                        &nbsp;</td>
                    <td width="33%">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="100%" colspan="3">
                        <asp:Label ID="Label10" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:Label ID="Label4" runat="server" Text="קטגוריה" style="float:right;" Font-Bold="true"></asp:Label></td>
                    <td width="34%"><asp:Label ID="Label6" runat="server" Text="מרשמים" style="float:right;" Font-Bold="true"></asp:Label></td>
                    <td width="33%"><label></label></td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:DropDownList ID="DropDownListMedicineCatagory" runat="server" style="float:right;" Width="75%" CssClass="form-control"></asp:DropDownList>
                    <td width="33%" dir="rtl">
                        <asp:RadioButton ID="WithoutPresRB" runat="server" Style="float:right; margin-left:10px;" OnCheckedChanged="WithoutPresRB_CheckedChanged" AutoPostBack="true" class="checkbox-inline"/><asp:Label ID="Label11" runat="server" Text="ללא מרשם" Style="float:right;"></asp:Label><br />
                        <asp:RadioButton ID="WithPresRB" runat="server" Style="float:right; margin-left:10px;" OnCheckedChanged="WithPresRB_CheckedChanged" AutoPostBack="true" class="checkbox-inline"/><asp:Label ID="Label12" runat="server" Text="עם מרשם" Style="float:right;"></asp:Label>
                    </td>
                    <td width="33%"></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label5" runat="server" Text="lkjhgfds" Width="100%" Visible="false"></asp:Label></td>
               </tr>
                <tr>
                    <td colspan ="3">
                        <asp:Button ID="ResetButton" runat="server" Text="אפס" CssClass="btn btn-outline-info form-control" width="60px" OnClick="ResetButton_Click"/>
                        <asp:Button ID="CloseMedicineGrid" runat="server" Text="סגור" Visible="false" CssClass="btn btn-outline-danger form-control" width="60px" OnClick="CloseMedicineGrid_Click" />
                        <asp:Button ID="SortButton" runat="server" Text="חפש" class="btn btn-outline-primary form-control" width="60px" OnClick="SortButton_Click"/>
                    </td>
                </tr>
            </table>
            <br />
            <asp:table runat="server" Width="100%" Visible="false" ID="table1">
                <asp:TableRow>
                    <asp:TableCell ID="GridCell" Width="50%">
                       <center>
                        <div style="width: 60%; height: 400px; overflow-x:auto; overflow-y:auto;">
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
                            <asp:GridView ID="SearchReasultGrid" runat="server" AutoGenerateColumns="False" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="SearchReasultGrid_PageIndexChanging" OnRowCommand="SearchReasultGrid_RowCommand" OnRowDataBound="SearchReasultGrid_RowDataBound" PageSize="5" ShowFooter="True" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="MedicineId" HeaderText="מספר תרופה" SortExpression="MedicineId" />
                                    <asp:BoundField DataField="MedicineName" HeaderText="שם התרופה" SortExpression="MedicineName" />
                                    <asp:BoundField DataField="MedicinePrice" HeaderText="מחיר" SortExpression="MedicinePrice" />
                                    <asp:BoundField DataField="MedicineStock" HeaderText="כמות במלאי" SortExpression="MedicineStock" />
                                    <asp:BoundField DataField="MedicineProducerName" HeaderText="יצרן" SortExpression="MedicineProducerName" />
                                    <asp:BoundField DataField="MedicineCatagoryName" HeaderText="קטגוריה" SortExpression="MedicineCatagoryName" />
                                    <asp:BoundField DataField="MedicineNeedPrescription" HeaderText="צורך במרשם" SortExpression="MedicineNeedPrescription" />
                                    <asp:ImageField DataImageUrlField="MedicinePictureUrl" HeaderText="תמונה" SortExpression="MedicinePictureUrl">
                                        <ControlStyle Height="100px" Width="100px" />
                                        <ItemStyle Height="50px" Width="50px" />
                                    </asp:ImageField>
                                    <asp:ButtonField Text="הוסף לסל" ButtonType="Button" CommandName="AddMedicine" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="Numeric" PageButtonCount="20" />
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
                    </asp:TableCell>
                </asp:TableRow>
            </asp:table><br /><br />
        <center>
            <asp:Button ID="CheckoutButton" runat="server" Text="בצע קנייה" Width="150px" Font-Bold="True" Font-Size="Large" OnClick="CheckoutButton_Click" class="btn btn-secondary form-control"></asp:Button>
            <asp:Button ID="SeeShoppingBag" runat="server" Text="צפה בסל" Width="150px" Font-Bold="true" Font-Size="Large" OnClick="SeeShoppingBag_Click" class="btn btn-secondary form-control"></asp:Button>
        </center>
    </form>
</body>
</html>
