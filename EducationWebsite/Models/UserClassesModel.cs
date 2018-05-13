using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite.Models
{
    public class UserClassesModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }
}