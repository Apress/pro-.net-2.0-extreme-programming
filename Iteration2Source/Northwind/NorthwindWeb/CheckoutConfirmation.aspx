<%@ Import Namespace="BusinessLayer" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="System.Collections" %>
<%@ Register TagPrefix="Categories" TagName="LeftNav" Src="Categories.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckoutConfirmation.aspx.cs" Inherits="CheckoutConfirmation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Checkout Confirmation</title>
</head>
<body>
  <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
    <tr>
      <td colspan="2" style="height: 43px">
        <TopNav:TopNav ID="topnav" runat="server" />
      </td>
    </tr>
    <tr>
      <td width="20%" valign="top" align="left">
        <Categories:LeftNav ID="leftnav" runat="server" />
      </td>
      <td valign="top" align="left">
        <table width="100%">
          <tr>
            <th align="left">
              Product
            </th>
            <th align="left">
              Price
            </th>
            <th align="center">
              Quantity
            </th>
            <th>
            </th>
          </tr>
          <%
              while (cartEnumerator.MoveNext())
              {
                  LineItem lineItem = (LineItem)cartEnumerator.Value;
                  Product product = lineItem.Item;
                  Response.Write("<tr><td>" + product.ProductName + "</td><td>"
                  + product.Price.ToString("C") + "</td><td align=\"center\">"
                  + lineItem.Quantity.ToString() + "</td></tr>");
                  total += product.Price * lineItem.Quantity;
              }
               %>
        </table>
      </td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td valign="top" align="right">
        Order Total:
        <%= total.ToString("C") %>
      </td>
    </tr>
    <tr>
      <td colspan="2" align="right">
        <form id="login" method="post" runat="server">
          <asp:Button ID="CompleteOrderButton" runat="server" Text="Complete Order" OnClick="CompleteOrderButton_Click" />
          <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClick="CancelButton_Click" />
        </form>
      </td>
    </tr>
  </table>
</body>
</html>
