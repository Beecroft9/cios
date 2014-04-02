/**
 * --------------------------------------------------------------------------------------------------------
 * File Name: AccountController.cs
 * Project Name: CIOS
 * --------------------------------------------------------------------------------------------------------
 * Author's Name and Email: Lee John (johnlh@goldmail.etsu.edu) & Cody Beecroft (cody.beecroft@gmail.com)
 * Course-Section: 3350-201
 * Creation Date: 3/31/2014
 * Last Modified: (Cody Beecroft, 3/31/2014, cody.beecroft@gmail.com)
 * --------------------------------------------------------------------------------------------------------
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
//using CIOS.Filters;
using CIOS.Models;
using CIOS.DAL;
using System.Timers;

namespace CIOS.Controllers
{
    /**
     * Class Name: AccountController : Controller 
     * Class Purpose: Controls the manipulation and communication of user accounts and the system
     * 
     * Date Created: 3/1/2014
     * Last Modified: Lee John, johnlh@goldmail.etsu.edu, 3/31/2014
     * @author Lee John (johnlh@goldmail.etsu.edu) & Cody Beecroft (cody.beecroft@gmail.com)
     */
    [Authorize]
    public class AccountController : Controller
    {
        CIOS.Email.EmailSystem email = new CIOS.Email.EmailSystem();
        private CbatContext db = new CbatContext();

        /**
        * Method Name: Login
        * Method Purpose: Allows a user to log in
        * 
        * Date Created: 2/28/2014
        * Last Modified: 3/31/2014
        * 
        * Specifications, Algorithms, and Assumptions:
        * Everytime the login page is accessed, the timer checks for if there needs to be reminder updates sent
        * 
        * @param returnURL: Generic code
        * @return ActionResult: A view depending on which type of user accesses the site
        */
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            const double interval24hours = 24 * 60 * 60 * 1000;
            Timer checkforTime = new Timer(interval24hours);
            checkforTime.Elapsed += new ElapsedEventHandler(checkforTime_Elapsed);

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /**
        * Method Name: checkforTime_Elapsed
        * Method Purpose: Checks for the need for an automatic reminder to be sent and sends it
        * 
        * Date Created: 3/30/2014
        * Last Modified: 3/30/2014
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param sender: generic code
        * @param e: The arguments passed when a timer returns an Event
        */
        private void checkforTime_Elapsed(object sender, ElapsedEventArgs e)
        {
            Schedule currentSchedule = db.Schedules.Find(2);
            if(currentSchedule.midReminder <= DateTime.Now)
            {
                foreach(var v in db.Students)
                {
                    if(v.hasInternship)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Midterm Memo Reminder";
                        email.body = "Dear " + v.firstName + ",\n\n" +
                            "I am reaching out to remind you that your Midterm Memo is due in two weeks.\n" +
                            "Let me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.paperReminder <= DateTime.Now)
            {
                foreach(var v in db.Students)
                {
                    if(v.hasInternship)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Paper Reminder";
                        email.body = "Dear " + v.firstName + ",\n\n" +
                            "Papers are due in two weeks unless you have negotiated a different deadline with your faculty supervisor." +
                            "A complete description of the paper content can be found on the Deadlines Sheet you were given at the beginning of the semester." +
                            "In brief, you need to address whether you met your learning objectives and how you met them; what classes you have been able to" +
                            "apply on the job; how the experience impacted your career goal.\nLet me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.quizReminder <= DateTime.Now)
            {
                foreach(var v in db.Students)
                {
                    if(v.hasInternship)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Seminar Quiz Reminder";
                        email.body = "Dear " + v.firstName + ",\n\n" +
                            "I am reaching out to remind you that your Seminar Quiz is due in two weeks.\n" +
                            "Let me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.evalReminder <= DateTime.Now)
            {
                foreach(var v in db.Students)
                {
                    if(v.hasInternship)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Employer Evaluation Reminder";
                        email.body = "Dear " + v.firstName + ",\n\n" +
                            "Please remember to remind your supervisor of the Employer Evaluation Form for completion." +
                            "\nLet me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.exitInterviewReminder <= DateTime.Now)
            {
                foreach(var v in db.Students)
                {
                    if(v.hasInternship)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Exit Interview Reminder";
                        email.body = "Dear " + v.firstName + ",\n\n" +
                            "It is time to schedule your exit interview with me in two weeks. Please have your exit interview form completed" +
                            " and sumbitted to the dropbox by the time you come to meet with me. The exit interview is an opportunity for us to" +
                            " chat about your experience. You do not have to dress in interview attire. If you are working at some distance from ETSU," +
                            " we can complete the exit interview by phone.\nLet me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.employerUpdateReminder <= DateTime.Now)
            {
                foreach(var v in db.Employers)
                {
                    if(v.hasIntern)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Intership/Co-op information update reminder";
                        email.body = "Dear " + v.Contact.firstName + ",\n\n" +
                            "I am reaching out to remind you that your Intership/Co-op information may need to be updated.\n" +
                            "Let me know if you have any questions. Have a great day!";

                        email.sendNewEmail();
                    }
                }
            }
            if(currentSchedule.employerEvaluationReminder <= DateTime.Now)
            {
                foreach(var v in db.Employers)
                {
                    if(v.hasIntern)
                    {
                        email.toEmail = v.UserProfile.Email;
                        email.subject = "CIOS: Employer Evaluation Reminder";
                        email.body = "Dear " + v.Contact.firstName + ",\n\n" +
                            "I am reaching out to inform you that your ETSU intern requires an evalution to be made of their performance." +
                            " You will be able to find the evaluation form under your user profile on the ETSU CBAT website.\n" +
                            "Let me know if you have any questions. Hang in there!";

                        email.sendNewEmail();
                    }
                }
            }
        }

        /**
        * Method Name: Login
        * Method Purpose: POST; The message sent to the system to validate the user log in
        * 
        * Date Created: 3/1/2014
        * Last Modified: 3/30/2014
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param returnURL: Generic
        * @param model: the table used to determine if all the required fields have been filled
        * @return ActionResult: The view to display
        */
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if(ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie:model.RememberMe))
            {
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        /**
        * Method Name: LogOFf
        * Method Purpose: POST; 
        * 
        * Date Created: 
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        /**
        * Method Name:
        * Method Purpose: GET;
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        */
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /**
        * Method Name:
        * Method Purpose: POST;
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * @param model: 
        */
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if(ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { email = model.email });
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch(MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /**
        * Method Name:
        * Method Purpose: POST;
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param provider
        * @param providerUserId
        * @return ActionResult
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if(ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using(var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if(hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        /**
        * Method Name:
        * Method Purpose: GET;
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param message:
        * @return ActionResult
        */
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        /**
        * Method Name:
        * Method Purpose: POST;
        * 
        * Date Created:
        * Last Modified:
        * 
        * Specifications, Algorithms, and Assumptions:
        * 
        * 
        * @param model 
        * @return ActionResult
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if(hasLocalAccount)
            {
                if(ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch(Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if(changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if(state != null)
                {
                    state.Errors.Clear();
                }

                if(ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch(Exception)
                    {
                        ModelState.AddModelError("", String.Format("Unable to create local account. An account with the name \"{0}\" may already exist.", User.Identity.Name));
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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
        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if(Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
        }
        /**
         * Class Name: 
         * Class Purpose: Controls the manipulation and communication of user accounts and the system
         * 
         * Date Created: 
         * Last Modified:
         * @author 
         */
        internal class ExternalLoginResult :ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
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
        * @param createStatus
        * @return string
        */
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch(createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
