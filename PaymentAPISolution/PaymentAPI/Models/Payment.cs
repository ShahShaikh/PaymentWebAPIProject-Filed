using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PaymentAPI.Models
{
    [Table("Payment")]
    public class Payment
    {

        [Key]
        public Guid PaymentID { get; set; }

        [Required]
        [CreditCard]
        [Column("CreditCardNumber")]
        public string CCN { get; set; }

        [Required]
        public string CardHolder { get; set; }

        [Required]
        [Column("ExpirationDate")]
        [ValidateDate]
        public DateTime ExpireDate { get; set; }

        [StringLength(3)]
        public string SecurityCode { get; set; }

        [Required]
        [Range(1.0, Double.MaxValue)]
        public decimal Amount { get; set; }
    }

    public enum PaymentStat
    {
        processed,
        Pending,
        failed
    }

    //Custom ExpireDate Validator
    public class ValidateDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if (dateTime >= DateTime.Now)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}