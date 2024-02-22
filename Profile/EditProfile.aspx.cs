using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.Profile
{
    public partial class EditProfile : System.Web.UI.Page
    {
        private readonly string connectionString = WebConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["User"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["User"]);
                    LoadExistingUserData(userId);
                }
            }
        }

        private void LoadExistingUserData(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [UserName] AS UserName, [Email] AS Email, [Password] AS Password, [FotoProfilo] AS FotoProfilo FROM [User] WHERE ID = @UserId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUserName.Text = reader["UserName"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPassword.Text = reader["Password"].ToString();
                            txtImageProfile.Text = reader["FotoProfilo"].ToString();
                        }
                    }
                }
            }
        }


        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }


        protected void btnDiscard_Click(object sender, EventArgs e)
        {

        }

    }
}