
using CRUD_MVVM_Q42024.Models;
using SQLite;

namespace CRUD_MVVM_Q42024.Services
{
    public class EmpleadoService
    {
        private readonly SQLiteConnection SQLiteConnection;

        public EmpleadoService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleado.db3");
            // Initialite connection
            SQLiteConnection = new SQLiteConnection(dbPath);
            // Create table
            SQLiteConnection.CreateTable<Empleado>();
        }

        public List<Empleado> GetAll()
        {
            var res = SQLiteConnection.Table<Empleado>().ToList();
            return res;
        }

        public int Insert(Empleado empleado)
        {
            return SQLiteConnection.Insert(empleado);
        }

        public int Update(Empleado empleado)
        {
            return SQLiteConnection.Update(empleado);
        }

        public int Delete(Empleado empleado)
        {
            return SQLiteConnection.Delete(empleado);
        }

    }
}
