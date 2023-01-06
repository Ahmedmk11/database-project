<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssocActions.aspx.cs" Inherits="Milestone3.AssocActions" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
          <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Balabizo</title>
    </head>
    <body>
        <form id="assocActionBody" runat="server">
            <asp:Button ID="logoutAA" CssClass="btn logoutBtn" runat="server" Text="Sign Out" OnClick="logOut" />
            <div id="aae" runat="server" class="form">
                <asp:Label CssClass="labels" runat="server" Text="Add / Delete Match"></asp:Label>
                <div class="labelClass">
                    <asp:Label ID="Label2" runat="server" Text="Host Club"></asp:Label>
                    <asp:TextBox ID="host" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label ID="Label3" runat="server" Text="Guest Club"></asp:Label>
                    <asp:TextBox ID="guest" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label ID="Label4" runat="server" Text="Starting Time"></asp:Label>
                    <asp:TextBox ID="starttime" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label ID="Label5" runat="server" Text="Ending Time"></asp:Label>
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                </div>
                <div class="btnContainer">
                    <asp:Button ID="Button4" CssClass="btn" runat="server" Text="Add Match" OnClick="addMatch" />
                    <asp:Button ID="Button5" CssClass="btn" runat="server" Text="Delete Match" OnClick="deleteMatch" />
                </div>
            </div>
            <div id="upcomingMatchesContainer" class="view" runat="server">
                <asp:Button ID="Button1" CssClass="btn" runat="server" Text="View Upcoming Matches" OnClick="viewUpMatch" />
            </div>
            <div id="playedMatchesContainer" class="view" runat="server">
                <asp:Button ID="Button2" CssClass="btn" runat="server" Text="View Played Matches" OnClick="viewPlayedMatch" />
            </div>

            <div id="clubsNeverMatchedContainer" class="view" runat="server">
                <asp:Button ID="Button3" CssClass="btn" runat="server" Text="View Clubs (Never Matched)" OnClick="viewClubsNeverMatched" />
            </div>
        </form>
    </body>
</html>
