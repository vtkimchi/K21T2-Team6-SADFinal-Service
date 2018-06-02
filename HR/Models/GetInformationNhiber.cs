using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Models;
using HR.Security;
using HR.Models.EntityFramework;
using NHibernate;
using NHibernate.Linq;
using HR.Models.Nhibernate;

namespace HR.Models
{
    public class GetInformationNhiber
    {
        // ma hoa md5
        EncryptMd5 en = new EncryptMd5();
        DecryptionMd5 de = new DecryptionMd5();

        public List<Employees> GetAllInfor()
        {
            List<Employees> staffList = new List<Employees>();
            using (ISession session = NhibernateSession.OpenSession())
            {
                var staff = session.Query<Employees>().ToList();
                foreach (var item in staff)
                {
                    staffList.Add(new Employees
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Department = item.Department,
                        Salary = de.Decrypt(item.Salary)
                    });
                }

            }
            return staffList;
        }

        public bool CheckID(Employees staffId)
        {
            using (ISession session = NhibernateSession.OpenSession())
            {
                bool exist = session.Query<Employees>().Any(x => x.ID == staffId.ID);
                return exist;
            }
        }

        public Staff InsertInfor(Employees staffinfor)
        {
            Staff st = new Staff();
            using (ISession session = NhibernateSession.OpenSession())
            {
                using (var trans = session.BeginTransaction())
                {
                    Employees staff = new Employees();
                    staff.Name = staffinfor.Name;
                    staff.Department = staffinfor.Department;
                    staff.Salary = en.Encrypt(staffinfor.Salary);

                    session.SaveOrUpdate(staff);
                    trans.Commit();
                    return st;
                }
            }
        }

    }
}