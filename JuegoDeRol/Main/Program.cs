using System;
using Entidades;

namespace Main
{
    class Program
    {
        enum Nombres
        {
            Jorge = 0,
            Miguel = 1,
            Pedro = 2,
            Vanessa = 3,
            Mai = 4,
        }

        enum Apodos // https://www.fantasynamegenerators.com/warrior-nicknames.php
        {
            Shieldmight,
            Boulderpelt,
            Strongblow,
            Ravenshield,
            Sharpvisage,
        }

        public enum Tipos
        {
            Gerrero,
            Mago,
            Monje,
            Ladron,
            Arquero,
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            Personaje personaje = new Personaje();

            // creacion aleatoria de un personaje
            // -datos
            // --nombre
            int indiceNombre = rnd.Next(Enum.GetNames(typeof(Nombres)).Length); // indice para obtener valor aleatorio del enum
            personaje.Datos.Nombre = Convert.ToString((Nombres)indiceNombre);
            // --apodo
            int indiceApodo = rnd.Next(Enum.GetNames(typeof(Apodos)).Length); 
            personaje.Datos.Apodo = Convert.ToString((Apodos)indiceApodo);
            // --tipo
            int indiceTipos = rnd.Next(Enum.GetNames(typeof(Tipos)).Length);
            personaje.Datos.Tipo = Convert.ToString((Tipos)indiceTipos);
            // --salud
            personaje.Datos.Salud = rnd.Next(101);
            // --nacimiento
            DateTime comienzo = new DateTime(1200, 1, 1);
            DateTime final = new DateTime(1500, 12, 31);
            personaje.Datos.Nacimiento = FechaAleatoria(comienzo, final); // todos nacen a las 12AM

            // -caracteristicas
            // --nivel
            personaje.Caracteristicas.Nivel = rnd.Next(10) + 1;
            // --velocidad
            personaje.Caracteristicas.Velocidad = rnd.Next(10) + 1;
            // --destreza
            personaje.Caracteristicas.Destreza = rnd.Next(5) + 1;
            // --fuerza
            personaje.Caracteristicas.Fuerza = rnd.Next(10) + 1;
            // --armadura
            personaje.Caracteristicas.Armadura = rnd.Next(10) + 1;
        }

        static DateTime FechaAleatoria(DateTime comienzo, DateTime final)
        {
            Random rnd = new Random();
            int rango = (final - comienzo).Days;
            return comienzo.AddDays(rnd.Next(rango));
        }
    }
}
