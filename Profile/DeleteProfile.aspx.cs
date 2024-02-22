using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.Profile
{
    public partial class DeleteProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int userId = GetUserId();

            string deleteQuery = "DELETE FROM [User] WHERE ID = @UserId";

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Session.Clear();
            Response.Redirect("../ContentShop/Login.aspx");
        }

        private int GetUserId()
        {
            int IDUser = int.Parse(Session["UserId"].ToString());
            return IDUser;
        }
    }
}