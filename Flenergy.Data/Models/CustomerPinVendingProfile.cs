using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class CustomerPinVendingProfile : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerPinVendingProfileId { get; set; }
        public float Amount { get; set; }
        public DateTime DatePurchased { get; set; }
        public string Units { get; set; }
        public string Pin { get; set; }



        /// <summary>
        /// Navigation Properties
        /// </summary>

        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
        public int EstateResidentId { get; set; }
        public Customer EstateResident { get; set; }
    }
}
