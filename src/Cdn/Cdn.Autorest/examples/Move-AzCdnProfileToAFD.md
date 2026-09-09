### Example 1: Start a migration
```powershell
$map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2

Move-AzCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -SkuName Premium_AzureFrontDoor -MigrationEndpointMapping @($map1)
```

```output
Start the initial progress of migration of CDN profile to Azure Front Door.

Migration of endpoint completed.

MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile

Now you can commit the migration to finalize the migration process.
```

The MigrationEndpointMapping parameter used in situation that users want to migrate an endpoint with and old name to a new endpoint name.

### Example 2: Start a migration with managed identity settings.
```powershell
$map1 = New-AzCdnMigrationEndpointMappingObject -MigratedFrom maxtestendpointcli-test-profile1.azureedge.net -MigratedTo maxtestendpointcli-test-profile2

Move-AzCdnProfileToAFD -ProfileName cli-test-profile -ResourceGroupName cli-test-rg -SkuName Premium_AzureFrontDoor -MigrationEndpointMapping @($map1) -IdentityType "SystemAssigned"
```

```output
Start the initial progress of migration of CDN profile to Azure Front Door.

Migration of endpoint completed.
Now enabling managed identity.
MigratedProfileResourceId
-------------------------
/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile

ExtendedProperty             : {
                                 "Sku": "Premium_AzureFrontDoor"
                               }
FrontDoorId                  :
Id                           : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourcegroups/cli-test-rg/providers/Microsoft.Cdn/profiles/cli-test-profile
IdentityPrincipalId          : 97fdf684-e1c7-431d-af54-a11c7443707d
IdentityTenantId             : 72f988bf-86f1-41af-91ab-2d7cd011db47
IdentityType                 : SystemAssigned
IdentityUserAssignedIdentity : {
                               }
Kind                         : cdn
Location                     : Global
LogScrubbingRule             :
LogScrubbingState            :
Name                         : cli-test-profile
OriginResponseTimeoutSecond  :
ProvisioningState            : Succeeded
ResourceGroupName            : cli-test-rg
ResourceState                : Migrating
SkuName                      : Standard_Microsoft
SystemData                   : {
                               }
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Tag                          : {
                               }
Type                         : Microsoft.Cdn/profiles

Now you can commit the migration to finalize the migration process.
```

The MigrationEndpointMapping parameter used in situation that users want to migrate an endpoint with and old name to a new endpoint name.