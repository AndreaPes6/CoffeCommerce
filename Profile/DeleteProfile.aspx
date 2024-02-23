<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="DeleteProfile.aspx.cs" Inherits="CoffeCommerce.Profile.DeleteProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mt-5 mb-5">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-header" style="background-color: #0C141A;">
                        <h5 class="card-title text-light"></h5>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <p class="card-text">Are you sure you want to delete your profile?</p>
                        </div>
                        <div class="mb-3 d-flex justify-content-center">
                           <a href="../Profile/MyProfile.aspx" class="btn btn-secondary rounded-pill me-3">Torna alla Home</a>
                           <asp:Button ID="btnDelete" runat="server" Text="Elimina Profilo" OnClick="btnDelete_Click" CssClass="btn btn-danger rounded-pill" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
