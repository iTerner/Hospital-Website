<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm bg-dark navbar-dark" style="direction:rtl;">
          <!-- Brand/logo -->
          <a class="navbar-brand" href="http://localhost:49675/HomePage.aspx"><i class="fa fa-fw fa-home"></i>דף הבית</a>
  
          <!-- Links -->
          <ul class="navbar-nav">
            <li class="nav-item" style="float:right;" >
              <a class="nav-link" href="#"><button type="button" class="btn btn-dark" data-toggle="modal" data-target="#myModal">התחברות</button></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:50px;">
              <a class="nav-link" href="#">
                  <asp:Button ID="Button3" runat="server" Text="הרשמה" CssClass="btn btn-dark" style="float:right;" OnClick="Button3_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:50px;">
                <a class="nav-link" href="http://localhost:49675/MedicineSearch.aspx"><asp:Button ID="Button1" runat="server" Text="בית מרקחת" CssClass="btn btn-dark" style="float:right;" OnClick="Button1_Click"/></a>
            </li>
            <li class="nav-item" style="float:right; margin-right:50px;">
              <a class="nav-link" href="http://localhost:49675/DoctorSearch.aspx"><asp:Button ID="Button2" runat="server" Text="חיפוש רופאים" CssClass="btn btn-dark" style="float:right;" OnClick="Button2_Click"/></a>
            </li>
          </ul>
        </nav><br /><br />
        <center>
       <h3>ברוכים הבאים לקופת חולים שלך ובשבילך</h3></center><br />
          <!-- The Modal Login Modal -->
          <div class="modal" id="myModal">
            <div class="modal-dialog">
              <div class="modal-content">
      
                <!-- Modal Header -->
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                  <b><h3 class="modal-title" style="float:right; margin-left:70%; margin-right:25%;">התחברות</h3></b>
                </div>

                <!-- Modal body -->
                <div class="modal-body">
                    <b><p style="float:right;">מלא את הפרטים הבאים</p></b><br /><br />
                          <div class="md-form mb-5" style="direction:rtl;">
                          <i class="fa fa-fw fa-user fa-2x" style="float:right; margin-left:20px;"></i>
                          <asp:TextBox ID="LoginIdTB" runat="server" Width="300px" CssClass="form-control" style="float:right;" placeholder="תעודת זהות"></asp:TextBox>
                        </div><br />
                        <div class="md-form mb-5" style="direction:rtl;">
                          <i class="fa fa-lock fa-2x" style="float:right; margin-right:10px; margin-left:30px;"></i>
                            <asp:TextBox ID="LoginPasswordTB" runat="server" Width="300px" CssClass="form-control" style="float:right;" placeholder="סיסמא" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="md-form mb-5" style="direction:rtl;">
                            <asp:Label ID="Label1" runat="server" Text="" Width="100%"></asp:Label>
                        </div>
                        <div class="md-form">
                            <asp:Label ID="Label6" runat="server" Text="" Width="77%" Style="direction:rtl; float:right; position:center;"></asp:Label>
                        </div>
                </div>
        
                <!-- Modal footer -->
                <div class="modal-footer">
                  <button type="button" class="btn btn-outline-danger" data-dismiss="modal" style="float:left; direction:rtl;">סגור</button>
                    <asp:Button ID="LoginSubmit" runat="server" Text="כניסה" CssClass="btn btn-outline-success" style="float:left; direction:rtl;" OnClick="LoginSubmit_Click"/>
                    <asp:LinkButton ID="ForgotPassword" runat="server" Style="float:left; direction:rtl; margin-left:45%" OnClick="ForgotPassword_Click">שחכתי סיסמא</asp:LinkButton>
                </div>
        
              </div>
            </div>
          </div>

        <table width="100%">
            <tr>
                <td width="50%" align="left" style="direction:rtl;">
                    <div class="container" style="width:100%">
                      <div id="myCarousel" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                          <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                          <li data-target="#myCarousel" data-slide-to="1"></li>
                          <li data-target="#myCarousel" data-slide-to="2"></li>
                        </ol>

                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                          <div class="item active">
                            <img src="Picture/homepage1.jpg" style="width:100%; height:550px; background-color:black;" />
                          </div>

                          <div class="item">
                            <img src="Picture/homepage2.jpeg" style="width:100%; height:550px; background-color:black;"  />
                          </div>
    
                          <div class="item">
                            <img src="Picture/homepage3.jpg" style="width:100%; height:550px; background-color:black;" />
                          </div>
                        </div>

                        <!-- Left and right controls -->
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                          <span class="glyphicon glyphicon-chevron-left"></span>
                          <span class="sr-only">Previous</span>
                        </a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">
                          <span class="glyphicon glyphicon-chevron-right"></span>
                          <span class="sr-only">Next</span>
                        </a>
                      </div>
                    </div>
                </td>
                <td width="50%" align="right" dir="rtl">
                    <br /><br /><br /><br />
                        <!-- לשים כרטיסיות עם כל מיני כתבות -->
                        <div class="card-deck">
                          <div class="card">
                            <img class="card-img-top" src="Picture/card1.jpg" alt="Card image cap" style="width:100%; height:200px;">
                            <div class="card-body">
                              <h4 class="card-title">המאבק בקורונה</h4>
                              <p class="card-text">נגיף הקורונה התפרץ בסין בדצמבר 2019 והפך למגפה עולמית: מאות אלפי אנשים מתו ומאות מיליונים ברחבי העולם הפסיקו את שגרת החיים. </p><br />
                              <a href="https://www.clalit.co.il/he/coronavirus/Pages/default.aspx" class="btn btn-primary" style="float:left;" target="_blank">לפרטים נוספים</a>
                            </div>
                          </div>
                          <div class="card">
                            <img class="card-img-top" src="Picture/card2.png" alt="Card image cap" style="width:100%; height:200px;">
                            <div class="card-body">
                              <h4 class="card-title">מוצרים דיגיטליים</h4>
                              <p class="card-text">הראש כואב? הגרון אדום? האוזניים מציקות? - המכשיר שיבדוק אתכם מבלי לצאת מהבית</p><br />
                              <a href="https://www.clalit.co.il/he/Tyto/Pages/preview.aspx" class="btn btn-primary" style="float:left;" target="_blank">לפרטים נוספים</a>
                            </div>
                          </div>
                          <div class="card">
                            <img class="card-img-top" src="Picture/card3.jpg" alt="Card image cap" style="width:100%; height:200px;">
                            <div class="card-body">
                              <h4 class="card-title">הכל במקום אחד</h4>
                              <p class="card-text">רוצה להזמין תור? להוציא מרשם מהרופא? מהרו להירשם</p>
                              <a href="http://localhost:49675/SignUp.aspx" class="btn btn-primary" style="float:left;" target="_blank">לפרטים נוספים</a>
                            </div>
                          </div>
                        </div><br />
                        <!-- BMI -->
                          <a class="nav-link" href="#"><button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal1" style="float:right; margin-right:50px;">למדידת BMI</button></a>
                              <div class="modal" id="myModal1">
                                <div class="modal-dialog">
                                  <div class="modal-content">
      
                                    <!-- Modal Header -->
                                    <div class="modal-header">
                                      <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <!-- Modal body -->
                                    <div class="modal-body">
                                        <p style="float:right; direction:rtl; margin-right:20px;"><h3><b>מלא את הפרטים הבאים</b></h3></p><br /><br />
                                              <div class="md-form mb-5" style="direction:rtl;">
                                                  <asp:Label ID="Label2" runat="server" Text="מין" Style="float:right; margin-right:50px;" Width="100px"></asp:Label>
                                                  <asp:DropDownList ID="GenderDDL" runat="server" Style="float:right; margin-right:10px;" CssClass="form-control" Width="150px">
                                                    <asp:ListItem Value="1">זכר</asp:ListItem>
                                                    <asp:ListItem Value="2">נקבה</asp:ListItem>
                                                  </asp:DropDownList>
                                            </div><br />
                                            <div class="md-form mb-5" style="direction:rtl;">
                                                <asp:Label ID="Label3" runat="server" Text="משקל(קילוגרם)" Style="float:right; margin-right:50px;" Width="100px"></asp:Label>
                                                <asp:TextBox ID="WeightTB" runat="server" Style="float:right; margin-right:10px;" CssClass="form-control" Width="150px" TextMode="Number" value="60"></asp:TextBox>
                                            </div><br />
                                            <div class="md-form mb-5" style="direction:rtl;">
                                                <asp:Label ID="Label4" runat="server" Text="גובה(סנטימטרים)" Style="float:right; margin-right:50px;" Width="100px"></asp:Label>
                                                <asp:TextBox ID="HeightTB" runat="server" Style="float:right; margin-right:10px;" CssClass="form-control" Width="150px" TextMode="Number" value="150"></asp:TextBox>
                                            </div><br /><br />
                                            <div class="md-form">
                                                <asp:Label ID="Sum" runat="server" Text="" Style="float:right; margin-right:50px; margin-left:50px;"></asp:Label>
                                            </div>
                                    </div>
        
                                    <!-- Modal footer -->
                                    <div class="modal-footer">
                                      <button type="button" class="btn btn-outline-danger" data-dismiss="modal" style="float:left; direction:rtl;">סגור</button>
                                        <asp:Button ID="CalcBMI" runat="server" Text="בדוק" CssClass="btn btn-outline-success" style="float:left; direction:rtl;" OnClick="CalcBMI_Click"/>
                                    </div>
        
                                  </div>
                                </div>
                              </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
