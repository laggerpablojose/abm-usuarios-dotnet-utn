# ABM de Usuarios .NET

Aplicación de consola desarrollada en C# como trabajo práctico académico de la materia Programación .NET de la Tecnicatura Universitaria en Tecnologías de la Información de la UTN FRSF.

## Objetivo académico

El objetivo del proyecto es aplicar conceptos de programación orientada a objetos mediante la construcción de un sistema de administración de permisos, grupos y usuarios.

El sistema permite representar relaciones entre objetos, utilizar colecciones no genéricas y organizar operaciones de alta, baja, modificación y consulta desde una aplicación de consola.

## Funcionalidades implementadas

- Menú principal de navegación.
- ABM completo de permisos.
- ABM completo de grupos.
- ABM completo de usuarios.
- Alta de nuevos permisos, grupos y usuarios.
- Listado de permisos, grupos y usuarios.
- Modificación de datos existentes.
- Eliminación de registros.
- Validación de códigos repetidos.
- Validación para evitar eliminar objetos relacionados.
- Asignación de permisos a grupos.
- Asociación de usuarios a grupos.
- Asignación de permisos propios a usuarios.
- Carga inicial de datos para prueba.
- Pruebas manuales de funcionamiento.

## Modelo de clases

El proyecto utiliza las siguientes clases principales:

### Permiso

Representa una autorización o acción disponible dentro del sistema.

### Grupo

Representa un conjunto de permisos. Un grupo puede tener varios permisos asociados.

### Usuario

Representa un usuario del sistema. Cada usuario se asocia a un grupo y puede tener permisos propios adicionales.

### Program

Contiene el punto de entrada de la aplicación, las listas generales, el menú principal y las operaciones ABM.

## Relaciones principales

- Un grupo contiene permisos.
- Un usuario pertenece a un grupo.
- Un usuario puede tener permisos propios.
- Las entidades se administran mediante listas generales estáticas.

## Tecnologías utilizadas

- C#
- .NET
- Visual Studio
- Aplicación de consola
- Git
- GitHub
- `System.Collections`
- `ArrayList`

## Conceptos aplicados

- Clases y objetos.
- Atributos privados.
- Propiedades públicas.
- Constructores completos.
- Sobrescritura del método `ToString`.
- Encapsulamiento.
- Relaciones entre clases.
- Asociación entre objetos.
- Colecciones no genéricas.
- Uso de `ArrayList`.
- Estructuras condicionales.
- Estructuras repetitivas.
- Métodos.
- Modularización.
- Validaciones básicas.
- Control de versiones con Git.

## Estado del proyecto

Finalizado para entrega académica.

El sistema cuenta con ABM completo de permisos, grupos y usuarios, incluyendo validaciones de códigos repetidos y controles para evitar la eliminación de objetos relacionados.

## Ejecución

1. Clonar o descargar el repositorio.
2. Abrir el archivo `.sln` con Visual Studio.
3. Compilar la solución.
4. Ejecutar el proyecto de consola.
5. Utilizar el menú principal para acceder a las operaciones disponibles.

## Integrantes

- Lagger, Pablo José.
- Lezcano, Claudio
- Bocchieri, Matías.
- Gramajo, María Paula.

## Aclaración

Este repositorio corresponde a un proyecto académico desarrollado para la materia Programación .NET de la UTN FRSF. No representa un sistema productivo, sino una práctica orientada a aplicar los contenidos trabajados en la cátedra.
