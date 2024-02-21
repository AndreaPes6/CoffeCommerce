using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

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

            string connString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);


            string username = TxtUserName.Text;
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;
            string profilePictureUrl = TxtProfilePicture.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                LblErrorMessage.Text = "Please fill in all required fields (Username, Email, Password)";
                LblErrorMessage.Visible = true;
                return;
            }

            if (IsUsernameAlreadyRegistered(username))
            {
                LblErrorMessage.Text = "The entered username is already registered. Please choose another one.";
                LblErrorMessage.Visible = true;
                return;
            }

            if (IsEmailAlreadyRegistered(email) || !IsValidEmail(email))
            {
                LblErrorMessage.Text = "The entered email is either invalid or already registered.";
                LblErrorMessage.Visible = true;
                return;
            }

            if (!IsStrongPassword(password))
            {
                LblErrorMessage.Text = "Password must be at least 8 characters long and contain numbers, lowercase and uppercase letters, and special characters.";
                LblErrorMessage.Visible = true;
                return;
            }

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
                    LblErrorMessage.Text = "<i class='bi bi-exclamation-triangle-fill'></i> An error occurred during registration. Please try again later.";
                    LblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred during registration: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private bool IsUsernameAlreadyRegistered(string username)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE UserName = @UserName", conn);
            cmd.Parameters.AddWithValue("@UserName", username);

            try
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while checking username: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool IsEmailAlreadyRegistered(string email)
        {
            string connString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email = @Email", conn);
            cmd.Parameters.AddWithValue("@Email", email);

            try
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while checking email: " + ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool IsStrongPassword(string password)
        {
            return password.Length >= 8
                   && password.Any(char.IsDigit)
                   && password.Any(char.IsLower)
                   && password.Any(char.IsUpper)
                   && password.Any(c => !char.IsLetterOrDigit(c));
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
