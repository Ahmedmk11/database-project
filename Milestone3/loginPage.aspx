<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="Milestone3.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <title>Login</title>
</head>
<body>
    <form id="loginPageBody" runat="server">
        <div class="form">
                <asp:Label runat="server" Text="Please Enter Username and Password"></asp:Label>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="loginUsername" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" TextMode="Password" Text="Password"></asp:Label>
                    <asp:TextBox ID="loginPassword" runat="server"></asp:TextBox>
                </div>
                <asp:Button CssClass="btn" runat="server" Text="Login" />
            </div>
    </form>
</body>
</html>
