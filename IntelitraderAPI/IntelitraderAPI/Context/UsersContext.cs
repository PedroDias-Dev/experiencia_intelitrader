using Flunt.Notifications;
using IntelitraderAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace IntelitraderAPI.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext()
        {

        }

        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                //optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-AUB5PDB\SQLEXPRESS; Initial Catalog = Users; user id=sa; password = sa132");

                optionsBuilder.UseSqlServer(@"Server=users-api-database;Database=Users;User Id=SA;Password=DockerSql2021!");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
