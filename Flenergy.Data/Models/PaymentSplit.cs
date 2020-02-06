using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class PaymentSplit : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentSplitId { get; set; }
        [RegularExpression("^[a-z- .A-Z]*$", ErrorMessage = "Only Alphabets allowed")]
        public string AccountName { get; set; }
        [RegularExpression("^[+0-9]*$", ErrorMessage = "Number Only.")]
        [MaxLength(10)]
        public string AccountNumber { get; set; }

      

        [Display(Name = "Do not deduct Charges from this account")]
        public bool DeductFeeFrom { get; set; }

        [Display(Name = "Is Estate Account?")]
        public bool IsEstateAccount { get; set; }


        [Display(Name = "Is Admin Account?")]
        public bool IsAdminAccount { get; set; }

        [Display(Name = "Is Technical Charge Account?")]
        public bool IsTechnicalChargeAccount { get; set; }

        [RegularExpression("^[+0-9]*$", ErrorMessage = "Number Only.")]
        public string BankCode { get; set; }

        public int EstateId { get; set; }
        public Estate Estate { get; set; }



    }
}
