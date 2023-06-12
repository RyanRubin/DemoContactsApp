using DcaModels;
using Microsoft.EntityFrameworkCore;

namespace DcaServices.DataAccess;

public class DcaDbContext : DbContext
{
    public DcaDbContext(DbContextOptions<DcaDbContext> options) : base(options)
    {
    }

    public DbSet<ContactEntity> Contacts { get; set; }
}
