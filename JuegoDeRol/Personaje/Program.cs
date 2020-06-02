using System;

namespace Entidades
{
    public enum Tipos
    {
        Tipo1,
        Tipo2,
        Tipo3,
        Tipo4
    }

    public class Personaje
    {
        int velocidad;
        int destreza;
        int fuerza;
        int nivel;
        int armadura;
        int salud;
        Tipos tipo;
        string nombre;
        string apodo;
        DateTime nacimiento;

        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public Tipos Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }

        int Edad(DateTime nacimiento)
        {
            int edad = 0;
            return edad;
        }
    }
}
