using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Cube3D.Entity
{
    [Table("DetalleMatriz")]
    public class DetalleMatriz
    {
        public int Id { get; set; }

        public int MatrizId { get; set; }

        public string Coordenada { get; set; }

        [Range(0,)]
        public int Valor { get; set; }

    }
}
