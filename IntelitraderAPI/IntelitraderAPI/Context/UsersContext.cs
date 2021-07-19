using IntelitraderAPI.Domains;
using Microsoft.EntityFrameworkCore;

namespace IntelitraderAPI.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-AUB5PDB\SQLEXPRESS; Initial Catalog=Users; user id=sa;password=sa132");

            base.OnConfiguring(optionsBuilder);

        }
    }
}
