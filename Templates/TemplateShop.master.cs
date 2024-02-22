using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.Templates
{
    public partial class TemplateShop : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             UpdateCartIconQuantity();
        }

        protected void UpdateCartIconQuantity()
        {
            int totQuantity = 0;

            // Check if Session["Carrello"] is not null and is of the correct type
            if (Session["Carrello"] != null && Session["Carrello"] is List<CartItem> products)
            {
                foreach (CartItem item in products)
                {
                    // Use int.TryParse to handle cases where Quantity is not a valid integer
                    if (int.TryParse(item.Quantity.ToString(), out int quantity))
                    {
                        totQuantity += quantity;
                    }
                    // Handle cases where Quantity is not a valid integer (log or handle as appropriate)
                    else
                    {
                        // Log or handle the error, e.g., by setting a default quantity
                        // totQuantity += 1; // Default quantity
                    }
                }
            }          
            Label1.Text=totQuantity.ToString();
        }
    }
}