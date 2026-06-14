using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TPBocchieriGramajoLezcanoLagger
{
    class Usuario
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private string dni;
        private string password;
        private string email;
        private Grupo grupo;
        private ArrayList listaPermisos;

        public Usuario(int codigo, string nombre, string apellido, string dni, string password, string email, Grupo grupo, ArrayList listaPermisos)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.password = password;
            this.email = email;
            this.grupo = grupo;
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
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set {  apellido = value; }
        }

        public string DNI
        {
            get { return dni; }
            set {  dni = value; }
        }

        public string Password
            {
            get { return password; }
            set { password = value; }
        }

        public string Email
        {
            get { return email; }
            set {  email = value; }
        }

        public Grupo Grupo
        {
            get{ return grupo; }
            set{ grupo = value; }
        }

        public ArrayList ListaPermisos
        {
            get{ return listaPermisos; }
            set {  listaPermisos = value; }
        }

        public override string ToString()
        {
            string permisosPropios = "";
            
            if (listaPermisos.Count == 0)
            {
                permisosPropios = "\n   Sin permisos propios.";
            }
            else
            {
                for (int i = 0; i < listaPermisos.Count; i++)
                {
                    Permiso permiso = (Permiso)listaPermisos[i];

                    permisosPropios = permisosPropios
                        + "\n   -"
                        + permiso.ToString();
                }
            }

            return "código: " + codigo
                + "\nNombre: " + nombre
                + "\nDNI: " + dni
                + "\nPassWord: " + password
                + "\nEmail: " + email
                + "\nGrupo:"
                + "\n----------------------------------------"
                + "\n" + grupo.ToString()
                + "\n----------------------------------------"
                + "\nLista de permisos propios:"
                + permisosPropios;
        }
    }
}
