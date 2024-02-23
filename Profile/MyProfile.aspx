<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="CoffeCommerce.Profile.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="mt-3 mb-4 ms-3">Profile</h1>
    <div class=" mb-5 d-flex">

        <div class="me-4">
            <a href="../Profile/EditProfile.aspx">
                <asp:Image ID="imgProfile" runat="server" CssClass="img-fluid rounded-circle border border-black" Width="150" />
            </a>
        </div>



        <div class="d-flex flex-column justify-content-between ms-2">
            <div class="ms-1">
                <div class="mt-3">
                    <h3>User Info</h3>
                    <div class="mb-2">
                        <strong>Username:</strong>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="mb-2">
                        <strong>Email:</strong>
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <strong>Password:</strong>
                        <asp:Label ID="Label1" runat="server" Text="***********"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="mt-5">
                <a class="btn btn-secondary rounded" href="../Profile/EditProfile.aspx">Edit Profile</a>
                <a class="btn btn-danger rounded" href="../Profile/DeleteProfile.aspx">Delete Profile</a>
            </div>
        </div>
    </div>
</asp:Content>
