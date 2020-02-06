using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Flenergy.Data.Models
{
    public class BaseEntity
    {
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Created User")]
        public string UserCreated { get; set; }

        [Display(Name = " Date Modified")]
        public DateTime? DateModified { get; set; }

        [Display(Name = "Modified User")]
        public string UserModified { get; set; }
    }
}
