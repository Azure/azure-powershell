### Example 1: Returns a task with extended information that includes all secrets.
```powershell
Get-AzContainerRegistryTask  -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -TaskName quicktask
```

```output
Location Name      SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLast
                                                                                                                    ModifiedBy
-------- ----      -------------------   -------------------       ----------------------- ------------------------ --------------
eastus   quicktask 29/01/2023 8:34:07 pm nanxiangliu@microsoft.com User                    29/01/2023 8:34:07 pm    nanxiangliu@m…
```

Returns a task with extended information that includes all secrets.

