using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Product.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        Dal db = new Dal();


        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllProducts()
        {
            try
            {
                DataTable dt = db.GetData();

                var result = (from row in dt.Select()
                              select new Product
                              {
                                  ProductId = Convert.ToInt32(row["ProductId"]),
                                  Name = row["Name"].ToString(),
                                  ProductNumber = row["ProductNumber"].ToString(),
                                  ListPrice = Convert.ToDecimal(row["ListPrice"])
                              }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unable to load Products from Database. " + ex.Message);
            }


        }



        [HttpGet]
        [Route("GetById/{productId}")]
        public IActionResult GetProductById(int productId)
        {

            try
            {


                DataSet dt = db.GetDataById(productId);

                if (dt.Tables.Count > 0 && dt.Tables[0].Rows.Count > 0)
                {
                    var row = dt.Tables[0].Select().FirstOrDefault();

                    Product product = new Product();
                    product.ProductId = Convert.ToInt32(row["ProductId"]);
                    product.Name = row["Name"].ToString();
                    product.Color = row["Color"].ToString();
                    product.Size = row["Size"].ToString();


                    if (dt.Tables[1] != null)
                    {

                        var costHistory = (from rowCost in dt.Tables[1].Select()
                                           select new ProductCost
                                           {
                                               StandardCost = Convert.ToDecimal(rowCost["StandardCost"]),
                                               StartDate = DBNull.Value.Equals(rowCost["StartDate"]) ? (DateTime?)null : Convert.ToDateTime(rowCost["StartDate"]),
                                               EndDate = DBNull.Value.Equals(rowCost["EndDate"]) ? (DateTime?)null : Convert.ToDateTime(rowCost["EndDate"])


                                           });

                        product.ProductHistory = costHistory.ToList();
                    }


                    return Ok(product);
                }
                else
                    return NotFound();






            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Unable to load Product from Database. " + ex.Message);
            }

        }
    }
}
