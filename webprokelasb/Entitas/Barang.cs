using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace webprokelasb.Entitas
{
    [Table("Barang")]
    public class Barang
    {
        [Key]
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public Decimal harga { get; set; }
        public string Stok { get; set; }
    }
}