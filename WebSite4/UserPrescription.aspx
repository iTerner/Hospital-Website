<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPrescription.aspx.cs" Inherits="UserPrescription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<link href="css/bootstrap.css" rel="stylesheet" />
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
            <center>
           <h1>
               <asp:Label ID="Label9" runat="server" Text="מרשמים"></asp:Label></h1></center><br />
            <table width="100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="SortPrescription" runat="server" style="float:right; margin-right:25px; direction:rtl;" CssClass="form-control" Width="150px" OnSelectedIndexChanged="SortPrescription_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">מיין לפי</asp:ListItem>
                            <asp:ListItem Value="1">תאריך</asp:ListItem>
                            <asp:ListItem Value="2">רופא</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="ClosePrescription" runat="server" Text="סגור" Style="margin-right:25px; float:right;" CssClass="btn btn-outline-danger form-control" OnClick="ClosePrescription_Click" Visible="false" Width="60px"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="" Width="100%"></asp:Label></td>
                </tr>
                <tr>
                    <td width="60%">
                        <asp:GridView ID="ShowPrescriptionGrid" runat="server" align="center" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowPrescriptionGrid_RowCommand" OnRowDataBound="ShowPrescriptionGrid_RowDataBound" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="PrescriptionId" HeaderText="מספר מרשם" SortExpression="PrescriptionId" />
                                <asp:BoundField DataField="PrescriptionDoctorId" HeaderText="תעודת זהות רופא" SortExpression="PrescriptionDoctorId" />
                                <asp:BoundField DataField="PrescriptionDate" HeaderText="תאריך הנפקה" SortExpression="PrescriptionDate" />
                                <asp:BoundField DataField="PrescriptionMedicineId" HeaderText="מספר תרופה" SortExpression="PrescriptionMedicineId" />
                                <asp:BoundField DataField="PrescriptionMedicineName" HeaderText="שם התרופה" SortExpression="PrescriptionMedicineName" />
                                <asp:BoundField DataField="PrescriptionMedicineCount" HeaderText="כמות" SortExpression="PrescriptionMedicineCount" />
                                <asp:ButtonField ButtonType="Button" CommandName="UsePrescription" Text="מימוש" />
                                <asp:ButtonField ButtonType="Button" CommandName="ShowMedicinePrice" Text="מחיר" />
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
                    </td>
                </tr>
                <tr>
                    <td><label width="100%"></label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
