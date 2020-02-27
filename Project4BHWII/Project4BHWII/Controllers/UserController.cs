using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project4BHWII.Models;
using Project4BHWII.Models.Database;

namespace Project4BHWII.Controllers
{
    public class UserController : Controller
    {
        private IRepUser rep;
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View(new User());
        }


        [HttpPost]
        public ActionResult Login(User UserDaten)
        {
            UserDaten.Firstname = "Holzi";
            UserDaten.Username = "Holzi";
            Session["User"] = UserDaten;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Registration(User userFromForm)
        {
            if(userFromForm == null)
            {
                return RedirectToAction("Registration");
            }

            if (!ModelState.IsValid)
            {
                return View(userFromForm);
            }
            else
            {
                rep = new RepUserDB();
                rep.Open()
                if(rep.Insert(userFromForm))
                {
                    rep.Close();
                    return View("Message", new Message("Registrierung erfolgeich", "Ihre Daten wurden erfolgreich gespeichert"));
                }
                rep.Close();
            }
           
            return View();
        }

        public void CheckUserData(User user)
        {
            if(user == null) { return; }
            if(!CheckFirstName(user.Firstname))
            {
                ModelState.AddModelError("Firstname","Firstname ist ein Pflichfeld");
            }
            
            if(!CheckLastName(user.Lastname))
            {
                ModelState.AddModelError("Lastname", "Lastname ist ein Pflichfeld");
            }

            if (!CheckUsername(user.Username))
            {
                ModelState.AddModelError("Username", "Username ist ein Pflichfeld");

            }
            if (!CheckPassword(user.Password))
            {
                ModelState.AddModelError("Password", "Password muss mind. 8 Zeichen lang sein, mind. 1 Kleinbuchstaben und 1 Großbuchstaben und ein Sonderzeichen enthalten");
            }
            if (!CheckPassword2(user.Password, user.Password2))
            {
                ModelState.AddModelError("Password", "Die Passwörter müssen ubereinstimmen");
            }

        }

        public bool CheckFirstName(String Firstname)
        {
            if (String.IsNullOrEmpty(Firstname.Trim()))
            {
                return false;
            }
            
            return true;
        }
        public bool CheckLastName(String Lastname)
        {
            if (String.IsNullOrEmpty(Lastname.Trim()))
            {
                return false;
            }
            return true;
        }

        public bool CheckUsername(String username)
        {
            if (String.IsNullOrEmpty(username.Trim()))
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword(String password)
        {
            string pwd = password.Trim();
            if (pwd.Length < 8)
            {
                return false;
            }

            if (!PasswordContainsLowerCase(pwd, 1))
            {
                return false;
            }
            if (!PasswordContainsUpperCase(pwd, 1))
            {
                return false;
            }
            if (!PasswordContainsSpecialCharacter(pwd, 1))
            {
                return false;
            }
            if (!PasswordContainsLetter(pwd, 1))
            {
                return false;
            }
            return true;
        }

        public bool CheckPassword2(String password, String password2)
        {
            if(password.Trim() != password2.Trim())
            {
                return false;
            }
            return true;
        }

        private bool PasswordContainsLowerCase(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLower(c))
                {
                    count++;
                }
            }

            return count >= minCount;
        }

        private bool PasswordContainsUpperCase(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }

            return count >= minCount;
        }

        private bool PasswordContainsSpecialCharacter(string text, int minCount)
        {
            String allowedChars = "!§$%&/()=?{}[]#+*-_|<>^€@,;.:°#\\";
            int count = 0;
            foreach (char c in text)
            {
                if (allowedChars.Contains(c))
                {
                    count++;
                }
            }

            return count >= minCount;
        }

        private bool PasswordContainsLetter(string text, int minCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    count++;
                }
            }

            return count >= minCount;
        }
    }
}
