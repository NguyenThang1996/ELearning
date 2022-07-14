using Microsoft.EntityFrameworkCore;
using ELearningAPI.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;

namespace ELearningAPI.Infrastructure.Configs
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// <Modified>
    /// Name Date Comments
    /// thangnh3 14/07/2022 created
    /// </Modified>
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        /// <summary>Initializes a new instance of the <see cref="DataContext" /> class.</summary>
        /// <param name="configuration">The configuration.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>Called when [configuring].</summary>
        /// <param name="options">The options.</param>
        /// <Modified>
        /// Name Date Comments
        /// thangnh3 14/07/2022 created
        /// </Modified>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<StaffEntity> Staffs { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PartEntity> Parts { get; set; }
    }
}
