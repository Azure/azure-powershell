### Example 1: Update action for a scope map
```powershell
Update-AzContainerRegistryScopeMap -Name newmap -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Action "repositories/busybox/content/read"
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLas
                                                                                                     tModifiedBy
----  ------------------- -------------------       ----------------------- ------------------------ -------------
newmap 01/20/2023 05:49:36 user@microsoft.com       User                    01/20/2023 05:49:36      user@microsoft.com  
```

Update action for a scope map



