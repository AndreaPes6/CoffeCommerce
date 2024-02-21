using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CoffeCommerce.Templates
{
    public partial class TemplateBackBO : System.Web.UI.MasterPage
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["UserId"] != null)
            {
                bool isAdmin = Convert.ToBoolean(Session["IsAdmin"]);
                if (!isAdmin)
                {
                    Response.Redirect("../ContentShop/HomeShop.aspx");
                }
                else
                {
                    string userProfileImageURL = GetUserProfileImageURL();
                    imgUserProfile.ImageUrl = userProfileImageURL;
                }
            }
        }

        private string GetUserProfileImageURL()
        {
            int userId = GetUserId();
            string userProfileImageURL = GetUserProfileImageFromDatabase(userId);
            return userProfileImageURL;
        }

        private int GetUserId()
        {
            int IDUser = int.Parse(Session["UserId"].ToString());
            return IDUser;
        }

        private string GetUserProfileImageFromDatabase(int userId)
        {
            string userProfileImageURL = "imgUserProfile";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT FotoProfilo FROM [User] WHERE ID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                userProfileImageURL = reader["FotoProfilo"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            return userProfileImageURL;
        }
    }
}
