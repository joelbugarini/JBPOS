using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using JBPOS.Models;


namespace JBPOS.DataContext
{
    public class JBPOS_DB_Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        private IConfigurationBuilder config = new ConfigurationBuilder();
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(config
                .AddJsonFile("appsettings.json", false, true)
                .Build()["ConnectionStrings:SqlConnection"]);
    }
}