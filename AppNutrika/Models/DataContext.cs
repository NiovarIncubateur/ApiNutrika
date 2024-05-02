using AppNutrika.Models.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace AppNutrika.Models
{
    public class DataContext : DbContext
    {


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
