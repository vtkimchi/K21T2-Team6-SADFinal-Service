﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class Employees
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Department { get; set; }
        public virtual string Salary { get; set; }
    }
}