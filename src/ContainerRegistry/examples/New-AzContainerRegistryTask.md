### Example 1: Create a quicktask
```powershell
 New-AzContainerRegistryTask -Name quicktask -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Location "eastus" -Status 'Enabled' -IsSystemTask -LogTemplate "acr/tasks:{{.Run.OS}}"
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt System
                                                                                                                    DataLa
                                                                                                                    stModi
                                                                                                                    fiedBy
-------- ----      -------------------   -------------------       ----------------------- ------------------------ ------
eastus   quicktask 29/01/2023 8:34:07 pm nanxiangliu@microsoft.com User                    29/01/2023 8:34:07 pm    nanxi…
```

Create a quicktask

