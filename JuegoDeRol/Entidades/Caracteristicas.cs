﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Caracteristicas
    {
        private int nivel;
        private int fuerza;
        private int velocidad;
        private int destreza;
        private int armadura;

        public int Nivel { get => nivel; set => nivel = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Armadura { get => armadura; set => armadura = value; }

        public Caracteristicas(int nivel, int fuerza, int velocidad, int destreza, int armadura)
        {
            Nivel = nivel;
            Fuerza = fuerza;
            Velocidad = velocidad;
            Destreza = destreza;
            Armadura = armadura;
        }
    }
}
