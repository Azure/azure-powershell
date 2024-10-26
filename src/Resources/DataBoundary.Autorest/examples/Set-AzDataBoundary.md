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
