using FBQ.Salud_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Dtos
{
    public class EnfermeraDTO
    {
        public int EmpleadoId { get; set; }
        public string TipoEnfermera { get; set; }
        public bool Estado { get; set; }
        public int HorarioId { get; set; }

    }
}
