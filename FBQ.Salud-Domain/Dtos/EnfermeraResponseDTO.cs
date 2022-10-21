using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBQ.Salud_Domain.Dtos
{
    public class EnfermeraResponseDTO
    {
        public virtual EmpleadoResponseDTO Empleado{ get; set; }
        public string TipoEnfermera { get; set; }

 

    }
}
