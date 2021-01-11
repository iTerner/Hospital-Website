<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css"
    integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous">
    <style type="text/css">
        .auto-style1 {
            position: absolute;
            top: 217px;
            left: 372px;
            z-index: 1;
        }
        .auto-style2 {
            position: absolute;
            top: 301px;
            left: 332px;
            z-index: 1;
            width: 216px;
            height: 42px;
        }
    </style>
</head>
<link href="bootstrap.css" rel="stylesheet" />
<body>

    <form id="form1" runat="server">
<div class="form-group">
  <label class="col-form-label col-form-label-lg" for="inputLarge">Large input</label>
  <input class="form-control form-control-lg" type="text" placeholder=".form-control-lg" id="inputLarge">
</div>
        <div class="form-group has-success">
  <label class="form-control-label" for="inputSuccess1">Valid input</label>
  <input type="text" value="correct value" class="form-control is-valid" id="inputValid">
  <div class="valid-feedback">Success! You've done it.</div>
</div>

<div class="form-group has-danger">
  <label class="form-control-label" for="inputDanger1">Invalid input</label>
  <input type="text" value="wrong value" class="form-control is-invalid" id="inputInvalid">
  <div class="invalid-feedback">Sorry, that username's taken. Try another?</div>
</div>

       
        <p>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1" TextMode="Phone"></asp:TextBox>
        </p>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style2" TextMode="Range"></asp:TextBox>

       
    </form>
</body>
</html>
