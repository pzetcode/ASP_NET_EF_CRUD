<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="DemoProject.UploadFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:FileUpload ID="FileUploadControl" runat="server" Width="500px" />
    <br />
    <asp:Button ID="UploadButton" runat="server" Text="Upload file" OnClick="UploadButton_Click" />
    <br />
    <asp:Label ID="StatusLabel" runat="server" Text=""></asp:Label>
</asp:Content>
