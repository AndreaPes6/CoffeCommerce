using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Stripe;

namespace CoffeCommerce.ContentShop
{
    public partial class Cart : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopolaCarrello();
            }
        }

        private void PopolaCarrello()
        {
            // Assicurati che il carrello sia stato inizializzato
            if (Session["Carrello"] != null)
            {
                // Ottieni il carrello dalla sessione
                List<CartItem> carrello = (List<CartItem>)Session["Carrello"];

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Prezzo", typeof(decimal));
                dt.Columns.Add("Quantità", typeof(int));
                dt.Columns.Add("UrlImage", typeof(string));

                decimal totale = 0;

                foreach (var articolo in carrello)
                {
                    string productId = articolo.ProductID.ToString();
                    decimal quantity = articolo.Quantity;

                    try
                    {
                        DBConn.conn.Open();

                        using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE ID = {productId}", DBConn.conn))
                        {
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.HasRows)
                            {
                                reader.Read();
                                dt.Rows.Add(reader["ID"], reader["Name"], reader["Price"], quantity, reader["FotoProduct"]);

                                decimal unitPrice = Convert.ToDecimal(reader["Price"]);
                                totale += quantity * unitPrice;
                            }
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

                totalAmountLabel.InnerText = totale.ToString("0.00");
                CartRepeater.DataSource = dt;
                CartRepeater.DataBind();
            }
            else
            {
                // Se il carrello è vuoto, mostra un messaggio appropriato
                emptyCartMessage.Visible = true;
                totalAmountLabel.InnerText = "0.00";
            }
        }

        // Evento per svuotare il carrello
        protected void EmptyCartButton_Click(object sender, EventArgs e)
        {
            Session.Remove("Carrello");
            PopolaCarrello();
        }

        // Evento per rimuovere un articolo dal carrello
        protected void RemoveFromCartButton_Command(object sender, CommandEventArgs e)
        {
            if (Session["Carrello"] != null)
            {
                // Ottieni l'indice dell'articolo da rimuovere
                int index = Convert.ToInt32(e.CommandArgument);

                List<CartItem> carrello = (List<CartItem>)Session["Carrello"];

                // Rimuovi l'articolo dal carrello
                carrello.RemoveAt(index);

                Session["Carrello"] = carrello;

                // Aggiorna il repeater e il totale del carrello
                PopolaCarrello();
            }
        }

        // Evento per procedere al pagamento con Stripe
        protected void ProceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            // Reindirizza l'utente alla pagina di checkout personalizzata
            Response.Redirect("Checkout.aspx");
        }
    }
}
