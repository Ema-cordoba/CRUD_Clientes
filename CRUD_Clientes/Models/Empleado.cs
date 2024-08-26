namespace CRUD_Clientes.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string NomvbreCompleto { get; set; }

        public string Correo { get; set; }

        public DateOnly FechaContrato { get; set; }

        public bool Activo { get; set; }
    }
}
