using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PaymentAPI.Models
{
    public class PaymentStatus
    {

        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentStatusID { get; set; }

        [Column("PaymentStatus")]
        public string PaymentStat { get; set; }


        //[ForeignKey("PaymentID")]
        public Guid PaymentID { get; set; }

        public virtual Payment Payment { get; set; }
    }
}