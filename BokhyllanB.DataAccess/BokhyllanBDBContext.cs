using BokhyllanB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokhyllanB.DataAccess
{
    public class BokhyllanBDBContext : DbContext
    {


        public DbSet<Book> Books { get; set; }
        

        public BokhyllanBDBContext():base("BokhyllanBDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
