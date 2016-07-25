using System.Data.Entity;
using Cube3D.Entity;

namespace Cube3D.Persistences
{
    public class Cube3DContext : DbContext
    {
        public Cube3DContext() : base("name=Cube3DConnectionString")
        {

        }

        public DbSet<Matriz> Matriz { get; set; }
        public DbSet<DetalleMatriz> DetalleMatriz { get; set; }
    }
}