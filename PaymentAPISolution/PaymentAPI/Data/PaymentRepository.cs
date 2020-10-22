using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using PaymentAPI.Models;

namespace PaymentAPI.Data
{
    public class PaymentRepository : ICheapPayment, IExpensivePayment, IPremiumPayment
    {
        //CheapPaymentprocess method for IcheapPaymentGateway
        public HttpStatusCode CheapPaymentProcess([FromBody] Payment payment)
        {
            PaymentDBContext dbContext = new PaymentDBContext();
            PaymentStatus ps = new PaymentStatus();
            try
            {
                payment.PaymentID = Guid.NewGuid();
                dbContext.payment.Add(payment);
                dbContext.SaveChanges();

                ps.PaymentStat = PaymentStat.processed.ToString();// "Processed";
                ps.PaymentID = payment.PaymentID;

                dbContext.paymentstatus.Add(ps);
                dbContext.SaveChanges();


                return HttpStatusCode.OK;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                //Catch Entity validation errors
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //If transaction failed, log status as "falied"
                ps.PaymentStat = PaymentStat.failed.ToString(); // "failed";
                dbContext.SaveChanges();

                return HttpStatusCode.InternalServerError;
            }
        }

        //ExpensivePaymentprocess method for IExpensivePaymentGateway
        public HttpStatusCode ExpensivePaymentProcess([FromBody] Payment payment)
        {
            PaymentDBContext dbContext = new PaymentDBContext();
            PaymentStatus ps = new PaymentStatus();
            try
            {
                payment.PaymentID = Guid.NewGuid();
                dbContext.payment.Add(payment);
                dbContext.SaveChanges();

                ps.PaymentStat = PaymentStat.processed.ToString();// "Processed";
                ps.PaymentID = payment.PaymentID;

                dbContext.paymentstatus.Add(ps);
                dbContext.SaveChanges();


                return HttpStatusCode.OK;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                //Catch Entity validation errors
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //If transaction failed, log status as "Pending" 
                ps.PaymentStat = PaymentStat.Pending.ToString(); // "Pending";
                dbContext.SaveChanges();

                return HttpStatusCode.InternalServerError;
            }
        }

        //PremiumPaymentprocess method for IPremiumPaymentGateway
        public HttpStatusCode PremiumPaymentProcess([FromBody] Payment payment)
        {
            PaymentDBContext dbContext = new PaymentDBContext();
            PaymentStatus ps = new PaymentStatus();
            try
            {
                payment.PaymentID = Guid.NewGuid();
                dbContext.payment.Add(payment);
                dbContext.SaveChanges();

                ps.PaymentStat = PaymentStat.processed.ToString();// "Processed";
                ps.PaymentID = payment.PaymentID;

                dbContext.paymentstatus.Add(ps);
                dbContext.SaveChanges();


                return HttpStatusCode.OK;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                //to capture Entity validation errors
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

                //If transaction failed, log status as "pending"
                ps.PaymentStat = PaymentStat.Pending.ToString(); // pending payment
                dbContext.SaveChanges();

                return HttpStatusCode.InternalServerError;
            }
        }
    }
}