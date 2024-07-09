using Microsoft.EntityFrameworkCore;
using NotUygulamasi.Models;

namespace NotUygulamasi.Data
{
    public class NotUygulamasiContext : DbContext
    {
        public NotUygulamasiContext(DbContextOptions<NotUygulamasiContext> options)
            : base(options)
        {
        }
        public DbSet<Not> Notlar { get; set; }
    }
}
