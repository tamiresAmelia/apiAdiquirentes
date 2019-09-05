namespace adiquirentesAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adiquirentes",
                c => new
                    {
                        AdiquirenteID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AdiquirenteID);
            
            CreateTable(
                "dbo.Taxas",
                c => new
                    {
                        TaxasId = c.Int(nullable: false, identity: true),
                        Bandeira = c.String(nullable: false),
                        credito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        debito = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AdiquirenteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxasId)
                .ForeignKey("dbo.Adiquirentes", t => t.AdiquirenteID, cascadeDelete: true)
                .Index(t => t.AdiquirenteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Taxas", "AdiquirenteID", "dbo.Adiquirentes");
            DropIndex("dbo.Taxas", new[] { "AdiquirenteID" });
            DropTable("dbo.Taxas");
            DropTable("dbo.Adiquirentes");
        }
    }
}
