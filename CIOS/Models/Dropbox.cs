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
    [Table("Dropbox")]
    public class Dropbox
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int dropboxId { get; set; }
        public int studentId { get; set; }
        public Nullable<bool> quiz { get; set; }
        public Nullable<bool> midTermMemo { get; set; }
        public Nullable<bool> finalReport { get; set; }
        public Nullable<bool> employerEval { get; set; }
        public Nullable<bool> exitInterview { get; set; }

        public virtual Student Student { get; set; }
    }
}