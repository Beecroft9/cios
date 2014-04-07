/**
 * --------------------------------------------------------------------------------------------------------
 * File Name:
 * Project Name:
 * --------------------------------------------------------------------------------------------------------
 * Author's Name and Email: Elijah Laws (lawseb@goldmail.etsu.edu), Lee John (johnlh@goldmail.etsu.edu)
 *                          Cody Beecroft (cody.beecroft@gmail.com
 * Course-Section:
 * Creation Date:
 * Last Modified: (Name, Date, Email)
 * --------------------------------------------------------------------------------------------------------
 */
namespace CIOS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CIOS.DAL;
    using CIOS.Models;
    using System.Collections.Generic;
    using System.Web.Security;
    using WebMatrix.WebData;
    using System.IO;
    using System.Reflection;
    using System.ComponentModel;
    /**
    * Class Name: 
    * Class Purpose: 
    * 
    * Date Created: 
    * Last Modified: 
    * @author 
    */
    internal sealed class Configuration :DbMigrationsConfiguration<CIOS.DAL.CbatContext>
    {
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
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CIOS.DAL.CbatContext";
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
        protected override void Seed(CIOS.DAL.CbatContext context)
        {
            Database.SetInitializer<CbatContext>(null);

            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
    "UserProfile", "UserId", "UserName", autoCreateTables:true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            // If the role does not exist, then create the role at startup.
            if(!roles.RoleExists("Personnel"))
            {
                roles.CreateRole("Personnel");
            }
            if(!roles.RoleExists("Employer"))
            {
                roles.CreateRole("Employer");
            }
            if(!roles.RoleExists("Student"))
            {
                roles.CreateRole("Student");
            }
            if(!roles.RoleExists("DepartmentChair"))
            {
                roles.CreateRole("DepartmentChair");
            }

            context.Schedules.AddOrUpdate(new Schedule { employerEvaluationReminder = new DateTime(9999, 1, 1),
                                                         employerUpdateReminder = new DateTime(9999, 1, 1),
                                                         evalFormDueDate = new DateTime(9999, 1, 1),
                                                         evalReminder = new DateTime(9999, 1, 1),
                                                         exitInterviewDueDate = new DateTime(9999, 1, 1),
                                                         exitInterviewReminder = new DateTime(9999, 1, 1),
                                                         midReminder = new DateTime(9999, 1, 1),
                                                         midTermDate = new DateTime(9999, 1, 1),
                                                         paperDueDate = new DateTime(9999, 1, 1),
                                                         paperReminder = new DateTime(9999, 1, 1),
                                                         quizDueDate = new DateTime(9999, 1, 1),
                                                         quizReminder = new DateTime(9999, 1, 1),
                                                         scheduleId = 1                                               
            });

            context.Departments.AddOrUpdate(d => d.name,
              new Department { name = "Accountancy" },
              new Department { name = "Computing" },
              new Department { name = "Economics and Finance" },
              new Department { name = "Engineering Technology, Surveying, & Digital Media" },
              new Department { name = "Management and Marketing" },
              new Department { name = "Military Science" });

            string fileName = @"~\App_Data\states.csv";

            StreamReader reader = new StreamReader(fileName);

            string[] fields;
            string theState = "";
            fields = reader.ReadLine().Split(',');

            while(reader.Peek() >= 0)
            {
                fields = reader.ReadLine().Split(',');
                theState = fields[1];
                context.States.AddOrUpdate(s => s.name,
                new State { name = theState });
            }// end while

            reader.Close();
        }
    }
}
