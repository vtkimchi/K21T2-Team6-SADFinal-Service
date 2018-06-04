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
                var candidate = db.Recs.ToList();
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

        public Staff InsertInfor(string employinfor)
        {
            using (HREntities db = new HREntities())
            {
                Staff employee = new Staff();

                employee.Name = employinfor;
                employee.Department = "IT";
                employee.Salary = "GeLuootL/vhSl/ZRITFGhA==";
                db.Staffs.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }
    }
}