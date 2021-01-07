using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProjesi.Models.Model
{
    [Table("İletişim")]
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }
        public string Whatsapp { get; set; }
        public string Fcebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }

    }
}