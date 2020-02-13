using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudMvcApp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Vest> Vesti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=IMANDIC\\SQLEXPRESS;database=Vesti;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public void Save()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(Vesti.ToList().ToArray());

            //write string to file
            System.IO.File.WriteAllText(@"D:\path.txt", json);
        }
    }
}
