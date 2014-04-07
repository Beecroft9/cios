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
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIOS.DAL;
using CIOS.Models;
using WebMatrix.WebData;
using System.Timers;

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
    public class ScheduleController : Controller
    {
        private CbatContext db = new CbatContext();

        //public Schedule currentSchedule = new Schedule();
        //
        // GET: /CSPersonnel/
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
            //db.Schedules.Add(currentSchedule);
            var dates = db.Schedules;
            return View(dates.ToList());
        }

        //
        // GET: /CSPersonnel/Details/5
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
        public ActionResult Details(int id = 2)
        {
            Schedule currentSchedule = db.Schedules.Find(id);
            if(currentSchedule == null)
            {
                return HttpNotFound();
            }
            //    ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(currentSchedule);
        }

        //
        // GET: /CSPersonnel/Edit/5
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
        public ActionResult Edit(int id = 2)
        {
            Schedule currentSchedule = db.Schedules.Find(id);
            if(currentSchedule == null)
            {
                return HttpNotFound();
            }
            //    ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(currentSchedule);
        }

        //
        // POST: /CSPersonnel/Edit/5
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
        public ActionResult Edit(Schedule currentSchedule)
        {
            TimeSpan tempDT = new TimeSpan(14, 0, 0, 0);
            if(ModelState.IsValid)
            {
                db.Entry(currentSchedule).State = System.Data.Entity.EntityState.Modified;
                currentSchedule.quizReminder = currentSchedule.quizDueDate.Subtract(tempDT);
                currentSchedule.paperReminder = currentSchedule.paperDueDate.Subtract(tempDT);
                currentSchedule.midReminder = currentSchedule.midTermDate.Subtract(tempDT);
                currentSchedule.employerEvaluationReminder = currentSchedule.evalFormDueDate.Subtract(tempDT);
                currentSchedule.evalReminder = currentSchedule.evalFormDueDate.Subtract(tempDT);
                currentSchedule.exitInterviewReminder = currentSchedule.exitInterviewDueDate.Subtract(tempDT);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(currentSchedule);
        }
    }
}
