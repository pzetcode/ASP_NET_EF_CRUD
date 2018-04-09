<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchingPanel.aspx.cs" Inherits="DemoProject.SearchingPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        a{color: beige;          
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ShowModelStateErrors="true" runat="server" />    
    <asp:Label ID="LabelNoRecords" runat="server" Text=""></asp:Label>
    <asp:GridView runat="server" ID="carsGrid" ItemType="DemoProject.CarsTable" DataKeyNames="Id"
         SelectMethod="carsGrid_GetData" AutoGenerateColumns="true">         
    </asp:GridView>
    <br />
    <asp:Label ID="LabelFactory" runat="server" Text="Enter factory:"></asp:Label>
    <asp:TextBox ID="TextBoxFactory" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click"/>
    <br />

    
</asp:Content>
