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
        }
    }
}
