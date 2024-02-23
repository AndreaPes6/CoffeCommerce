using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (Session["Carrello"] != null)
            {
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
                    int productId = articolo.ProductID;
                    decimal quantity = articolo.Quantity;

                    DataRow existingRow = dt.AsEnumerable().FirstOrDefault(r => r.Field<int>("ID") == productId);

                    if (existingRow != null)
                    {
                        // If the product is already in the DataTable, update the quantity and total
                        existingRow["Quantità"] = Convert.ToInt32(existingRow["Quantità"]) + (int)quantity;

                        decimal unitPrice = Convert.ToDecimal(existingRow["Prezzo"]);
                        totale += quantity * unitPrice;
                    }
                    else
                    {
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
                }

                totalAmountLabel.InnerText = totale.ToString("0.00");
                CartRepeater.DataSource = dt;
                CartRepeater.DataBind();
            }
        }


        protected void EmptyCartButton_Click(object sender, EventArgs e)
        {
            Session.Remove("Carrello");
            PopolaCarrello();
            Response.Redirect(Request.RawUrl);
        }

        protected void RemoveFromCartButton_Command(object sender, CommandEventArgs e)
        {
            if (Session["Carrello"] != null)
            {
                int index = Convert.ToInt32(e.CommandArgument);

                List<CartItem> carrello = (List<CartItem>)Session["Carrello"];

                carrello.RemoveAt(index);

                Session["Carrello"] = carrello;

                PopolaCarrello();
            }
        }

        protected void ProceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            if (Session["Carrello"] != null && ((List<CartItem>)Session["Carrello"]).Count > 0)
            {
                Response.Redirect("Checkout.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "EmptyCartAlert", "alert('Il carrello è vuoto.');", true);
            }
        }
    }
}
