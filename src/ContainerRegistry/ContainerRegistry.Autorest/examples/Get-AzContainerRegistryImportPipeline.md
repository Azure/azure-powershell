### Example 1: Lists all import pipelines for the specified container registry.
```powershell
Get-AzContainerRegistryImportPipeline -RegistryName RegistryExample -ResourceGroupName MyResourceGroup
```

```output
Name    SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----    -------------------   -------------------       ----------------------- ------------------------ ------------------------
Example 30/01/2023 9:09:31 am user@microsoft.com        User                    30/01/2023 9:09:31 am    user@microsoft.com
```

Lists all import pipelines for the specified container registry.


