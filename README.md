# Sistema de Control de Acceso a Edificios

## Descripción

Este proyecto es una aplicación de escritorio desarrollada en **C# Windows Forms** con **SQL Server** para la gestión de accesos a un edificio. Permite registrar y controlar el ingreso y salida de empleados y visitantes, emitir alertas por accesos no autorizados y visualizar reportes.

---

## Funcionalidades Principales

- **Login con control de acceso por roles** (Administrador, Seguridad, Empleado).
- **CRUD funcional** para:
  - Empleados (nombre, rol, zona de acceso).
  - Visitantes (nombre, teléfono, motivo de visita).
- **Registro de accesos** por zona, con fecha/hora de entrada y salida.
- **Generación de alertas** de seguridad por accesos indebidos o fuera de horario.
- **Panel de monitoreo en tiempo real**.
- **Reportes filtrados** por persona, zona, horario y rol.
- Uso de **Stored Procedures** para lógica centralizada.
- Aplicación de patrones de diseño:
  - **Repository Pattern** para abstracción de datos.
  - **Singleton** para la conexión a base de datos.
- Aplicación de principios **SOLID**:
  - **S - Single Responsibility**: Cada clase tiene una única responsabilidad.
  - **O - Open/Closed Principle**: Las clases están abiertas a extensión pero cerradas a modificación.

---

## Diagrama Entidad-Relación

![Diagrama ER](capturas/DiagramaDeClases)

---

## Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework (Windows Forms)
- **Base de Datos:** SQL Server
- **ORM:** ADO.NET (con Repository Pattern)
- **Diseño:** Patrones de diseño OOP
- **Control de versiones:** GitHub

---

## Capturas de Pantalla

| Login por roles | CRUD de Empleados | CRUD de Visitantes |
|------------------|-------------------|---------------------|
| ![Login](capturas/login.png) | ![Empleados](capturas/crud-empleados.png) | ![Visitantes](capturas/crud-visitantes.png) |

---

## Instrucciones para Compilar y Ejecutar

1. **Clona el repositorio**
   
