using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recruitment.Models
{
    public class Candidates
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual Nullable<System.DateTime> Birthday { get; set; }
        public virtual string Phone { get; set; }
     }
}