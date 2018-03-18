# WoollyBusiness

example SbContext Scaffold build
and migrating VS application Context into empty WoollyBusinessApplication db
```
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=WoollyBusiness;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Update-Database -Context WoollyBusinessApplication
```
https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
