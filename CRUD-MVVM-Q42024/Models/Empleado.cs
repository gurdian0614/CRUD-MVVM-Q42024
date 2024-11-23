
using SQLite;

namespace CRUD_MVVM_Q42024.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}
