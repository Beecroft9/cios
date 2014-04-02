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
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CIOS.Models;

namespace CIOS.DAL
{
    /**
    * Class Name: 
    * Class Purpose: 
    * 
    * Date Created: 
    * Last Modified: 
    * @author 
    */
    public class CbatContext :DbContext
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
        public CbatContext()
            : base("DefaultConnection")
        {
            // default
        }

        public DbSet<State> States { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Advisor> Advisors { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<DepartmentChair> DepartmentChairs { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Dropbox> Dropboxes { get; set; }
        public DbSet<StudentAppointment> StudentAppointments { get; set; }
        public DbSet<StudentMajor> StudentMajors { get; set; }
        public DbSet<CSPersonnel> CSPersonnels { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<LearningAgreement> LearningAgreements { get; set; }
        public DbSet<OpportunityMajor> OpportunityMajor { get; set; }

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
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Address>().HasMany(i => i.Students).WithOptional().WillCascadeOnDelete(true);
            //modelBuilder.Entity<Student>().HasKey(j => j.UserProfile.UserId);
        }
    }
}