using Microsoft.EntityFrameworkCore;
using WastLibraryWeb.Models;

namespace WastLibraryWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<Category> Categories => Set<Category>();
}