﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyAPIHelloworldApp.Models;

namespace MyAPIHelloworldApp.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product{Id=1,Name="Pineapple",Category="Groceries",Price=1},
            new Product{Id=2,Name="TeddyBear",Category="Toys",Price=3.75m},
            new Product{Id=3,Name="Axe",Category="Hardware",Price=16.99M}
        };

        public IEnumerable<Product>GetallProducts()
        {
            return products;
        }

        public IHttpActionResult getProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if(product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
