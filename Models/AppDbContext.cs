using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Agencia_Viagens01.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Itens> Itens { get; set; }
        public DbSet<PacoteViagem> PacoteViagem { get; set; }
        public DbSet<Compra> Compra { get; set; }



    }
}

﻿
