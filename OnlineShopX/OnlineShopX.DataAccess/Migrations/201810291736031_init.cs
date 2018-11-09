namespace OnlineShopX.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.Int(nullable: false),
                        CategoryPicture = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductPrice = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailabeSize = c.Int(nullable: false),
                        AvailabeColor = c.String(),
                        Color = c.String(),
                        Size = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Picture = c.Byte(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderNumber = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Delivered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderNumber = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        SalesTax = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        TransactionStatus = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        Payment_PaymentId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Payments", t => t.Payment_PaymentId)
                .Index(t => t.Payment_PaymentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        BillingAddress = c.String(),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.PaymentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Address = c.String(),
                        City = c.Int(nullable: false),
                        Gender = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CustomersOrders",
                c => new
                    {
                        Customers_CustomerId = c.Int(nullable: false),
                        Orders_OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customers_CustomerId, t.Orders_OrderId })
                .ForeignKey("dbo.Customers", t => t.Customers_CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_OrderId, cascadeDelete: true)
                .Index(t => t.Customers_CustomerId)
                .Index(t => t.Orders_OrderId);
            
            CreateTable(
                "dbo.OrdersOrderDetails",
                c => new
                    {
                        Orders_OrderId = c.Int(nullable: false),
                        OrderDetail_OrderDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Orders_OrderId, t.OrderDetail_OrderDetailId })
                .ForeignKey("dbo.Orders", t => t.Orders_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_OrderDetailId, cascadeDelete: true)
                .Index(t => t.Orders_OrderId)
                .Index(t => t.OrderDetail_OrderDetailId);
            
            CreateTable(
                "dbo.OrderDetailProducts",
                c => new
                    {
                        OrderDetail_OrderDetailId = c.Int(nullable: false),
                        Products_ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderDetail_OrderDetailId, t.Products_ProductId })
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetail_OrderDetailId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Products_ProductId, cascadeDelete: true)
                .Index(t => t.OrderDetail_OrderDetailId)
                .Index(t => t.Products_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OrderDetailProducts", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetailProducts", "OrderDetail_OrderDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.Orders", "Payment_PaymentId", "dbo.Payments");
            DropForeignKey("dbo.OrdersOrderDetails", "OrderDetail_OrderDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.OrdersOrderDetails", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.CustomersOrders", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.CustomersOrders", "Customers_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderDetailProducts", new[] { "Products_ProductId" });
            DropIndex("dbo.OrderDetailProducts", new[] { "OrderDetail_OrderDetailId" });
            DropIndex("dbo.OrdersOrderDetails", new[] { "OrderDetail_OrderDetailId" });
            DropIndex("dbo.OrdersOrderDetails", new[] { "Orders_OrderId" });
            DropIndex("dbo.CustomersOrders", new[] { "Orders_OrderId" });
            DropIndex("dbo.CustomersOrders", new[] { "Customers_CustomerId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Orders", new[] { "Payment_PaymentId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropTable("dbo.OrderDetailProducts");
            DropTable("dbo.OrdersOrderDetails");
            DropTable("dbo.CustomersOrders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Payments");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
