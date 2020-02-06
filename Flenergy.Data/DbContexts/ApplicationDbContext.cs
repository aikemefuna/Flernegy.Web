using Flenergy.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Flenergy.Data.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public virtual DbSet<Adm_Gateway> Adm_Gateway { get; set; }
        public virtual DbSet<Adm_Meter> Adm_Meter { get; set; }
        public virtual DbSet<Adm_ServiceCharge> Adm_ServiceCharge { get; set; }
        public virtual DbSet<BillingCategory> BillingCategory { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerPinVendingProfile> CustomerPinVendingProfiles { get; set; }
        public virtual DbSet<Disco> Discos { get; set; }
        public virtual DbSet<Estate> Estates { get; set; }
        public virtual DbSet<EstateAdmin> EstateAdmins { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<PaymentSplit> PaymentSplits { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<AdmStates> AdmStates { get; set; }
        public virtual DbSet<LocalGovernment> LocalGovernments { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.SeedStatesData();
            builder.SeedLgaData();

    
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var authenticatedUserName = httpContext.User.Identity.Name;

                // If it returns null, even when the user was authenticated, you may try to get the value of a specific claim 
                // var authenticatedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((BaseEntity)entity.Entity).DateCreated = DateTime.UtcNow;
                        ((BaseEntity)entity.Entity).UserCreated = authenticatedUserName;
                    }

                 ((BaseEntity)entity.Entity).DateModified = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).UserModified = authenticatedUserName;
                }
            }
        }
    }
}
