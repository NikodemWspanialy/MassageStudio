using MassageStudio.App.Models;
using MassageStudio.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MassageStudio.Data;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Massage> massages { get; set; }
    public DbSet<Term> freeTerms { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Massage>(m =>
        {
            m.Property(x => x.UserId).IsRequired();
            m.Property(x => x.Date).IsRequired();
            m.Property(x => x.Type).IsRequired();
            m.HasOne(x => x.User)
            .WithMany(x => x.massages)
            .HasForeignKey(X => X.UserId);
            m.HasOne(x => x.term)
            .WithOne(x => x.massage);
        });
        builder.Entity<Term>(t =>
        {
            t.Property(x => x.Date).IsRequired();
        });
    }
}
