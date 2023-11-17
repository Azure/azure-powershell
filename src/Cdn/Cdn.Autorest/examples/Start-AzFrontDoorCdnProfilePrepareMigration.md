### Example 1: When a classic AFD instance associated without WAF policy and has no customer certificates.
```powershell
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/testSubId/resourceGroups/rgName/providers/Microsoft.Cdn/profiles/name-migrated
```

When a classic AFD instance associated without WAF policy and has no customer certificates.
Migrate the classic AFD to Azure Front Door(Standard/Premium) profile..
The change need to be committed after this.

### Example 2: When a classic AFD instance associated with WAF and copy to a new WAF policy.
```powershell
$wafMapping = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/testSubId/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/testSubId/resourcegroups/rgName/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/newWAFName
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -MigrationWebApplicationFirewallMapping $wafMapping
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/testSubId/resourceGroups/rgName/providers/Microsoft.Cdn/profiles/name-migrated
```

When a classic AFD instance associated with WAF and copy to a new WAF policy. The new WAF policy should be created in the same subscription and resource group with the classic AFD instance's.
Migrate classic AFD to Azure Front Door(Standard/Premium) profile..
The change need to be committed after this.

### Example 3: When a classic AFD instance associated with WAF and select an existing WAF policy.
```powershell
$wafMapping = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/testSubId/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/testSubId/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/existingWAFName
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -MigrationWebApplicationFirewallMapping $wafMapping
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/testSubId/resourceGroups/rgName/providers/Microsoft.Cdn/profiles/name-migrated
```

When a classic AFD instance associated with WAF and select an existing WAF policy. You could only select the WAF policy located in the same subscription with the classic AFD instance's.
Migrate the classic AFD to Azure Front Door(Standard/Premium) profile..
The change need to be committed after this.


### Example 4: When a classic AFD instance associated with more than one WAF policy and has no customer certificates.
```powershell
$wafMapping1 = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/testSubId/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/testSubId/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01test

$wafMapping2 = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/testSubId/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf02 -MigratedToId  /subscriptions/testSubId/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf02test

# enable Managed Identity via SystemAssigned and UserAssigned
$identityType = "SystemAssigned, UserAssigned"

# UserIdentity information
$userInfo = @{
	"/subscriptions/testSubId/resourceGroups/rgName01/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity01" = @{}
	"/subscriptions/testSubId/resourceGroups/rgName02/providers/Microsoft.ManagedIdentity/userAssignedIdentities/identity02" = @{}
}

Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Premium_AzureFrontDoor -MigrationWebApplicationFirewallMapping @($wafMapping1, $wafMapping2) -IdentityType $identityType -IdentityUserAssignedIdentity $userInfo
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/testSubId/resourceGroups/rgName/providers/Microsoft.Cdn/profiles/name-migrated
```

When a classic AFD instance associated with more than one WAF policy and has no customer certificates.
Migrate the classic AFD to Azure Front Door(Standard/Premium) profile..
The change need to be committed after this.

### Example 5: When a classic AFD instance not associated with WAF and has no customer certificate, and the subscription of the classic AFD instance is different from the local subscrition.
```powershell
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/testSubId01/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -SubscriptionId testSubId01
```

```output
MigratedProfileResourceId
-------------------------
/subscriptions/testSubId/resourceGroups/rgName/providers/Microsoft.Cdn/profiles/name-migrated
```

When a classic AFD instance not associated with WAF and has no customer certificate, and the subscription of the classic AFD instance is different from the local subscrition.
Migrate the classic AFD to Azure Front Door(Standard/Premium) profile..
The change need to be committed after this.