### Example 1: When the CDN proflie not associated with WAF and has no customer certificate... 
```powershell
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor
```

```output
Location
--------
```

When the CDN proflie not associated with WAF and has no customer certificate.
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

### Example 2: When the CDN proflie associated with WAF and copy to a new WAF policy...
```powershell
$wafMapping = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/newWAFName
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -MigrationWebApplicationFirewallMapping $wafMapping
```

```output
Location
--------
```

When the CDN proflie associated with WAF and copy to a new WAF policy. The new WAF policy should be created in the same subscription and resource group with the CDN profile's.
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

### Example 3: When the CDN proflie associated with WAF and select an existing WAF policy...
```powershell
$wafMapping = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/existingWAFName
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -MigrationWebApplicationFirewallMapping $wafMapping
```

```output
Location
--------
```

When the CDN proflie associated with WAF and select an existing WAF policy. You could only select the WAF policy located in the same subscription with the CDN profile's.
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.


### Example 4: When the CDN proflie associated with WAF and has customer certificate... 
```powershell
$wafMapping1 = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01test

$wafMapping2 = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf02 -MigratedToId  /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf02test

# enable MSI via SystemAssigned and UserAssigned
$identityType = "SystemAssigned, UserAssigned"

# UserIdentity information
$userInfo = @{
	"/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourceGroups/rgName01/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity01" = @{}
	"/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourceGroups/rgName02/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity02" = @{}
}

Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Premium_AzureFrontDoor -MigrationWebApplicationFirewallMapping @($wafMapping1, $wafMapping2) -IdentityType $identityType -IdentityUserAssignedIdentity $userInfo
```

```output
Location
--------
```

When the CDN proflie associated with WAF and has customer certificate.
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

### Example 5: When the CDN proflie not associated with WAF and has no customer certificate, and the subscription of the CDN profile is different from the local subscrition
```powershell
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId01/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -SubscriptionId testSubId01
```

```output
Location
--------
```

When the CDN proflie not associated with WAF and has no customer certificate, and the subscription of the CDN profile is different from the local subscrition.
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.