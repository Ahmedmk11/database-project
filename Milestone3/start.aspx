<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="start.aspx.cs" Inherits="Milestone3.start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <title></title>
</head>
<body>
    <form id="startBody" runat="server">
        <asp:Label runat="server" Text="WHO ARE YOU"></asp:Label>
        <asp:Button ID="saBtn" CssClass="btn" runat="server" Text="System Admin" OnClick="chooseSa" />
        <asp:Button ID="samBtn" CssClass="btn" runat="server" Text="Sports Association Manager" OnClick="chooseSam" />
        <asp:Button ID="smBtn" CssClass="btn" runat="server" Text="Stadium Manager" OnClick="chooseSm" />
        <asp:Button ID="crBtn" CssClass="btn" runat="server" Text="Club Representative" OnClick="chooseCr" />
        <asp:Button ID="fBtn" CssClass="btn" runat="server" Text="Fan" OnClick="chooseFan" />
    </form>
</body>
</html>
