using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HR.Models;
using HR.Models.EntityFramework;
using HR.Security;
using HR.Mapping;

namespace HR.Controllers
{
    public class EmployeesController : ApiController
    {
        public IEnumerable<Employees> GetAllStaff()
        {
            Mapp data = new Mapp();
            
            List<Employees> listEmploy = data.GetInfor();
            return listEmploy;
        }

        [HttpPost]
        public HttpResponseMessage CreateNewInfor(HttpRequestMessage request, Employees employeeInfor)
        {
            Mapp data = new Mapp();
            if (data.Checkid(employeeInfor) == true)
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.OK, data.Insert(employeeInfor));
            }


        }
    }
}
