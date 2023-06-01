### Example 1: Create new token for certain container registry
```powershell
New-AzContainerRegistryToken -Name token2 -RegistryName lnxcr -ResourceGroupName lnxtest -ScopeMapId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lnxtest/providers/Microsoft.ContainerRegistry/registries/lnxcr/scopeMaps/newmap
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
token 01/20/2023 05:14:16  user@microsoft.com User                01/20/2023 05:14:16                       user

```

Create new token for certain container registry


