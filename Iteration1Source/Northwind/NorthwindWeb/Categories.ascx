<%@ Import Namespace="BusinessLayer" %>
<%@ Import Namespace="DataLayer" %>
<%@ Import Namespace="System.Collections" %>
<%@ Control Language="C#" CodeFile="Categories.ascx.cs" Inherits="Categories_ascx" AutoEventWireup="true" %>

<table width="100%">
  <%
      if (categories != null)
      {
          for (int i = 0; i < categories.Count; i++)
          {
              Category category = (Category)categories[i];
   %>
   <tr>
    <td>
        <a href="BrowseCatelog.aspx?categoryID=<% Response.Write(category.CategoryID.ToString()); %>">
            <% Response.Write(category.CategoryName); %>
        </a>
    </td>
   </tr>
   <%
      }
  }
    %>
</table>