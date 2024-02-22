using System;
using System.Data.SqlClient;

namespace CoffeCommerce.Profile
{
    public partial class MyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = GetUserId(); 

                try
                {
                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbEcommConnectionString"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT UserName, Email, FotoProfilo FROM [User] WHERE ID = @UserId";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);

                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                lblName.Text = reader["UserName"].ToString();
                                lblEmail.Text = reader["Email"].ToString();

                                if (!reader.IsDBNull(reader.GetOrdinal("FotoProfilo")))
                                {
                                    string profileImageUrl = reader["FotoProfilo"].ToString();
                                    if (!string.IsNullOrEmpty(profileImageUrl))
                                    {
                                        imgProfile.ImageUrl = profileImageUrl;
                                    }
                                    else
                                    {
                                        imgProfile.ImageUrl = "https://static.vecteezy.com/ti/vettori-gratis/p1/2318271-icona-profilo-utente-vettoriale.jpg";
                                    }
                                }
                                else
                                {
                                    imgProfile.ImageUrl = "https://static.vecteezy.com/ti/vettori-gratis/p1/2318271-icona-profilo-utente-vettoriale.jpg";
                                }
                            }
                            reader.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        private int GetUserId()
        {
            int IDUser = int.Parse(Session["UserId"].ToString());
            return IDUser;
        }
    }
}
