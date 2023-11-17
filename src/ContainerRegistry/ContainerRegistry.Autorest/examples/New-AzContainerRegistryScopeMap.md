### Example 1: Create scope map for a container registry
```powershell
New-AzContainerRegistryScopeMap -Name newmap -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Action "repositories/busybox/content/read"
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
newmap 01/20/2023 05:30:05 user@microsoft.com        User                    01/20/2023               05:30:05      
```

Create scope map for a container registry
