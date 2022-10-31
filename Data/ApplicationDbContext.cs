using _2doParcial_Nicol.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2doParcial_Nicol.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Vitaminas> Vitaminas { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {


    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vitaminas>().HasData(
            new Vitaminas { VitaminaId = 1, Nombre = "vitamina A" },
            new Vitaminas { VitaminaId = 2, Nombre = "vitamina c" },
            new Vitaminas { VitaminaId = 3, Nombre = "vitamina D" },
            new Vitaminas { VitaminaId = 4, Nombre = "vitamina E" },
            new Vitaminas { VitaminaId = 5, Nombre = "vitamina F" }

            );
    }
}
