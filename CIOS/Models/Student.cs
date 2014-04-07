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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CIOS.Models
{
    /**
    * Class Name: 
    * Class Purpose: 
    * 
    * Date Created: 
    * Last Modified: 
    * @author 
    */
    [Table("Student")]
    public class Student
    {
        public Student()
        {
            this.Dropboxes = new HashSet<Dropbox>();
            this.Evaluations = new HashSet<Evaluation>();
            this.LearningAgreements = new HashSet<LearningAgreement>();
            this.StudentAppointments = new HashSet<StudentAppointment>();
            this.StudentMajors = new HashSet<StudentMajor>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }
        public int UserId { get; set; }
        public string altEmailAddress { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string eNumber { get; set; }
        public string altPhone { get; set; }
        public string cellPhone { get; set; }
        public string targetSemester { get; set; }
        public Nullable<bool> internshipCompleted { get; set; }
        public int addressId { get; set; }
        public bool isActive { get; set; }
        public System.DateTime lastAccess { get; set; }
        public bool hasInternship { get; set; }
        
        public virtual Address Address { get; set; }
        public virtual ICollection<Dropbox> Dropboxes { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<LearningAgreement> LearningAgreements { get; set; }
        public virtual ICollection<StudentAppointment> StudentAppointments { get; set; }
        public virtual ICollection<StudentMajor> StudentMajors { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}