﻿using LoginSec.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginSec.Areas.Identity.Data;

public class IdentityApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration :
    IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(e => e.FirstName).HasMaxLength(255);
        builder.Property(e => e.LastName).HasMaxLength(255);
    }
} 