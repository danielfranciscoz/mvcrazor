
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

## Validaciones con DataAnnotations

Para validar los datos enviados desde el cliente, es posible utilizar Etiquetas en los campos de nuestro modelo, podremos validar escenarios como: Requerido, Tamaño Minimo o Maximo, Correo, Patrones, Etc.
```sh
[Required]
[EmailFormatValid]
[MaxLength(value)]
[MinLength(value)]
[Range(minValue, maxValue, ErrorMessage = "Here goes your error message")]
```

Tambien podemos personalizar los mensajes de error con:

```sh
[Required(ErrorMessage="Mensaje Personalizado")]
```


## Manejo de datos no encontrados (Error 404 - Not Found)

- Retornar el método NotFound en el controlador
- Visualizar el error con el siguiente codigo en el startup

```sh
   app.UseStatusCodePages();
```

- Podemos mejorar la visualizacion del error, atravez de una vista propia, actualizar en el startup

```sh
app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
```

Agregar en el controlador de home

```sh
[Route("/Home/HandleError/{code:int}")]
public IActionResult HandleError(int code)
{
   ViewData["ErrorMessage"] = $"Ocurrio un error, el codigo de error es: {code}";
   return View("~/Views/Shared/HandleError.cshtml");
}
```


## Sesiones de usuario


El manejo de sesiones es importante cuando queremos crear inicios de sesion  en nuestra aplicacion, lo primero es habilitarlas en el startup

En la configuracion de los servicios agregar
```sh
services.AddSession();
```

En la configuracion agregar y/o reemplazar
```sh
app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
```

Posterior agregar el controlador de login con las acciones de login y logout

Al momento de realizar el proceso de login, será necesario validar que el usuario enviado exista y posterior almacenarlo en la session

```sh

            if (usuarioExist)
            {
                HttpContext.Session.SetString(VariabledeSesion, NombreUsuario);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError("", "Datos ingresado no válido.");
            }

            return View(u);
```


La accion de logout debe limpiar la sesion

```sh
    HttpContext.Session.Clear();
```

- Agregar la vista para el login, basandose en [Formulario de Inicio de Sesión básico](https://jsfiddle.net/StartBootstrap/efvg9j7a/)
- Editar el layout principal con un form en el header para poder realizar logout

```sh
   @using (Html.BeginForm("Logout", "Login", FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
                            {
                            <a class="nav-link" href="javascript:document.getElementById('logoutForm').submit()">
                                Sign out(@usuarioActual)
                            </a>
                            }

```


Podremos obtener en la vista el usuario de la sesion de la siguiente manera

```sh
@using Microsoft.AspNetCore.Http

@{
    var usuarioActual = Context.Session.GetString("VariableSesion");

}
```
