using Microsoft.EntityFrameworkCore;
using myFinance_web_dotnet.Domain;


namespace myFinance_web_dotnet.Infrastructure
{
    public class MyFinanceDbContext : DbContext
    {
        public DbSet<PlanoConta> PlanoConta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=DESKTOP-G3TGQTJ\SQL2019;Database=myfinanceweb;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}