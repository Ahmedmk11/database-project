<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentativeLogin.aspx.cs" Inherits="Milestone3.ClubRepresentativeLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                    <asp:Label runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="loginPassword" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <asp:Button CssClass="btn" runat="server" Text="Login" OnClick="loginclubrepresentative"/>
                <a href="clubRepRegister.aspx">Dont have an Account?</a>
            </div>
    </form>
</body>
</html>
