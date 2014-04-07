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
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIOS.DAL;
//using CIOS.Filters;
using CIOS.Models;

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
    public class DeliverablesController :Controller
    {
        private CbatContext db = new CbatContext();
        public static List<StudentDropbox> tempList;
        //
        // GET: /Deliverables/
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
        public ActionResult Index(string searchTerm)
        {
            tempList = new List<StudentDropbox> { };

            var model = from p1 in db.Students
                        join p2 in db.Dropboxes
                        on p1.studentId equals p2.studentId
                        where ((p1.firstName + " " + p1.middleName + " " + p1.lastName).StartsWith(searchTerm) || searchTerm == null)
                        && p1.hasInternship == true
                        select new StudentDropbox
                        {
                            name = p1.firstName + " " + p1.middleName + " " + p1.lastName,
                            quiz = (bool)p2.quiz,
                            memo = (bool)p2.midTermMemo,
                            paper = (bool)p2.finalReport,
                            exitInterview = (bool)p2.exitInterview,
                            eval = (bool)p2.employerEval,
                            dropboxId = p2.dropboxId
                        };

            if(tempList.Count > 0)
            {
                tempList.Clear();
            }
            foreach(var t in model)
            {
                tempList.Add(t);
            }
            if(Request.IsAjaxRequest())
            {
                return PartialView("_List", model);
            }
            else
            {
                return View(model);
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
        * @param returnURL: 
        * @return 
        */
        public ActionResult SearchAutoComplete(string term)
        {

            var model = db.Students
            .Where(b => b.hasInternship == true && (b.firstName + " " + b.middleName + " " + b.lastName).StartsWith(term))
            .Take(15)
            .Select(b => new
            {
                label = b.firstName + " " + b.middleName + " " + b.lastName
            });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Deliverables/Edit/5
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
        public ActionResult Edit(int id)
        {
            StudentDropbox studbox = tempList.Find(box => box.dropboxId == id);
            if(studbox == null)
            {
                return HttpNotFound();
            }
            //    ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);
            return View(studbox);

        }

        //
        // POST: /Deliverables/Edit/5
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
        public ActionResult Edit(StudentDropbox currentDropBox)
        {


            Dropbox drp = (db.Dropboxes
                .Where(c => c.dropboxId == currentDropBox.dropboxId)).First();


            drp.employerEval = currentDropBox.eval;
            drp.exitInterview = currentDropBox.exitInterview;
            drp.finalReport = currentDropBox.paper;
            drp.midTermMemo = currentDropBox.memo;
            drp.quiz = currentDropBox.quiz;
            if(ModelState.IsValid)
            {
                db.Entry(drp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View("Index");
            //ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "UserName", cspersonnel.UserId);

        }


    }
}
