# Information
Implementación de la infraestructura para llamar al repositorio.

	srbetancBBDDSQl.Infraestructure						
						|
						Instancias						
							|
							InstanciaUno
						|
						Validaciones

# Documentation
Instancias : nombre del la base de datos que se va a consumir. CardHolder, Omnicanal, etc.

Validaciones: Se definen en esta estructura las clases para validar las Header, body y validaciones adicionales.

# Build 
InstanciaUnoInfraestructura.cs: infraestructura del servicio donde se  llama al repositorio y dónde se ejecutan las validaciones de la entrada.

# Nuget Packages
1.  FluentValidation(11.2.0)
2.  MethodBoundaryAspect.Fody(2.0.145)