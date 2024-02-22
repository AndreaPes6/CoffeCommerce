<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="CoffeCommerce.Profile.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="mb-4">Modifica Profilo</h2>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblUserName" runat="server" Text="Nome Utente"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="Inserisci il nome utente"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Inserisci l'email"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Inserisci la password"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblImageProfile" runat="server" Text="URL Immagine Profilo"></asp:Label>
                    <asp:TextBox ID="txtImageProfile" runat="server" CssClass="form-control" placeholder="Inserisci l'URL dell'immagine profilo"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <asp:Button ID="btnConfirm" runat="server" Text="Conferma Modifiche" OnClick="btnConfirm_Click" CssClass="btn btn-success mr-2" />
                <asp:Button ID="btnDiscard" runat="server" Text="Annulla Modifiche" OnClick="btnDiscard_Click" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
