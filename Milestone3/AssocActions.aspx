<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssocActions.aspx.cs" Inherits="Milestone3.AssocActions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .3a {
            display: flex;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="3a">
        
        <asp:Label ID="Label1" runat="server" Text="To add a new match"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Host Club "></asp:Label>
            <asp:TextBox ID="host" runat="server"></asp:TextBox>
        </p>
            <asp:Label ID="Label3" runat="server" Text="Guest Club "></asp:Label>
            <asp:TextBox ID="guest" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Starting time "></asp:Label>
            <asp:TextBox ID="starttime" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Ending time "></asp:Label>
            <asp:TextBox ID="endtime" runat="server"></asp:TextBox>
       </p>
        <asp:Button ID="Button1" runat="server" Text="Add Match" OnClick="addMatch" />
    </div>
    </form>
</body>
</html>
