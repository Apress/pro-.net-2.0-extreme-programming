<%@ Import Namespace="BusinessLayer" %>
<%@ Control Language="C#" CodeFile="TopNav.ascx.cs" Inherits="TopNav_ascx" %>

<table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
  <tr valign="top">
    <td>Home</td>
    <td>
      <form id="search" action="BrowseCatelog.aspx" method="post">
        <input type="text" name="searchString" /> <input type="submit" value="Search" />
      </form>
    </td>
    <td align="center">
      <a href="DisplayShoppingCart.aspx"><img alt="Display Shopping Cart" src="images/cart.jpg" border="0">
      </a>
      <br>
      <% 
        Response.Write(cart.Quantity.ToString() + " Item(s)");
      %>
    </td>
  </tr>
</table>
