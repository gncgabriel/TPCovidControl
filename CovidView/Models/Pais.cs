using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CovidView.Models
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        [Display(Name="Nome do pais")]
        public string Nome { get; set; }

        [ForeignKey("covid_info")]
        public CovidInfo Covid_Info { get; set; }

    }
}
