using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Razon_Finals.Models;

namespace Razon_Finals.Controllers
{
    public class ProductsController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                itpfinals_dbEntities db = new itpfinals_dbEntities();
                var products = db.Products;
                var response = Request.CreateResponse<IEnumerable<Product>>(HttpStatusCode.OK, products);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index(int id)
        {
            try
            {
                itpfinals_dbEntities db = new itpfinals_dbEntities();
                var product = db.Products.Where(m => m.ProductID == id).FirstOrDefault();
                if (product == null)
                    throw new Exception("Product Id not found.");
                var response = Request.CreateResponse<Product>(HttpStatusCode.OK, product);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }
        }
        public string Put(int id, [FromBody] string value)
        {
            return value + "updated successfully with id" + id;
        }
    }
}