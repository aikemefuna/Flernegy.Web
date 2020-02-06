using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Flenergy.Data.Models
{
    public  class AdmStates
    {
        [Key]
        public int StateId { get; set; }

        [Display(Name = "State")]
        public string StateName { get; set; }


        public ICollection<LocalGovernment> LocalGovernments { get; set; }
      
        public AdmStates()
        {
            LocalGovernments = new Collection<LocalGovernment>();
          
        }
    }
}
