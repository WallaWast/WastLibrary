using Microsoft.EntityFrameworkCore;
using WastLibrary.Models;

namespace WastLibrary.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Category> Categories => Set<Category>();
}