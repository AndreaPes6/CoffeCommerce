using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.ContentShop
{
    public partial class HomeShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    ProductRepeater.DataSource = dataReader;
                    ProductRepeater.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (DBConn.conn.State == System.Data.ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }
        }

        //mostra in base alla categoria selezionata dalla dropdownlist
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        DBConn.conn.Open();
        int IDSelected = int.Parse(DropDownList1.SelectedValue);
        string query = (IDSelected == 0) ? "SELECT * FROM Products" : $"SELECT * FROM Products WHERE IDCategory = {IDSelected}";

        SqlCommand cmd = new SqlCommand(query, DBConn.conn);
        SqlDataReader dataReader = cmd.ExecuteReader();

        if (dataReader.HasRows)
        {
            ProductRepeater.DataSource = dataReader;
            ProductRepeater.DataBind();
        }

        tltCategory.InnerText = (IDSelected == 0) ? "All Categories" : DropDownList1.SelectedItem.Text;
    }
    catch (Exception ex)
    {
        Response.Write(ex.ToString());
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
            LinkButton btnAddToCart = (LinkButton)sender;
            string productId = btnAddToCart.CommandArgument;
            if (!string.IsNullOrEmpty(productId))
            {
                if (int.TryParse(productId, out int ProdID))
                {
                    int quantity = 1;

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