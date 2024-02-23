<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateShop.master" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="CoffeCommerce.ContentShop.WelcomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col p-0">
                <div class="d-flex align-items-center justify-content-start" style="background-image: url('https://cdn.wallpapersafari.com/99/44/vV159M.jpg'); background-size: cover; height: 100vh;">
                    <div class="px-5">
                        <h1 class="fw-bold txt-lbladd text-start text-transition" id="welcomeTitle">Welcome to the World of Coffee</h1>
                        <p class="text-start fw-bold txt-lbladd text-transition">Unlock a unique coffee experience, ready to be part of your daily routine.</p>
                        <a class="btn btn-discovery rounded-pill text-transition" href="../ContentShop/HomeShop.aspx">DISCOVERY</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>