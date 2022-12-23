<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAdminActions.aspx.cs" Inherits="Milestone3.SystemAdminActions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="systemAdminActionsBody" runat="server">
        <asp:Button ID="logoutSAA" CssClass="btn" runat="server" Text="Sign Out" OnClick="logOut" />
        <div class="form">
            <asp:Label runat="server" Text="Add New Club"></asp:Label>
            <div class="labelClass">
                <asp:Label runat="server" Text="Club Name"></asp:Label>
                <asp:TextBox ID="nameClub" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Club Location"></asp:Label>
                <asp:TextBox ID="locClub" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" runat="server" Text="Add" OnClick="addClub" />
        </div>
        <div class="form">
            <asp:Label runat="server" Text="Delete Club"></asp:Label>
            <div class="labelClass">
                <asp:Label runat="server" Text="Club Name"></asp:Label>
                <asp:TextBox ID="nameClubDelete" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" runat="server" Text="Delete" OnClick="deleteClub" />
        </div>

        <div class="form">
            <asp:Label runat="server" Text="Add New Stadium"></asp:Label>
            <div class="labelClass">
                <asp:Label runat="server" Text="Stadium Name"></asp:Label>
                <asp:TextBox ID="stadiumNameAdd" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Stadium Location"></asp:Label>
                <asp:TextBox ID="stadiumLocAdd" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label runat="server" Text="Stadium Capacity"></asp:Label>
                <asp:TextBox ID="stadiumCapAdd" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" runat="server" Text="Add" OnClick="addStadium" />
        </div>
        <div class="form">
            <asp:Label runat="server" Text="Delete Stadium"></asp:Label>
            <div class="labelClass">
                <asp:Label runat="server" Text="Stadium Name"></asp:Label>
                <asp:TextBox ID="stadiumNameDelete" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" runat="server" Text="Delete" OnClick="deleteStadium" />
        </div>
        <div class="form">
            <asp:Label runat="server" Text="Block Fan"></asp:Label>
            <div class="labelClass">
                <asp:Label runat="server" Text="Fan Name"></asp:Label>
                <asp:TextBox ID="blockFanNat" runat="server"></asp:TextBox>
            </div>
            <asp:Button CssClass="btn" runat="server" Text="Block" OnClick="blockFan" />
        </div>

    </form>
</body>
</html>
