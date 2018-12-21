namespace BlockbusterGames.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConsoleTypes",
                c => new
                    {
                        ConsoleTypeId = c.Int(nullable: false, identity: true),
                        Console_type = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConsoleTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        price = c.Int(nullable: false),
                        Release_Date = c.DateTime(nullable: false),
                        GenreId = c.Int(nullable: false),
                        ConsoleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.ConsoleTypes", t => t.ConsoleTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.ConsoleTypeId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        GenreType = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        No_Of_Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "GameId", "dbo.Games");
            DropForeignKey("dbo.Rents", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Games", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Games", "ConsoleTypeId", "dbo.ConsoleTypes");
            DropIndex("dbo.Rents", new[] { "GameId" });
            DropIndex("dbo.Rents", new[] { "CustomerId" });
            DropIndex("dbo.Games", new[] { "ConsoleTypeId" });
            DropIndex("dbo.Games", new[] { "GenreId" });
            DropTable("dbo.Rents");
            DropTable("dbo.Genres");
            DropTable("dbo.Games");
            DropTable("dbo.Customers");
            DropTable("dbo.ConsoleTypes");
        }
    }
}
