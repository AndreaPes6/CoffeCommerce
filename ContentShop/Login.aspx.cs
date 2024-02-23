
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.ContentShop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("../BackOffice/HomeBO.aspx");
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            string connString = ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ToString();
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                SqlCommand registerUser = new SqlCommand($"SELECT ID FROM [User] WHERE UserName='{username}' AND Password='{password}'", conn);

                string UserId = registerUser.ExecuteScalar()?.ToString();

                if (UserId != null)
                {
                    Session["UserId"] = UserId;
                    Response.Redirect("../BackOffice/HomeBO.aspx");
                }
                else
                {
                    LblErrorMessage.Text = "<i class='bi bi-exclamation-triangle-fill'></i> Credenziali errate";
                    LblErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("An error occurred while logging in: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }


    }
}