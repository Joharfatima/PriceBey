<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="PriceBey.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <center> <h1>Register</h1>
            <h3>Create a new account</h3>
           <h3> <asp:TextBox ID="txturname" placeholder="Username" runat="server"></asp:TextBox></h3>
            <h3> <asp:TextBox ID="Txtemail" placeholder="E-mail" runat="server"></asp:TextBox></h3>
            <h3> <asp:TextBox ID="Txtpasswd" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox></h3>
           <h3>  <asp:TextBox ID="txtcops" placeholder="Confirm Password" TextMode="Password" runat="server"></asp:TextBox></h3>
              <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Sign Me Up" /></center>
        </div>
    </form>
</body>
</html>
