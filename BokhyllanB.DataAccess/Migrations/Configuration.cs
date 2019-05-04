namespace BokhyllanB.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BokhyllanB.DataAccess.BokhyllanBDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BokhyllanB.DataAccess.BokhyllanBDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Books.AddOrUpdate(b => b.Title, new Model.Book { Title = "Lord Of The Roings", Author = "J.R.R. Tolkien" }, new Model.Book { Title = "The Silver Chair", Author = "C.S. Lewies" });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
