using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Wallet : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; }
        public string TransId { get; set; }
        public float Amount { get; set; }

        public int EstateId { get; set; }
        public Estate Estate { get; set; }


    }
}
