using AppNutrika.Models.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace AppNutrika.Models
{
    public class DataContext : DbContext
    {
        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "user=admin; password=Niovar2024; database=nutrikadb";
            var serverVersion = new MySqlServerVersion(new Version(10, 6, 13));
            optionsBuilder.UseMySql(connection, serverVersion); 
        }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Traitement> traitement { get; set; }
        public DbSet<Consommation> consommation { get; set; }
        public DbSet<Observation> observation { get; set; }
        public DbSet<CategorieOfConsommation> categorieOfConsommation { get; set; }
        public DbSet<Materiels> materiels { get; set; }
        public DbSet<Production> production { get; set; }
        public DbSet<RoleOfUser> roleOfUsers { get; set; }
        public DbSet<User> users { get; set; }
    }
}
