using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite.Models
{
    public class AllClassesModel
    {
        public EducationWebsite.Models.ClassesModel[] AllClasses { get; set; }
        public string SelectedClass { get; set; }
    }
}