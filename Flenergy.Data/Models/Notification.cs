using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Flenergy.Data.Models
{
    public class Notification : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }
        public string NotificationMessage { get; set; }

        public int  EstateId { get; set; }
        public Estate Estate { get; set; }
    }
}
