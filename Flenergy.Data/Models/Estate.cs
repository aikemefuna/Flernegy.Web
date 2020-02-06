using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Estate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstateId { get; set; }
        public string EstateName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string LogoUrl { get; set; }
        public double NumberOfResident { get; set; }
        public int EstateCode { get; set; }
       
        public double NoOfCustomers { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }

        public ICollection<Customer> Customers { get; set; }
        public ICollection<BillingCategory> BillingCategories { get; set; }
        public ICollection<EstateAdmin> EstateAdmins { get; set; }
        public ICollection<Notification> Notifications { get; set; }

     
    }
}
