using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CoffeCommerce.BackOffice
{
    public partial class DetailsBO : Page
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
                    urlImg.Src = dataReader["FotoProduct"].ToString();
                    txtsName.InnerText = dataReader["Name"].ToString();
                    txtDescription.InnerText = dataReader["Description"].ToString();
                    txtPrice.InnerText = $"Price: {dataReader["Price"]}€";
                  
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] != null)
            {
                string productId = Request.QueryString["product"];
                Response.Redirect($"Edit.aspx?product={productId}");
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] != null)
            {
                string productId = Request.QueryString["product"];
                try
                {
                    DBConn.conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ID = @ProductId", DBConn.conn);
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Mostra un messaggio di conferma utilizzando JavaScript e reindirizza immediatamente
                        ScriptManager.RegisterStartupScript(this, GetType(), "DeleteSuccess", "alert('Prodotto eliminato con successo'); window.location.href = 'HomeBO.aspx';", true);
                    }
                    else
                    {
                        Response.Write("<script>alert('Impossibile eliminare il prodotto')</script>");
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


    }
}
