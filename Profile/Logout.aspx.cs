using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.Profile
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                // Se l'utente non è autenticato, reindirizza alla pagina di login
                Response.Redirect("../ContentShop/Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Cancella tutti i dati di sessione
            Response.Redirect("../ContentShop/Login.aspx"); // Reindirizza alla pagina di login
        }
    }
}