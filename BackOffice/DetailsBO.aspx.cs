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
                    string productPhoto = dataReader["FotoProduct"].ToString();
                    string productName = dataReader["Name"].ToString();
                    string productDescription = dataReader["Description"].ToString();
                    string productPrice = dataReader["Price"].ToString();

                    string productHtml = $@"
                    <div class='container mt-5'>
                        <div class='row'>
                            <div class='col-md-4'>
                                <img src='{productPhoto}' class='img-fluid rounded product-image w-75 border- border-solid-black' alt='{productName}' onclick='zoomImage(this)' style='cursor: pointer;'>
                            </div>
                            <div class='col-md-6'>
                                <h2 class='fw-bold text-uppercase mb-4'>{productName}</h2>
                                <p class='fs-5 mb-4'>{productDescription}</p>
                                <p class='fw-bold fs-4 mb-4'>Price: €{productPrice}</p>
                                <asp:Button ID='btnEdit' runat='server' Text='Edit Product' CssClass='btn btn-primary' OnClick='btnEdit_Click' />
                                <asp:Button ID='btnDelete' runat='server' Text='Delete Product' CssClass='btn btn-danger' OnClick='btnDelete_Click' />
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
                        Response.Write("<script>alert('Product deleted successfully')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to delete product')</script>");
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
