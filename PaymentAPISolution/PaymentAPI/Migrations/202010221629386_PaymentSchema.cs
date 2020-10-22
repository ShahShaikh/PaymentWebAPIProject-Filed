namespace PaymentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        PaymentID = c.Guid(nullable: false),
                        CreditCardNumber = c.String(nullable: false),
                        CardHolder = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        SecurityCode = c.String(maxLength: 3),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.PaymentStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PaymentStatus = c.String(),
                        PaymentID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Payment", t => t.PaymentID, cascadeDelete: true)
                .Index(t => t.PaymentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentStatus", "PaymentID", "dbo.Payment");
            DropIndex("dbo.PaymentStatus", new[] { "PaymentID" });
            DropTable("dbo.PaymentStatus");
            DropTable("dbo.Payment");
        }
    }
}
