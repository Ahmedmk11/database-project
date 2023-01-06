<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stadiumManagerActions.aspx.cs" Inherits="Milestone3.stadiumManagerActions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Balabizo</title>
    </head>
    <body>
        <form id="stadiumManagerActionsBody" runat="server">
            <asp:Button ID="logoutSMA" CssClass="btn logoutBtn" runat="server" Text="Sign Out" OnClick="logOut" />
            <div id="are" runat="server" class="form">
                <asp:Label CssClass="labels" runat="server" Text="Handle Host Request"></asp:Label>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Host Club"></asp:Label>
                    <asp:TextBox ID="host" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Guest Club"></asp:Label>
                    <asp:TextBox ID="guest" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Start Time"></asp:Label>
                    <asp:TextBox ID="starttime" runat="server"></asp:TextBox>
                </div>
                <div class="btnContainer">
                    <asp:Button CssClass="btn" runat="server" Text="Accept" OnClick="acceptReq" />
                    <asp:Button CssClass="btn" runat="server" Text="Reject" OnClick="rejectReq" />
                </div>
            </div>

            <div id="stadiumInfoContainer" class="view" runat="server">
                <asp:Button CssClass="btn" runat="server" Text="View Stadium" OnClick="stadiumInfo" />
            </div>
            <div id="requestsReceivedContainer" class="view" runat="server">
                <asp:Button CssClass="btn" runat="server" Text="View Requests" OnClick="reqReceived" />
            </div>
        </form>
    </body>
</html>
