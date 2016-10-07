<%@ Page language="c#" Debug="true" CodeFile="OrderConfirmation.aspx.cs" AutoEventWireup="false" Inherits="OrderConfirmation" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Register TagPrefix="Categories" TagName="LeftNav" Src="Categories.ascx" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="BusinessLayer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" Runat="server">
    <title>Order Confirmation</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="height: 43px"><TopNav:TopNav id="topnav" runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Categories:LeftNav id="leftnav" runat="server" />
        </td>
        <td valign="top" align="left">
          Thank you for your order. You should be receiving an email confirmation 
          shortly. Your order confirmation number is: <%=Request["orderID"]%>
        </td>
      </tr>
    </table>
  </body>
</html>
