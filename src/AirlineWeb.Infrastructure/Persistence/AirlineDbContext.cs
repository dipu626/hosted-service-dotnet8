using AirlineWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineWeb.Infrastructure.Persistence
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options) : base(options)
        {
        }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (WebhookSubscriptions?.Any() == false)
            {
                WebhookSubscription subscription = new()
                {
                    Id = 1,
                    WebhookURI = "dummyData",
                    Secret = "dummyData",
                    WebhookPublisher = "dummyData",
                    WebhookType = "dummyData"
                };

                modelBuilder.Entity<WebhookSubscription>().HasData(subscription);
            }
        }
    }
}
