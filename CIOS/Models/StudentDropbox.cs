using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CIOS.Models
{
    public class StudentDropbox
    {

        [DisplayName("Editing Student: ")]
        public string name { get; set; }
        [DisplayName("Seminar Quiz")]
        public bool quiz { get; set; }
        [DisplayName("Mid-Term Memo")]
        public bool memo { get; set; }
        [DisplayName("Paper")]
        public bool paper { get; set; }
        [DisplayName("Exit Interview")]
        public bool exitInterview { get; set; }
        [DisplayName("Employer Evaluation")]
        public bool eval { get; set; }
        public int dropboxId { get; set; }

        public virtual Dropbox Dropboxes { get; set; }
        public virtual Student Student { get; set; }
    }
}