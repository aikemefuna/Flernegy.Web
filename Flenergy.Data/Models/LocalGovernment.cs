using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class LocalGovernment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalGovernmentId { get; set; }

        [Display(Name = "Local Govt.")]
        public string LocalGovernmentName { get; set; }
        public int StateId { get; set; }
        public AdmStates AdmStates { get; set; }
    }
}
