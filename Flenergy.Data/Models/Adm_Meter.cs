using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Adm_Meter: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Adm_MeterId { get; set; }
        public string Meterno { get; set; }
        public string MeterType { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer{ get; set; }



        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
