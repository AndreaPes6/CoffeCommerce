
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
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
                    string ProductId = articolo.ProductID.ToString();
                    decimal Quantity = articolo.Quantity;

                    try
                    {

                        DBConn.conn.Open();
                        SqlCommand cmd = new SqlCommand($"Select * from Products where ID={ProductId}", DBConn.conn);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            dt.Rows.Add(reader["ID"], reader["Name"], reader["Price"], Quantity, reader["FotoProduct"]);

                            decimal UnitPrice = decimal.Parse(reader["Price"].ToString());
                            totale += Quantity * UnitPrice;

                        }
                    } catch (Exception ex)
                    {
                        Response.Write(ex.ToString());
                    } finally
                    {
                        if(DBConn.conn.State == ConnectionState.Open)
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

        public class CartItem
        {
            public int ProductID { get; set; }
            public int Quantity { get; set; }

            public CartItem(int productID, int quantity)
            {
                ProductID = productID;
                Quantity = quantity;
            }
        }
    }
}*/

