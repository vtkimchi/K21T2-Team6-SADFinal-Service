using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Models;
using HR.Security;
using HR.Models.EntityFramework;

namespace HR.Models
{
    public class GetInformationEntity
    {
        // ma hoa md5
        EncryptMd5 en = new EncryptMd5();
        DecryptionMd5 de = new DecryptionMd5();

        // =================================Entity===============================//
        public bool CheckID(Employees employeesId)
        {
            using (HREntities db = new HREntities())
            {
                if (db.Staffs.Any(p => p.ID == employeesId.ID))
                {
                    return true;
                }
                return false;
            }
        }

        public Staff InsertInfor(Employees employinfor)
        {
            using (HREntities db = new HREntities())
            {
                Staff employee = new Staff();
                employee.ID = employinfor.ID;
                employee.Name = employinfor.Name;
                employee.Department = employinfor.Department;
                employee.Salary = en.Encrypt(employinfor.Salary);
                db.Staffs.Add(employee);
                db.SaveChanges();
                return employee;
            }
        }
        public List<Employees> GetAllInfor()
        {

            List<Employees> employeesList = new List<Employees>();


            using (HREntities db = new HREntities())
            {
                var staff = db.Staffs.ToList();
                foreach (var item in staff)
                {

                    employeesList.Add(new Employees
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Department = item.Department,
                        Salary = de.Decrypt(item.Salary)
                    });
                }
            }

            return employeesList;
        }

    }
}