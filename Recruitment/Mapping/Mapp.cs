using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Recruitment.Models.EntityFramework;


namespace Recruitment.Mapping
{
    public class Mapp
    {
        GetInformationEntity en = new GetInformationEntity();
        GetInformationNhiber nhiber = new GetInformationNhiber();

        public List<Candidates> GetInfor()
        {
            return en.GetAllInfor();
        }
        public Staff Insert(string employeeInfor)
        {
            return en.InsertInfor(employeeInfor);
        }
        //public bool Checkid(Candidates employ)
        //{
        //    return en.CheckID(employ);
        //}

        //public Rec Insert(Candidates employeeInfor)
        //{
        //    return en.InsertInfor(employeeInfor);
        //}
    }
}