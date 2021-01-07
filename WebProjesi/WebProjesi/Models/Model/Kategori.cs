using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProjesi.Models.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Blog> Blogs { get; set; } //blog postların olduğu bir liste içericek. her blogpost bir kategoriye aittir.
    }
}