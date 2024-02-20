<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="CoffeCommerce.BackOffice.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg my-5">
        <h2 class="fw-bold fw-light txt-lbladd">Add Products</h2>
        <div class="d-flex">

            <div>
                <img src="../Assets/Images/AddProd.jpg" alt="imagine caffè" class="img-coffe img-fluid rounded shadow" />
            </div>

            <!-- form add product-->
            <div>
                <div class="row g-3">
                    <div class="col-md-6">
                        <label for="inputName" class="form-label txt-lbladd">Name Product</label>
                        <input type="text" class="form-control" id="inputName" runat="server">
                    </div>
                    <div class="col-md-6">
                        <label for="inputPrice" class="form-label txt-lbladd">Price</label>
                        <input type="text" class="form-control" id="inputPrice" runat="server">
                    </div>
                    <div class="input-group">
                        <span class="input-group-text txt-lbladd">Description</span>
                        <textarea class="form-control" aria-label="With textarea" id="txtDescription" runat="server"></textarea>
                    </div>

                    <div class="col-md-4">
                        <label for="dpwCategories" class="form-label txt-lbladd">Select Categories</label>
                        <asp:DropDownList ID="dpwCategories" runat="server" AutoPostBack="true" CssClass="form-select dp-dw-cat">
                            <asp:ListItem Value="1">Capsule Dolce Gusto</asp:ListItem>
                            <asp:ListItem Value="2">Capsule Nespresso</asp:ListItem>
                            <asp:ListItem Value="3">Capsule Lavazza</asp:ListItem>
                            <asp:ListItem Value="4">Cialde ESE</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="basic-url" class="form-label txt-lbladd">Image URL</label>
                        <div class="input-group">
                            <span class="input-group-text txt-lbladd" id="basic-addon3">https://example.com/</span>
                            <input type="text" class="form-control" id="imgUrl" aria-describedby="basic-addon3 basic-addon4" runat="server">
                        </div>
                    </div>
                    <div class="col-12">
                        <asp:Button ID="buttonAdd" runat="server" Text="Add Product" class="btn btn-add rounded-pill" OnClick="buttonAdd_Click" />
                    </div>
                </div>
            </div>

        </div>



    </div>


</asp:Content>
