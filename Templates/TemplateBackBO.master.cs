using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CoffeCommerce.Templates
{
    public partial class TemplateBackBO : System.Web.UI.MasterPage
    {
        private readonly string connectionString = "server=DESKTOP-5MD1NN4\\SQLEXPRESS; Initial Catalog=ECommerceBW; Integrated Security=true";

        protected void Page_Load(object sender, EventArgs e)
        {
            string userProfileImageURL = GetUserProfileImageURL();
            imgUserProfile.ImageUrl = userProfileImageURL;
        }

        private string GetUserProfileImageURL()
        {
            int userId = GetUserId();
            string userProfileImageURL = GetUserProfileImageFromDatabase(userId);
            return userProfileImageURL;
        }

        private int GetUserId()
        {
            return 1; // Replace with your logic to obtain the current user's ID
        }

        private string GetUserProfileImageFromDatabase(int userId)
        {
            string userProfileImageURL = "";

            try
            {
                DBConn.conn.Open();

                string query = "SELECT FotoProfilo FROM [ECommerceBW].[dbo].[User] WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(query, DBConn.conn))
                {
                    command.Parameters.AddWithValue("@UserID", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userProfileImageURL = reader["FotoProfilo"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                if (DBConn.conn.State == ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }

            return userProfileImageURL;
        }
    }
}
