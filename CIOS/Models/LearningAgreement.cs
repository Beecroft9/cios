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
    [Table("LearningAgreement")]
    public class LearningAgreement
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int learningAgreementId { get; set; }
        public int studentId { get; set; }
        public int employerId { get; set; }
        public int contactId { get; set; }
        public string courseNumber { get; set; }
        public int courseCreditHours { get; set; }
        public int expectedHours { get; set; }
        public Nullable<double> hourlyPay { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime endDate { get; set; }
        public string objectives { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Student Student { get; set; }
    }
}