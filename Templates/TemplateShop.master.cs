using System;

namespace CoffeCommerce.Templates
{
    public partial class TemplateShop : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserId"] != null)
                {
                    bool isAdmin = Convert.ToBoolean(Session["IsAdmin"]);

                    if (isAdmin)
                    {
                        Response.Redirect("../BackOffice/HomeBO.aspx");
                    }
                    else
                    {
                        imgUserProfile.ImageUrl = Session["UserProfileImage"].ToString();
                        imgUserProfile.Visible = true;
                    }
                }
                else
                {
                    BtnLogin.Visible = true;
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ContentShop/Login.aspx");
        }
    }
}
