<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorPrescription.aspx.cs" Inherits="DoctorPrescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link href="css/bootstrap.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server" dir="rtl">
           <nav class="navbar navbar-expand-sm bg-dark navbar-dark" style="direction:rtl;">
          <!-- Brand/logo -->
          <a class="navbar-brand" href="http://localhost:49675/DoctorInfo.aspx"><img src="Picture/doctorlogo.jpg" style="width:40px; height:40px;" /><asp:Label runat="server" ID="HelloLabel" style="margin-right:5px;"></asp:Label></a>
  
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
                <a class="nav-link" href=""><asp:Button ID="Appointment" runat="server" Text="לוח עבודה" CssClass="btn btn-dark" style="float:right;" OnClick="Appointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Contact" runat="server" Text="צור קשר" CssClass="btn btn-dark" style="float:right;" OnClick="Contact_Click"/></a>
            </li>
            <li class="nav-item float-left">
              <a class="nav-link float-left" href="#"><asp:Button ID="DoctorLogOut" runat="server" Text="התנתקות" CssClass="btn btn-dark" OnClick="DoctorLogOut_Click"/></a>
            </li>
            </ul>
        </nav><br /><br />
                    <div><center><h1><asp:Label ID="Label3" runat="server" Text="מרשמים" Font-Bold="true"></asp:Label></h1></center></div><br />
            <div><h3>
                <asp:Label ID="Label4" runat="server" Text="מלא את הפרטים הבאים" Style="float:right; margin-right:50px;" Font-Bold="true"></asp:Label></h3></div><br /><br /><br />
            <table width="100%">
                <tr>
                    <td width="70%">
            <div align="right" style="margin-right:50px;">
                <table class="auto-style4">
                    <tr>
                        <td rowspan="5" width="2%"><label width="100%"></label></td>
                        <td class="auto-style1">
                            <asp:Label ID="UserIdL" runat="server" Text="שם לקוח" Style="float:right; margin-bottom:20px;" Font-Bold="true"></asp:Label></td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="UserNameDDL" runat="server" Width="150px" AutoPostBack="true" class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td width="20%">
                            <asp:Label ID="UserIdO" runat="server" Text="" Style="float:right; margin-bottom:20px;" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="MedicineNameL" runat="server" Text="שם התרופה" Style="float:right; margin-bottom:20px;" Font-Bold="true"></asp:Label></td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="MedicineNameDDL" runat="server" Width="150px" AutoPostBack="true" class="form-control">
                            </asp:DropDownList>
                        </td>
                        <td width="20%">
                            <asp:Label ID="MedicineNameO" runat="server" Text="" Style="float:right; margin-bottom:20px;" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="MedicineCountL" runat="server" Text="כמות" Style="float:right;" Font-Bold="true"></asp:Label></td>
                        <td class="auto-style2">
                            <asp:TextBox ID="MedicineCountTB" runat="server" Width="150px" Style="float:right; margin-top:25px;" TextMode="Number" class="form-control"></asp:TextBox>
                        </td>
                        <td width="20%">
                            <asp:Label ID="MedicineCountO" runat="server" Text="" Style="float:right;" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Label5" runat="server" Text="" Width="100%"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="3">
                          <div class="btn-group">
                            <asp:Button ID="SendPrescription" runat="server" Text="שלח" CssClass="btn btn-outline-success" OnClick="SendPrescription_Click"/>
                            <asp:Button ID="ResetData" runat="server" Text="נקה" CssClass="btn btn-outline-primary" OnClick="ResetData_Click" />
                          </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                </table>
            </div>
            </td>
            <td width="30%">
            <div width="40%">
            </div>
                </td>    
            </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                   <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
         </table>
        </div>
    </form>
</body>
</html>
