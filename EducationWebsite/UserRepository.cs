using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using EducationWebsite.Models;

namespace EducationWebsite
{
    public interface IUserRepository
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
        UserModel GetUser(int userId);
        //ClassesModel[] GetUserClasses(int userId);
    }

    //public class UserModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class UserRepository : IUserRepository
    {


        public UserModel LogIn(string email, string password)
        {
            var user = DatabaseAccessor.Instance.User
                .FirstOrDefault(t => t.UserEmail.ToLower() == email.ToLower()
                                      && t.UserPassword == password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }

        public UserModel Register(string email, string password)
        {
            var user = DatabaseAccessor.Instance.User
                    .Add(new EducationWebsite.User { UserEmail = email, UserPassword = password });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserModel { Id = user.UserId, Name = user.UserEmail };
        }


        public UserModel GetUser(int userId)
        {
            return DatabaseAccessor.Instance.User
                .Where(t => t.UserId == userId)
                .Select(t => new UserModel
                {
                    Id = t.UserId,
                    Name = t.UserEmail,

                })
            .FirstOrDefault();
        }

        //private ClassesModel[] GetUserClasses(int userId)
        //{
        //    var user = DatabaseAccessor.Instance.User
        //        .FirstOrDefault(t => t.UserId == userId);
        //    var grid2 = new WebGrid(user.Class.ToArray());
        //    //var userClasses = DatabaseAccessor.Instance.User.FirstOrDefault(t => t.UserId == userId);

        //    //return userClasses.Class.ToArray();

        //}
    }
}