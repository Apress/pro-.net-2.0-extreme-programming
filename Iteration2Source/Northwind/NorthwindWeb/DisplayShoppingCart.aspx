<%@ Import Namespace="BusinessLayer" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register TagPrefix="Categories" TagName="LeftNav" Src="Categories.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Page language="C#" CodeFile="DisplayShoppingCart.aspx.cs" Inherits="DisplayShoppingCart_aspx" AutoEventWireup="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Display Shopping Cart</title>
</head>
  <body>
    <table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="HEIGHT: 43px"><TopNav:TopNav id="topnav" Runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Categories:LeftNav ID="leftnav" Runat="server" />
        </td>
        <td valign="top" align="left">
          <table width="100%">
            <tr>
              <th align="left">
                Product</th>
              <th align="left">
                Price</th>
              <th align="left">
                Available</th>
              <th align="left">
                Quantity</th>
              <th>
              </th>
            </tr>
            <%                             
              while (cartEnumerator.MoveNext())
              {
              %>
            <form action="DisplayShoppingCart.aspx" id="UpdateContents" method="post">
              <tr>
                <%
                  lineItem = (LineItem)cartEnumerator.Value;
                  Product product = lineItem.Item;
                  Response.Write("<td>" + product.ProductName + "</td><td>"
                    + product.Price.ToString("C") + "</td><td>"
                    + product.Quantity.ToString() + "</td>");
                  Response.Write("<input type=\"hidden\" name=\"availableQty\" value=\"" + product.Quantity + "\">");
                  Response.Write("<input type=\"hidden\" name=\"productID\" value=\"" + product.ProductID + "\">");
                %>
                <td>
                  <input type="text" size="2" name="quantity" value="<%=lineItem.Quantity%>" />
                  <%
                    Response.Write(lineItem.Message);
                    lineItem.Message = "";
                  %>
                </td>
                <td>
                  <input type="submit" value="Update Quantity" />
                </td>
              </tr>
            </form>
            <%
              }
              %>
          </table>
        </td>
      </tr>
      <tr>
        <td colspan="5" align="center">
          <form action="CheckoutConfirmation.aspx" id="CheckoutConfirmation" method="post">
            <input type="submit" value="Checkout" />
          </form>
        </td>
      </tr>
    </table>
  </body>
</html>
