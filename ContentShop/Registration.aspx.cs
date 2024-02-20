using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CoffeCommerce.ContentShop
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void BtnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }


        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = TxtUserName.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string profilePictureUrl = TxtProfilePicture.Text;

            string connString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand registerUser = new SqlCommand("INSERT INTO [User] (UserName, Email, Password, FotoProfilo, Amministratore) VALUES (@UserName, @Email, @Password, @ProfilePictureUrl, @IsAdmin)", conn);
                registerUser.Parameters.AddWithValue("@UserName", username);
                registerUser.Parameters.AddWithValue("@Email", email);
                registerUser.Parameters.AddWithValue("@Password", password);
                registerUser.Parameters.AddWithValue("@ProfilePictureUrl", profilePictureUrl);
                registerUser.Parameters.AddWithValue("@IsAdmin", 1);

                int rowsAffected = registerUser.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    LblErrorMessage.Text = "<i class='bi bi-exclamation-triangle-fill'></i> Si è verificato un errore durante la registrazione. Riprova più tardi.";
                    LblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Si è verificato un errore durante la registrazione: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
