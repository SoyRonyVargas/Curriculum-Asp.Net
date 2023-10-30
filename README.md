﻿
# Generar el context desde la consola de paquetes

```
Scaffold-DbContext "Server=localhost\SQLEXPRESS; Database=TuBaseDeDatos; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

# Actualizar modelos

```
Scaffold-DbContext "Server=localhost\SQLEXPRESS; Database=TuBaseDeDatos; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```