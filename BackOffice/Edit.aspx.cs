using System;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace CoffeCommerce.BackOffice
{
    public partial class Edit : System.Web.UI.Page
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {//CARICHIAMO I DATI PRESENTI UTILIZZANDO ID
            if (!IsPostBack)
            {
                if (Request.QueryString["product"] != null)
                {
                    int productId = Convert.ToInt32(Request.QueryString["product"]);
                    LoadExistingProductData(productId);
                }
            }
        }

        private void LoadExistingProductData(int productId)
        {//VISUALIZZARE I DATI GIA' ESISTENTI
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [Name] AS ProductName, [Description] AS ProductDescription, [Price] AS ProductPrice, [FotoProduct] AS ProductImage FROM Products WHERE ID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductID", productId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtProductName.Text = reader["ProductName"].ToString();
                            txtProductDescription.Text = reader["ProductDescription"].ToString();
                            txtProductPrice.Text = reader["ProductPrice"].ToString();
                            txtProductImage.Text = reader["ProductImage"].ToString(); 
                        }
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateExistingProduct();
        }

        private void UpdateExistingProduct()
        {
            int productId = Convert.ToInt32(Request.QueryString["product"]);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET [Name] = @ProductName, [Description] = @ProductDescription, [Price] = @ProductPrice, [FotoProduct] = @ProductImage WHERE ID = @ProductID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    command.Parameters.AddWithValue("@ProductDescription", txtProductDescription.Text);
                    command.Parameters.AddWithValue("@ProductPrice", Convert.ToDecimal(txtProductPrice.Text));
                    command.Parameters.AddWithValue("@ProductImage", txtProductImage.Text);
                    command.Parameters.AddWithValue("@ProductID", productId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("HomeBO.aspx");
        }
    }
}
