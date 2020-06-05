using System;
using System.Collections.Generic;
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
            Caracteristicas caracteristicas;
            Datos datos;
            Personaje personaje;
            List<Personaje> personajes = new List<Personaje>();
            int indiceNombre; // indice para obtener valor aleatorio del enum
            int indiceApodo;
            int indiceTipos;
            int cantPersonajes = 6;

            // creacion aleatoria de un personaje
            for (int i = 0; i < cantPersonajes; i++)
            {
                // datos
                indiceNombre = rnd.Next(Enum.GetNames(typeof(Nombres)).Length);
                indiceApodo = rnd.Next(Enum.GetNames(typeof(Apodos)).Length);
                indiceTipos = rnd.Next(Enum.GetNames(typeof(Tipos)).Length);
                DateTime comienzo = new DateTime(1200, 1, 1);
                DateTime final = new DateTime(1500, 12, 31);
                datos = new Datos(
                                    Convert.ToString((Nombres)indiceNombre),    // nombre
                                    Convert.ToString((Apodos)indiceApodo),      // apodo
                                    Convert.ToString((Tipos)indiceTipos),       // tipo
                                    FechaAleatoria(comienzo, final),            // nacimiento (todos nacen a las 12AM)
                                    rnd.Next(101)                               // salud
                    );

                // caracteristicas
                caracteristicas = new Caracteristicas(
                                    rnd.Next(10) + 1,                           // nivel
                                    rnd.Next(10) + 1,                           // fuerza
                                    rnd.Next(10) + 1,                           // velocidad
                                    rnd.Next(5) + 1,                            // destreza
                                    rnd.Next(10) + 1                            // armadura
                    );

                personaje = new Personaje(datos, caracteristicas);
                personajes.Add(personaje);
            }
        }

        static DateTime FechaAleatoria(DateTime comienzo, DateTime final)
        {
            Random rnd = new Random();
            int rango = (final - comienzo).Days;
            return comienzo.AddDays(rnd.Next(rango));
        }
    }
}
