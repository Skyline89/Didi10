using Didi10Rugby.Help;
using Didi10Rugby.Models;
using Didi10Rugby.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Didi10Rugby.Controllers
{

    public class AccountController : Controller
    {
        //create database global object and check it
        Didi10dbDataContext db;
        public AccountController()
        {
            if (db == null)
            {
                db = new Didi10dbDataContext();
            }
        }
        //Registration without parametre
        public ActionResult Registration()
        {
            return View();
        }
        //Registration with parametre
        [HttpPost]
        public ActionResult Registration(MyRegistrationModel myRegistrationModel)
        {
            var unRegistredUser = new UnRegistredUser()
            {
                Name = myRegistrationModel.Name,
                Surname = myRegistrationModel.SurName,
                BornDate = myRegistrationModel.BornDate,
                Age = myRegistrationModel.Age,
                Address = myRegistrationModel.Address,
                Team = myRegistrationModel.Team,
                Phone = myRegistrationModel.Phone,
                UserCategory = myRegistrationModel.UserCategory,
                Email = myRegistrationModel.Email,
                CreatDate = DateTime.UtcNow,
                Password = AccountHelper.GetHash256ByString(myRegistrationModel.Password + AccountHelper.AuthSecret),
                ConfirmationCode = AccountHelper.RandomString()
            };
            db.UnRegistredUsers.InsertOnSubmit(unRegistredUser);
            db.SubmitChanges();
            return View();
        }
        public ActionResult Confirmation(string id)
        {
            var unRegistredUser = db.UnRegistredUsers.FirstOrDefault(s => s.ConfirmationCode == id);
            //var myRegistrationModel = new MyRegistrationModel();

            if (unRegistredUser.UserCategory == "მოთამაშე")
            {
                db.Players.InsertOnSubmit(
                    new Player()
                    {
                        PlayerName = unRegistredUser.Name,
                        PlayerSurname = unRegistredUser.Surname,
                        BornDate = unRegistredUser.BornDate,
                        Age = unRegistredUser.Age,
                        Address = unRegistredUser.Address,
                        PhoneNumber = unRegistredUser.Phone,
                        Email = unRegistredUser.Email,
                        Password = unRegistredUser.Password,
                    });
                db.SubmitChanges();

                db.UnRegistredUsers.DeleteAllOnSubmit(
                    db.UnRegistredUsers.Where(s => s.Email == unRegistredUser.Email));
                db.SubmitChanges();
            return RedirectToAction("Registration");
        }
            else if(unRegistredUser.UserCategory == "მწვრთნელი")
            {
                db.Coaches.InsertOnSubmit(
                  new Coach()
        {
            Name = unRegistredUser.Name,
                   Surname = unRegistredUser.Surname,
                   BornDate = unRegistredUser.BornDate,
                   Address = unRegistredUser.Address,
                   PhoneNumber = unRegistredUser.Phone,
                   Email = unRegistredUser.Email,
                   Password = unRegistredUser.Password,
                  });
                db.SubmitChanges();
                db.UnRegistredUsers.DeleteAllOnSubmit(
                    db.UnRegistredUsers.Where(s => s.Email == unRegistredUser.Email));
                db.SubmitChanges();
                return RedirectToAction("Registration");
            }
            return RedirectToAction("Registration");
        }
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {

            string password = AccountHelper.GetHash256ByString(login.Password + AccountHelper.AuthSecret);
            var player = db.Players.FirstOrDefault(s => s.Email == login.Email && s.Password == login.Password);
            if  (player == null)
            {
                ViewBag.error = "ასეთი მოთამაშე არ არსებობს";
            }

            var coach = db.Coaches.FirstOrDefault(s => s.Email == login.Email && s.Password == login.Password);
            if (coach == null)
            {
                ViewBag.error = "ასეთი მწვერთნელი არ არსებობს";
            }
            return View();
        }

    }
}