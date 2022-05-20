using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Razon_Finals.Models;

namespace Razon_Finals.Controllers
{
    public class EmployeeController : ApiController
    {
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index()
        {
            try
            {
                itpfinals_dbEntities db = new itpfinals_dbEntities();
                var employees = db.Employees;
                var response = Request.CreateResponse<IEnumerable<Employee>>(HttpStatusCode.OK, employees);
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
                var employee = db.Employees.Where(m => m.EmployeeID==id).FirstOrDefault();
                if (employee == null)
                    throw new Exception("Employee Id not found.");
                var response = Request.CreateResponse<Employee>(HttpStatusCode.OK, employee);
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
}