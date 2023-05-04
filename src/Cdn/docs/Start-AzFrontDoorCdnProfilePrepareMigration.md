---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/start-azfrontdoorcdnprofilepreparemigration
schema: 2.0.0
---

# Start-AzFrontDoorCdnProfilePrepareMigration

## SYNOPSIS
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
MigrationWebApplicationFirewallMapping should be associated if the front door has WAF policy.
MSI Identity should be associated if the frontdoor has Customer Certificates.
The change need to be committed after this.

## SYNTAX

```
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName <String> -ClassicResourceReferenceId <String>
 -ProfileName <String> -SkuName <SkuName> [-SubscriptionId <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-MigrationWebApplicationFirewallMapping <IMigrationWebApplicationFirewallMapping[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Migrate the CDN profile to Azure Frontdoor(Standard/Premium) profile.
The change need to be committed after this.

## EXAMPLES

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
$wafMapping = New-AzFrontDoorCdnMigrationWebApplicationFirewallMappingObject -MigratedFromId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01 -MigratedToId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName02/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/newWAFName
Start-AzFrontDoorCdnProfilePrepareMigration -ResourceGroupName rgName -ClassicResourceReferenceId /subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName/providers/Microsoft.Network/Frontdoors/name -ProfileName name-migrated -SkuName Standard_AzureFrontDoor -MigrationWebApplicationFirewallMapping $wafMapping
```

```output
Location
--------
```

When the CDN proflie associated with WAF and copy to a new waf policy.
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

When the CDN proflie associated with WAF and select an existing WAF policy.
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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassicResourceReferenceId
Resource ID of the classic front door instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MigrationWebApplicationFirewallMapping
Waf mapping for the migrated profile
To construct, see NOTES section for MIGRATIONWEBAPPLICATIONFIREWALLMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IMigrationWebApplicationFirewallMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the new AFD Standard/Premium profile that need to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SkuName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20221101Preview.IMigrateResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`MIGRATIONWEBAPPLICATIONFIREWALLMAPPING <IMigrationWebApplicationFirewallMapping[]>`: Waf mapping for the migrated profile
  - `[MigratedFromId <String>]`: Resource ID.
  - `[MigratedToId <String>]`: Resource ID.

## RELATED LINKS

