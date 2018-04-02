<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExportDbContent.aspx.cs" Inherits="DemoProject.ExportDbContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:Button ID="SerializeButton" runat="server" Text="Download XML db data to client" OnClick="SerializeButton_Click" />
    <br />
    <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
</asp:Content>
