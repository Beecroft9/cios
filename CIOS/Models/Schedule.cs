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
using System.ComponentModel;
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
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        
        public int scheduleId { get; set; }
        [DisplayName("Seminar Quiz")]
        public System.DateTime quizDueDate { get; set; }
        [DisplayName("Midterm Memo")]
        public System.DateTime midTermDate { get; set; }
        [DisplayName("Paper")]
        public System.DateTime paperDueDate { get; set; }
        [DisplayName("Employer Evaluation")]
        public System.DateTime evalFormDueDate { get; set; }
        [DisplayName("Exit Interview")]
        public System.DateTime exitInterviewDueDate { get; set; }
        public System.DateTime quizReminder { get; set; }
        public System.DateTime midReminder { get; set; }
        public System.DateTime paperReminder { get; set; }
        public System.DateTime evalReminder { get; set; }
        public System.DateTime exitInterviewReminder { get; set; }
        [DisplayName("Update Employer Information")]
        public System.DateTime employerUpdateReminder { get; set; }
        public System.DateTime employerEvaluationReminder { get; set; }
    }
}