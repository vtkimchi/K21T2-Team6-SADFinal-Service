using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Recruitment.Models;

namespace Recruitment.Controllers
{
    public class CandidatesController : ApiController
    {
        public List<Candidates> GetAllCandidate()

        {
            GetInformationEntity data = new GetInformationEntity();
            List<Candidates> listCandidate = data.GetAllInfor();
            return listCandidate;
        }




        //public IEnumerable<Candidate_Infor> GetAllCandidate()
        //{
        //    List<Candidate_Infor> candidateList = new List<Candidate_Infor>();


        //    using (SMAEntities1 db = new SMAEntities1())
        //    {
        //        var candidate = db.Candidate_Infor.ToList();
        //        foreach (var item in candidate)
        //        {

        //            candidateList.Add(new Candidate_Infor
        //            {
        //                ID = item.ID,
        //                Name = item.Name,
        //                Phone_Number = item.Phone_Number,
        //                Email = item.Email,
        //                Birth = Convert.ToDateTime(item.Birth)

        //            });
        //        }
        //    }

        //    return candidateList;
        //}

        //public IEnumerable<Candidate_Infor> CandidateIdStaff(string id)
        //{
        //    SMAEntities1 db = new SMAEntities1();
        //    List<Candidate_Infor> candidateID = new List<Candidate_Infor>();

        //    var candidate = db.Candidate_Infor.Where(x => x.ID == id);

        //    foreach (var item in candidate)
        //    {
        //        candidateID.Add(new Candidate_Infor
        //        {
        //            ID = item.ID,
        //            Name = item.Name,
        //            Phone_Number = item.Phone_Number,
        //            Email = item.Email,
        //            Birth = item.Birth
        //        });
        //    }
        //    return candidateID;

        //}




    }
}
