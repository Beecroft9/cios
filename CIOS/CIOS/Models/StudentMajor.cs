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
    [Table("StudentMajor")]
    public class StudentMajor
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int studentMajorId { get; set; }
        public int studentId { get; set; }
        public int majorId { get; set; }
        public Nullable<double> overallGPA { get; set; }
        public Nullable<double> majorGPA { get; set; }
        public Nullable<int> hoursCompleted { get; set; }
        public System.DateTime expectedGraduation { get; set; }

        public virtual Major Major { get; set; }
        public virtual Student Student { get; set; }
    }
}