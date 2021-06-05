
## Habilitar Runtime Compilation para Razor

instalar [Paquete](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/)

En startup agregar 

```sh
services.AddRazorPages().AddRazorRuntimeCompilation();
```

## Conectando con DB

### Paquetes Necesarios


```sh
dotnet tool install --global dotnet-ef (solo en caso de no tenerlo instalado)

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add Microsoft.EntityFrameworkCore.SqlServer
```
Posteriormente será necesario ejecutar el comando que se encarga de Mapear las tablas

```sh
dotnet ef dbcontext scaffold "Data Source=server;Initial Catalog=database;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;" Microsoft.EntityFrameworkCore.SqlServer  -o Models -t tableName -c contextName --context-dir Database -f
```

Es muy importante aplicar inyección de dependencias para mantener la seguridad de la cadena de conexión

```sh
services.AddDbContext<contextName>(o => o.UseSqlServer(Configuration.GetConnectionString("ConnectionName")));
```

Para agregar los servicios mediante inyección de dependencia


```sh
services.AddScoped<IInterfaceName, ClassName>();
```
