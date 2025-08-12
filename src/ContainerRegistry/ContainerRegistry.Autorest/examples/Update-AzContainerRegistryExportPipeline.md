### Example 1: Update an export pipeline for a container registry with the specified parameters.

```powershell
Update-AzContainerRegistryExportPipeline -Name Exam -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -EnableSystemAssignedIdentity -TargetType AzureStorageBlobContainer -TargetUri https://sa.blob.core.windows.net/public/ -TargetKeyVaultUri https://examplekeyvault.vault.azure.net/secrets/test/18d55a35beba4b20bdd044a2a9d14c30
```

```output
Name   SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   -------------------   -------------------       ----------------------- ------------------------ ------------------------
Exam   30/01/2023 9:09:31 am user@microsoft.com        User                    30/01/2023 9:09:31 am    user@microsoft.com
```

Update an export pipeline for a container registry with the specified parameters.