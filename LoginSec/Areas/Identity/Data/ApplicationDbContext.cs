using LoginSec.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginSec.Areas.Identity.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<MonetaryDonation> MonetaryDonations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<GoodsDonation> GoodsDonations { get; set; }
        public DbSet<Monetary_Allocation> Monetary_Allocations { get; set; }
        public DbSet<Good_Allocation> Good_Allocations { get; set; }
        public DbSet<PurchaseGoods> PurchaseGoods { get; set; }
    }
}
