using Microsoft.EntityFrameworkCore;
using ELearningAPI.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;

namespace ELearningAPI.Infrastructure.Configs
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }
        public DbSet<StaffEntity> Staffs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PartEntity> Parts { get; set; }
    }
}
