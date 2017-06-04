using Donate4Life.Models;
using Donate4Life.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Donate4Life.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Donate4LifeEntities1())
                {
                    var userWithTheSameNameExist = context.Users.Any(s => s.Email == user.Email);

                    if (userWithTheSameNameExist)
                    {
                        ModelState.AddModelError("", "Вече съществува потребител с този имейл.");
                        return View(user);
                    }

                    if (user.Password != user.ConfirmPassword)
                    {
                        ModelState.AddModelError("", "Въведените пароли се различават.");
                        return View(user);
                    }

                    context.Users.Add(new Users {
                            Email = user.Email,
                            IsAdmin = false,
                            Password = user.Password,
                            UserName = user.Username,
                            Tokens = null
                    });

                    context.SaveChanges();
                }

                TempData["success"] = "Успеина регистрация!";
            }

            return View(user);
            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Donate4LifeEntities1())
                {
                    var regUser = context.Users.FirstOrDefault(s => s.Email == user.Email);

                    if (regUser == null)
                    {
                        ModelState.AddModelError("", "Грешна парола или потребителско име.");
                        return View(user);
                    }

                    var correctPassword = regUser.Password == user.Password;
                    if (!correctPassword)
                    {
                        ModelState.AddModelError("", "Грешна парола или потребителско име.");
                        return View(user);
                    }

                    string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                    context.Tokens.Add(new Tokens
                    {
                       UserId = regUser.Id,
                       IssuedOn = DateTime.Now,
                       ExpiresOn = DateTime.Now.AddHours(2),
                       AuthToken = token
                    });

                    context.SaveChanges();

                    Session["UserId"] = regUser.Id.ToString();
                }

                TempData["success"] = "Успеина регистрация!";
            }

            return RedirectToAction("Index","Home");
        }

        
        public ActionResult Logout()
        {
            var userId = (int)Session["UserId"];
            var tokenService = new TokenService();

            tokenService.RemoveTokensByUserId(userId);
            Session["UserId"] = 0;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            try
            {
                var userId = int.Parse(Session["UserId"].ToString());

                using (var context = new Donate4LifeEntities1())
                {
                    var user = context.Users.FirstOrDefault(s => s.Id == userId);

                    if (user == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return View(new User
                    {
                        Username = user.UserName,
                        Email = user.Email
                    });
                }
            }
            catch (Exception e)
            {
                 return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeEmail(EditProfile editProfile)
        {
            if (editProfile.Email == null || editProfile.NewEmail == null || editProfile.Password == null)
            {
                TempData["errorEmail"] = "Всички полета са задължителни.";
                return RedirectToAction("EditProfile", "Account", editProfile);
            }


            using (var context = new Donate4LifeEntities1())
            {
                var user= context.Users.FirstOrDefault(s=>s.Email == editProfile.Email && s.Password ==  editProfile.Password);

                if (user == null)
                {
                    TempData["errorEmail"] = "Грешно потребителско име или парола";
                    return RedirectToAction("EditProfile", "Account", editProfile);
                }

                user.Email = editProfile.NewEmail;

                context.SaveChanges();
            }

            TempData["successChangeEmail"] = "Успешна смяна на имейл";

            return RedirectToAction("EditProfile", "Account", editProfile);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(EditProfile editProfile)
        {
            if (editProfile.Email == null || editProfile.NewPassword == null || editProfile.Password == null)
            {
                TempData["errorPass"] = "Всички полета са задължителни.";
                return RedirectToAction("EditProfile", "Account", editProfile);
            }


            using (var context = new Donate4LifeEntities1())
            {
                var user = context.Users.FirstOrDefault(s => s.Email == editProfile.Email && s.Password == editProfile.Password);

                if (user == null)
                {
                    TempData["errorPass"] = "Грешно потребителско име или парола";
                    return RedirectToAction("EditProfile", "Account", editProfile);
                }

                user.Password = editProfile.NewPassword;

                context.SaveChanges();
            }

            TempData["successChangePass"] = "Успешна смяна на паролата";

            return RedirectToAction("EditProfile", "Account", editProfile);
        }
    }
}