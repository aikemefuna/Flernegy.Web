using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Disco : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DiscoId { get; set; }
        public string DiscoName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
    }
}
