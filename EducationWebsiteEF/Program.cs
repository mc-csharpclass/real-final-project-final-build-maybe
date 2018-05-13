using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationWebsiteEF
{
    class Program
    {
        static void Main()
        {
            // Database accessor. This opens the database automatically
            var school = new EducationWebsiteEntities();

            // This accesses the ClassMaster table
            foreach (var classMaster in school.Classes)
            {
                Console.WriteLine("ClassId: {0}\nClassName: {1}\nClassDescription: {2}\nClassPrice: {3}\n",
                    classMaster.ClassId, classMaster.ClassName, classMaster.ClassDescription, classMaster.ClassPrice);
            }

            Console.Write("Done.");
            Console.ReadLine();

            //new stuff

            foreach (var students in school.Users)
            {
                //Console.WriteLine("\n{0}", students.UserName);
                Console.WriteLine("\n{0}", students.UserEmail);
                foreach (var classes in students.Classes)
                {
                    Console.WriteLine("ClassId: {0} ClassName: {1}", classes.ClassId, classes.ClassName);
                }
            }

            Console.WriteLine("\nDone");
            Console.ReadLine();
        }
    }
}
