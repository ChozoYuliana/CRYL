﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrylService.Dominio
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int Telefono { get; set; }
        public string Sexo { get; set; }
    }
}