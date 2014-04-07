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
    [Table("Evaluation")]
    public class Evaluation
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int evaluationId { get; set; }
        public int studentId { get; set; }
        public int opportunityId { get; set; }
        public string attitude { get; set; }
        public string abilityToLearn { get; set; }
        public string judgement { get; set; }
        public string dependability { get; set; }
        public string initiative { get; set; }
        public string relationshipWithOthers { get; set; }
        public string maturity { get; set; }
        public string qualityOfWork { get; set; }
        public string attendance { get; set; }
        public string punctuality { get; set; }
        public string outstandingPersonalQualities { get; set; }
        public string needToImprove { get; set; }
        public Nullable<bool> discussedWithStudent { get; set; }

        public virtual Opportunity Opportunity { get; set; }
        public virtual Student Student { get; set; }
    }
}