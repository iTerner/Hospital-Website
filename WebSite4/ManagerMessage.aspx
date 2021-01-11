<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerMessage.aspx.cs" Inherits="ManagerMessage" %>

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
                <table width="100%">
                <tr>
                    <td class="auto-style1">
                        <h1><center>
                        <asp:Label ID="Label3" runat="server" Text="הודעות" Font-Bold="true"></asp:Label></center></h1>
                    </td>
                </tr>
                <td>
                    <td><label width="100%"></label></td>
                </td>
                <tr>
                    <td>
                        <asp:DropDownList ID="MessageTypeDDL" runat="server" style="float:right; margin-right:30px; direction:rtl;" Width="200px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="MessageTypeDDL_SelectedIndexChanged">
                            <asp:ListItem>הצג הודעות</asp:ListItem>
                            <asp:ListItem Value="1">הודעות שנשלחו אלי</asp:ListItem>
                            <asp:ListItem Value="2">הודעות חדשות</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td><label width="100%"></label></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="WhoDDL" runat="server" style="float:right; margin-right:30px; direction:rtl;" Width="200px" CssClass="form-control" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="WhoDDL_SelectedIndexChanged">
                            <asp:ListItem>בחר</asp:ListItem>
                            <asp:ListItem Value="1">רופא</asp:ListItem>
                            <asp:ListItem Value="2">לקוח</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseMessages" runat="server" Text="סגור" Width="60px" Style="float:right; margin-right:30px;" Visible="false" CssClass="btn btn-outline-danger form-control" OnClick="CloseMessages_Click"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <label Text="" width="100%"></label>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style1">
                    </td>
                </tr>
                <tr>
                    <td>
                        <center>
                        <asp:GridView ID="ShowMessageUserGrid" runat="server" align="center" Visible="False" Style="direction:rtl;" AutoGenerateColumns="False" OnRowCommand="ShowMessageUserGrid_RowCommand" OnRowDataBound="ShowMessageUserGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageUserId" HeaderText="תעודת זהות" SortExpression="MessageUserId" />
                                <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא ההודעה" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:ButtonField ButtonType="Button" CommandName="AnswerUser" HeaderText="תשובה" Text="תשובה" />
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
                        <asp:GridView ID="ShowMessageDoctorGrid" runat="server" align="center" Style="direction:rtl;" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowMessageDoctorGrid_RowCommand" OnRowDataBound="ShowMessageDoctorGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageDoctorId" HeaderText="תעודת זהות" SortExpression="MessageDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם הרופא" SortExpression="DoctorName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא ההודעה" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:ButtonField ButtonType="Button" CommandName="AnswerDoctor" HeaderText="תשובה" Text="תשובה" />
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
                        <asp:GridView ID="ShowMessageSendUser" runat="server" align="center" Visible="False" Style="direction:rtl;" AutoGenerateColumns="False" OnRowCommand="ShowMessageSendUser_RowCommand" OnRowDataBound="ShowMessageSendUser_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageUserId" HeaderText="תעודת זהות" SortExpression="MessageUserId" />
                                <asp:BoundField DataField="UserName" HeaderText="שם" SortExpression="UserName" />
                                <asp:BoundField DataField="MessageAnswerDate" HeaderText="תאריך" SortExpression="MessageAnswerDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}" />
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא הודעה" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:BoundField DataField="MessageAnswer" HeaderText="תשובה" SortExpression="MessageAnswer" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteMessageUser" HeaderText="מחק הודעה" Text="מחק" />
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
                        <asp:GridView ID="ShowMessageSendDoctor" runat="server" align="center" Style="direction:rtl;" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowMessageSendDoctor_RowCommand" OnRowDataBound="ShowMessageSendDoctor_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageDoctorId" HeaderText="תעודת זהות" SortExpression="MessageDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם" SortExpression="DoctorName" />
                                <asp:BoundField DataField="MessageAnswerDate" HeaderText="תאריך" SortExpression="MessageAnswerDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא הודעה" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:BoundField DataField="MessageAnswer" HeaderText="תשובה" SortExpression="MessageAnswer" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteMessageDoctor" HeaderText="מחק הודעה" Text="מחק"/>
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
                         </center>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1"><label Text="" width="100%"></label></td>
                </tr>
                <tr>
                    <td>
                        <center>
                        <div align="center">
                            <asp:Label ID="Label4" runat="server" Text="הכנס הודעה" Font-Bold="true" Style="float:right; margin-right:110px; text-align:right;" Visible="false"></asp:Label><br /><br />
                            <asp:TextBox ID="AnswerTB" runat="server" Style="margin-right:110px; direction:rtl; float:right;" CssClass="form-control" Height="52px" TextMode="MultiLine" Width="250px" Visible="false"></asp:TextBox><br /><br />
                            <asp:Label ID="AnswerO" runat="server" Style="margin-right:100px; direction:rtl;" CssClass="float-right" Width="229px" Font-Bold="true"></asp:Label><br />

                            <asp:Button ID="UndoMessageAnswer" runat="server" Text="סגור" CssClass="btn btn-outline-danger form-control" Width="60px" Style="float:right; margin-right:180px;" Visible="false" OnClick="UndoMessageAnswer_Click"/>
                            <asp:Button ID="ResetMessageAnswer" runat="server" Text="נקה" CssClass="btn btn-outline-primary form-control" Width="60px" Style="float:right;" Visible="false" OnClick="ResetMessageAnswer_Click"/>
                            <asp:Button ID="SendMessageAnswer" runat="server" Text="שלח" style="float:right;" CssClass="btn btn-outline-success form-control" Width="60px" Visible="false" OnClick="SendMessageAnswer_Click"/>
                        </div>
                        </center>
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
