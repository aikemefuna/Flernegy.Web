using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class EstateConfig : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstateConfigId { get; set; }
        public string  ApiKey { get; set; }
        public string MerchantId { get; set; }


        /// <summary>
        /// Navigation Properties
        /// </summary>
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public int Adm_GatewayId { get; set; }
        public Adm_Gateway Adm_Gateway { get; set; }
    }
}
