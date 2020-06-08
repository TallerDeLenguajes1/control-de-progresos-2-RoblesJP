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
            int cantPersonajes = 5;
            List<Personaje> personajes = CargarPersonajes(cantPersonajes); // lista que contiene a todos los personajes
            Personaje[] resultadoCombate;
            int nroCombate = 0;
            Personaje reyDeLosSieteReinos;

            MostrarPersonajes(personajes);

            // batalla
            while (personajes.Count > 1)
            {
                nroCombate++;
                Console.WriteLine("\n--- Combate #{0} ({1} vs {2}) ---",    nroCombate,
                                                                            personajes[0].Datos.Nombre + " " + personajes[0].Datos.Apodo, 
                                                                            personajes[1].Datos.Nombre + " " + personajes[1].Datos.Apodo);
                resultadoCombate = Combate(personajes[0], personajes[1]);
                Console.WriteLine("Ganador del combate: {0} con {1} de salud",  resultadoCombate[0].Datos.Nombre + " " + resultadoCombate[0].Datos.Apodo,
                                                                                resultadoCombate[0].Datos.Salud);
                personajes.Remove(resultadoCombate[1]);
            }
            reyDeLosSieteReinos = personajes[0];
            Console.WriteLine("\n--- Batalla finalizada---");
            Console.WriteLine("El nuevo Rey de los Siete Reinos es: {0}", reyDeLosSieteReinos.Datos.Nombre + " " + reyDeLosSieteReinos.Datos.Apodo);
        }

        static DateTime FechaAleatoria(DateTime comienzo, DateTime final)
        {
            Random rnd = new Random();
            int rango = (final - comienzo).Days;
            return comienzo.AddDays(rnd.Next(rango));
        }

        static List<Personaje> CargarPersonajes(int cant)
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

        static void MostrarPersonajes(List<Personaje> lista)
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

            while (personajeA.Datos.Salud > 0 && personajeB.Datos.Salud > 0)
            {
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
            }
            return resultado;
        }
    }
}
