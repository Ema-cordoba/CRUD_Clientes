using Microsoft.EntityFrameworkCore;
using CRUD_Clientes.Models;
namespace CRUD_Clientes.Data
{
    public class DBContext : DbContext
    {
        //Utilizo un contructor pasandole como tipo de parametro el generico DBContextOptions

        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
            
        }

        //Creo el DVSet para mapeo de entidades

        public DbSet<Empleado> Empleados { get; set; }


        //Defino las caracteristicas de la tabla

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //Hago referencia de que voy a trabajar con la tabla empleado
            modelBuilder.Entity<Empleado>(table =>
            {
                table.HasKey(columna => columna.IdEmpleado);
                //El ID es entero auntoincremental
                table.Property(columna => columna.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();

                //Es como hacer una query donde la propiedad tiene como maximo 50
                table.Property(columna => columna.NomvbreCompleto).HasMaxLength(50);
                table.Property(columna => columna.Correo).HasMaxLength(50);


            });

            modelBuilder.Entity<Empleado>().ToTable("Empleado");
        }

    }
}
