using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace adiquirentesAPI.Models
{
    public class Adiquirente
    {
        public int AdiquirenteID { get; set; }
        [Required]

        public char AdiquirenteAbre { get; set; }

        public string Name { get; set; }
    }
}