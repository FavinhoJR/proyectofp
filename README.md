# Proyecto de Gestión de Estadísticas de un Campeonato de Fútbol (Proyecto Favio U)

## Descripción del Proyecto

Esta aplicación web permite gestionar las estadísticas de un campeonato de fútbol. Los usuarios pueden registrar y gestionar información sobre equipos, partidos y jugadores. La aplicación está desarrollada utilizando ASP.NET Core y C#.

## Funcionalidades

- Registrar y almacenar información de equipos participantes.
- Almacenar estadísticas de partidos, incluyendo marcadores, fechas y sedes.
- Registrar y almacenar estadísticas individuales de jugadores, incluyendo goles, asistencias, tarjetas amarillas y rojas.
- Consultar y visualizar las estadísticas almacenadas.
- Actualizar, modificar y eliminar información de equipos, partidos y jugadores.

## Estructura del Proyecto

### Estructuras de Datos

- **Árbol AVL**: Utilizado para gestionar la información de los equipos participantes.
- **Tabla Hash**: Utilizada para gestionar las estadísticas de los partidos.
- **Lista Enlazada**: Utilizada para gestionar las estadísticas individuales de los jugadores.

### Controladores

- **EquipoController**: Gestión de equipos.
- **PartidoController**: Gestión de partidos.
- **JugadorController**: Gestión de jugadores.

### Vistas

- **Equipo**
  - `Index.cshtml`: Muestra la lista de equipos.
  - `Crear.cshtml`: Formulario para agregar un nuevo equipo.
  - `Editar.cshtml`: Formulario para editar un equipo existente.
- **Partido**
  - `Index.cshtml`: Muestra la lista de partidos.
  - `Crear.cshtml`: Formulario para agregar un nuevo partido.
  - `Editar.cshtml`: Formulario para editar un partido existente.
- **Jugador**
  - `Index.cshtml`: Muestra la lista de jugadores.
  - `Crear.cshtml`: Formulario para agregar un nuevo jugador.
  - `Editar.cshtml`: Formulario para editar un jugador existente.

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/FavinhoJR/CreditCardManagement.git
