<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="DetailsBO.aspx.cs" Inherits="CoffeCommerce.BackOffice.DetailsBO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="fw-bold fw-light txt-lbladd my-5">Product Details Back Office</h1>
    <div class="container m-0 p-0">


        <div class="row justify-content-start mt-3 ">
            <div>
                <div class='container m-0 p-0' id="productDetails" runat="server">
                    <div class='row'>
                        <div class='col-md-4 me-3'>
                            <img id="urlImg" runat="server" class='img-fluid rounded product-image w-100 border border-solid-black shadow' alt='' onclick='zoomImage(this)' style='cursor: pointer;'>
                        </div>
                        <div class='col-md-7'>
                            <h4 class=' fw-light txt-lbladd text-uppercase mb-4' id="txtsName" runat="server"></h4>
                            <p class='fs-6 mb-4' id="txtDescription" runat="server"></p>
                            <p class='fs-6 mb-3' id="txtPrice" runat="server"></p>
                            <div class="d-flex mt-3">
                                <asp:Button ID="btnEdit" runat="server" Text="Edit Product" CssClass="btn btn-secondary me-3 rounded-pill" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete Product" CssClass="btn btn-danger rounded-pill" OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            



        </div>

        



    </div>
</asp:Content>
