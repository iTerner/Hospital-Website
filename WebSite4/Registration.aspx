<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    </head>
<body dir="rtl">
    <form id="form1" runat="server" >
        <div width="100%" hieght="90%">
        <table width="100%" hieght="100%" dir="rtl">
            <tr height="10%">
            <td width="100%" align="center" colspan="3"><asp:Label ID="TitleL" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="רישום למרפאה" Width="50%"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td width="15%"><asp:Label ID="NameL" style="float:right; margin-bottom:20px;" runat="server" Font-Bold="True" Font-Size="X-Large" Text="שם"></asp:Label></td>
                <td width="40%"><asp:TextBox ID="NameTB" style="float:right; margin-bottom:20px;" runat="server" Width="80%"></asp:TextBox></td>
                <td width="45%"><asp:Label ID="NameO" style="float:right; margin-bottom:20px;" align="right" runat="server" Width="100%" Font-Size="X-Large"></asp:Label></td>
            </tr>
            <tr>
                <td width="15%" class="auto-style1">
                    <asp:Label ID="IdL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="תעודת זהות"></asp:Label>
                </td>
                <td width="40%" class="auto-style1">
                    <asp:TextBox ID="IdTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%"></asp:TextBox>
                </td>
                <td width="45%" class="auto-style1">
                    <asp:Label ID="IdO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="GenderL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="מין"></asp:Label>
                </td>
                <td width="40%">
                    <asp:RadioButton ID="GenderMale" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="Medium" Text="זכר" />
                    <asp:RadioButton ID="GenderFemale" runat="server" style="float:right; margin-bottom:20px; margin-right:15px;" Font-Bold="True" Font-Size="Medium" Text="נקבה" />
                </td>
                <td width="45%">
                    <asp:Label ID="GenderO" runat="server" Style="margin-bottom:20px;" Width="100%" align="right" CssClass="float-right" Font-Size="X-Large" Height="34px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="DateL" style="float:right; margin-bottom:20px;" runat="server" Font-Bold="True" Font-Size="X-Large" Text="תאריך לידה"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="Calander" style="float:right; margin-bottom:20px;" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="DateO" runat="server" style="float:right; margin-bottom:20px;" Width="100%" align="right" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
                        <tr>
                <td width="15%" class="auto-style2">
                    <asp:Label ID="CityL" runat="server" Font-Bold="True" style="float:right; margin-bottom:20px;" Font-Size="X-Large" Text="עיר"></asp:Label>
                            </td>
                <td width="40%" class="auto-style2">
                    <asp:DropDownList ID="CityList" runat="server" style="float:right; margin-bottom:20px;" DataSourceID="SqlDataSourceCity" DataTextField="CityName" DataValueField="CityName">
                    </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSourceCity" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [CityName] FROM [Citys]"></asp:SqlDataSource>
                            </td>
                <td width="45%" class="auto-style2">
                    <asp:Label ID="CityO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                            </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="AdressL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="כתובת"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="AdressTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="AdressO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%" class="auto-style1">
                    <asp:Label ID="HouseNumberL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="מספר בית"></asp:Label>
                </td>
                <td width="40%" class="auto-style1">
                    <asp:TextBox ID="HouseNumberTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%"></asp:TextBox>
                </td>
                <td width="45%" class="auto-style1">
                    <asp:Label ID="HouseNumberO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="PhoneL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="מספר טלפון"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="PhoneTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="PhoneO" runat="server" style="float:right; margin-bottom:20px;" align="right" width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="EmailL" runat="server" style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="אימייל"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="EmailTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="EmailO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="PasswordL" style="float:right; margin-bottom:20px;" runat="server" Font-Bold="True" Font-Size="X-Large" Text="סיסמא"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="PasswordTB"  style="float:right; margin-bottom:20px;" runat="server" Width="80%" TextMode="Password"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="PasswordO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td width="15%">
                    <asp:Label ID="ImutPasswordL" runat="server"  style="float:right; margin-bottom:20px;" Font-Bold="True" Font-Size="X-Large" Text="אימות סיסמא"></asp:Label>
                </td>
                <td width="40%">
                    <asp:TextBox ID="ImutPasswordTB" runat="server" style="float:right; margin-bottom:20px;" Width="80%" TextMode="Password"></asp:TextBox>
                </td>
                <td width="45%">
                    <asp:Label ID="ImutPasswordO" runat="server" style="float:right; margin-bottom:20px;" align="right" Width="100%" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" width="100%" class="auto-style2" align="center">
                    <asp:Button ID="ResetButton" runat="server" Font-Bold="True" Font-Size="Large" Text="נקה" align="center" OnClick="ResetButton_Click" Class="btn alert-danger"/>
                    <asp:Button ID="SubmitButton" runat="server" Font-Bold="True" Font-Size="Large" Text="שלח" align="center" OnClick="SubmitButton_Click" class="btn btn-success"/>
                </td>
            </tr>
        </table>
</div>
    </form>
    <script>
    </script>
</body>
</html>
