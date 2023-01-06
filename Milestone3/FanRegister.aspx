<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanRegister.aspx.cs" Inherits="Milestone3.FanRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Register</title>
    </head>
    <body>
        <form id="fanRegisterBody" runat="server">
            <div id="fID" runat="server" class="form">
                <asp:Label CssClass="labels" runat="server" Text="Register"></asp:Label>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="fanName" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="fanUsername" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="fanPassword" TextMode="Password" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="National ID"></asp:Label>
                    <asp:TextBox ID="fanNat" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Phone Number"></asp:Label>
                    <asp:TextBox ID="fanPhone" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Birthday"></asp:Label>
                    <asp:TextBox ID="fanBirthday" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="fanAddress" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="registerFann" CssClass="btn" runat="server" Text="Register" OnClick="registerFan" />
            </div>
        </form>
    </body>
</html>