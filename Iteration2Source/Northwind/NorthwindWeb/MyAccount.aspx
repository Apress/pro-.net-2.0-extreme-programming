<%@ Page language="c#" CodeFile="MyAccount.aspx.cs" AutoEventWireup="false" Inherits="MyAccount" %>
<%@ Register TagPrefix="Options" TagName="AccountNav" Src="AccountNav.ascx" %>
<%@ Register TagPrefix="TopNav" TagName="TopNav" Src="TopNav.ascx" %>
<%@ Import Namespace="BusinessLayer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>MyAccount</title>
  </head>
  <body>
    <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
      <tr>
        <td colspan="2" style="HEIGHT: 43px"><TopNav:TopNav id="topnav" runat="server" /></td>
      </tr>
      <tr>
        <td width="20%" valign="top" align="left">
          <Options:AccountNav id="leftnav" runat="server" />
        </td>
        <td valign="top" align="left">
          <table width="80%">
            <%
            if (customer != null)
            {
            %>
            <tr>
              <td><b>Customer Name</b></td>
              <td><% Response.Write(customer.UserName); %></td>
            </tr>
            <tr>
              <td><b>Company Name</b></td>
              <td><% Response.Write(customer.CompanyName); %></td>
            </tr>
            <tr>
              <td><b>Address</b></td>
              <td><% Response.Write(customer.Address); %></td>
            </tr>
            <tr>
              <td><b>City</b></td>
              <td><% Response.Write(customer.City); %></td>
            </tr>
            <tr>
              <td><b>Postal Code</b></td>
              <td><% Response.Write(customer.PostalCode); %></td>
            </tr>
            <tr>
              <td><b>Country</b></td>
              <td><% Response.Write(customer.Country); %></td>
            </tr>
            <tr>
              <td><b>Phone Number</b></td>
              <td><% Response.Write(customer.PhoneNumber); %></td>
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
