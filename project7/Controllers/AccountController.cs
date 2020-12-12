using project7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace project7.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
      
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // поиск пользователя в бд
                User user = null;
                using (ProjectContext db = new ProjectContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.login && u.Password == model.password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.login, true);
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем есть ");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (ProjectContext db = new ProjectContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Login == model.login);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (ProjectContext db = new ProjectContext())
                    {
                        db.Users.Add(new User { Login = model.login, Password = model.Password, Birthdate = model.birthdate, Name=model.name, Surname=model.surname });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Login == model.login && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }
            }

            return View(model);
        }



        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
