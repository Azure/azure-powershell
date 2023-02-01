### Example 1: Update token scope map for a token
```powershell
Update-AzContainerRegistryToken -name token -ScopeMapId /subscriptions/${subscription}/resourceGroups/myResourceGroups/providers/Microsoft.ContainerRegistry/registry/MyRegistries/scopeMaps/test -RegistryName MyRegistry -ResourceGroupName myResourceGroups
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
token 01/20/2023 05:59:56  user@microsoft.com User                    01/20/2023 05:59:56             user

```

Update token scope map for a token
