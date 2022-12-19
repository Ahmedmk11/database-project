<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssocRegister.aspx.cs" Inherits="Milestone3.AssocRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form class="form" id="assocRegForm" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Please Register"></asp:Label>
       <p>
                   <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label>

       </p>
        <p>
            
            <asp:TextBox ID="name" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
                   <asp:Label ID="Label3" runat="server" Text="Username:"></asp:Label>

       </p>
        <p>
            <asp:TextBox ID="username" runat="server" Text=""></asp:TextBox>
        </p>
        <p>
                   <asp:Label ID="Label4" runat="server" Text="Password:"></asp:Label>

       </p>
        <p>
        <asp:TextBox ID="password" runat="server" Text=""></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="register" OnClick="register" />
    </form>
</body>
</html>
