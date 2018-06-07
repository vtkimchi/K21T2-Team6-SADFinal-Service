using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recruitment.Models.Nhibernate;
using NHibernate;
using NHibernate.Linq;
using Recruitment.Models;
using Recruitment.Models.EntityFramework;

namespace Recruitment.Models
{
    public class GetInformationNhiber
    {
        public List<Candidates> GetAllInfor()
        {
            List<Candidates> CandidateList = new List<Candidates>();
            using (ISession session = NhibernateSession.OpenSession())
            {
                var Candidate = session.Query<Candidates>().ToList();
                foreach (var item in Candidate)
                {
                    CandidateList.Add(new Candidates
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Birthday = item.Birthday,
                        Phone = item.Phone
                    });
                }

            }
            return CandidateList;
        }


        public bool CheckID(Candidates staffId)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                bool exist = session.Query<Candidates>().Any(x => x.ID == staffId.ID);
                return exist;
            }
        }

        public Staff InsertInfor(string staffinfor)
        {
            Staff st = new Staff();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    Employees staff = new Employees();
                    staff.Name = staffinfor;
                    staff.Department = "IT";
                    staff.Salary = "GeLuootL/vhSl/ZRITFGhA==";

                    session.Save(staff);
                    trans.Commit();
                    return st;
                }
            }
        }

    }
}