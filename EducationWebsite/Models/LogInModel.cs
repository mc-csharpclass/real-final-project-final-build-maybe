using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EducationWebsite.Models
{
    public class LogInModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    //public LogInModel LoginCheck(string email, string password)
    //{
    //    var entities = new EduWebSiteEntities();
    //    entities.Database.Connection.Open();
    //    var loginCheck = entities.User.ToArray();
    //    var results = Array.FindAll(loginCheck, s => s.Equals(email));

        

    //    if (results[0] == null)
    //    {
    //        return null;
    //    }
    //    else
    //    {
    //        return null;
    //    }

    //    return null;
    //}
}