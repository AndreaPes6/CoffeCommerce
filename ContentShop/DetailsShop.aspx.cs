using CoffeCommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;

namespace CoffeCommerce.ContentShop
{
    public partial class DetailsShop : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["product"] != null)
                {
                    string productId = Request.QueryString["product"];
                    LoadProductDetails(productId);
                }
            }
        }

        private void LoadProductDetails(string productId)
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ID = @ProductId", DBConn.conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    string productPhoto = dataReader["FotoProduct"].ToString();
                    string productName = dataReader["Name"].ToString();
                    string productDescription = dataReader["Description"].ToString();
                    string productPrice = dataReader["Price"].ToString();

                    string productHtml = $@"
                        <div class='container mt-5'>
                            <div class='row'>
                                <div class='col-md-6'>
                                    <img src='{productPhoto}' class='img-fluid rounded product-image w-75 border- border-solid-black' alt='{productName}' onclick='zoomImage(this)' style='cursor: pointer;'>
                                </div>
                                <div class='col-md-6'>
                                    <h2 class='fw-bold text-uppercase mb-4'>{productName}</h2>
                                    <p class='fs-5 mb-4'>{productDescription}</p>
                                    <p class='fw-bold fs-4 mb-4'>Price: €{productPrice}</p>
                                    <div class='form-group mb-4'>
                                        <label for='quantity' class='fw-bold'>Quantity:</label>
                                        <select class='form-select form-select-lg' id='quantity'>
                                            <option selected>1</option>
                                            <option>2</option>
                                            <option>3</option>
                                            <option>4</option>
                                            <option>5</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                        </div>";

                    productDetails.InnerHtml = productHtml;
                }
                else
                {
                    productDetails.InnerHtml = "<p class='text-danger'>Product not found</p>";
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<p class='text-danger'>Error: {ex.Message}</p>");
            }
            finally
            {
                if (DBConn.conn.State == System.Data.ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] != null)
            {
                string productId = Request.QueryString["product"];
                string productName = "";
                decimal productPrice = 0;
                Product product = new Product(productId, productName, productPrice);
                AddToCart(product);
                Response.Redirect("Cart.aspx");
            }
        }

        private void AddToCart(Product product)
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            cart.AddProduct(product);
        }

        public class Product
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Product(string id, string name, decimal price)
            {
                Id = id;
                Name = name;
                Price = price;
            }
        }

        public class Cart
        {
            public List<Product> Items { get; set; }
            public Cart()
            {
                Items = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                Items.Add(product);
            }
        }

    }
}
