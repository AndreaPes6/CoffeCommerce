<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="CoffeCommerce.Profile.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5 mb-5">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header" style="background-color: #0C141A;">
                        <h5 class="card-title text-light">Logout</h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <p class="card-text">Sei sicuro di voler effettuare il logout?</p>
                        </div>
                        <div class="mb-3 d-flex justify-content-center">
                            <asp:Button ID="Button1" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


