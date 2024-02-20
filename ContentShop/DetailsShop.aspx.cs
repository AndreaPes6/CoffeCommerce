using CoffeCommerce;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI;
using CoffeCommerce.ContentShop;


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
                    imgProd.Src = dataReader["FotoProduct"].ToString();
                    tltName.InnerText = dataReader["Name"].ToString();
                    txtDescription.InnerText = dataReader["Description"].ToString();
                    txtPrice.InnerText = $"Price: € {dataReader["Price"].ToString()}";                   
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
            string productId = Request.QueryString["product"];
            if (!string.IsNullOrEmpty(productId))
            {
                if (int.TryParse(productId, out int ProdID))
                {
                    int quantity = int.Parse(dwdQuantity.SelectedValue);

                    CartItem item = new CartItem(ProdID, quantity);

                    List<CartItem> products;
                    if (Session["Carrello"] == null)
                    {
                        // Se la sessione non esiste, crea una nuova lista
                        products = new List<CartItem>();
                    }
                    else
                    {
                        // Se la sessione esiste, recupera la lista esistente
                        products = (List<CartItem>)Session["Carrello"];
                    }

                    // Aggiungi il nuovo elemento alla lista
                    products.Add(item);

                    // Aggiorna la sessione con la lista aggiornata
                    Session["Carrello"] = products;

                    ScriptManager.RegisterStartupScript(this, GetType(), "addToCartItem", "alert('Articolo aggiunto con successo al carrello!');", true);
                }
                else
                {
                    Response.Write("<p class='text-danger'>Invalid product ID format</p>");
                }
            }
            else
            {
                Response.Write("<p class='text-danger'>Product ID is null or empty</p>");
            }
        }







    }
}
