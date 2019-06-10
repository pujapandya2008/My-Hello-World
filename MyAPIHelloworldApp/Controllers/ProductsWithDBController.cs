using System;
using System.Collections.Generic;
using MyAPIHelloworldApp.Models;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyAPIHelloworldApp.Controllers
{
    public class ProductsWithDBController : ApiController
    {
        List<Product> products = new List<Product>();
        public IEnumerable<Product> GetallProducts()
        {            
            DALManager dal = new DALManager();            
            DataSet ds = dal.GetAllProduct();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Product product = new Product { Id = int.Parse(dr["ID"].ToString()), Name = dr["Name"].ToString(), Category = dr["Category"].ToString(), Price = Convert.ToDecimal(dr["Price"])};
                products.Add(product);
            }
            return products;
        }

        public IHttpActionResult getProduct(int id)
        {
            DALManager dal = new DALManager();
            DataSet ds = dal.GetAllProduct();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Product prod = new Product { Id = int.Parse(dr["ID"].ToString()), Name = dr["Name"].ToString(), Category = dr["Category"].ToString(), Price = Convert.ToDecimal(dr["Price"]) };
                products.Add(prod);
            }
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
