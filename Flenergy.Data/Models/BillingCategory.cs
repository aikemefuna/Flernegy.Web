using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class BillingCategory : BaseEntity
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BillingCategoryId { get; set; }
        public string BillingCategoryName { get; set; }
        public float BillingAmount { get; set; }
        public double NoOfCustomers { get; set; }
       
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public ICollection<Customer> Customers { get; set; }
     
       

    }
}
