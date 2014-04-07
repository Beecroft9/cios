/**
 * --------------------------------------------------------------------------------------------------------
 * File Name:
 * Project Name:
 * --------------------------------------------------------------------------------------------------------
 * Author's Name and Email: Lee John (johnlh@goldmail.etsu.edu) & Cody Beecroft (cody.beecroft@gmail.com)
 * Course-Section:
 * Creation Date:
 * Last Modified: (Name, Date, Email)
 * --------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using CIOS.DAL;
using CIOS.Models;
using WebMatrix.WebData;

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
    public class HomeController : Controller
    {
        CbatContext db = new CbatContext();

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
            return View();
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
       * @param returnUrl:
       * @return ActionResult
       */
        public ActionResult ForgotPassword(EmailVer model)
        {

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ForgotPassword(EmailVer model, FormCollection formData)
        {
            

                string password = Membership.GeneratePassword(12, 1);
                UserProfile prof;
                var variable = formData["Email"];

                foreach (var profile in db.UserProfiles)
                {
                    if (profile.Email == variable)
                    {
                        prof = profile;
                        var token = WebSecurity.GeneratePasswordResetToken(prof.UserName);
                        //var pwResetURL = Request.Url.GetLeftPart(UriPartial.Authority) + "/resetpassword?token=" + token;
                        WebSecurity.ResetPassword(token, password);
                        CIOS.Email.EmailSystem email = new CIOS.Email.EmailSystem();
                        email.toEmail = prof.Email;
                        email.subject = "CIOS: Password Change";
                        email.body = "Hello " + prof.UserName + ". Here's your new password: " + password + ". Please reset your password once signed in!";
                        try
                        {
                            email.sendNewEmail();
                            return RedirectToAction("Login", "Account");

                        }
                        catch (Exception e)
                        {
                            ModelState.AddModelError("", "Error occured whilst email sendage" + e.Message);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email address not found");
                        return View(model);
                    }
                }
                ModelState.AddModelError("", "Email address not found");
                return View(model);
           
        }


    }
}


