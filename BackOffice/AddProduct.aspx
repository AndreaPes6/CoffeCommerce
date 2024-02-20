<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/TemplateBackBO.master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="CoffeCommerce.BackOffice.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-lg my-5">
        <h2>Add Products</h2>
        <div class="row row-col-2">

            <div class="col">
                <img src="../Assets/Images/AddProd.jpg" alt="imagine caffè" class="img-coffe" />
            </div>


            <!-- form add product-->
            <div class="col">
                <div class="row g-3">
                    <div class="col-md-6">
                        <label for="inputName" class="form-label">Name Product</label>
                        <input type="text" class="form-control" id="inputName" runat="server">
                    </div>
                    <div class="col-md-6">
                        <label for="inputPrice" class="form-label">Price</label>
                        <input type="text" class="form-control" id="inputPrice" runat="server">
                    </div>
                    <div class="input-group">
                        <span class="input-group-text">Description</span>
                        <textarea class="form-control" aria-label="With textarea" id="txtDescription" runat="server"></textarea>
                    </div>

                    <div class="col-md-4 d-flex ">
                        <span class="input-group-text">Select Categories</span>
                        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select dp-dw-cat">
                            <asp:ListItem Value="1">Capsule Dolce Gusto</asp:ListItem>
                            <asp:ListItem Value="2">Capsule Nespresso</asp:ListItem>
                            <asp:ListItem Value="3">Capsule Lavazza</asp:ListItem>
                            <asp:ListItem Value="4">Cialde ESE</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="basic-url" class="form-label">Image URL</label>
                        <div class="input-group">
                            <span class="input-group-text" id="basic-addon3">https://example.com/</span>
                            <input type="text" class="form-control" id="imgUrl" aria-describedby="basic-addon3 basic-addon4" runat="server">
                        </div>
                        <div class="form-text" id="basic-addon4">Example help text goes outside the input group.</div>
                    </div>
                    <div class="col-12">
                        <button type="submit" class="btn btn-primary">Add Product</button>
                    </div>
                </div>
            </div>

        </div>



    </div>


</asp:Content>
