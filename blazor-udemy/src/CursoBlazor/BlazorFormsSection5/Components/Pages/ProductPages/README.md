### This solution folder was scaffolded using the `dotnet-aspnet-codegenerator`:

With the already existing **Product entity, this s

#### The following command was executed

```bash
/home/lfilipecosta3/src/personal-projects/learn-blazor/blazor-udemy/src/CursoBlazor/BlazorFormsSection5/obj/dotnet-aspnet-codegenerator \
  --project /home/lfilipecosta3/src/personal-projects/learn-blazor/blazor-udemy/src/CursoBlazor/BlazorFormsSection5/BlazorFormsSection5.csproj \
  --target-framework net10.0 \
  --configuration "Debug" \
  --no-build blazor CRUD \
  --relativeFolderPath "/home/lfilipecosta3/src/personal-projects/learn-blazor/blazor-udemy/src/CursoBlazor/BlazorFormsSection5/Components/Pages/ProductPages" \
  --model BlazorFormsSection5.Entities.Product \
  --dataContext BlazorFormsSection5.Context.AppDbContext \
  --namespaceName BlazorFormsSection5 \
  -dbProvider sqlite
```

After that, I had to manually add the following nuget packages:
- Microsoft.AspNetCore.Components.QuickGrid
- Microsoft.AspNetCore.Components.QuickGrid.EntityFrameworkAdapter
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore