using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace adiquirentesAPI.Models
{
    public class Taxas
    {
        public int TaxasId { get; set; }
        [Required]
        public string Bandeira { get; set; }
        public decimal credito { get; set; }
        public decimal debito { get; set; }
        public int AdiquirenteID { get; set; }
        [ForeignKey("AdiquirenteID")]
        public Adiquirente Adiquirente { get; set; }
    }
}