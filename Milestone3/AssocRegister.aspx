<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssocRegister.aspx.cs" Inherits="Milestone3.AssocRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Register</title>
    </head>
    <body>
        <form id="assocRegForm" runat="server">
            <div id="arID" runat="server" class="form registerFrm">
                <asp:Label CssClass="labels" ID="Label1" runat="server" Text="Register"></asp:Label>
                <div class="labelClass">
                    <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="name" runat="server"></asp:TextBox>
                </div>

                <div class="labelClass">
                    <asp:Label ID="Label3" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                </div>

                <div class="labelClass">
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="password" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Register" OnClick="register" />
            </div>
        </form>
    </body>
</html>

