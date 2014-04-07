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
     [Table("OpportunityMajor")]
    public class OpportunityMajor
    {
         [Key]
         [Column(Order = 0)]
         public int MajorId { get; set; }
         [Key]
         [Column(Order = 1)]
         public int OpportunityId { get; set; }
        public virtual Major Major { get; set; }
        public virtual Opportunity Opportunity { get; set; }
    }
}