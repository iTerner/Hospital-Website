<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuestHome.aspx.cs" Inherits="GuestHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: white;
}

li {
  float: left;
  border-right:1px solid #bbb;
}

li:last-child {
  border-right: none;
}

li a {
  display: block;
  color: black;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

li a:hover:not(.active) {
  background-color: #28ADC1;
}

}
        
    </style>

</head>
    <link href="css/bootstrap.css" rel="stylesheet" />
<body dir="rtl">
<form runat="server">
        <div width="100%">
        </div><br /><br /><br /><br /><br />
    <div align="center">
        <div align="center">

            <table width="30%">
                <tr>
                    <td colspan="2">
                        <h4><asp:Label ID="Label2" runat="server" Text="התחברות לאתר" Width="100%" style="text-align:center;" Font-Bold="true"></asp:Label></h4></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
            <td width="20%"><asp:Label ID="LoginId" runat="server" Text="תעודת זהות" Width ="100%"></asp:Label></td>
            <td width="60%"><asp:TextBox ID="LoginIdTB" runat="server" Width ="100%" class="form-control"></asp:TextBox></td></tr>
                <tr><td colspan="2">
                        <asp:Label ID="Label1" runat="server" Text="" Width="100%"></asp:Label></td></tr>
                <tr>
            <td width="20%"><asp:Label ID="LoginPassword" runat="server" Text="סיסמא" Width ="20%"></asp:Label></td>
            <td width="60%"><asp:TextBox ID="LoginPasswordTB" runat="server" Width ="100%" TextMode="Password" class="form-control"></asp:TextBox></td>
                    </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr><td colspan="2" align="left">
                    <asp:LinkButton ID="ForgotPassword" runat="server" text="שכחתי סיסמא"></asp:LinkButton>
                    <a href="" onclick="window.open('ForgotPassword.aspx','FP','width=500,height=50,top=300,left=500,fullscreen=no,resizable=0');">Forgot password</a>
                    <asp:LinkButton ID="LinkButton1" runat="server" style="float:right;" Text="רישום למרפאה" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </td></tr>
                <tr>
            <td colspan="2"><asp:Label ID="Label6" runat="server" Text="" Width="70%"></asp:Label>
                    </td></tr>
                <tr>
            <td colspan="2" align="center"><asp:Button ID="LoginSubmit" runat="server" style="text-align:center;" Text="כניסה" class="btn btn-outline-success" OnClick="LoginSubmit_Click"/></td></tr>
            </table>

        </div>
    </div>
</form>
</body>
</html>
