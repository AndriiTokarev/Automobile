using System.Diagnostics.CodeAnalysis;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }
}