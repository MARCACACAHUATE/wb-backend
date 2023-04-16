# WujuBalloon Backend

Backend para el proyecto WujuBallon que se encargara de proveer todas las funciones de los modulos de Eventos y Cursos descritas en el documento de diseño.

## Prerequisitos 
Para que funcione el proyecto primero debemos tener instalado:

- [.Net SDK 7.0](https://dotnet.microsoft.com/es-es/download/dotnet/7.0)
- Base de datos Postgres del proyecto funcionando

## Iniciar el Proyecto

```bash
    # Clonamos el proyecto
    git clone https://github.com/MARCACACAHUATE/wb-backend.git

    # instalamos las dependencias del proyecto
    dotnet restore

    # compilamos y corremos el proyecto
    dotnet run
```

## Crear la base de datos

La base de datos puede ser creada mediante las migraciones. Para poder realizar esto debemos tener instalado lo siguiente:

- Obiamente tener una instancia de PostgreSQL funcionando con una DB llamada "WujuDB" ya creada.
- [La herramienta de CLI de Entity Framework.](https://learn.microsoft.com/en-us/ef/core/cli/dotnet) Si estan utilizando alguna version de Visual Studio creo que ya viene instalada.

```bash
    # el projecto utiliza secrets para las credenciles de conexion a la DB asi que debemos inicializarlos.
    dotnet user-secrets init

    # seteamos el secreto que almacenara las credenciales. Nota: remplasar los valores my_ por tus credenciales.
    dotnet user-secrets set "ConnectionString" "Server=my_host Database=WujuDB;Port=my_port; User Id=my_user;Password=my_password"

    # Si todo esta bien ahora corremos la migracion.
    dotnet ef database update
```

[*Documentacion de los UserSecrets*](https://learn.microsoft.com/es-es/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows)


Si todo salio bien ya tendremos las tablas creadas en la base de datos.