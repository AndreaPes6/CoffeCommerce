using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CoffeCommerce.ContentShop
{
    public partial class HomeShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCarouselData();
                BindData();

            }
        }

        private void BindData()
        {
            try
            {
                DBConn.conn.Open();
                string query = "SELECT * FROM Products";

                SqlCommand cmd = new SqlCommand(query, DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    ProductRepeater.DataSource = dataReader;
                    ProductRepeater.DataBind();
                }

                tltCategory.InnerText = "All Categories";
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

        protected void btnAddToCart_Command(object sender, CommandEventArgs e)
        {
            string productId = e.CommandArgument.ToString();

            if (!string.IsNullOrEmpty(productId))
            {
                if (int.TryParse(productId, out int ProdID))
                {
                    RepeaterItem item = (RepeaterItem)((LinkButton)sender).NamingContainer;
                    DropDownList ddlQuantity = (DropDownList)item.FindControl("ddlQuantity");

                    if (ddlQuantity != null)
                    {
                        int quantity = Convert.ToInt32(ddlQuantity.SelectedValue);

                        CartItem cartItem = new CartItem(ProdID, quantity);

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
                        products.Add(cartItem);

                        // Aggiorna la sessione con la lista aggiornata
                        Session["Carrello"] = products;

                        // Aggiorna la quantità nell'icona del carrello

                    }
                    else
                    {
                        Response.Write("<p class='text-danger'>Quantità non valida</p>");
                    }
                }
                else
                {
                    Response.Write("<p class='text-danger'>Formato ID prodotto non valido</p>");
                }
            }
            else
            {
                Response.Write("<p class='text-danger'>ID prodotto nullo o vuoto</p>");
            }
        }





        private void BindCarouselData()
        {
            try
            {
                DBConn.conn.Open();
                string query = "SELECT TOP 5 * FROM Products ORDER BY NEWID()";

                SqlCommand cmd = new SqlCommand(query, DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    DataColumn productIdColumn = new DataColumn("ProductID", typeof(int));
                    dt.Columns.Add(productIdColumn);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Aggiungi l'ID del prodotto come colonna al DataTable
                        row["ProductID"] = row["ID"];
                        row["FotoProductRandom"] = GetRandomImageFromRow(row);
                    }

                    RepeaterCarousel.DataSource = dt;
                    RepeaterCarousel.DataBind();
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

        private string GetRandomImageFromRow(DataRow row)
        {
            List<string> imageList = new List<string>();
            foreach (DataColumn column in row.Table.Columns)
            {
                if (column.ColumnName.StartsWith("FotoProduct") && row[column] != DBNull.Value)
                {
                    imageList.Add(row[column].ToString());
                }
            }

            if (imageList.Count == 0)
            {
                return "";
            }

            Random random = new Random();
            int randomIndex = random.Next(imageList.Count);
            return imageList[randomIndex];
        }

    }
}