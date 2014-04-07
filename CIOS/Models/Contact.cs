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
    [Table("Contact")]
    public class Contact
    {
        public Contact()
        {
            this.Employers = new HashSet<Employer>();
            this.LearningAgreements = new HashSet<LearningAgreement>();
            this.Opportunities = new HashSet<Opportunity>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int contactId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<LearningAgreement> LearningAgreements { get; set; }
        public virtual ICollection<Opportunity> Opportunities { get; set; }
    }
}