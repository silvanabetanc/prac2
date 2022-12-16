# Information
Microservicio para invocar a servicios externos.

WSClientes0009 ====>  www.servicioxterno.com/prueba.aspx

# Documentation 
Controla la ejecución del programa dirigiendo las llamadas a otras funciones dentro del proyecto.

SwaggerDoc: en el archivo Program.cs , agregar nombre del servicio, título, descripción 

# Build 
InstanciaController.cs: representa el nombre del dominio en la que implementa el controlador Ejemplo: ClienteController.cs

InitConfig.cs: carga inicial de componentes, centralizada.

Program.cs: Clase de inicialización del servicio, carga centralizada, injection de repositorio, infraestructura, kafka.


# Nuget Packages
1. Swashbuckle.AspNetCore(6.2.3)
2. BP.Provider(1.0.0)
3. MethodBoundaryAspect.Fody(2.0.145)
4. Microsoft.AspNetCore.Mvc.Versioning(5.0.0)