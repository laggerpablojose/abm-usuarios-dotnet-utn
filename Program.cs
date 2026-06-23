using System;
using System.Collections;

namespace TPBocchieriGramajoLezcanoLagger
{
    class Program
    {
        static ArrayList listaPermisos = new ArrayList();
        static ArrayList listaGrupos = new ArrayList();
        static ArrayList listaUsuarios = new ArrayList();

        static void Main(string[] args)
        {
            InicializarDatos();
            MenuPrincipal();
        }

        static void InicializarDatos()
        {
            listaPermisos.Clear();
            listaGrupos.Clear();
            listaUsuarios.Clear();

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

            listaPermisos.Add(permisoConsultar);
            listaPermisos.Add(permisoCrear);
            listaPermisos.Add(permisoModificar);

            /*
             * Creación de listas de permisos para los grupos.
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

            listaGrupos.Add(grupoAdministradores);
            listaGrupos.Add(grupoOperadores);
            listaGrupos.Add(grupoConsultas);

            /*
             * Creación de listas de permisos propios para los usuarios.
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

            listaUsuarios.Add(usuario1);
            listaUsuarios.Add(usuario2);
            listaUsuarios.Add(usuario3);
        }

        static void MenuPrincipal()
        {
            int opcion;

            do
            {
                Console.WriteLine("===== ABM DE USUARIOS .NET =====");
                Console.WriteLine("1 - Permisos");
                Console.WriteLine("2 - Grupos");
                Console.WriteLine("3 - Usuarios");
                Console.WriteLine("0 - Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        MenuPermisos();
                        break;

                    case 2:
                        MenuGrupos();
                        break;

                    case 3:
                        MenuUsuarios();
                        break;

                    case 0:
                        Console.WriteLine("Finalizando programa...");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

                Console.WriteLine();

            } while (opcion != 0);
        }

        /*
         * ABM DE PERMISOS
         */

        static void MenuPermisos()
        {
            int opcion;

            do
            {
                Console.WriteLine("===== ABM DE PERMISOS =====");
                Console.WriteLine("1 - Listar permisos");
                Console.WriteLine("2 - Alta permiso");
                Console.WriteLine("3 - Modificar permiso");
                Console.WriteLine("4 - Eliminar permiso");
                Console.WriteLine("0 - Volver");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarPermisos();
                        break;

                    case 2:
                        AltaPermiso();
                        break;

                    case 3:
                        ModificarPermiso();
                        break;

                    case 4:
                        EliminarPermiso();
                        break;

                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.WriteLine();
                }

            } while (opcion != 0);
        }

        static void ListarPermisos()
        {
            Console.WriteLine();
            Console.WriteLine("LISTA DE PERMISOS");
            Console.WriteLine("-----------------------------");

            if (listaPermisos.Count == 0)
            {
                Console.WriteLine("No hay permisos cargados.");
            }
            else
            {
                for (int i = 0; i < listaPermisos.Count; i++)
                {
                    Permiso permiso = (Permiso)listaPermisos[i];

                    Console.WriteLine(permiso.ToString());
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void AltaPermiso()
        {
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Permiso permisoExistente = BuscarPermiso(codigo);

            if (permisoExistente != null)
            {
                Console.WriteLine("Ya existe un permiso con ese código.");
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Permiso nuevoPermiso = new Permiso(
                codigo,
                nombre,
                descripcion
            );

            listaPermisos.Add(nuevoPermiso);

            Console.WriteLine("Permiso agregado correctamente.");
        }

        static void ModificarPermiso()
        {
            Console.Write("Código del permiso a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Permiso permiso = BuscarPermiso(codigo);

            if (permiso == null)
            {
                Console.WriteLine("Permiso no encontrado.");
                return;
            }

            Console.Write("Nuevo código: ");
            int nuevoCodigo = int.Parse(Console.ReadLine());

            Permiso permisoConNuevoCodigo = BuscarPermiso(nuevoCodigo);

            if (permisoConNuevoCodigo != null && permisoConNuevoCodigo != permiso)
            {
                Console.WriteLine("Ya existe otro permiso con ese código.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Nueva descripción: ");
            string nuevaDescripcion = Console.ReadLine();

            permiso.Codigo = nuevoCodigo;
            permiso.Nombre = nuevoNombre;
            permiso.Descripcion = nuevaDescripcion;

            Console.WriteLine("Permiso modificado correctamente.");
        }

        static void EliminarPermiso()
        {
            Console.Write("Código del permiso a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Permiso permiso = BuscarPermiso(codigo);

            if (permiso == null)
            {
                Console.WriteLine("Permiso no encontrado.");
                return;
            }

            if (PermisoEstaAsignado(permiso))
            {
                Console.WriteLine("No se puede eliminar. El permiso está asignado a un grupo o usuario.");
                return;
            }

            listaPermisos.Remove(permiso);

            Console.WriteLine("Permiso eliminado correctamente.");
        }

        /*
         * ABM DE GRUPOS
         */

        static void MenuGrupos()
        {
            int opcion;

            do
            {
                Console.WriteLine("===== ABM DE GRUPOS =====");
                Console.WriteLine("1 - Listar grupos");
                Console.WriteLine("2 - Alta grupo");
                Console.WriteLine("3 - Modificar grupo");
                Console.WriteLine("4 - Eliminar grupo");
                Console.WriteLine("0 - Volver");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarGrupos();
                        break;

                    case 2:
                        AltaGrupo();
                        break;

                    case 3:
                        ModificarGrupo();
                        break;

                    case 4:
                        EliminarGrupo();
                        break;

                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.WriteLine();
                }

            } while (opcion != 0);
        }

        static void ListarGrupos()
        {
            Console.WriteLine();
            Console.WriteLine("LISTA DE GRUPOS");
            Console.WriteLine("-----------------------------");

            if (listaGrupos.Count == 0)
            {
                Console.WriteLine("No hay grupos cargados.");
            }
            else
            {
                for (int i = 0; i < listaGrupos.Count; i++)
                {
                    Grupo grupo = (Grupo)listaGrupos[i];

                    Console.WriteLine(grupo.ToString());
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void AltaGrupo()
        {
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Grupo grupoExistente = BuscarGrupo(codigo);

            if (grupoExistente != null)
            {
                Console.WriteLine("Ya existe un grupo con ese código.");
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            ArrayList permisosSeleccionados = SeleccionarPermisos();

            Grupo nuevoGrupo = new Grupo(
                codigo,
                nombre,
                descripcion,
                permisosSeleccionados
            );

            listaGrupos.Add(nuevoGrupo);

            Console.WriteLine("Grupo agregado correctamente.");
        }

        static void ModificarGrupo()
        {
            Console.Write("Código del grupo a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Grupo grupo = BuscarGrupo(codigo);

            if (grupo == null)
            {
                Console.WriteLine("Grupo no encontrado.");
                return;
            }

            Console.Write("Nuevo código: ");
            int nuevoCodigo = int.Parse(Console.ReadLine());

            Grupo grupoConNuevoCodigo = BuscarGrupo(nuevoCodigo);

            if (grupoConNuevoCodigo != null && grupoConNuevoCodigo != grupo)
            {
                Console.WriteLine("Ya existe otro grupo con ese código.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Nueva descripción: ");
            string nuevaDescripcion = Console.ReadLine();

            ArrayList nuevosPermisos = SeleccionarPermisos();

            grupo.Codigo = nuevoCodigo;
            grupo.Nombre = nuevoNombre;
            grupo.Descripcion = nuevaDescripcion;
            grupo.ListaPermisos = nuevosPermisos;

            Console.WriteLine("Grupo modificado correctamente.");
        }

        static void EliminarGrupo()
        {
            Console.Write("Código del grupo a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Grupo grupo = BuscarGrupo(codigo);

            if (grupo == null)
            {
                Console.WriteLine("Grupo no encontrado.");
                return;
            }

            if (GrupoEstaAsignado(grupo))
            {
                Console.WriteLine("No se puede eliminar. El grupo está asignado a un usuario.");
                return;
            }

            listaGrupos.Remove(grupo);

            Console.WriteLine("Grupo eliminado correctamente.");
        }

        /*
 * ABM DE USUARIOS
 */

        static void MenuUsuarios()
        {
            int opcion;

            do
            {
                Console.WriteLine("===== ABM DE USUARIOS =====");
                Console.WriteLine("1 - Listar usuarios");
                Console.WriteLine("2 - Alta usuario");
                Console.WriteLine("3 - Modificar usuario");
                Console.WriteLine("4 - Eliminar usuario");
                Console.WriteLine("0 - Volver");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        ListarUsuarios();
                        break;

                    case 2:
                        AltaUsuario();
                        break;

                    case 3:
                        ModificarUsuario();
                        break;

                    case 4:
                        EliminarUsuario();
                        break;

                    case 0:
                        Console.WriteLine("Volviendo al menú principal...");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    Console.WriteLine();
                }

            } while (opcion != 0);
        }

        static void ListarUsuarios()
        {
            Console.WriteLine();
            Console.WriteLine("LISTA DE USUARIOS");
            Console.WriteLine("-----------------------------");

            if (listaUsuarios.Count == 0)
            {
                Console.WriteLine("No hay usuarios cargados.");
            }
            else
            {
                for (int i = 0; i < listaUsuarios.Count; i++)
                {
                    Usuario usuario = (Usuario)listaUsuarios[i];

                    Console.WriteLine(usuario.ToString());
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void AltaUsuario()
        {
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());

            Usuario usuarioExistente = BuscarUsuario(codigo);

            if (usuarioExistente != null)
            {
                Console.WriteLine("Ya existe un usuario con ese código.");
                return;
            }

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("DNI: ");
            string dni = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Grupo grupo = SeleccionarGrupo();

            if (grupo == null)
            {
                Console.WriteLine("No se pudo crear el usuario porque no se seleccionó un grupo válido.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Selección de permisos propios del usuario.");

            ArrayList permisosPropios = SeleccionarPermisos();

            Usuario nuevoUsuario = new Usuario(
                codigo,
                nombre,
                apellido,
                dni,
                password,
                email,
                grupo,
                permisosPropios
            );

            listaUsuarios.Add(nuevoUsuario);

            Console.WriteLine("Usuario agregado correctamente.");
        }

        static void ModificarUsuario()
        {
            Console.Write("Código del usuario a modificar: ");
            int codigo = int.Parse(Console.ReadLine());

            Usuario usuario = BuscarUsuario(codigo);

            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            Console.Write("Nuevo código: ");
            int nuevoCodigo = int.Parse(Console.ReadLine());

            Usuario usuarioConNuevoCodigo = BuscarUsuario(nuevoCodigo);

            if (usuarioConNuevoCodigo != null && usuarioConNuevoCodigo != usuario)
            {
                Console.WriteLine("Ya existe otro usuario con ese código.");
                return;
            }

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Nuevo apellido: ");
            string nuevoApellido = Console.ReadLine();

            Console.Write("Nuevo DNI: ");
            string nuevoDni = Console.ReadLine();

            Console.Write("Nuevo password: ");
            string nuevoPassword = Console.ReadLine();

            Console.Write("Nuevo email: ");
            string nuevoEmail = Console.ReadLine();

            Grupo nuevoGrupo = SeleccionarGrupo();

            if (nuevoGrupo == null)
            {
                Console.WriteLine("No se pudo modificar el usuario porque no se seleccionó un grupo válido.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Selección de nuevos permisos propios del usuario.");

            ArrayList nuevosPermisos = SeleccionarPermisos();

            usuario.Codigo = nuevoCodigo;
            usuario.Nombre = nuevoNombre;
            usuario.Apellido = nuevoApellido;
            usuario.DNI = nuevoDni;
            usuario.Password = nuevoPassword;
            usuario.Email = nuevoEmail;
            usuario.Grupo = nuevoGrupo;
            usuario.ListaPermisos = nuevosPermisos;

            Console.WriteLine("Usuario modificado correctamente.");
        }

        static void EliminarUsuario()
        {
            Console.Write("Código del usuario a eliminar: ");
            int codigo = int.Parse(Console.ReadLine());

            Usuario usuario = BuscarUsuario(codigo);

            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado.");
                return;
            }

            listaUsuarios.Remove(usuario);

            Console.WriteLine("Usuario eliminado correctamente.");
        }

        static Usuario BuscarUsuario(int codigo)
        {
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                Usuario usuario = (Usuario)listaUsuarios[i];

                if (usuario.Codigo == codigo)
                {
                    return usuario;
                }
            }

            return null;
        }

        static Grupo SeleccionarGrupo()
        {
            if (listaGrupos.Count == 0)
            {
                Console.WriteLine("No hay grupos cargados.");
                return null;
            }

            Grupo grupoSeleccionado = null;

            do
            {
                Console.WriteLine();
                Console.WriteLine("GRUPOS DISPONIBLES");
                Console.WriteLine("-----------------------------");

                for (int i = 0; i < listaGrupos.Count; i++)
                {
                    Grupo grupo = (Grupo)listaGrupos[i];

                    Console.WriteLine("Código: " + grupo.Codigo + " - Nombre: " + grupo.Nombre);
                }

                Console.Write("Ingrese el código del grupo: ");
                int codigoGrupo = int.Parse(Console.ReadLine());

                grupoSeleccionado = BuscarGrupo(codigoGrupo);

                if (grupoSeleccionado == null)
                {
                    Console.WriteLine("Grupo no encontrado. Intente nuevamente.");
                }

            } while (grupoSeleccionado == null);

            return grupoSeleccionado;
        }

        /*
         * MÉTODOS AUXILIARES
         */

        static Permiso BuscarPermiso(int codigo)
        {
            for (int i = 0; i < listaPermisos.Count; i++)
            {
                Permiso permiso = (Permiso)listaPermisos[i];

                if (permiso.Codigo == codigo)
                {
                    return permiso;
                }
            }

            return null;
        }

        static Grupo BuscarGrupo(int codigo)
        {
            for (int i = 0; i < listaGrupos.Count; i++)
            {
                Grupo grupo = (Grupo)listaGrupos[i];

                if (grupo.Codigo == codigo)
                {
                    return grupo;
                }
            }

            return null;
        }

        static ArrayList SeleccionarPermisos()
        {
            ArrayList permisosSeleccionados = new ArrayList();

            int codigoPermiso;

            do
            {
                Console.WriteLine();
                Console.WriteLine("PERMISOS DISPONIBLES");
                ListarPermisos();

                Console.WriteLine("Ingrese el código del permiso para agregar.");
                Console.WriteLine("Ingrese 0 para terminar.");
                Console.Write("Código de permiso: ");

                codigoPermiso = int.Parse(Console.ReadLine());

                if (codigoPermiso != 0)
                {
                    Permiso permiso = BuscarPermiso(codigoPermiso);

                    if (permiso == null)
                    {
                        Console.WriteLine("Permiso no encontrado.");
                    }
                    else
                    {
                        if (PermisoYaSeleccionado(permisosSeleccionados, permiso))
                        {
                            Console.WriteLine("Ese permiso ya fue seleccionado.");
                        }
                        else
                        {
                            permisosSeleccionados.Add(permiso);
                            Console.WriteLine("Permiso agregado a la lista.");
                        }
                    }
                }

            } while (codigoPermiso != 0);

            return permisosSeleccionados;
        }

        static bool PermisoYaSeleccionado(ArrayList lista, Permiso permisoBuscado)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                Permiso permiso = (Permiso)lista[i];

                if (permiso == permisoBuscado)
                {
                    return true;
                }
            }

            return false;
        }

        static bool PermisoEstaAsignado(Permiso permisoBuscado)
        {
            for (int i = 0; i < listaGrupos.Count; i++)
            {
                Grupo grupo = (Grupo)listaGrupos[i];

                for (int j = 0; j < grupo.ListaPermisos.Count; j++)
                {
                    Permiso permiso = (Permiso)grupo.ListaPermisos[j];

                    if (permiso == permisoBuscado)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                Usuario usuario = (Usuario)listaUsuarios[i];

                for (int j = 0; j < usuario.ListaPermisos.Count; j++)
                {
                    Permiso permiso = (Permiso)usuario.ListaPermisos[j];

                    if (permiso == permisoBuscado)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool GrupoEstaAsignado(Grupo grupoBuscado)
        {
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                Usuario usuario = (Usuario)listaUsuarios[i];

                if (usuario.Grupo == grupoBuscado)
                {
                    return true;
                }
            }

            return false;
        }
    }
}