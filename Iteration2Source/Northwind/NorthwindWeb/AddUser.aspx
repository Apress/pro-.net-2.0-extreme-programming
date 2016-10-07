<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Register TagPrefix="Options" TagName="AdminNav" Src="AdminNav.ascx" %>
<%@ Page language="c#" CodeFile="AddUser.aspx.cs" AutoEventWireup="false" Inherits="AddUser" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" Runat="server">
    <title>Add User</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="height: 43px"><TopNav:TopNav id="topnav" runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" vAlign="top" align="left">
          <Options:AdminNav id="leftnav" runat="server" />
        </td>
        <td vAlign="top" align="left">
          <table width="80%">
            <tr>
              <td>
                <form id="addUser" method="post" runat="server">
                  <table>
                    <tr>
                      <th align="left">
                            User Name</th>
                      <th align="left">
                            Password</th>
                      <th align="left">
                            Role</th>
                    </tr>
                    <tr>
                      <td>
                          <asp:TextBox id="userNameTextBox" runat="server"></asp:TextBox>
                      </td>
                      <td>
                          <input type="password" name="passwordTextBox" id="passwordTextBox">
                      </td>
                      <td>
                        <asp:DropDownList id="roleDropDownList" runat="server">
                        <asp:ListItem Value="customer">customer</asp:ListItem>
                        <asp:ListItem Value="employee">employee</asp:ListItem>
                        </asp:DropDownList>
                      </td>
                    </tr>
                    <tr>
                      <td></td>
                      <td></td>
                      <td><asp:Button id="submitButton" runat="server" Text="Submit"></asp:Button></td>
                    </tr>
                  </table>
                <asp:Label id="successLabel" runat="server" Visible="False"></asp:Label>
              </form>
            </td>
          </tr>
        </table>
      </td>
    </tr>
  </table>
</body>
</html>
