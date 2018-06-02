using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recruitment.Models;
using Recruitment.Models.EntityFramework;

namespace Recruitment.Models
{
    public class GetInformationEntity
    {
        public List<Candidates> GetAllInfor()
        {

            List<Candidates> candidateList = new List<Candidates>();


            using (HREntities db = new HREntities())
            {
                var candidate = db.Recruitments.ToList();
                foreach (var item in candidate)
                {

                    candidateList.Add(new Candidates
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Phone = item.Phone,                       
                        Birthday = Convert.ToDateTime(item.Birthday)

                    });
                }
            }

            return candidateList;
        }
    }
}