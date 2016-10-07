<%@ Page Language="C#" CodeFile="Login.aspx.cs" Inherits="Login_aspx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="login" method="post" runat="server">
    <div>
        <asp:Label ID="titleLabel" style="z-index: 104; left: 427px; position: absolute; top: 56px" Runat="Server">Northwind Login</asp:Label>
        <asp:Label ID="usernameLabel" style="z-index: 101; left: 362px; position: absolute; top: 126px" Runat="Server">Username:</asp:Label>
        <asp:Label ID="passwordLabel" style="z-index: 102; left: 364px; position: absolute; top: 184px" Runat="Server">Password:</asp:Label>
        <asp:TextBox ID="usernameTextBox" style="z-index: 103; left: 452px; position: absolute; top: 121px" TabIndex="1" Runat="Server" Width="145px" Height="22px"></asp:TextBox>
        <input id="passwordTextBox" style="z-index: 106; left: 451px; width: 145px; position: absolute; top: 181px; height: 22px" tabindex="2" type="password" name="passwordTextBox" />
        <asp:Button ID="submitButton" OnClick="SubmitButton_Click" style="z-index: 105; left: 576px; position: absolute; top: 231px" TabIndex="3" Runat="Server" Text="Login" />
        <asp:Label ID="successLabel" style="z-index: 107; left: 332px; position: absolute; top: 311px" Runat="Server" Width="389px" Visible="False" />
    </div>
    </form>
</body>
</html>
