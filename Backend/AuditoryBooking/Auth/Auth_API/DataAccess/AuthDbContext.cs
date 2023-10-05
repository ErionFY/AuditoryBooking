using Auth_DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Auth_DAL;

public partial class AuthDbContext:IdentityDbContext<UserExtended>
    {
        //public DbSet<RefreshToken> RefreshToken { get; set; }
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    public partial class AuthDbContext
    {
        // for checking that DI is getting a different instance each time when the dbcontext is injected in the context of a web request
        private Guid _instanceId = Guid.NewGuid();

        public static void AddBaseOptions(DbContextOptionsBuilder<AuthDbContext> builder, string connectionString)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Connection string must be provided", nameof(connectionString));

            builder.UseNpgsql(connectionString, x =>
            {
                x.EnableRetryOnFailure();
            });
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {

            string connectionString = "Server=localhost;Port=5432;Database=AuditoryBookingAuthDB; User Id=postgres;Password=906_Efyr_160FY";



            DbContextOptionsBuilder<AuthDbContext> dbContextOptionsBuilder =
                new DbContextOptionsBuilder<AuthDbContext>();

            AuthDbContext.AddBaseOptions(dbContextOptionsBuilder, connectionString);

            return new AuthDbContext(dbContextOptionsBuilder.Options);
        }
    }
