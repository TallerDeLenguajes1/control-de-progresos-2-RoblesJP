using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Personaje
    {
        private Datos datos;
        private Caracteristicas caracteristicas;

        public Datos Datos { get => datos; set => datos = value; }
        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            Datos = datos;
            Caracteristicas = caracteristicas;
        }
    }
}
