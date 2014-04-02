/**
 * --------------------------------------------------------------------------------------------------------
 * File Name:
 * Project Name:
 * --------------------------------------------------------------------------------------------------------
 * Author's Name and Email: Elijah Laws (lawseb@goldmail.etsu.edu)
 * Course-Section:
 * Creation Date:
 * Last Modified: (Name, Date, Email)
 * --------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using CIOS.Models;
using CIOS.DAL;


namespace CIOS.Controllers
{
    /**
    * Class Name: 
    * Class Purpose: 
    * 
    * Date Created: 
    * Last Modified: 
    * @author 
    */
    [Authorize(Roles = "Personnel")]
    public class CreateNewUserController : Controller
    {
        private CbatContext db = new CbatContext();

        //
        // GET: /CreateNewUser/
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public ActionResult Index()
        {
            var cspersonnels = db.CSPersonnels.Include(c => c.UserProfile);
            return View(cspersonnels.ToList());
        }

        //
        // GET: /CreateNewUser/Details/5
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public ActionResult Details(int id = 0)
        {
            CSPersonnel cspersonnel = db.CSPersonnels.Find(id);
            if (cspersonnel == null)
            {
                return HttpNotFound();
            }
            return View(cspersonnel);
        }

        //
        // GET: /CreateNewUser/Create
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName");
            return View();
        }

        //
        // POST: /CreateNewUser/Create
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CSPersonnel cspersonnel)
        {
            if (ModelState.IsValid)
            {
                // I would really like a transaction here.... 
                CSPersonnel cp = new CSPersonnel();

                cp.firstName = cspersonnel.firstName;
                cp.lastName = cspersonnel.lastName;
                cp.middleName = cspersonnel.middleName;

                cp.lastAccess = DateTime.Now;


                try
                {

                    if (WebSecurity.Initialized == false)
                    {
                        // WebSecurity is used to create the new user and account.
                        WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                       "UserProfile", "UserId", "UserName", autoCreateTables: false);
                    }

                    string password = Membership.GeneratePassword(12, 1);

                    // Create both the user and account.
                    WebSecurity.CreateUserAndAccount(cspersonnel.UserProfile.UserName, password, new { email = cspersonnel.UserProfile.Email });
                    
                    // Assign a user to a role.
                    Roles.AddUserToRole(cspersonnel.UserProfile.UserName, "Student");

                    // Update the foreign key in cp
                    cp.UserId = (int)Membership.GetUser(cspersonnel.UserProfile.UserName).ProviderUserKey;

                    // save cspersonnel to db
                    db.CSPersonnels.Add(cp);
                    db.SaveChanges();

                    CIOS.Email.EmailSystem email = new CIOS.Email.EmailSystem();

                    email.toEmail = cspersonnel.UserProfile.Email;
                    email.subject = "CIOS: New Account Created";
                    email.body = "You can log into your account with the following information:\n" +
                        "Username: " + cspersonnel.UserProfile.UserName + "\n" +
                        "Password: " + password + "\n\n" +
                        "Please log into the CIOS system and change your password.";

                    email.sendNewEmail();

                    return RedirectToAction("Index");



                } catch (System.Web.Security.MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", "The username already exists.");
                }
            }

           // ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(cspersonnel);
        }

        //
        // GET: /CreateNewUser/Edit/5
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public ActionResult Edit(int id = 0)
        {
            CSPersonnel cspersonnel = db.CSPersonnels.Find(id);
            if (cspersonnel == null)
            {
                return HttpNotFound();
            }
        //    ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(cspersonnel);
        }

        //
        // POST: /CreateNewUser/Edit/5
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CSPersonnel cspersonnel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cspersonnel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(cspersonnel);
        }

        //
        // GET: /CreateNewUser/Delete/5
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        public ActionResult Delete(int id = 0)
        {
            CSPersonnel cspersonnel = db.CSPersonnels.Find(id);
            if (cspersonnel == null)
            {
                return HttpNotFound();
            }
            return View(cspersonnel);
        }

        //
        // POST: /CreateNewUser/Delete/5
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            

            if (WebSecurity.Initialized == false)
            {
                // WebSecurity is used to create the new user and account.
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
               "UserProfile", "UserId", "UserName", autoCreateTables: false);
            }

            CSPersonnel cspersonnel = db.CSPersonnels.Find(id);
            string username = cspersonnel.UserProfile.UserName;
            db.CSPersonnels.Remove(cspersonnel);
            db.SaveChanges();

            Roles.RemoveUserFromRole(username, "Personnel");
            ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(username); // deletes record from webpages_Membership table
            ((SimpleMembershipProvider)Membership.Provider).DeleteUser(username, true); // deletes record from UserProfile table
            
            return RedirectToAction("Index");
        }
        /**
        * Method Name:
        * Method Purpose:
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: 
        * @return 
        */
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}