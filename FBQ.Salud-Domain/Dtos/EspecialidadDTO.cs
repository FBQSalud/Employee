﻿
using FBQ.Salud_Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace FBQ.Salud_Domain.Dtos
{
    public class EspecialidadDTO
    {
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
