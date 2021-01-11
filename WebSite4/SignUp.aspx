<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/bootstrap.css" rel="stylesheet" />
      <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <script>
        $(document).ready(function(){
          $('[data-toggle="popover"]').popover();   
        });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h1><label width="100%">הרשמה</label></h1><br />
            <h3>מלא את הפרטים הבאים</h3></center>
        </div><br />
        <div style="width:100%">
        <table style="width:70%; margin-right:50px; float:right; direction:rtl;">
            <tr style="margin-bottom:15px;">
                <td style="width:15%; margin-bottom:30px;">
                    <asp:Label ID="NameL" runat="server" Text="שם" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="NameTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="NameO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:30px;">
                <td style="width:15%">
                    <asp:Label ID="IdL" runat="server" Text="תעודת זהות" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="IdTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="IdO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="GenderL" runat="server" Text="מין" style="float:right; direction:rtl;margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:RadioButton ID="GenderMale" runat="server" AutoPostBack="true" style="float:right; direction:rtl; margin-bottom:20px;" OnCheckedChanged="GenderMale_CheckedChanged"/>
                    <asp:Label ID="Label21" runat="server" Text="זכר" Style="margin-left:30px; float:right; direction:rtl; margin-bottom:20px;"></asp:Label>
                    <asp:RadioButton ID="GenderFemale" runat="server" AutoPostBack="true" style="float:right; direction:rtl; margin-bottom:20px;" OnCheckedChanged="GenderFemale_CheckedChanged"/>
                    <asp:Label ID="Label22" runat="server" Text="נקבה" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="GenderO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="DateL" runat="server" Text="תאריך לידה" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td><asp:TextBox ID="DateTB" runat="server" TextMode="Date" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="DateO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="CityL" runat="server" Text="עיר" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="CityList" runat="server" AutoPostBack="true" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:DropDownList>
                    </td>
                <td>
                    <asp:Label ID="CityO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="AdressL" runat="server" Text="כתובת" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="AdressTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="AdressO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="HouseNumberL" runat="server" Text="מספר בית" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="HouseNumberTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="HouseNumberO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="PhoneL" runat="server" Text="מספר טלפון" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="PhoneTB" runat="server" TextMode="Phone" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="PhoneO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="EmailL" runat="server" Text="מייל" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="EmailTB" runat="server" TextMode="Email" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="EmailO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="PasswordL" runat="server" Text="סיסמא" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="PasswordTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox>
                      <button type="button" data-toggle="collapse" data-target="#demo" style="float:right; margin-right:5px; direction:rtl; border:none;"><img runat="server" src="Picture/info_icon.png" style="height:30px; width:30px" /></button><br /><br /><br />
                  <div id="demo" class="collapse" style="float:right; direction:rtl;">
                      סיסמא חייבת להכיל לפחות 8 תויים, מספר, אות קטנה וגדולה
                  </div>
                </td>
                <td>
                    <asp:Label ID="PasswordO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr style="margin-bottom:15px;">
                <td style="width:15%">
                    <asp:Label ID="ImutPasswordL" runat="server" Text="אימות סיסמא" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
                <td>
                    <asp:TextBox ID="ImutPasswordTB" runat="server" style="float:right; direction:rtl; margin-bottom:20px;" CssClass="form-control" Width="200px"></asp:TextBox></td>
                <td>
                    <asp:Label ID="ImutPasswordO" runat="server" Text="" style="float:right; direction:rtl; margin-bottom:20px;"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3"><center>
                    <asp:Button ID="SubmitButton" runat="server" Text="הירשם" Style="margin-left:10px;" CssClass="btn btn-outline-success form-control" Width="80px" OnClick="SubmitButton_Click"/>
                    <asp:Button ID="ResetButton" runat="server" Text="נקה" Style="position:center;" CssClass="btn btn-outline-danger form-control" Width="60px" OnClick="ResetButton_Click"/></center></td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
