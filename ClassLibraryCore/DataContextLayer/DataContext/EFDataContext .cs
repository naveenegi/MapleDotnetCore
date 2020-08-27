using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryCore.DataContextLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibraryCore.DataContextLayer.DataContext
{
    public class EFDataContext : DbContext
    {

        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<CoveragePlan> CoveragePlans { get; set; }
        public DbSet<RateChart> RateCharts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"data source=DELL3542\ANSU; initial catalog=SMSDB;Trusted_Connection=True;integrated security=True");
         
        }
    }
}
