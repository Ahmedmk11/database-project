<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubRepRegister.aspx.cs" Inherits="Milestone3.clubRepRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="repRegister" runat="server">
        <div class="form">
                <asp:Label runat="server" Text="Placeholder"></asp:Label>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="repName" runat="server"></asp:TextBox>
                </div>
                    <asp:Label runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="usernameRep" runat="server"></asp:TextBox>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="passwordRep" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Club Name"></asp:Label>
                    <asp:TextBox ID="clubNameRep" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="ButtonRep" CssClass="btn" runat="server" Text="Register" OnClick="registerCR" />
            </div>
    </form>
</body>
</html>
