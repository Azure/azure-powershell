### Example 1: {{ Add title here }}
```powershell
Get-AzContainerRegistryToken -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLa
                                                                                                      stModifiedBy
----   ------------------- -------------------       ----------------------- ------------------------ ------------
token  01/20/2023 05:12:02 user@microsoft.com        User                    01/20/2023 05:12:02      user
token2 01/20/2023 05:14:16 user@microsoft.com        User                    01/20/2023 05:14:16      user

```

List Registry token in a registry


