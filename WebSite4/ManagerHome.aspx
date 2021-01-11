<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerHome.aspx.cs" Inherits="ManagerHome" %>

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
          <a class="navbar-brand" href="http://localhost:49675/ManagerHome.aspx"><img src="Picture/managerlogo.png" style="width:40px; height:40px;" /><asp:Label runat="server" ID="HelloLabel" style="margin-right:5px;"></asp:Label></a>
  
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
                <a class="nav-link" href=""><asp:Button ID="Appointment" runat="server" Text="תורים" CssClass="btn btn-dark" style="float:right;" OnClick="Appointment_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Orders" runat="server" Text="הזמנות" CssClass="btn btn-dark" style="float:right;" OnClick="Orders_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:5px;">
              <a class="nav-link" href=""><asp:Button ID="Vacation" runat="server" Text="חופשות" CssClass="btn btn-dark" style="float:right;" OnClick="Vacation_Click"/></a>
            </li>
            <li class="nav-item float-left">
              <a class="nav-link float-left" href="#"><asp:Button ID="ManagerLogOut" runat="server" Text="התנתקות" CssClass="btn btn-dark" OnClick="ManagerLogOut_Click"/></a>
            </li>
            </ul>
        </nav><br /><br />
        <div width="100%">
            <table width="100%">
                <tr>
                    <td><h1><center>
                        <asp:Label ID="Label1" runat="server" Text="נתונים" Font-Bold="true"></asp:Label></center></h1></td>
                </tr>
                <tr>
                    <td><label width="100%" text=""></label></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="ShowAllData" runat="server" style="float:right; margin-right:25px; direction:rtl;" Width="150px" CssClass="form-control">
                            <asp:ListItem Value="0">מיין לפי</asp:ListItem>
                            <asp:ListItem Value="1">רופאים</asp:ListItem>
                            <asp:ListItem Value="2">לקוחות</asp:ListItem>
                        </asp:DropDownList>
                        
                            <asp:Button ID="ShowGrid" runat="server" Text="הצג" CssClass="btn btn-outline-primary form-control" style="float:right; margin-right:25px;" OnClick="ShowGrid_Click" Width="60px"/>
                            <asp:Button ID="CloseGrid" runat="server" Text="סגור" Visible="false" CssClass="btn btn-outline-danger form-control" style="float:right;" OnClick="CloseGrid_Click" Width="60px"/>
                        
                    </td>
                </tr>
                <tr>
                    <td><label Width="100%"></label><br /></td>
                </tr>
                <tr>
                    <td>
                        <center>
                        <div style="overflow-x:auto; overflow-y:auto; width:90%;">
                        <asp:GridView ID="ShowDataGridForUser" runat="server" align="center" Width="100%" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowDataGridForUser_RowCommand" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowEditing="ShowDataGridForUser_RowEditing">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="UserId" HeaderText="תעודת זהות" SortExpression="UserId" ReadOnly="True" />
                                <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                                <asp:BoundField DataField="UserGender" HeaderText="מין" SortExpression="UserGender" />
                                <asp:BoundField DataField="UserBirth" HeaderText="תאריך לידה" SortExpression="UserBirth" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}" />
                                <asp:BoundField DataField="UserPhone" HeaderText="טלפון" SortExpression="UserPhone" />
                                <asp:BoundField DataField="CityName" HeaderText="עיר מגורים" SortExpression="CityName" />
                                <asp:BoundField DataField="UserPhone" HeaderText="טלפון" SortExpression="UserPhone" />
                                <asp:BoundField DataField="UserEmail" HeaderText="מייל" SortExpression="UserEmail" />
                                <asp:BoundField DataField="UserPassword" HeaderText="סיסמא" SortExpression="UserPassword" />
                                <asp:BoundField DataField="UserDateLogin" HeaderText="תאריך התחברות אחרון" SortExpression="UserDateLogin" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteUser" Text="מחק" />
                                <asp:ButtonField ButtonType="Button" CommandName="ContactWithUser" Text="צור קשר" />
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
                        <div style="overflow-x:auto; overflow-y:auto; height:300px; width:90%; position:center;">
                        <asp:GridView ID="ShowDataGridForDoctor" runat="server" align="center" Width="100%" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowDataGridForDoctor_RowCommand" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="ShowDataGridForDoctor_RowCancelingEdit" OnRowEditing="ShowDataGridForDoctor_RowEditing" OnRowUpdating="ShowDataGridForDoctor_RowUpdating">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="DoctorId" HeaderText="תעודת זהות" SortExpression="DoctorId" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם" SortExpression="DoctorName" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorGender" HeaderText="מין" SortExpression="DoctorGender" ReadOnly="True" />
                                <asp:BoundField DataField="CityName" HeaderText="עיר מגורים" SortExpression="CityName" ReadOnly="True" />
                                <asp:BoundField DataField="SpecialityName" HeaderText="התמחות" SortExpression="SpecialityName" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorPhone" HeaderText="מספר טלפון" SortExpression="DoctorPhone" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorLicense" HeaderText="שנים במקצוע" SortExpression="DoctorLicense" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorUniversity" HeaderText="אוניברסיטה" SortExpression="DoctorUniversity" ReadOnly="True" />
                                <asp:BoundField DataField="DoctorBirthDay" HeaderText="תאריך לידה" SortExpression="DoctorBirthDay" ReadOnly="True"  HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}"/>
                                <asp:TemplateField HeaderText="האם בחופשה" SortExpression="DoctorIsOnVacation">
                                    <EditItemTemplate>
                                        <!--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DoctorIsOnVacation") %>'></asp:TextBox>-->
                                        <div>
                                            <asp:Label ID="Label9" runat="server" Text="מתאריך" style="float:right; margin-right:10px;"></asp:Label>
                                            <asp:TextBox ID="StartVac" runat="server" style="float:right; margin-right:40px;" TextMode="Date" Width="200px" CssClass="form-control"></asp:TextBox><br /><br />
                                            <asp:Label ID="Label10" runat="server" Text="עד לתאריך" style="float:right; margin-right:10px;"></asp:Label>
                                            <asp:TextBox ID="EndVac" runat="server" style="float:right; margin-right:20px;" TextMode="Date" Width="200px" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("DoctorIsOnVacation") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteDoctor" Text="מחק" />
                                <asp:ButtonField ButtonType="Button" CommandName="ContactWithDoctor" Text="צור קשר" />
                                <asp:CommandField ButtonType="Button" CancelText="ביטול" DeleteText="מחק" EditText="עדכון חופשה" ShowEditButton="True" UpdateText="עדכן" />
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
                </tr>
                <tr>
                    <td><label Text="" width="100%"></label></td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <table align ="right" dir="rtl">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="הכנס נושא"  Font-Bold="True" Style="margin-right:110px; text-align:right;" Visible="False" CssClass="float-right" Height="24px"></asp:Label></td>
                                    <td>
                                        <asp:TextBox ID="ThemeTB" runat="server" Width="341px" Visible="false" Style="direction:rtl; float:right;" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Label ID="Label2" runat="server" Text="הכנס הודעה" Font-Bold="True" Style="margin-right:110px; text-align:right;" Visible="False" CssClass="float-right" Height="24px"></asp:Label></td>
                                    <td><asp:TextBox ID="MessageContent" runat="server" Style="margin-left:100px; direction:rtl;"  CssClass="form-control" Height="52px" TextMode="MultiLine" Width="341px" Visible="false" ></asp:TextBox></td>
                               </tr>
                                <tr>
                                    <td colspan="2">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label3" runat="server" Text="" Width="100%"></asp:Label></td>
                                </tr>
                                <tr><td colspan="2"><center>
                                    <asp:Button ID="SendMessage" runat="server" Text="שלח" style="margin-right:200px; float:right;" CssClass="btn btn-outline-success form-control" Visible="false" OnClick="SendMessage_Click" Width="60px"/>
                                    <asp:Button ID="ResetMessage" runat="server" Text="נקה" CssClass="btn btn-outline-danger form-control" Style="float:right;" Visible="false" OnClick="ResetMessage_Click" Width="60px"/>
                                    <asp:Button ID="CloseMessage" runat="server" Text="סגור" CssClass="btn btn-outline-primary form-control" Style="float:right;" Visible="false" OnClick="CloseMessage_Click" Width="60px"/>
                                </center></td></tr>
                           </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label Text="" width="100%"></label>
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
