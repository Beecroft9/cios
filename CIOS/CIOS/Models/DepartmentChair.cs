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
    [Table("DepartmentChair")]
    public class DepartmentChair
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int departmentChairId { get; set; }
        public int UserId { get; set; }
        public int departmentId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }

        public virtual Department Department { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}