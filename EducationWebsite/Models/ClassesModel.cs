using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EducationWebsite.Models
{
    public class ClassesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ClassesModel(int id, string name, string description, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;

        }
    }
}