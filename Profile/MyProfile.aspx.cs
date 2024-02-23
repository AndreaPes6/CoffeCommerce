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
            // Verifica se la sessione esiste e contiene un valore per l'ID utente
            if (Session["UserId"] != null && !string.IsNullOrEmpty(Session["UserId"].ToString()))
            {
                // Tenta di convertire il valore della sessione in un intero
                if (int.TryParse(Session["UserId"].ToString(), out int IDUser))
                {
                    // Restituisci l'ID utente convertito
                    return IDUser;
                }
            }

            // Se la sessione non contiene un valore per l'ID utente, restituisci un valore predefinito o gestisci l'errore come preferisci
            // Qui puoi scegliere di restituire un valore predefinito, lanciare un'eccezione o gestire l'errore in un altro modo
            // Ad esempio, potresti restituire -1 per indicare che l'ID utente non è stato trovato
            return -1;
        }
    }
}
