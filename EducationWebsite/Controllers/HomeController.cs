using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EducationWebsite.Models;

namespace EducationWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IClassesManager classesManager;
        private readonly IClassesRepository classesRepository;
        private readonly IUserRepository userRepository;

        public HomeController(IUserManager userManager,
                              IClassesManager classesManager,
                              IClassesRepository classesRepository,
                              IUserRepository userRepository)
        {
            this.userManager = userManager;
            this.classesManager = classesManager;
            this.classesRepository = classesRepository;
            this.userRepository = userRepository;
        }

        //public HomeController()
        //{

        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Register(registerModel.Email, registerModel.Password);

                return Redirect("/Home/LoginBeta");
            }

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult LoginBeta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginBeta(LogInModel logInModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.LogIn(logInModel.Email, logInModel.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "User name and password do not match.");
                }
                else
                {
                    Session["User"] = new EducationWebsite.Models.UserModel { Id = user.Id, Name = user.Name };

                    System.Web.Security.FormsAuthentication.SetAuthCookie(logInModel.Email, false);

                    return Redirect(returnUrl ?? "~/");
                }
            }

            return View(logInModel);
        }
        

        public PartialViewResult DisplayLoginName()
        {
            return new PartialViewResult();
        }

        public ActionResult ClassList()
        {
            var classList = classesManager.GetAllClasses
                .Select(t => new Models.ClassesModel(t.Id, t.Name, t.Description, t.Price))
                .ToArray();


            var model = new AllClassesModel { AllClasses = classList };
            return View(model);
        }

        public ActionResult Enroll()
        {
            var classList = classesManager.GetAllClasses
                .Select(t => new Models.ClassesModel(t.Id, t.Name, t.Description, t.Price))
                .ToArray();
            var model = new AllClassesModel { AllClasses = classList };

            return View(model);
        }

        [HttpPost]
        public ActionResult Enroll(AllClassesModel classesName)
        {


            var userGet = (EducationWebsite.Models.UserModel)Session["User"];
            var user = DatabaseAccessor.Instance.User
                .FirstOrDefault(t => t.UserId == userGet.Id);

            var classes = DatabaseAccessor.Instance.Class
                .FirstOrDefault(t => t.ClassName == classesName.SelectedClass);

            user.Class.Add(classes);

            DatabaseAccessor.Instance.SaveChanges();


            return Redirect("/Home/CurrentEnrolledClasses");
        }

        public ActionResult CurrentEnrolledClasses()
        {
            if (Session["User"] == null)
            {
                return Redirect("/Home/LoginBeta");
            }
            else
            {


                var user = (EducationWebsite.Models.UserModel)Session["User"];
                var user1 = userRepository.GetUser(user.Id);

                var classes = classesManager.GetUserClasses(user1.Id)
                    .Select(t => new EducationWebsite.Models.UserClassesModel
                    {
                        ClassId = t.Id,
                        ClassName = t.Name,
                        ClassDescription = t.Description,
                        ClassPrice = t.Price
                    }).ToArray();

                return View(classes);
            }
        }

        
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Index");
        }


        public ActionResult AddClassToUser(int userId, int classId)
        {
            //var data = new EduWebSiteEntities();
            //var user = DatabaseAccessor.Instance.User
            //    .FirstOrDefault(t => t.UserId == userId);

            //var classes = DatabaseAccessor.Instance.Class
            //    .FirstOrDefault(t => t.ClassId == classId);

            //user.Class.Add(classes);

            //DatabaseAccessor.Instance.SaveChanges();
            
            return View();
        }
    }
}