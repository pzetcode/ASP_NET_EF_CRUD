<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dbcontent.aspx.cs" Inherits="DemoProject.Dbcontent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
        <style type="text/css">
        a{color: beige;          
        }
        a:active{
          color: springgreen;
          text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <asp:Literal ID="dbRowsControl" runat="server"></asp:Literal>    
</asp:Content>
