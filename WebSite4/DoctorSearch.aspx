<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorSearch.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center"><asp:Label ID="Label1" runat="server" Text="חיפוש רופאים"></asp:Label></h1>
        </div><br />
        <div>
            <center>
            <p>תוכלו לחפש רופאים לפי מלל חופשי</p><br />
            <p>או באמצעות הסננים שלנו</p>
            </center>
            <table width="50%" align="center" dir="rtl">
                <tr>
                    <td colspan="3">   
                         <asp:Label ID="Label7" runat="server" Text="חיפוש מילולי" style="float:right;" Font-Bold="true"></asp:Label><br />

                        <asp:TextBox ID="ManualSearch" runat="server" Width="60%" style="float:right;" CssClass="form-control"></asp:TextBox></td>

                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label2" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="33%">
                        <asp:DropDownList ID="DropDownListSpec" runat="server" DataSourceID="SqlDataSourceSpec" DataTextField="SpecialityName" DataValueField="SpecialityName" Width="75%" style="float:right;" CssClass="form-control"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceSpec" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [SpecialityName] FROM [Speciality]"></asp:SqlDataSource>
                    </td>
                    <td width="34%">
                        <asp:DropDownList ID="DropDownListGen" runat="server" Width="75%" style="float:right;" CssClass="form-control">
                            <asp:ListItem Value="GenderNone">בחר מין</asp:ListItem>
                            <asp:ListItem>זכר</asp:ListItem>
                            <asp:ListItem>נקבה</asp:ListItem>
                        </asp:DropDownList></td>
                    <td width="33%">
                        <asp:SqlDataSource ID="SqlDataSourceCity" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [CityName] FROM [Citys]" ></asp:SqlDataSource>
                        <asp:DropDownList ID="DropDownListCity" runat="server" style="float:right;" Width="75%" DataSourceID="SqlDataSourceCity" DataTextField="CityName" DataValueField="CityName" CssClass="form-control"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label3" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label8" runat="server" Text="" Width="100%" ></asp:Label></td>
                </tr>
               <tr>
                    <td colspan="3">
                        <asp:Label ID="Label9" runat="server" Text="" Width="100%" Visible="false"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan ="3">
                        <asp:Button ID="SortButton" runat="server" Text="חפש" OnClick="SortButton_Click" CssClass="form-control btn btn-outline-primary" Width="60px" Style="float:left; margin-left:50px;"/>
                        <asp:Button ID="ResetButton" runat="server" Text="אפס" CssClass="btn btn-outline-info form-control" Width="60px" Style="float:left; margin-left:10px;" OnClick="ResetButton_Click" />
                        <asp:Button ID="CloseButton" runat="server" Text="סגור" CssClass="btn btn-outline-danger form-control" Width="60px" Style="float:left; margin-left:10px;" Visible="false" OnClick="CloseButton_Click"/>
                    </td>
                </tr>
            </table>
            <br />
            <div align ="center" width="50%" style="overflow-x:auto; overflow-y:auto; height=200px;">
                <asp:GridView ID="SearchReasultGrid" runat="server" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="SearchReasultGrid_RowCommand" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="DoctorName" HeaderText="שם הרופא" SortExpression="DoctorName" />
                        <asp:BoundField DataField="DoctorGender" HeaderText="מין" SortExpression="DoctorGender" />
                        <asp:BoundField DataField="DoctorPhone" HeaderText="מספר טלפון" SortExpression="DoctorPhone" />
                        <asp:BoundField DataField="CityName" HeaderText="עיר מגורים" SortExpression="CityName" />
                        <asp:BoundField DataField="SpecialityName" HeaderText="תחום התמחות" SortExpression="SpecialityName" />
                        <asp:ButtonField ButtonType="Button" CommandName="Contact" Text="צור קשר" />
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
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="" Height="200px" Width="100%"></asp:Label>
        </div>
    </form>
</body>
</html>
