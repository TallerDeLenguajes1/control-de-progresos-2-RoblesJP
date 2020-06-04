using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Datos
    {
        private int salud;
        private string tipo;
        private string nombre;
        private string apodo;
        private DateTime nacimiento;

        public int Salud { get => salud; set => salud = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }

        public int Edad(DateTime fecha)
        {
            int edad = fecha.Year - Nacimiento.Year;
            return edad;
        }
    }
}
