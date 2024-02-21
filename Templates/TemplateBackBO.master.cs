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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
            string userProfileImageURL = GetUserProfileImageURL();
            imgUserProfile.ImageUrl = userProfileImageURL;
            }
            catch(Exception ex)
            {
                Response.Write("Errore" + ex.Message);
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
                DBConn.conn.Open();

                string query = "SELECT FotoProfilo FROM [ECommerceBW].[dbo].[User] WHERE ID = @UserID";

                using (SqlCommand command = new SqlCommand(query, DBConn.conn))
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