### Example 1: Get Tenant Level Data Boundary

```powershell
Get-AzDataBoundaryTenant
```

```output
Name                                    Id                                                                                      Properties 
--------                                ----                                                                                    ------------
00000000-0000-0000-0000-000000000000    /providers/Microsoft.Resources/dataBoundaries/00000000-0000-0000-0000-000000000000      dataBoundary: EU, provisioningState: Created
```

Gets the dataBoundary at the tenant level.