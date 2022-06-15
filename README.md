# UserMicroService
Para ejecutar el proyecto, basta con descargarlo y adecuar la connectionString según el ambiente.
Contiene un pequeño data seed, para empezar a probar.
Se utiliza Swagger.

## Capas del proyecto
- Bussines
  - Bussines
    1. Users: Implementa la capa de lógica de negocio relacionado a la entidad user, se realiza el mapping entre request / response y la entidad de dominio.

- DataAccess
  - Context: contiene el contexto para acceso a la base de datos
  - DataAccess: implementación del repositorio para el acceso a datos.
  
- EntitiesProvider
  - DomainEntities: entidades de dominio.
  - Enums: pequeño enumerado para los mensajes a retornar
  - Interfaces: 
    1. Bussiness: interfaz de la lógica de negocio
    2. DataAccess: interfaz de acceso a datos
  - ModelEntities:
    1. Request: contiene los modelos que se utilizan en las request
    2. Response: contiene los modelos que se van a retormar.
  
- Test
  - Test
    1. Bussiness: contiene el test de la capa de negocio.
