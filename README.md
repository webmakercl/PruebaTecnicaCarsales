
# Prueba Tecnica IT Hunters

Proyecto .NET 8 Con Angular. 
PruebaTecnicaCarsales es una POC que consume la API de RickAndMorty 

https://rickandmortyapi.com/documentation/


## Documentacion  WebApi .NET 8

Referente a la API .NET 8 se han creado carpetas para manejar los servicios, modelos y controladores

Se ha modificado el **Program.cs** 

* Se registraron las dependecias de los servicios
* Mostrar siempre el swaggerUI ,
* CORS para comunicacion entre los componentes de back y front
* Se ha limitado el acceso a los schemas

**Carpeta Controllers**

* Se añadieron 2 controladores para manejar las peticiones correspondientes a los Episodios y Personajes

* Cada controlador registra la inyeccion de dependencia mediante el constructor para el servicio que corresponda

* Se añadieron etiquetas para especificar el tipo de dato consumido y el tipo de dato producido, en ambos casos es application/json

**Carpeta Models**

* Se añadieron 3 clases que representan los modelos de datos ocupados

* La clase **ApiResponse** es la estructura con la que responde la api de rickandmorty, donde Info representa informacion y paginacion y Results el resultado de la consulta realizada

* **ApiResponse** tiene un tipo Record el cual fue declarado en la misma clase

* **Character** representa la estructura de datos para los Personajes. Ademas se han creado 2 Record para manejar los objetos **Origin** y **Location**

* **Episode** representa la estructura de datos para los Episodios.

**Carpeta Services**

* Se añadieron 2 clases cada una encargada de la ejecucion y deserializacion de la respuesta.

* **EpisodeService** Es el encargado de ejecutar la consulta de los Episodios mediante httpClient hacia la api y deserializacion de la respuesta.

* **CharacterService** Es el encargado de ejecutar la consulta para los Personajes mediante httpClient hacia la api y deserializacion de la respuesta.



## Documentacion  Angular 19

* Se añadieron los componentes necesarios para Episodios y Personajes
* Se añadio app.routes.ts
* Se modifico main.ts para uso de standalone y se añadio la etiqueta en la inicializacion de los componentes
* Se creo carpeta Services para cada componente donde se ejecuta la consulta y se crearon las estructuras de datos
* Se añadio la posibilidad de reintentar cuando falla la obtencion de datos.
* **Gran parte del CSS fue generado con COPILOT**

## Como ejecutar la solucion
* Abrir 2 terminal de desarrollador o powershell para desarrolldores una para cada app.

**En el caso de la app .NET 8**
* **cd '.\1.- BFF\'** -> para entrar a la raiz de la app
* **dotnet run** -> para ejecutar la aplicacion 
* http://localhost:5000 -> Se ha modificado el archivo LaunchSettings para hacer match al puerto

**En el caso de la app Angular**
* **cd '.\2.- Angular\'** -> para entrar a la raiz de la app
* **ng serve** -> para ejecutar la aplicacion 
* http://localhost:51194/
 



## Pendientes. //TO_DO:
* Cargar la informacion de los personajes una vez seleccionado un episodio en la tabla de Episodios
* Cargar informacion detalla al hacer click sobre un personaje en la seccion personajes