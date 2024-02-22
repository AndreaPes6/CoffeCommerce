<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="CoffeCommerce.Profile.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="mt-3 ms-3">Profilo</h1>
        <div class="row">
            <div class="col-md-6">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-fluid rounded" />
            </div>
            <div class="col-md-6">
                <h3 class="mt-3">Informazioni utente</h3>
                <p><strong>Nome Utente:</strong> <asp:Label ID="lblName" runat="server" Text=""></asp:Label></p>
                <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></p>
                <!-- Aggiungi altri campi del profilo se necessario -->
            </div>
        </div>
    </div>
</asp:Content>