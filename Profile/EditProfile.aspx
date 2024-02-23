<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="CoffeCommerce.Profile.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 class="mb-4 mt-3">Edit Profile</h2>

        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblUserName" runat="server" Text="Username"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Placeholder="Inserisci la nuova password" TextMode="Password"></asp:TextBox>
                </div>
            </div>

              <div class="mb-3 d-flex justify-content-center">
      <asp:Label ID="LblErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
  </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="lblImageProfile" runat="server" Text="Profile Image Url"></asp:Label>
                    <asp:TextBox ID="txtImageProfile" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="btn  mr-2 rounded btn-add" />
                <asp:Button ID="btnDiscard" runat="server" Text="Discard Changes" OnClick="btnDiscard_Click" CssClass="btn  rounded btn-add" />
            </div>
        </div>
    </div>
</asp:Content>
