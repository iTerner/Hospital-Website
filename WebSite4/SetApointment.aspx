<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SetApointment.aspx.cs" Inherits="SetApointment" %>

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
        <div><center><h1>
                <asp:Label ID="Label1" runat="server" Text="קביעת תורים"></asp:Label></h1></center><br /><br />
                <label style="float:right; direction:rtl; margin-right:50px; font-size:large;" >מלא את הפרטים הבאים</label><br />
        </div><br /><br />
        <div dir="rtl">
            <asp:Table runat="server" Width="60%" Style="direction:rtl; margin-right:40px">
                <asp:TableRow ID="AppType">
                    <asp:TableHeaderCell Width="15%"><asp:Label ID="Label2" runat="server" Text="סוג התור" style="float:right; margin-right:15px;"></asp:Label></asp:TableHeaderCell>
                    <asp:TableCell Width="20%"><asp:DropDownList ID="SpecailtyDropDownList" runat="server" Style="float:right" Width="45%" OnSelectedIndexChanged="SpecailtyDropDownList_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control">
                        </asp:DropDownList></asp:TableCell>
                    <asp:TableCell Width="20%"><asp:Label ID="SpecalityValid" runat="server" Text="" Style="float:right" Width="100%" ></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="AppDoctor">
                    <asp:TableHeaderCell Width="15%"><asp:Label ID="Label4" runat="server" Text="בחר רופא" style="float:right; margin-right:15px;" Visible="false"></asp:Label></asp:TableHeaderCell>
                    <asp:TableCell Width="20%"><asp:DropDownList ID="DoctorDropDownList" runat="server" Style="float:right" Width="45%" AutoPostBack="true" OnSelectedIndexChanged="DoctorDropDownList_SelectedIndexChanged" Visible="false" CssClass="form-control"></asp:DropDownList></asp:TableCell>
                    <asp:TableCell Width="20%"><asp:Label ID="DoctorValid" runat="server" CssClass="float-right" Width="100%" Style="float:right; margin-right:5px; direction:rtl;"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" ID="isDoctorAvaliavle"><center><h3>
                        <asp:Label ID="IsDoctorAvaliable" runat="server" Text="" Width="100%" Style="float:right; margin-right:5px; direction:rtl;"></asp:Label></h3></center></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="AppDate">
                    <asp:TableHeaderCell Width="15%"><asp:Label ID="Label6" runat="server" Text="בחר תאריך" style="float:right; margin-right:15px;" Visible="false"></asp:Label></asp:TableHeaderCell>
                    <asp:TableCell Width="20%"><asp:TextBox ID="DateTB" runat="server" Width="45%" Style="float:right" TextMode="Date" AutoPostBack="True" OnTextChanged="DateTB_TextChanged" Visible="false" CssClass="form-control"></asp:TextBox></asp:TableCell>
                    <asp:TableCell Width="20%"><asp:Label ID="DateValid" runat="server" Text="" Style="float:left"  Width="100%"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="AppHour" Visible="false">
                    <asp:TableHeaderCell Width="15%"> <asp:Label ID="Label8" runat="server" Text="בחר שעות" style="float:right; margin-right:15px;" Visible="false"></asp:Label></asp:TableHeaderCell>
                    <asp:TableCell Width="25%"><div style="width: 50%; height: 300px; overflow-x:auto; overflow-y:auto;">
                        <asp:GridView ID="HoursGridView" runat="server" AutoGenerateColumns="False" Visible="False" OnRowCommand="HoursGridView_RowCommand" OnRowDataBound="HoursGridView_RowDataBound" OnPageIndexChanging="HoursGridView_PageIndexChanging" PageSize="6" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="HourNumber" SortExpression="HourNumber" />
                                <asp:BoundField DataField="HourStartTime" HeaderText="שעת התחלה" SortExpression="HourStartTime" />
                                <asp:BoundField DataField="HourEndTime" HeaderText="שעת סיום" SortExpression="HourEndTime" />
                                <asp:ButtonField ButtonType="Button" Text="בחר" CommandName="SetApointment" />
                            </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerSettings Mode="Numeric" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        </div></asp:TableCell>
                    <asp:TableCell Width="20%"><asp:Label ID="StartHourLabel" runat="server" Text="" Style="float:right;direction:rtl;" Width="100%"></asp:Label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3"><label width="100%"></label></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="AppSend">
                    <asp:TableCell ColumnSpan="3">
                        <asp:Button ID="SubmitButton" runat="server" Text="שלח" Visible="false" OnClick="SubmitButton_Click" CssClass="form-control btn btn-outline-success" Width="100px" Style="float:right; margin-right:40px;"/>
                        <asp:Button ID="ResetButton" runat="server" Text="נקה" Visible="false" OnClick="ResetButton_Click" CssClass="form-control btn btn-outline-primary" Width="100px" Style="float:right; margin-right:10px;"/>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>
