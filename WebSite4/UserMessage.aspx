<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMessage.aspx.cs" Inherits="UserMessage" %>

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
        <div><center>
            <h1><asp:Label ID="Label3" runat="server" Text="הודעות"></asp:Label></h1></center><br />
            <table width="100%">
               <tr>
                    <td align="100%" class="auto-style2">
                        <asp:DropDownList ID="SortMessageDDL" runat="server" style="margin-right:25px; float:right; direction:rtl;" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="SortMessageDDL_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem Value="0">הצג הודעות</asp:ListItem>
                            <asp:ListItem Value="1">הודעות שנשלחו אלי</asp:ListItem>
                            <asp:ListItem Value="2">הודעות שלי</asp:ListItem>
                        </asp:DropDownList><br /><br />
                        <asp:DropDownList ID="ChooseNewMessage" runat="server" style="float:right; margin-right:25px; direction:rtl;" Width="200px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="ChooseNewMessage_SelectedIndexChanged" CssClass="form-control">
                            <asp:ListItem>בחר</asp:ListItem>
                            <asp:ListItem Value="1">רופא</asp:ListItem>
                            <asp:ListItem Value="2">מנהל</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="CloseMessages" runat="server" Text="סגור" style="float:right; margin-right:15px;" CssClass="btn btn-outline-danger form-control" Visible="false" OnClick="CloseMessages_Click" Width="60px"/>
                    </td>
                </tr>
                <tr>
                    <td align ="100%" dir="rtl">
                        <asp:GridView ID="ShowMessage" runat="server" align="center" AutoGenerateColumns="False" OnRowCommand="ShowMessage_RowCommand" OnRowDataBound="ShowMessage_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId"></asp:BoundField>
                                <asp:BoundField DataField="MessageDoctorId" HeaderText="תעודת זהות" SortExpression="MessageDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם" SortExpression="DoctorName" />
                                <asp:BoundField DataField="MessageAnswerDate" HeaderText="תאריך" SortExpression="MessageAnswerDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}" />
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
                        <asp:GridView ID="ShowMessageManagerGrid" runat="server" Align="Center" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowMessageManagerGrid_RowCommand" OnRowDataBound="ShowMessageManagerGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageManagerId" HeaderText="תעודת זהות" SortExpression="MessageManagerId" />
                                <asp:BoundField DataField="ManagerName" HeaderText="שם" SortExpression="ManagerName" />
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
                        <asp:GridView ID="ShowNewMessageManagerGrid" runat="server" Align="Center" Visible="False" AutoGenerateColumns="False" OnRowCommand="ShowNewMessageManagerGrid_RowCommand" OnRowDataBound="ShowNewMessageManagerGrid_RowDataBound" style="direction:rtl;" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageManagerId" HeaderText="תעודת זהות" SortExpression="MessageManagerId" />
                                <asp:BoundField DataField="ManagerName" HeaderText="שם" SortExpression="ManagerName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}"/>
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן הודעה" SortExpression="MessageContent" />
                                <asp:ButtonField ButtonType="Button" CommandName="AnswerManager" Text="תשובה" />
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
                        <asp:GridView ID="ShowNewMessageDoctorGrid" runat="server" Align="Center" Visible="False" style="direction:rtl;" AutoGenerateColumns="False" OnRowCommand="ShowNewMessageDoctorGrid_RowCommand" OnRowDataBound="ShowNewMessageDoctorGrid_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="MessageId" HeaderText="מספר הודעה" SortExpression="MessageId" />
                                <asp:BoundField DataField="MessageDoctorId" HeaderText="תעודת זהות" SortExpression="MessageDoctorId" />
                                <asp:BoundField DataField="DoctorName" HeaderText="שם" SortExpression="DoctorName" />
                                <asp:BoundField DataField="MessageSendDate" HeaderText="תאריך" SortExpression="MessageSendDate" HtmlEncode="false" DataFormatString="{0:dd/mm/yyyy}" />
                                <asp:BoundField DataField="MessageTheme" HeaderText="נושא" SortExpression="MessageTheme" />
                                <asp:BoundField DataField="MessageContent" HeaderText="תוכן" SortExpression="MessageContent" />
                                <asp:ButtonField ButtonType="Button" CommandName="AnswerDoctor" Text="תשובה" />
                                <asp:ButtonField ButtonType="Button" CommandName="DeleteDoctorMessage" Text="מחק" />
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
                        <div>
                        <asp:Label ID="UserAnswerL" runat="server" Text="הכנס הודעה" Style="float:right; margin-right:25px; margin-left:25px; text-align:right;" Font-Bold="true" Visible="false"></asp:Label><br />
                        <asp:TextBox ID="UserAnswerTB" runat="server" Width="250px" Style="float:right; margin-right:25px; text-align:right; direction:rtl;" TextMode="MultiLine" Visible="false" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="UserAnswerO" runat="server" Text="" Width="300px" Font-Bold="true" style="float:right; text-align:right;" Visible="false"></asp:Label><br /><br />
                        <asp:Button ID="SendMessageButton" runat="server" Text="שלח" CssClass="btn btn-outline-success form-control" Style="float:right; margin-right:25px;" Visible="false" OnClick="SendMessageButton_Click" Width="40px"/>
                        <asp:Button ID="ResetMessageButton" runat="server" Text="נקה" CssClass="btn btn-outline-primary form-control" Style="float:right;" Visible="false" OnClick="ResetMessageButton_Click" Width="40px"/>
                        <asp:Button ID="UndoMessageButton" runat="server" Text="ביטול" CssClass="btn btn-outline-danger form-control" Style="float:right;" OnClick="UndoMessageButton_Click" Visible="false" Width="40px"/>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
