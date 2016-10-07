<%@ Page language="c#" CodeFile="CustomerOrderHistory.aspx.cs" AutoEventWireup="false" Inherits="CustomerOrderHistory" %>
<%@ Register TagPrefix="Options" TagName="AccountNav" Src="AccountNav.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Import Namespace="BusinessLayer" %>
<%@ Import Namespace="System.Collections" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>Customer Order History</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="height: 43px"><TopNav:TopNav id="topnav" runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Options:AccountNav id="leftnav" runat="server" />
        </td>
        <td vAlign="top" align="left">
          <table width="80%">
            <tr>
              <th align="left">
                Order ID - Date</th>
            </tr>
            <%
              if ( orders != null )
              {
                for ( int i = 0; i < orders.Count; i++ )
                {
                  Order order = (Order)orders[i];
                      
              %>
            <tr>
              <td>
                <a href="OrderDetailView.aspx?orderID=<% Response.Write(order.OrderID.ToString()); %>">
                  <% Response.Write(order.OrderID.ToString()); %>
                  &nbsp; - &nbsp;
                  <% Response.Write(order.OrderDate.ToShortDateString()); %>
                </a>
              </td>
            </tr>
            <%
                }
              }
            %>
          </table>
        </td>
      </tr>
    </table>
  </body>
</html>
