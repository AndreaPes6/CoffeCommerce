﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoffeCommerce.ContentShop
{
    public partial class HomeShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                string content = "";

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        content += $@"<div class=""col"">
                                       <div class=""c-card card h-100 d-flex flex-column justify-content-between"">
                                                                 <div class=""p-2 d-flex justify-content-center"">
                                              <img src=""{dataReader["FotoProduct"]}"" class=""card-img-top rounded"" alt=""{dataReader["Name"]}"" style=""width:150px; height:auto;"">
                                          
                                                                </div>
                                             <div>
                                                 <div class=""card-body "">
                                              <h6 class=""card-title fw-bolder"">{dataReader["Name"]}</h6>
                                              <p class=""card-text  text-secondary"" style=""font-size:0.8em;"">{dataReader["Description"]}</p>   
                                           </div>
                                             <div class="" d-flex justify-content-around align-items-baseline p-3"">
                                                
                                               <p class=""card-text me-2"">€{dataReader["Price"]}</p>
                                               <a href=""DetailsShop.aspx?product={dataReader["ID"]}""  class=""btn btn-card rounded-pill"">Details</a>
                                            </div>
                                               </div>
                                          
                                          
                                              
                                           </div>
                                      </div> ";

                    }
                }
                contentHtml.InnerHtml = content;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if(DBConn.conn.State == System.Data.ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }

            }
        }
    }
}