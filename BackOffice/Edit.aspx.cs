using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.BackOffice
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            UpdateProduct();
        }

        private void LoadProductData()
        {

        }

        private void UpdateProduct()
        {
        }
    }
}
