<%@ Page language="c#" CodeFile="OrderDetailView.aspx.cs" AutoEventWireup="false" Inherits="OrderDetailView" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="BusinessLayer" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Register TagPrefix="Options" TagName="AccountNav" Src="AccountNav.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" Runat="server">
    <title>Order Detail</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td style="height: 43px" colSpan="2"><TopNav:TopNav id="topnav" runat="server"></TopNav:TopNav></td>
      </tr>
      <tr>
        <td valign="top" align="left" width="20%"><Options:AccountNav id="leftnav" runat="server"></Options:AccountNav></td>
        <td valign="top" align="left">
          <%
          if (order != null)
          {
            %>
          <table width="80%">
            <tr>
              <td><b>Order ID</b></td>
              <td>
                <% Response.Write(order.OrderID); %>
              </td>
            </tr>
            <tr>
              <td><b>Customer ID</b></td>
              <td>
                <% Response.Write(order.CustomerID); %>
              </td>
            </tr>
            <tr>
              <td><b>Order Date</b></td>
              <td>
                <% Response.Write(order.OrderDate.ToShortDateString()); %>
              </td>
            </tr>
            <tr>
              <td><b>Ship Date</b></td>
              <td>
                <% Response.Write(order.ShipDate.ToShortDateString()); %>
              </td>
            </tr>
            <tr>
              <td><b>Ship Name</b></td>
              <td>
                <% Response.Write(order.ShipName); %>
              </td>
            </tr>
            <tr>
              <td><b>Ship Address</b></td>
              <td>
                <% Response.Write(order.ShipAddress); %>
              </td>
            </tr>
            <tr>
              <td><b>City</b></td>
              <td>
                <% Response.Write(order.ShipCity); %>
              </td>
            </tr>
            <tr>
              <td><b>Postal Code</b></td>
              <td>
                <% Response.Write(order.ShipPostalCode); %>
              </td>
            </tr>
            <tr>
              <td><b>Country</b></td>
              <td>
                <% Response.Write(order.ShipCountry); %>
              </td>
            </tr>
          </table>
          <%
          }
          %>
          <p><b><i>Order Details:</i></b></p>
          <hr>
          <%
          if ((orderDetails != null) && (orderDetails.Count > 0))
          {
            %>
          <table>
            <tr>
              <th>
                Product ID</th>
              <th>
                Unit Price</th>
              <th>
                Quantity Ordered</th>
              <th>
                Discount</th>
            </tr>
            <%
            for (int i = 0; i < orderDetails.Count; i++)
            {
              OrderDetail orderDetail = (OrderDetail)orderDetails[i];
              %>
            <tr>
              <td><% Response.Write(orderDetail.ProductID); %></td>
              <td><% Response.Write(orderDetail.UnitPrice); %></td>
              <td><% Response.Write(orderDetail.QuantityOrdered); %></td>
              <td><% Response.Write(orderDetail.Discount); %></td>
            </tr>
            <%
            }
            %>
          </table>
          <%
          }
          %>
        </td>
      </tr>
    </table>
  </body>
</html>
