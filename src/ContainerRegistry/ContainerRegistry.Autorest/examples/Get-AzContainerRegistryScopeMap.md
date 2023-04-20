### Example 1: List all scope maps for a container registry
```powershell
Get-AzContainerRegistryScopeMap -RegistryName RegistryExample -ResourceGroupName MyResourceGroup 
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
newmap 01/20/2023 05:30:05 user@microsoft.com        User                    01/20/2023               05:30:05      
```

List all scope maps for a container registry


