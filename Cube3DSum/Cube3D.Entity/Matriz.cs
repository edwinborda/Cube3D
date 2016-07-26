using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cube3D.Entity
{
    [Table("Matriz")]
    public class Matriz
    {
        public int Id { get; set; }

        [Range(0,50)]
        public int TamMatriz { get; set; }

        [Range(0,50)]
        public int NumOperaciones { get; set; }
    }
}
