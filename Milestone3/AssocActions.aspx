<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssocActions.aspx.cs" Inherits="Milestone3.AssocActions" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
          <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Place Holder</title>
    </head>
    <body>
        <form id="assocActionBody" runat="server">
            <div class="form">
                <asp:Label ID="Label1" runat="server" Text="To add a new match"></asp:Label>
                <div class="labelClass">
                    <asp:Label ID="Label2" runat="server" Text="Host Club "></asp:Label>
                    <asp:TextBox ID="host" runat="server"></asp:TextBox>
                </div>
                    <asp:Label ID="Label3" runat="server" Text="Guest Club "></asp:Label>
                    <asp:TextBox ID="guest" runat="server"></asp:TextBox>
                <div class="labelClass">
                    <asp:Label ID="Label4" runat="server" Text="Starting time "></asp:Label>
                    <asp:TextBox ID="starttime" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label ID="Label5" runat="server" Text="Ending time "></asp:Label>
                    <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
                </div>
                <div id="btnContainer">
                    <asp:Button ID="Button4" CssClass="btn" runat="server" Text="Add Match" OnClick="addMatch" />
                    <asp:Button ID="Button5" CssClass="btn" runat="server" Text="Delete Match" OnClick="deleteMatch" />
                </div>
            </div>
            <div id="upcomingMatchesContainer" class="view" runat="server">
                <asp:Button ID="Button1" CssClass="btn" runat="server" Text="View Matches" OnClick="viewUpMatch" />
            </div>
            <div id="playedMatchesContainer" class="view" runat="server">
                <asp:Button ID="Button2" CssClass="btn" runat="server" Text="View Matches" OnClick="viewPlayedMatch" />
            </div>

            <div id="clubsNeverMatchedContainer" class="view" runat="server">
                <asp:Button ID="Button3" CssClass="btn" runat="server" Text="View Matches" OnClick="viewClubsNeverMatched" />
            </div>
        </form>
    </body>
</html>
