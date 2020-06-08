using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public enum Nombres
    {
        Jorge = 0,
        Miguel = 1,
        Pedro = 2,
        Vanessa = 3,
        Mai = 4,
    }

    public enum Apodos // https://www.fantasynamegenerators.com/warrior-nicknames.php
    {
        Shieldmight = 0,
        Boulderpelt = 1,
        Strongblow = 2,
        Ravenshield = 3,
        Sharpvisage = 4,
    }

    public enum Tipos
    {
        Gerrero = 0,
        Mago = 1,
        Monje = 2,
        Ladron = 3,
        Arquero = 4,
    }

    public enum Max
    {
        Nivel = 10,
        Fuerza = 10,
        Velocidad = 10,
        Destreza = 5,
        Armadura = 10,
    }

    public class Personaje
    {
        // campos
        private Datos datos;
        private Caracteristicas caracteristicas;

        // propiedades
        public Datos Datos { get => datos; set => datos = value; }
        public Caracteristicas Caracteristicas { get => caracteristicas; set => caracteristicas = value; }

        // constructor
        public Personaje(Datos datos, Caracteristicas caracteristicas)
        {
            Datos = datos;
            Caracteristicas = caracteristicas;
        }

        // accion atacar
        public void Atacar(Personaje defensor)
        {
            Random rnd = new Random();
            // atacante
            float poderDisparo = Caracteristicas.Destreza * Caracteristicas.Fuerza * Caracteristicas.Nivel;
            float efectividadDisparo = (rnd.Next(100) + 1);
            float valorAtaque = poderDisparo * efectividadDisparo;

            // defensor
            float valorDefensa = defensor.Caracteristicas.Armadura * defensor.Caracteristicas.Velocidad;

            // resultado
            float maximoDañoProvocado = 50000;
            float dañoProvocado = ((valorAtaque * efectividadDisparo - valorDefensa) / maximoDañoProvocado) * 100;
            defensor.Datos.Salud -= (int )dañoProvocado;
        }
    }
}
