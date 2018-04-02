<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="DemoProject.AddCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
     <section id="insertForm">
        <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
            <asp:FormView runat="server" ID="addCar"
                ItemType="DemoProject.CarsTable" 
                InsertMethod="addCar_InsertItem" DefaultMode="Insert"
                RenderOuterTable="false" OnItemInserted="addCar_ItemInserted">
                <InsertItemTemplate>
                    <fieldset>
                        <ol>
                            <asp:DynamicEntity runat="server" Mode="Insert" />
                        </ol>
                        <asp:Button runat="server" Text="Insert" CommandName="Insert" />
                        <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" />
                    </fieldse>
                </InsertItemTemplate>
            </asp:FormView>     
     </section>    
</asp:Content>
