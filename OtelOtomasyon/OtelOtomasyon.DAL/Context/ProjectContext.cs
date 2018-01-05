using OtelOtomasyon.DAL.Entities;
using OtelOtomasyon.DAL.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.DAL.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("name=dbConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());

        }

        public DbSet<Fiyat> Fiyatlar { get; set; }
        public DbSet<Kat> Katlar { get; set; }
        public DbSet<Login> Loginler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Oda> Odalar { get; set; }
        public DbSet<OdaTur> OdaTurler { get; set; }
        public DbSet<Ozellik> Ozellikler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Role> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FiyatMapping());
            modelBuilder.Configurations.Add(new KatMapping());
            modelBuilder.Configurations.Add(new LoginMapping());
            modelBuilder.Configurations.Add(new MusteriMapping());
            modelBuilder.Configurations.Add(new OdaMapping());
            modelBuilder.Configurations.Add(new OdaTurMapping());
            modelBuilder.Configurations.Add(new OzellikMapping());
            modelBuilder.Configurations.Add(new PersonelMapping());
            modelBuilder.Configurations.Add(new RezervasyonMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new SatisMapping());

            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());
        }


    }
}
