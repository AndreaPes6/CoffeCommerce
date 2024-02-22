<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="CoffeCommerce.Profile.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mb-5">
        <h1 class="mt-3 ms-3">Profilo</h1>
        <div class="row">
            <div class="col-md-6">
                <div class="text-center">
                    <asp:Image ID="imgProfile" runat="server" CssClass="img-fluid rounded-circle" />
                </div>
            </div>
            <div class="col-md-6">
                <div class="mt-3">
                    <h3>Informazioni utente</h3>
                    <div class="mb-3">
                        <strong>Nome Utente:</strong> <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>               
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <a class="btn btn-primary rounded-pill" href="../Profile/EditProfile.aspx">Modifica profilo</a>
                <a class="btn btn-danger rounded-pill" href="../Profile/DeleteProfile.aspx">Elimina profilo</a>
            </div>
        </div>
    </div>
</asp:Content>