using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace webprokelasb.Entitas
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public string KodeKategori { get; set; }
        public string NamaKategori { get; set; }

    }
}