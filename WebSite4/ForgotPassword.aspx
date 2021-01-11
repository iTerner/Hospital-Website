<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 15%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="direction:rtl;">
            <center><h2><label>שחכתי סיסמא</label></h2></center><br />
            <center><h4><label>מלא את הפרטים הבאים</label></h4></center>
            <center>
                <label>הסיסמא חייבת להכיל להיות לפחות 8 תווים ובעלת אות גדולה, קטנה ומספר</label><br /><br />
            <table style="width:50%">
                <tr>
                    <td style="width:15%">
                        <asp:Label ID="Label1" runat="server" Text="תעודת זהות" Style="float:right; direction:rtl;"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="IdTB" runat="server" CssClass="form-control" Width="200px" Style="float:right; direction:rtl;"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="IdO" runat="server" Text="" Style="float:right; direction:rtl;"></asp:Label></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="סיסמא חדשה" Style="float:right; direction:rtl;"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="NewPasswordTB" runat="server" CssClass="form-control" Width="200px" Style="float:right; direction:rtl;"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="NewPasswordO" runat="server" Text="" Style="float:right; direction:rtl;"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width:15%">
                        <asp:Label ID="Label5" runat="server" Text="אימות סיסמא" Style="float:right; direction:rtl;"></asp:Label></td>
                    <td>
                        <asp:TextBox ID="ConfirmPasswordTB" runat="server" CssClass="form-control" Width="200px" Style="float:right; direction:rtl;"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="ConfirmPasswordO" runat="server" Text="" Style="float:right; direction:rtl;"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3"><center>
                        <asp:Button ID="ChangePassword" runat="server" Text="שנה" CssClass="form-control btn btn-outline-success" Width="60px" style="margin-right:10px;" OnClick="ChangePassword_Click" />
                        <asp:Button ID="ResetButton" runat="server" Text="אפס" CssClass="form-control btn btn-outline-primary" Width="60px" OnClick="ResetButton_Click"/></center></td>
                </tr>
            </table>
                </center>
        </div>
    </form>
</body>
</html>
