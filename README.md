
## Habilitar Runtime Compilation para Razor

instalar [Paquete](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/)

En startup agregar 

```sh
services.AddRazorPages().AddRazorRuntimeCompilation();
```


