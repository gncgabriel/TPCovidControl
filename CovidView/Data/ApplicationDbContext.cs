using System;
using System.Collections.Generic;
using System.Text;
using CovidView.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CovidView.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<CovidInfo> Covid_Info { get; set; }



    }
}
