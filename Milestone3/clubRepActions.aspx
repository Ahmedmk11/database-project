<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubRepActions.aspx.cs" Inherits="Milestone3.clubRepActions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Balabizo</title>
    </head>
    <body>
        <form id="clubRepActions" runat="server">
            <asp:Button ID="logoutCRA" CssClass="btn logoutBtn" runat="server" Text="Sign Out" OnClick="logOut" />
            <div id="craCLR" runat="server" class="form">
                <div class="labelClass">
                    <asp:Label runat="server" Text="Stadium Name"></asp:Label>
                    <asp:TextBox ID="snCRA" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Start Time"></asp:Label>
                    <asp:TextBox ID="stCRA" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="reqBtn" CssClass="btn" runat="server" Text="Send Request" OnClick="addReq" />
            </div>
            <div id="clubInfoContainer" class="view" runat="server">
                <asp:Button ID="Button1repAct" CssClass="btn" runat="server" Text="Club Information" OnClick="clubInfo" />
            </div>
            <div id="clubUpcomingContainer" class="view" runat="server">
                <asp:Button ID="Button2repAct" CssClass="btn" runat="server" Text="Upcoming Matches" OnClick="upcomMatchClub" />
            </div>
            <div id="AvailableStadiumsContainer" class="view" runat="server">
                <div id="cre" runat="server" class="labelClass">
                    <asp:Label CssClass="orSPAN" runat="server" Text="Date"></asp:Label>
                    <asp:TextBox ID="dtCRA" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="Button3repAct" CssClass="btn" runat="server" OnClick="availableStadium" Text="Available Stadiums" />
            </div>
        </form>
    </body>
</html>
