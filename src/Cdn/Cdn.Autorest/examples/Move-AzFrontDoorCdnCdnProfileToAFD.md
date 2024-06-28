### Example 1: Start Migration
```powershell
Move-AzFrontDoorCdnCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -Sku Premium_AzureFrontDoor
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-te…
```

Start migration progress

### Example 2: Start Migration with MigrationEndpointMapping
```powershell
Move-AzFrontDoorCdnCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -Sku Premium_AzureFrontDoor -MigrationEndpointMapping @(@{"migrated-from"="maxtestendpointcli-test-profile1.azureedge.net";"migrated-to"="maxtestendpointcli-test-profile2"})
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile
```

The MigrationEndpointMapping parameter used in situation that users want to migrate an endpoint with and old name to a new endpoint name.

