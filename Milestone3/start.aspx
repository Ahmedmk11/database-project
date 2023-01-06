<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="Milestone3.start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <link rel="stylesheet" type="text/css" href="style.css"/>
        <title>Balabizo</title>
    </head>
    <body>
        <form id="startBody" runat="server">
            <asp:Label CssClass="labels" runat="server" Text="Choose a Category"></asp:Label>
            <div id="startBtns">
                <asp:Button ID="samBtn" CssClass="btn" runat="server" Text="Sports Association Manager" OnClick="chooseSam" />
                <asp:Button ID="smBtn" CssClass="btn" runat="server" Text="Stadium Manager" OnClick="chooseSm" />
                <asp:Button ID="crBtn" CssClass="btn" runat="server" Text="Club Representative" OnClick="chooseCr" />
                <asp:Button ID="fBtn" CssClass="btn" runat="server" Text="Fan" OnClick="chooseFan" />
            </div>
        </form>
    </body>
</html>
