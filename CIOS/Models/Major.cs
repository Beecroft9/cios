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
    [Table("Major")]
    public class Major
    {
        public Major()
        {
            this.StudentMajors = new HashSet<StudentMajor>();
            this.Opportunities = new HashSet<Opportunity>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int majorId { get; set; }
        public int departmentId { get; set; }
        public string name { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<StudentMajor> StudentMajors { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}