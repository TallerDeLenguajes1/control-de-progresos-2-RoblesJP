using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Datos
    {
        private string nombre;
        private string apodo;
        private string tipo;
        private DateTime nacimiento;
        private int salud;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public int Salud { get => salud; set => salud = value; }

        public Datos(string nombre, string apodo, string tipo, DateTime nacimiento, int salud)
        {
            Nombre = nombre;
            Apodo = apodo;
            Tipo = tipo;
            Nacimiento = nacimiento;
            Salud = salud;
        }

        public int Edad(DateTime fecha)
        {
            int edad = fecha.Year - Nacimiento.Year;
            return edad;
        }
    }
}
