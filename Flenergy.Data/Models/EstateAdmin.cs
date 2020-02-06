
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class EstateAdmin : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstateAdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public string Password { get; set; }
        public string EstateAdminNumber { get; set; }
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public string FullName
        {
            get { return LastName + " " + FirstName + " " + MiddleName; }
        }
    }
}
