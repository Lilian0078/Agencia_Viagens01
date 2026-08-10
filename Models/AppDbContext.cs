using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Agencia_Viagens01.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}

﻿
