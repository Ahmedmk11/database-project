<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="clubRepActions.aspx.cs" Inherits="Milestone3.clubRepActions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="clubRepActions" runat="server">
        <asp:Button ID="logoutCRA" CssClass="btn" runat="server" Text="Sign Out" OnClick="logOut" />
        <div id="clubInfoContainer" class="view" runat="server">
            <asp:Button ID="Button1repAct" CssClass="btn" runat="server" Text="View Matches" OnClick="clubInfo" />
        </div>
        <div id="clubUpcomingContainer" class="view" runat="server">
            <asp:Button ID="Button2repAct" CssClass="btn" runat="server" Text="View Matches" OnClick="upcomMatchClub" />
        </div>
        <div id="AvailableStadiumsContainer" class="view" runat="server">
            <div class="labelClass">
                <asp:Label runat="server" Text="Date"></asp:Label>
                <input id="dtCRA" />
            </div>
            <button id="Button3repAct" class="btn" onclick="availableStadium">View Matches</button>
        </div>
    </form>
</body>
</html>
