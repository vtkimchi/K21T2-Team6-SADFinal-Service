using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Models;
using HR.Models.EntityFramework;
using HR.Models.Nhibernate;

namespace HR.Mapping
{
    public class Mapp
    {
        GetInformationEntity en = new GetInformationEntity();
        GetInformationNhiber nhiber = new GetInformationNhiber();

        public List<Employees> GetInfor()
        {
            return en.GetAllInfor();
        }

        public bool Checkid(Employees employ)
        {
            return en.CheckID(employ);
        }

        public Staff Insert(Employees employeeInfor)
        {
            return en.InsertInfor(employeeInfor);
        }
    }
}