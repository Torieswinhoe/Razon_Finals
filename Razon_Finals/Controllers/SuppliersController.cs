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
    public class SuppliersController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                itpfinals_dbEntities db = new itpfinals_dbEntities();
                var suppliers = db.Suppliers;
                var response = Request.CreateResponse<IEnumerable<Supplier>>(HttpStatusCode.OK, suppliers);
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
                var supplier = db.Suppliers.Where(m => m.SupplierID == id).FirstOrDefault();
                if (supplier == null)
                    throw new Exception("Supplier Id not found.");
                var response = Request.CreateResponse<Supplier>(HttpStatusCode.OK, supplier);
                return response;
            }
            catch (Exception ex)
            {
                var errorresponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                return errorresponse;
            }

        }
    }
}