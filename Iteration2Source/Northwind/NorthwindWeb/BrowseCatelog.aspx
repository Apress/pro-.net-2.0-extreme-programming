<%@ Page Language="C#" CodeFile="BrowseCatelog.aspx.cs" Inherits="BrowseCatelog_aspx" %>
<%@ Register TagPrefix="Categories" TagName="LeftNav" Src="Categories.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Import Namespace="System.Collections" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="BusinessLayer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head Runat="server">
    <title>Browse Catalog</title>
</head>
<body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
        <tr>
            <td colspan="2" style="height:43px">
                <TopNav:TopNav ID="topnav" runat="server" />
            </td>
        </tr>
        <tr>
            <td width="20%" valign="top" align="left">
                <Categories:LeftNav ID="leftnav" runat="server" />
            </td>
            <td>
                <table width="80%">
                    <%
                        if (products != null)
                        {
                            for (int i = 0; i < products.Count; i++)
                            {
                                product = (Product)products[i];
                    %>
                    <tr>
                        <td>
                            <a href="ProductDetail.aspx?productID=<% Response.Write(product.ProductID.ToString()); %>">
                                <% Response.Write(product.ProductName); %>
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
