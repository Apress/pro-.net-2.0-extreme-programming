<%@ Page language="c#" CodeFile="Admin.aspx.cs" AutoEventWireup="false" Inherits="Admin" %>
<%@ Register TagPrefix="Options" TagName="AdminNav" Src="AdminNav.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" Runat="server">
    <title>Administration Features</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="height: 43px"><TopNav:TopNav id="topnav" runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Options:AdminNav id="leftnav" runat="server" />
        </td>
        <td valign="top" align="left">
          <table width="80%">
          </table>
        </td>
      </tr>
    </table>
  </body>
</html>
