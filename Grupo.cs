using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TPBocchieriGramajoLezcanoLagger
{
    class Grupo
    {
        private int codigo;
        private string nombre;
        private string descripcion;
        private ArrayList listaPermisos;

        public Grupo(int codigo, string nombre, string descripcion, ArrayList listaPermisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.listaPermisos = listaPermisos;
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

        public ArrayList ListaPermisos
        {
            get
            {
                return listaPermisos;
            }
            set
            {
                listaPermisos = value;
            }
        }

        public override string ToString()
        {
            string permisos = "";

            if (listaPermisos.Count == 0)
            {
                permisos = "\n    Sin permisos.";
            }
            else
            {
                for (int i = 0; i < listaPermisos.Count; i++)
                {
                    Permiso permiso = (Permiso)listaPermisos[i];

                    permisos = permisos
                        + "\n    - "
                        + permiso.ToString();
                }
            }

            return "Código: " + codigo
                + "\nNombre: " + nombre
                + "\nDescripción: " + descripcion
                + "\nLista de permisos:" + permisos;
        }
    }
}
