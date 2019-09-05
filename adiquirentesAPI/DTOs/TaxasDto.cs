using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adiquirentesAPI.DTOs
{
    public class TaxasDto
    {
        public string Adiquirente { get; set; }
        public string Bandeira { get; set; }
        public decimal credito { get; set; }
        public decimal debito { get; set; }          

        public decimal ValorLiquido { get; set; }
       
    }
}