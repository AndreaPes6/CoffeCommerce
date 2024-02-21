using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace CoffeCommerce.ContentShop
{
    public partial class Login : Page
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
                SqlCommand loginUser = new SqlCommand($"SELECT ID, Amministratore FROM [User] WHERE UserName='{username}' AND Password='{password}'", conn);

                SqlDataReader reader = loginUser.ExecuteReader();

                if (reader.Read())
                {
                    string userId = reader["ID"].ToString();
                    bool isAdmin = Convert.ToBoolean(reader["Amministratore"]);

                    Session["UserId"] = userId;
                    Session["IsAdmin"] = isAdmin;

                    if (isAdmin)
                    {
                        Response.Redirect("../BackOffice/HomeBO.aspx");
                    }
                    else
                    {
                        Response.Redirect("HomeShop.aspx");
                    }
                }
                else
                {
                    LblErrorMessage.Text = "<i class='bi bi-exclamation-triangle-fill'></i> Invalid credentials";
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
