﻿/**
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
    [Table("Department")]
    public class Department
    {
        public Department()
        {
            this.Advisors = new HashSet<Advisor>();
            this.DepartmentChairs = new HashSet<DepartmentChair>();
            this.Majors = new HashSet<Major>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int departmentId { get; set; }
        public string name { get; set; }

        public virtual ICollection<Advisor> Advisors { get; set; }
        public virtual ICollection<DepartmentChair> DepartmentChairs { get; set; }
        public virtual ICollection<Major> Majors { get; set; }
    }
}