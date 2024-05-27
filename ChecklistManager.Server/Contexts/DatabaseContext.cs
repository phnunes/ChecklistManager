using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections.Generic;
using ChecklistManager.Server.Models;

namespace ChecklistManager.Server.Contexts
{
    public class DatabaseContext : DbContext
    {
        private readonly string conn = "Server=(local)\\SQLEXPRESS;Database=dbchecklist;Trusted_Connection=True;Integrated Security=true;TrustServerCertificate=True;";//
        public DatabaseContext()
        { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conn);
        }
        public DbSet<ChecklistManager.Server.Models.Vehicle> Vehicle { get; set; } = default!;
        public DbSet<ChecklistManager.Server.Models.Checklist> Checklist { get; set; } = default!;
    }
}

