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
    [Table("Employer")]
    public class Employer
    {
        public Employer()
        {
            this.LearningAgreements = new HashSet<LearningAgreement>();
            this.Opportunities = new HashSet<Opportunity>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int employerId { get; set; }
        public int UserId { get; set; }
        public int contactId { get; set; }
        public int addressId { get; set; }
        public string companyName { get; set; }
        public string webAddress { get; set; }
        public int numOfEmployees { get; set; }
        public Nullable<int> numYearsInOperation { get; set; }
        public string briefDescription { get; set; }
        public bool isActive { get; set; }
        public System.DateTime lastAccess { get; set; }
        public bool hasIntern { get; set; }

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<LearningAgreement> LearningAgreements { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}