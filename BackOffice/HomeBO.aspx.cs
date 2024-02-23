using CoffeCommerce.ContentShop;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.BackOffice
{
    public partial class HomeBO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                string content = "<table class=\"table\">";
                content += "<thead><tr><th>Name</th><th>Description</th><th>Price</th><th>Action</th></tr></thead><tbody>";

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        content += $@"<tr>
                                <td>{dataReader["Name"]}</td>
                                <td>{dataReader["Description"]}</td>
                                <td>€ {dataReader["Price"]}</td>
                                <td><a href=""DetailsBO.aspx?product={dataReader["ID"]}"" class=""details-link"">Details</a></td>
                                      </ tr > ";
                    }
                }

                content += "</tbody></table>";
                dataReader.Close();

                contentHtml.InnerHtml = content;
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

        // Mostra in base alla categoria selezionata dalla dropdownlist
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();

                string content = "<table class=\"table\">";
                content += "<thead><tr><th>Name</th><th>Description</th><th>Price</th><th>Action</th></tr></thead><tbody>";

                int IDSelected = int.Parse(DropDownList1.SelectedValue);

                if (IDSelected == 0)
                {
                    // Se l'ID selezionato è 0 All Categories mostra tutti i tipi di prodotti
                    SqlCommand cmdAllProducts = new SqlCommand("SELECT * FROM Products", DBConn.conn);
                    SqlDataReader dataReader = cmdAllProducts.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            content += $@"<tr>
                                    <td>{dataReader["Name"]}</td>
                                    <td>{dataReader["Description"]}</td>
                                    <td>€ {dataReader["Price"]}</td>
                                    <td><a href=""DetailsBO.aspx?product={dataReader["ID"]}"" class=""details-link"">Details</a></td>
                                          </ tr > ";
                        }
                    }

                    dataReader.Close();
                }
                else
                {
                    // Altrimenti mostra i prodotti della categoria selezionata della drop
                    SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE IDCategory = {IDSelected}", DBConn.conn);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            content += $@"<tr>
                                    <td>{dataReader["Name"]}</td>
                                    <td>{dataReader["Description"]}</td>
                                    <td>€ {dataReader["Price"]}</td>
                                    <td><a href=""DetailsBO.aspx?product={dataReader["ID"]}"" class=""details-link"">Details</a></td>
                                          </ tr > ";
                        }
                    }

                    dataReader.Close();
                    tltCategory.InnerText = DropDownList1.SelectedItem.Text;
                }

                content += "</tbody></table>";
                contentHtml.InnerHtml = content;
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