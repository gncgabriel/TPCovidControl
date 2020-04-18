using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidView.Models
{
    [Table("Covid_Infos")]
    public class CovidInfo
    {
        [Display(Name ="Casos confimados")]
        public int? Casos_Confirmados { get; set; }
        
        [Display(Name ="Mortes")]
        public int? Mortes { get; set; }

        [Display(Name ="Recuperados")]
        public int? Recuperados { get; set; }

        public string pais { get; set; }

        [Key]
        public int id { get; set; }
    }
}
