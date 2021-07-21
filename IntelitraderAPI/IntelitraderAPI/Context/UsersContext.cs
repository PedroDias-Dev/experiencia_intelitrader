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

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=users-api-database;Database=Users;User Id=SA;Password=DockerSql2021!");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
