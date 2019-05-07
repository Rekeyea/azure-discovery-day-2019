# azure-discovery-day-2019
Implementación de una Arquitectura Serverless con Azure Cosmos DB, Azure Functions y Azure SignalR

## Infraestructura Necesaria en Azure

* Azure Cosmos DB
* Azure Functions App
    * Crear el storage de modo que permita subir un Static Site
* Azure SignalR

## Modificaciones Necesarias

* En el archivo local.settings.json se escriben los connection string de los servicios levantados
* Se sube la Azure Function
* Se suben los Settings a la Azure Function
* Se cambia el index.html (dentro de la carpeta "content") para utilizar la URL de la Azure Function App
* Se sube el index.html al Blob Storage de la Azure Function en el contenedor $web (como static site)