### Example 1: Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
```powershell
Move-AzCdnProfile -ResourceGroupName AFD -ClassicResourceReferenceId /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourcegroups/AFD/providers/Microsoft.Network/Frontdoors/afdruncanary2 -ProfileName afdruncanary2-migrated -SkuName Standard_AzureFrontDoor 
```

```output
Location
--------
```

Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile. The change need to be committed after this.

