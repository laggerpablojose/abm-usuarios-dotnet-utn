using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TPBocchieriGramajoLezcanoLagger
{
    public class Permiso
    {
        private int codigo;
        private string nombre;
        private string descripcion;

        public Permiso(int codigo, string nombre, string descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }

        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

        public override string ToString()
        {
            return "código: " + codigo
                + " | Nombre: " + nombre
                + " | Descripción: " + descripcion;
        }
    }
}
