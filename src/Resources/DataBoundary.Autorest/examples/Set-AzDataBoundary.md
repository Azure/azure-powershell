### Example 1: Set Tenant Level Data Boundary

```powershell
$dataBoundary = "EU"
Set-AzDataBoundary -DataBoundary $dataBoundary
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Sets the dataBoundary at the tenant level.

### Example 2: Set Tenant Level Data Boundary2

```powershell
$dataBoundary = "EU"
Set-AzDataBoundary -DataBoundaryDefinition $dataBoundary
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Sets the dataBoundary at the tenant level.

### Example 3: Set Tenant Level Data Boundary3

```powershell
$dataBoundary = "EU"
Set-AzDataBoundary -JsonFilePath $dataBoundary
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Sets the dataBoundary at the tenant level.

### Example 4: Set Tenant Level Data Boundary4

```powershell
$dataBoundary = "EU"
Set-AzDataBoundary -JsonString $dataBoundary
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Sets the dataBoundary at the tenant level.

