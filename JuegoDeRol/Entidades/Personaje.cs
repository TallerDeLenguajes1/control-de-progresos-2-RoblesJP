using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Personaje
    {
        private Caracteristicas caracteristicas = new Caracteristicas();
        private Datos datos = new Datos();

        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public Datos Datos { get => datos; set => datos = value; }
    }
}
