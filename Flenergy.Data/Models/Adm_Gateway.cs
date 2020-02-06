using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Adm_Gateway : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Adm_GatewayId { get; set; }
        public string Gateway { get; set; }
        public string SinglePaymentUrl { get; set; }
        public string SplitPaymentUrl { get; set; }
        public string StatusUrl { get; set; }
    }
}
