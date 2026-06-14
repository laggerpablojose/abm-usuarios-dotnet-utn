using System;
using System.Collections;

namespace TPBocchieriGramajoLezcanoLagger
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Creación de permisos.
             */

            Permiso permisoConsultar = new Permiso(
                1,
                "Consultar",
                "Permite consultar información."
                );

            Permiso permisoCrear = new Permiso(
                2,
                "Crear",
                "Permite registrar nuevos objetos."
                );

            Permiso permisoModificar = new Permiso(
                3,
                "Modificar",
                "Permite modificar objetos existentes."
                );

            ArrayList listaPermisos = new ArrayList();

            listaPermisos.Add(permisoConsultar);
            listaPermisos.Add(permisoCrear);
            listaPermisos.Add(permisoModificar);

            /*
             * Creación de Las Listas de permisos de los grupos.
             * Se agregan referencias a los permisos ya creados.
             */

            ArrayList permisosAdministradores = new ArrayList();

            permisosAdministradores.Add(permisoConsultar);
            permisosAdministradores.Add(permisoCrear);
            permisosAdministradores.Add(permisoModificar);

            ArrayList permisosOperadores = new ArrayList();

            permisosOperadores.Add(permisoConsultar);
            permisosOperadores.Add(permisoCrear);

            ArrayList permisosConsultas = new ArrayList();

            permisosConsultas.Add(permisoConsultar);

            /*
             * Creación de grupos.
             */

            Grupo grupoAdministradores = new Grupo(
            1,
            "Administradores",
            "Grupo con permisos para consultar, crear y modificar.",
            permisosAdministradores
            );

            Grupo grupoOperadores = new Grupo(
                2,
                "Operadores",
                "Grupo con permisos para consultar y crear.",
                permisosOperadores
            );

            Grupo grupoConsultas = new Grupo(
                3,
                "Consultas",
                "Grupo con permiso únicamente para consultar.",
                permisosConsultas
            );

            ArrayList listaGrupos = new ArrayList();

            listaGrupos.Add(grupoAdministradores);
            listaGrupos.Add(grupoOperadores);
            listaGrupos.Add(grupoConsultas);

            /*
             * Creación de las listas de permisos propios.
             */

            ArrayList permisosUsuario1 = new ArrayList();

            ArrayList permisosUsuario2 = new ArrayList();

            permisosUsuario2.Add(permisoModificar);

            ArrayList permisosUsuario3 = new ArrayList();

            /*
             * Creación de usuarios.
             */

            Usuario usuario1 = new Usuario(
                1,
                "Ana",
                "López",
                "30111222",
                "ana123",
                "ana.lopez@email.com",
                grupoAdministradores,
                permisosUsuario1
                );

            Usuario usuario2 = new Usuario(
                2,
                "Bruno",
                "Pérez",
                "32333444",
                "bruno123",
                "bruno.perez@email.com",
                grupoOperadores,
                permisosUsuario2
                );

            Usuario usuario3 = new Usuario(
                3,
                "Carla",
                "Gómez",
                "34555666",
                "carla123",
                "carla.gomez@email.com",
                grupoConsultas,
                permisosUsuario3
            );

            ArrayList listaUsuarios = new ArrayList();

            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
            listaUsuarios.Add(usuario3);

            /*
             * Presentación de los objetos creados.
             */

            Console.WriteLine("PERMISOS");
            Console.WriteLine("=============================");

            for (int i = 0; i < listaPermisos.Count; i++)
            {
                Permiso permiso = (Permiso)listaPermisos[i];

                    Console.WriteLine(permiso.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("GRUPOS");
            Console.WriteLine("=============================");

            for (int i = 0; i < listaGrupos.Count; i++)
            {
                Grupo grupo = (Grupo)listaGrupos[i];

                Console.WriteLine(grupo.ToString());
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine();
            Console.WriteLine("USUARIOS");
            Console.WriteLine("========================================");

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                Usuario usuario = (Usuario)listaUsuarios[i];

                Console.WriteLine(usuario.ToString());
                Console.WriteLine("========================================");
            }

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para finalizar.");
            Console.ReadKey();

        }
    }

}