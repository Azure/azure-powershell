### Example 1: Get all Azure region location details with default context
```powershell
Get-AzImportExportLocation
```

```output
Name                 Type
----                 ----
Australia East       Microsoft.ImportExport/locations
Australia Southeast  Microsoft.ImportExport/locations
Brazil South         Microsoft.ImportExport/locations
Canada Central       Microsoft.ImportExport/locations
Canada East          Microsoft.ImportExport/locations
...
West Central US      Microsoft.ImportExport/locations
West Europe          Microsoft.ImportExport/locations
West India           Microsoft.ImportExport/locations
West US              Microsoft.ImportExport/locations
West US 2            Microsoft.ImportExport/locations
```

This cmdlet gets all Azure region location details with default context.

### Example 2: Get Azure region location details by location name
```powershell
Get-AzImportExportLocation -Name eastus
```

```output
Name    Type
----    ----
East US Microsoft.ImportExport/locations
```

This cmdlet gets Azure region location details by location name.

### Example 3: Get Azure region location details by identity
```powershell
$Id = "/providers/Microsoft.ImportExport/locations/eastus"
Get-AzImportExportLocation -InputObject $Id
```

```output
Name    Type
----    ----
East US Microsoft.ImportExport/locations
```

This cmdlet lists gets Azure region location details by identity.