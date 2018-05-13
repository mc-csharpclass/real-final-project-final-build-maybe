using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite
{
    public interface IClassesRepository
    {
        ClassesModel GetClasses(int classId);
        //ClassesModel Add(int userId, int classId)
        ClassesModel[] GetAllClasses { get; }
        ClassesModel[] GetUserClasses(int userId);
    }

    public class ClassesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //public ClassesModel(int id, string name, string description, decimal price)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Price = price;

        //}
    }

    public class ClassesRepositoy : IClassesRepository
    {
        public ClassesModel GetClasses(int classId)
        {
            //return DatabaseAccessor.Instance.Class
            //    .Where(t => t.ClassId == classId)
            //    .Select(t => new ClassesModel
            //    {
            //        Id = t.,
            //        Name = t.Name,
            //        Description = t.Description,
            //        Price = t.Price
            //    })
            //.First();      //.SingleOrDefault(); 
            return null;

        }
        //public class ClassesModel
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Description { get; set; }
        //    public decimal Price { get; set; }
        //}

        public ClassesModel[] GetAllClasses
        {
            get
            {
                return DatabaseAccessor.Instance.Class
                    .Select(t => new ClassesModel
                    {
                        Id = t.ClassId,
                        Name = t.ClassName,
                        Description = t.ClassDescription,
                        Price = t.ClassPrice
                    }).ToArray();
            }
        }

        public ClassesModel[] GetUserClasses(int userId)
        {
            var user = DatabaseAccessor.Instance.User
                .FirstOrDefault(t => t.UserId == userId);

            //return user.Class.ToArray();
            return user.Class
                .Select(t => new ClassesModel
                {
                    Id = t.ClassId,
                    Name = t.ClassName,
                    Description = t.ClassDescription,
                    Price = t.ClassPrice
                }).ToArray();
        }
    }
}