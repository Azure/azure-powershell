### Example 1: Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.
```powershell
Invoke-AzCdnCanProfileMigrate -ResourceGroupName AFD -ClassicResourceReferenceId /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourcegroups/AFD/providers/Microsoft.Network/Frontdoors/afdruncanary2
```

```output
CanMigrate DefaultSku
---------- ----------
True       Standard_AzureFrontDoor
```

Checks if CDN profile can be migrated to Azure Frontdoor(Standard/Premium) profile.