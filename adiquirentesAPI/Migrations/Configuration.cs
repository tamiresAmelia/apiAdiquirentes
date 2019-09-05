namespace adiquirentesAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<adiquirentesAPI.Models.adiquirentesAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(adiquirentesAPI.Models.adiquirentesAPIContext context)
        {
            //   public int AdiquirenteID { get; set; }
            //[Required]

            //public char AdiquirenteAbre { get; set; }

            //public string Name { get; set; }

            context.Adiquirentes.AddOrUpdate(new Models.Adiquirente[]
            {
                new Models.Adiquirente()
                {
                    AdiquirenteID = 1, AdiquirenteAbre = 'A', Name = "Adiquirente A"
                },
                 new Models.Adiquirente()
                {
                    AdiquirenteID = 2, AdiquirenteAbre = 'B', Name = "Adiquirente B"
                },
                  new Models.Adiquirente()
                {
                    AdiquirenteID = 3, AdiquirenteAbre = 'C', Name = "Adiquirente C"
                },
            });
            //     public int TaxasId { get; set; }
            //[Required]
            //public string Bandeira { get; set; }
            //public decimal credito { get; set; }
            //public decimal debito { get; set; }
            //public int AdiquirenteID { get; set; }
            //[ForeignKey("AdiquirenteID")]
            //public Adiquirente Adiquirente { get; set; }
            context.Taxas.AddOrUpdate(new Models.Taxas[] {
                new Models.Taxas()
                {
                    TaxasId=1, Bandeira="Visa", credito=2.25M, debito=2.00M,AdiquirenteID = 1
                },
                  new Models.Taxas()
                {
                    TaxasId=2, Bandeira="Master", credito=2.35M, debito=1.98M,AdiquirenteID = 1
                },
                new Models.Taxas()
                {
                    TaxasId=3, Bandeira="Visa", credito=2.50M, debito=2.08M,AdiquirenteID = 2
                },
                 new Models.Taxas()
                {
                    TaxasId=4, Bandeira="Master", credito=2.65M, debito=1.75M,AdiquirenteID = 2
                },
                  new Models.Taxas()
                {
                    TaxasId=5, Bandeira="Visa", credito=2.75M, debito=2.16M,AdiquirenteID =3
                },
                 new Models.Taxas()
                {
                    TaxasId=6, Bandeira="Master", credito=3.10M, debito=1.58M,AdiquirenteID =3
                },
            });
        }

    }
}
