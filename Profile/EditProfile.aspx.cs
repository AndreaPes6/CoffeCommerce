using System;
using System.Collections.Generic;
using System.Configuration;
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
                 int userId = GetUserId();    
                 LoadExistingUserData(userId);     
            }
        }

        private void LoadExistingUserData(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT [UserName], [Email], [Password], [FotoProfilo] FROM [User] WHERE ID = @UserId";

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
            int userId = GetUserId();

            string updatedUserName = txtUserName.Text;
            string updatedEmail = txtEmail.Text;
            string updatedPassword = txtPassword.Text;
            string updatedFotoProfilo = txtImageProfile.Text;

            if (!IsStrongPassword(updatedPassword))
            {
                LblErrorMessage.Text = "La password deve essere di almeno 8 caratteri e contenere almeno una lettera maiuscola, una lettera minuscola, un numero e un carattere speciale.";
                LblErrorMessage.Visible = true;
                return;
            }

            string updateQuery = "UPDATE [User] SET UserName = @UserName, Email = @Email, Password = @Password, FotoProfilo = @FotoProfilo WHERE ID = @UserId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", updatedUserName);
                    command.Parameters.AddWithValue("@Email", updatedEmail);
                    command.Parameters.AddWithValue("@Password", updatedPassword);
                    command.Parameters.AddWithValue("@FotoProfilo", updatedFotoProfilo);
                    command.Parameters.AddWithValue("@UserId", userId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("../Profile/MyProfile.aspx");
        }

        protected void btnDiscard_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Profile/MyProfile.aspx");
        }

        private int GetUserId()
        {
            int IDUser = int.Parse(Session["UserId"].ToString());
            return IDUser;
        }

        private bool IsStrongPassword(string password)
        {
            return password.Length >= 8
                   && password.Any(char.IsDigit)
                   && password.Any(char.IsLower)
                   && password.Any(char.IsUpper)
                   && password.Any(c => !char.IsLetterOrDigit(c));
        }
    }
}