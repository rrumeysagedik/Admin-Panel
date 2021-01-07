using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProjesi.Models.Model
{
    [Table("Hakkimda")] //burada özellikle table ismini belirtmesek bile database classın ismini otomatik olarak tabloya verecekti.
    public class Hakkimda
    {
        [Key]
        public int HakkımdaId { get; set; } //biz key anhtarını belirtmesek bile database ıd ibaresini gördüğünden otomatik olarak key şeklinde ayarlayacaktır.
        [Required] //required girilmesi zorunlu işlevini yerine getirir. yani açıklamayı girmek zorundayız.
        [DisplayName("Hakkımda Açıklama")]
        public string Aciklama { get; set; }
    }
}