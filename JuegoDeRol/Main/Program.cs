using System;
using System.Collections.Generic;
using Entidades;
using ConsoleTables;
using System.Globalization;
using System.Xml.Serialization;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int cantPersonajes = 5;
            List<Personaje> personajes = cargarPersonajes(cantPersonajes); // lista que contiene a todos los personajes
            mostrarPersonajes(personajes);
            Personaje reyDeLosSieteReinos = Batalla(personajes);
            Console.WriteLine("\nEl Rey de los Siete Reinos es {0} \'{1}\'", reyDeLosSieteReinos.Datos.Nombre, reyDeLosSieteReinos.Datos.Apodo);
        }

        static DateTime FechaAleatoria(DateTime comienzo, DateTime final)
        {
            Random rnd = new Random();
            int rango = (final - comienzo).Days;
            return comienzo.AddDays(rnd.Next(rango));
        }

        static List<Personaje> cargarPersonajes(int cant)
        {
            List<Personaje> personajes = new List<Personaje>();
            Random rnd = new Random();
            Caracteristicas caracteristicas;
            Datos datos;
            Personaje personaje;
            int indiceNombre; // indice para obtener valor aleatorio del enum
            int indiceApodo;
            int indiceTipos;
            DateTime final;
            DateTime comienzo;
            DateTime fechaNacimieno;

            for (int i = 0; i < cant; i++)
            {
                // datos
                indiceNombre = i;
                indiceApodo = i;
                indiceTipos = rnd.Next(Enum.GetNames(typeof(Tipos)).Length);
                final = DateTime.Now;
                comienzo = final.AddYears(-300);
                do
                {
                    fechaNacimieno = FechaAleatoria(comienzo, final);
                } while ((final.Year - fechaNacimieno.Year) < 50);  // Los personajes tendran entre 50 y 300 años

                datos = new Datos(
                                    Convert.ToString((Nombres)indiceNombre),            // nombre
                                    Convert.ToString((Apodos)indiceApodo),              // apodo
                                    Convert.ToString((Tipos)indiceTipos),               // tipo
                                    fechaNacimieno,                                     // nacimiento (todos nacen a la misma hora)
                                    rnd.Next(101)                                       // salud
                    );

                // caracteristicas
                caracteristicas = new Caracteristicas(
                                    rnd.Next(Convert.ToInt32(Max.Nivel)) + 1,           // nivel
                                    rnd.Next(Convert.ToInt32(Max.Fuerza)) + 1,          // fuerza
                                    rnd.Next(Convert.ToInt32(Max.Velocidad)) + 1,       // velocidad
                                    rnd.Next(Convert.ToInt32(Max.Destreza)) + 1,        // destreza
                                    rnd.Next(Convert.ToInt32(Max.Armadura)) + 1         // armadura
                    );

                personaje = new Personaje(datos, caracteristicas);
                personajes.Add(personaje);
            }
            return personajes;
        }

        static void mostrarPersonajes(List<Personaje> lista)
        {
            var cultura = CultureInfo.CreateSpecificCulture("es-ES");

            ConsoleTable tabla = new ConsoleTable(
                                    "Nombre",
                                    "Apodo",
                                    "Tipo",
                                    "Nacimiento",
                                    "Edad",
                                    "Salud",
                                    "Nivel",
                                    "Fuerza",
                                    "Velocidad",
                                    "Destreza",
                                    "Armadura"
                );

            foreach (Personaje personaje in lista)
            {
                tabla.AddRow(
                                    personaje.Datos.Nombre,
                                    personaje.Datos.Apodo,
                                    personaje.Datos.Tipo,
                                    personaje.Datos.Nacimiento.Date.ToString("d", cultura),
                                    personaje.Datos.Edad(),
                                    personaje.Datos.Salud,
                                    personaje.Caracteristicas.Nivel,
                                    personaje.Caracteristicas.Fuerza,
                                    personaje.Caracteristicas.Velocidad,
                                    personaje.Caracteristicas.Destreza,
                                    personaje.Caracteristicas.Armadura
                    );
            }

            tabla.Write();
        }

        static Personaje[] Combate(Personaje personajeA, Personaje personajeB)
        {
            Personaje[] resultado = new Personaje[2];

            for (int i = 0; i < 3; i++)
            {
                personajeA.Atacar(personajeB);
                if (personajeB.Datos.Salud <= 0)
                {
                    personajeA.Datos.Salud += +10;
                    resultado[0] = personajeA;
                    resultado[1] = personajeB;
                    break;
                }

                personajeB.Atacar(personajeA);
                if (personajeA.Datos.Salud <= 0)
                {
                    personajeB.Datos.Salud += +10;
                    resultado[0] = personajeB;
                    resultado[1] = personajeA;
                    break;
                }
            }

            return resultado;
        }

        static Personaje Batalla(List<Personaje> lista)
        {
            Personaje[] resultadoCombate = null;
            while (lista.Count > 1)
            {
                resultadoCombate = Combate(lista[0], lista[1]);
                lista.Remove(resultadoCombate[1]);
            }

            return lista[0];
        }
    }
}
