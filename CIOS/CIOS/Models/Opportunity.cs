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
    [Table("Opportunity")]
    public class Opportunity
    {
        public Opportunity()
        {
            this.Evaluations = new HashSet<Evaluation>();
            this.Majors = new HashSet<Major>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int opportunityId { get; set; }
        public int employerId { get; set; }
        public int contactId { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public Nullable<bool> compensated { get; set; }
        public Nullable<double> payRate { get; set; }
        public System.DateTime applicationDeadline { get; set; }
        public string positionDescription { get; set; }
        public string contactMailingAddress { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<Major> Majors { get; set; }
    }
}