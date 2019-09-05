using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using adiquirentesAPI.Models;
using adiquirentesAPI.DTOs;
using System.Linq.Expressions;


namespace adiquirentesAPI.Controllers
{
    [RoutePrefix("api/taxas")]
    public class TaxasController : ApiController
    {
        private adiquirentesAPIContext db = new adiquirentesAPIContext();

        // Typed lambda expression for Select() method. 
        private static readonly Expression<Func<Taxas, TaxasDto>> AsTaxasDto =
            x => new TaxasDto
            {
                Adiquirente = x.Adiquirente.Name,
                Bandeira = x.Bandeira,
                credito = x.credito,
                debito = x.debito
            };

        [Route("ListaAdiquirentes")]
        [HttpGet]
        public IQueryable<TaxasDto> GetAdiquirente()
        {
            return db.Taxas.Include(b => b.Adiquirente)
                .Where(b => b.AdiquirenteID == b.Adiquirente.AdiquirenteID)
                .Select(AsTaxasDto);
        }
        

        // POST: api/Taxas
        [Route("CalculaTaxas")]
        [HttpPost]
        public IHttpActionResult PostAdiquirentes([FromBody]decimal Valor, [FromBody]string Bandeira, [FromBody]char Adiquirente, [FromBody]string Tipo, [FromBody] TaxasDto taxas)
        {
            try
            {
                decimal acrescimo = 0;

                if (Tipo == "credito")
                {
                    var taxaCobrada = (from tx in db.Taxas.Include(b => b.Adiquirente)
                                       where tx.Bandeira == Bandeira && tx.Adiquirente.AdiquirenteAbre == Adiquirente
                                       select tx.credito).FirstOrDefaultAsync();
                    acrescimo = (Valor * Convert.ToDecimal(taxaCobrada)) / 100;
                }
                else if (Tipo == "debito")
                {
                    var taxaCobrada = (from tx in db.Taxas.Include(b => b.Adiquirente)
                                       where tx.Bandeira == Bandeira && tx.Adiquirente.AdiquirenteAbre == Adiquirente
                                       select tx.debito).FirstOrDefaultAsync();
                    acrescimo = (Valor * Convert.ToDecimal(taxaCobrada)) / 100;
                }

                decimal valorTotal = (Valor + acrescimo);

                taxas.ValorLiquido = valorTotal;

                return Ok(taxas.ValorLiquido);




            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaxasExists(int id)
        {
            return db.Taxas.Count(e => e.TaxasId == id) > 0;
        }
    }
}