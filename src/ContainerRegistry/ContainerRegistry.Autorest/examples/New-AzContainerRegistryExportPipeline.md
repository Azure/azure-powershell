### Example 1: Create a new export pipeline
```powershell
New-AzContainerRegistryExportPipeline -name Exam -RegistryName RegistryExample -ResourceGroupName MyResourceGroup -IdentityType 'SystemAssigned' -TargetType AzureStorageBlobContainer -TargetUri https://sa.blob.core.windows.net/public/ -TargetKeyVaultUri https://examplekeyvault.vault.azure.net/secrets/test/18d55a35beba4b20bdd044a2a9d14c30
```

```output
Name   SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   -------------------   -------------------       ----------------------- ------------------------ ------------------------
Exam   30/01/2023 9:09:31 am user@microsoft.com        User                    30/01/2023 9:09:31 am    user@microsoft.com
```

Create a new export pipeline


