<%@ Page language="C#" CodeFile="ProductDetail.aspx.cs" Inherits="ProductDetail_aspx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Register TagPrefix="Categories" TagName="LeftNav" Src="Categories.ascx" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="BusinessLayer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" Runat="server">
    <title>Product Detail</title>
</head>
  <body>
    <table id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
      <tr>
        <td style="HEIGHT: 43px" colSpan="2"><TopNav:TopNav ID="topnav" Runat="server"></TopNav:TopNav></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Categories:LeftNav ID="leftnav" Runat="server" />
        </td>
        <td valign="top" align="left">
          <table width="100%">
            <%
              if (product != null)
              {
            %>
            <tr>
              <th align="left">
                Product</th>
              <th align="center">
                Price</th>
              <th align="center">
                Quantity Available</th>
              <th>
              </th>
            </tr>
            <tr>
              <td align="left">
                <% Response.Write(product.ProductName); %>
              </td>
              <td align="center">
                <% Response.Write(product.Price.ToString("C")); %>
              </td>
              <td align="center">
                <% Response.Write(product.Quantity); %>
              </td>
              <td>
                <form Runat="server">
                  <asp:Button ID="Button" OnClick="Button_Click" Runat="server" Text="Buy"></asp:Button>
                </form>
              </td>
            </tr>
            <%
              }
            %>
          </table>
        </td>
      </tr>
    </table>
  </body>
</html>
