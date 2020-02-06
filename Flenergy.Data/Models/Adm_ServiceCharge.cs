using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Adm_ServiceCharge : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Adm_ServiceChargeId { get; set; }
        public double ChargeRate { get; set; }
        public double TechnicalCharge { get; set; }
        public string ChargeType { get; set; }
        public bool IsChargeSplitted { get; set; }

        public int EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
