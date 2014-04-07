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
    [Table("StudentAppointment")]
    public class StudentAppointment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int studentAppointmentId { get; set; }
        public int studentId { get; set; }
        public System.DateTime appointment { get; set; }
        public string targetStartTopic { get; set; }
        public string goals { get; set; }
        public Nullable<bool> resumeCoached { get; set; }
        public Nullable<bool> resumeReviewed { get; set; }
        public Nullable<bool> resumeCompleted { get; set; }
        public string classHours { get; set; }
        public string timeAvailable { get; set; }
        public string goalNotes { get; set; }
        public string resumeNotes { get; set; }
        public string factorsNotes { get; set; }
        public string studentLeads { get; set; }
        public string studentCBATOpt { get; set; }
        public string actionPlan { get; set; }

        public virtual Student Student { get; set; }
    }
}