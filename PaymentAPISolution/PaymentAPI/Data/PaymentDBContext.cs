using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaymentAPI.Data
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PaymentDBContext, PaymentAPI.Migrations.Configuration>("PaymentDBContext"));
        }
        public DbSet<Payment> payment { get; set; }

        public DbSet<PaymentStatus> paymentstatus { get; set; }
    }
}