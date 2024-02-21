using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.BackOffice
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();

                string name = inputName.Value;
                decimal price;


                // Utilizza decimal.TryParse per la conversione sicura del prezzo
                if (decimal.TryParse(inputPrice.Value, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out price))
                {
                    string description = txtDescription.Value;
                    int IDCategory = int.Parse(dpwCategories.SelectedValue);
                    string urlImage = imgUrl.Value;



                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO Products (Name, Description, Price, FotoProduct, IDCategory) " +
                                                          "VALUES (@Name, @Description, @Price, @UrlImage, @IDCategory)", DBConn.conn);

                    // Aggiungi i parametri alla query
                    cmdInsert.Parameters.AddWithValue("@Name", name);
                    cmdInsert.Parameters.AddWithValue("@Description", description);
                    cmdInsert.Parameters.AddWithValue("@Price", price);
                    cmdInsert.Parameters.AddWithValue("@UrlImage", urlImage);
                    cmdInsert.Parameters.AddWithValue("@IDCategory", IDCategory);

                    int affectedRow = cmdInsert.ExecuteNonQuery();

                    //conferma avvenuto inserimento
                    if (affectedRow != 0)
                    {
                        string script = "alert('Articolo inserito con successo!');";
                        ClientScript.RegisterStartupScript(this.GetType(), "SuccessScript", script, true);
                    }
                }
                else
                {
                    // Gestisci l'errore di conversione del prezzo
                    string script = "alert('Il formato del prezzo non è valido.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ErrorScript", script, true);
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (DBConn.conn.State == System.Data.ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }
        }



    }
}