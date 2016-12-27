
using Microsoft.EntityFrameworkCore;

namespace IpStorage.Models
{
    public partial class video_tdsContext : DbContext
    {
        public virtual DbSet<Visitors> Visitors { get; set; }

        public video_tdsContext(DbContextOptions<video_tdsContext> options)
        : base(options)
        { }
        //_clientRepository = new ClientRepository(new SlummingContext(connection));
        public video_tdsContext(string connection) : base(new DbContextOptionsBuilder<video_tdsContext>().UseSqlServer(connection).Options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=184.168.47.19;initial catalog=video_tds;user id=misterbaron;password=letsmakeSome$!;MultipleActiveResultSets=True;App=EntityFramework");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitors>(entity =>
            {
                entity.Property(e => e.Browser).HasMaxLength(40);

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasColumnName("IP")
                    .HasMaxLength(20);

                entity.Property(e => e.UserAgent)
                    .IsRequired()
                    .HasMaxLength(200);
            });
        }
    }
}