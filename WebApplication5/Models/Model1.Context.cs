//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NewdbEntities18 : DbContext
    {
        public NewdbEntities18()
            : base("name=NewdbEntities18")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<demande> demande { get; set; }
        public virtual DbSet<departement> departement { get; set; }
        public virtual DbSet<equipement> equipement { get; set; }
        public virtual DbSet<eya> eya { get; set; }
        public virtual DbSet<fiche_tech> fiche_tech { get; set; }
        public virtual DbSet<intervention> intervention { get; set; }
        public virtual DbSet<piece> piece { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<type> type { get; set; }
        public virtual DbSet<type_entretien> type_entretien { get; set; }
    }
}
