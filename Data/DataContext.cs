using Eventos.Identity;
using Eventos.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.Data
{
    public class DataContext : IdentityDbContext<Usuario, Papeis, int,
                                                Microsoft.AspNetCore.Identity.IdentityUserClaim<int>, UsuarioPapeis,
                                                Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<Lote> Lotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<UsuarioPapeis>(usuarioPapeis =>
            {
                usuarioPapeis.HasKey(ur => new { ur.UserId, ur.RoleId });

                usuarioPapeis.HasOne(ur => ur.papeis)
                    .WithMany(r => r.UsuarioPapeis)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                usuarioPapeis.HasOne(ur => ur.usuario)
                   .WithMany(r => r.UsuarioPapeis)
                   .HasForeignKey(ur => ur.UserId)
                   .IsRequired();
            }); 
        }
    }
}
