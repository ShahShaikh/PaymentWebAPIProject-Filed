using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PaymentAPI.Data
{
    interface IPremiumPayment
    {
        HttpStatusCode PremiumPaymentProcess([FromBody] Payment payment);
    }
}
