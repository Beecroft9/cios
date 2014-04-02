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
    [Table("Address")]
    public partial class Address
    {
        public Address()
        {
            this.Employers = new HashSet<Employer>();
            this.Students = new HashSet<Student>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int addressId { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }

        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}