using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite
{
    public interface IClassesManager
    {
        ClassesManagerModel GetClasses(int classId);  //was (int userId);
        //ClassesModel Add(int userId, int classId);
        ClassesManagerModel[] GetAllClasses { get; }
        ClassesManagerModel[] GetUserClasses(int userId);
    }

    public class ClassesManagerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ClassesManagerModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
        }
    }

    public class ClassesManager : IClassesManager
    {
        private readonly IClassesRepository classesRepository;
        private readonly IUserRepository userRepository;

        public ClassesManager(IClassesRepository classesRepository,
            IUserRepository userRepository)
        {
            this.classesRepository = classesRepository;
            this.userRepository = userRepository;
        }

        public ClassesManagerModel GetClasses(int classId)
        {
            //var classes = classesRepository.GetClass(classId);

            //return new ClassesModel
            //{
            //    Id = classes.Id,
            //    Name = classes.Name,
            //    Description = classes.Description,
            //    Price = classes.Price
            //};
            return null;
        }

        public ClassesManagerModel[] GetAllClasses
        {
            get
            {
                return classesRepository.GetAllClasses
                    .Select(t => new ClassesManagerModel(t.Id, t.Name, t.Description, t.Price))
                    .ToArray();
            }
        }

        public ClassesManagerModel[] GetUserClasses(int userId)
        {
            var classes = classesRepository.GetUserClasses(userId)
                .Select(t => new ClassesManagerModel(t.Id, t.Name, t.Description, t.Price))
                .ToArray();

            return classes;
        }
    }
}