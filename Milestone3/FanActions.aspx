<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanActions.aspx.cs" Inherits="Milestone3.fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Balabizo</title>
    </head>
    <body>
        <form id="fanActionContainer" runat="server">
            <asp:Button ID="logoutFA" CssClass="btn logoutBtn" runat="server" Text="Sign Out" OnClick="logOut" />
            <div id="faCLR" runat="server" class="form">
                <div class="labelClass">
                    <asp:Label runat="server" Text="Host Club "></asp:Label>
                    <asp:TextBox ID="hostFan" runat="server"></asp:TextBox>
                </div>
                <div class="labelClass">
                    <asp:Label runat="server" Text="Guest Club "></asp:Label>
                    <asp:TextBox ID="guestFan" runat="server"></asp:TextBox>
                </div>
                <div id="purchaseConfirmation" runat="server"></div>
                <div id="btnContainer">
                    <asp:Button CssClass="btn" runat="server" Text="purchase Ticket" OnClick="purchaseTicket" />
                </div>
            </div>
            <div id="AvailableTicketsContainer" class="view" runat="server">
                <div class="labelClass">
                    <asp:Label CssClass="orSPAN" runat="server" Text="Date"></asp:Label>
                    <asp:TextBox ID="dtF" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="Button1F" CssClass="btn" runat="server" Text="View Available Tickets" OnClick="availableTicket" />
            </div>
        </form>
    </body>
</html>