<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DoctorMessage.aspx.cs" Inherits="DoctorMessage" %>

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
        <div><center>
            <h1><asp:Label ID="Label1" runat="server" Text="הודעות" Font-Bold="true"></asp:Label></h1></center></div><br />
        <div width="100%">
            <table width="100%">
                <tr>
                    <td rowspan="13" width="5%"><label width="100%"></label></td>
                    <td width="90%">
                        <asp:DropDownList ID="ShowMessageDDL" runat="server" Width="200px" style="float:right;" AutoPostBack="true" OnSelectedIndexChanged="ShowMessageDDL_SelectedIndexChanged" class="form-control">
                            <asp:ListItem Value="0">הצג הודעות</asp:ListItem>
                            <asp:ListItem Value="1">הודעות שנשלחו אלי</asp:ListItem>
                            <asp:ListItem Value="2">הודעות שלי</asp:ListItem>
                        </asp:DropDownList><br /><br />

                        <asp:DropDownList ID="DropDownListSort" runat="server" style="float:right; margin-left:10px;" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DropDownListSort_SelectedIndexChanged" Visible="false" class="form-control">
                            <asp:ListItem>בחר</asp:ListItem>
                            <asp:ListItem Value="1">לקוח</asp:ListItem>
                            <asp:ListItem Value="2">מנהל</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseMessages" runat="server" Text="סגור" style="float:right; margin-right:15px;" CssClass="btn btn-outline-danger" Visible="false" OnClick="CloseMessages_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="center" height="50%">
                        <asp:GridView ID="UserMessageGrid" runat="server" align ="center" Visible="False" AutoGenerateColumns="False" OnRowCommand="UserMessageGrid_RowCommand" OnRowDataBound="UserMessageGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageUserId" HeaderText="תעודת זהות" SortExpression="MessageUserId" />
                                <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן ההודעה" SortExpression="MessageContent" />
                                <asp:ButtonField Text="תשובה" CommandName="AnswerUser" HeaderText="תשובה" ButtonType="Button" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteUserMessage" Text="מחק" />
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
                        <asp:GridView ID="ManagerMessageGrid" runat="server" AutoGenerateColumns="False" align ="center" Visible="False" OnRowCommand="ManagerMessageGrid_RowCommand" OnRowDataBound="ManagerMessageGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageManagerId" HeaderText="תעודת זהות" SortExpression="MessageManagerId" />
                                <asp:BoundField DataField="ManagerName" HeaderText="שם" SortExpression="ManagerName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:ButtonField ButtonType="Button" CommandName="Answer" Text="תשובה" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteManagerMessage" Text="מחק" />
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
                                                <asp:GridView ID="ManagerSendMessageGrid" runat="server" Align="center" AutoGenerateColumns="False" style="direction:rtl;" OnRowCommand="ManagerSendMessageGrid_RowCommand" OnRowDataBound="ManagerSendMessageGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageManagerId" HeaderText="תעודת זהות" SortExpression="MessageManagerId" />
                                <asp:BoundField DataField="ManagerLastName" HeaderText="שם" SortExpression="ManagerName" />
                                <asp:BoundField DataField="MessageAnswerDate" HeaderText="תאריך" SortExpression="MessageAnswerDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:BoundField DataField="MessageAnswer" HeaderText="תשובה" SortExpression="MessageAnswer" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteMessage" Text="מחק" />
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
                        <asp:GridView ID="UserSendMessageGrid" runat="server" Align="center" AutoGenerateColumns="False" style="direction:rtl;" OnRowCommand="UserSendMessageGrid_RowCommand" OnRowDataBound="UserSendMessageGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageUserId" HeaderText="תעודת זהות" SortExpression="MessageUserId" />
                                <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                                <asp:BoundField DataField="MessageAnswerDate" HeaderText="תאריך" SortExpression="MessageAnswerDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן ההודעה" SortExpression="MessageContent" />
                                <asp:BoundField DataField="MessageAnswer" HeaderText="תשובה" SortExpression="MessageAnswer" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteUserMessage" Text="מחק" />
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
                    <td>
                        <center>
                            <div style="margin-right:50px;">
                                <asp:Label ID="Label2" runat="server" Text="כתוב תשובה" Font-Bold="true" style="float:right;"  Visible="false"></asp:Label><br />
                                <asp:TextBox ID="DoctorMessageAnswer" runat="server" Width="250px" style="float:right;" Visible="false" TextMode="MultiLine" class="form-control"></asp:TextBox><br /><br /><br />
                                <div class="btn-group" style="float:right;">
                                    <asp:Button ID="SendMessage" runat="server" Text="שלח" CssClass="btn btn-outline-success" Visible="false" OnClick="SendMessage_Click"></asp:Button>
                                    <asp:Button ID="ResetMessage" runat="server" Text="נקה" CssClass="btn btn-outline-primary" Visible="false" OnClick="ResetMessage_Click"></asp:Button>
                                    <asp:Button ID="Undo" runat="server" Text="ביטול" CssClass="btn btn-outline-danger" Visible="false" OnClick="Undo_Click"></asp:Button>
                                </div><br /><br /><br />
                            </div>
                        </center>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td width="100%"><center><h3>
                        &nbsp;</h3></center></td>
                </tr>
                <tr>
                    <td>
                        <label width="100%" Text=""></label>
                    </td>
                </tr>
                <tr>
                    <td><h3>
                        &nbsp;</h3></td>
                </tr>
                <tr>
                    <td>
                        <label width="100%" Text=""></label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>

                    </td>
                </tr>
                <tr>
                    <td>
                        <label></label>
                    </td>
                </tr>
                <tr>
                    <td><center><h3>
                        &nbsp;</h3></center></td>
                </tr>
                <tr>
                    <td>
                        <label></label>
                    </td>
                </tr>
            </table>
            <br />
    </form>
</body>
</html>
