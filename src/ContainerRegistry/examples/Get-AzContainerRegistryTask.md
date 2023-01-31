### Example 1: List registry tasks of a container registry
```powershell
Get-AzContainerRegistryTask  -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLast
                                                                                                                    ModifiedBy
-------- ----      -------------------   -------------------       ----------------------- ------------------------ --------------
eastus   quicktask 29/01/2023 8:34:07 pm nanxiangliu@microsoft.com User                    29/01/2023 8:34:07 pm    nanxiangliu@m…
```

List registry tasks of a container registry

