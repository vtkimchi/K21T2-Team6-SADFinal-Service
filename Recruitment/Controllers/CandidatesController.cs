using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recruitment.Models;
using Recruitment.Mapping;

namespace Recruitment.Controllers
{
    public class CandidatesController : ApiController
    {
        public List<Candidates> GetAllCandidate()

        {
            Mapp data = new Mapp();
            //GetInformationEntity data = new GetInformationEntity();
            List<Candidates> listCandidate = data.GetInfor();
            return listCandidate;
        }

        [HttpPost]
        public HttpResponseMessage CreateNewInfor(HttpRequestMessage request, Candidates employeeInfor)
        {
            Mapp data = new Mapp();
            string Name = employeeInfor.Name;
            return request.CreateResponse(HttpStatusCode.OK, data.Insert(Name));
        }
    }
}
