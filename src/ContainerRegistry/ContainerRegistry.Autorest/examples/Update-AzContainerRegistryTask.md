### Example 1: Updates a task with the specified parameters.
```powershell
Update-AzContainerRegistryTask -TaskName quicktask  -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -Status 'Enabled'
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLast
                                                                                                                    ModifiedBy
-------- ----      -------------------   -------------------       ----------------------- ------------------------ --------------
eastus   quicktask 29/01/2023 8:34:07 pm user@microsoft.com        User                    30/01/2023 7:58:33 pm    user@microsoft.com
```

Updates a task with the specified parameters.
