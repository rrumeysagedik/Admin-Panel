using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebProjesi.Models.Model;
//bu kısım kod ile oluşturduğumuz tabloların sqle yansıtılmasını sağlar.
namespace WebProjesi.Models.DataContext
{
    public class KisiselDBContext:DbContext
    {
        public KisiselDBContext()
        {
            Database.Connection.ConnectionString = "Data Source=.;Initial Catalog=RumeyseCF;Integrated Security=True";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Admin> Admin{ get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Hakkimda> Hakkimda { get; set; }
        public DbSet<Hizmet> Hizmet { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Kimlik> Kimlik { get; set; }
        public DbSet<Slider> Slider { get; set; }


    }
    // webconfigde connection stringi oluşturduktan sonra database i oluşturmak için package managerde migrationları enable etmek gerekiyor.
    //veritabanı için yapılan değişikleri veritabanına yansıttığımızda migration oluşuyor. Bu migrationlar bir log gibi güncelleme değişiklerini takip ediyor.güncelleme geri alma işlemlerini takip ediyor.
}