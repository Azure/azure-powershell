---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservercapabilitiesbylocation
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation

## SYNOPSIS
Lists the capabilities available in a given location for a specific subscription.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the capabilities available in a given location for a specific subscription.

## EXAMPLES

### Example 1: Get PostgreSQL Flexible Server capabilities for East US region
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName "East US"
```

```output
Name                                 : FlexibleServerCapabilities
FastProvisioningSupported           : Enabled
GeoBackupSupported                  : Enabled
OnlineResizeSupported               : Enabled
StorageAutoGrowthSupported          : Enabled
SupportedFastProvisioningEditions   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FastProvisioningEditionCapability}
SupportedFeatures                   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerCapability}
SupportedServerEditions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerEditionCapability}
SupportedServerVersions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerVersionCapability}
ZoneRedundantHaAndGeoBackupSupported: Enabled
ZoneRedundantHaSupported            : Enabled
```

Gets the comprehensive PostgreSQL Flexible Server capabilities available in the East US region, including all supported features, editions, versions, and backup options.

### Example 2: Get PostgreSQL Flexible Server capabilities for a specific subscription and location
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByLocation -LocationName "West Europe" -SubscriptionId "ssssssss-ssss-ssss-ssss-ssssssssssss"
```

```output
Name                                 : FlexibleServerCapabilities
FastProvisioningSupported           : Enabled
GeoBackupSupported                  : Enabled
OnlineResizeSupported               : Enabled
StorageAutoGrowthSupported          : Enabled
SupportedFastProvisioningEditions   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FastProvisioningEditionCapability}
SupportedFeatures                   : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerCapability}
SupportedServerEditions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.FlexibleServerEditionCapability}
SupportedServerVersions             : {Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ServerVersionCapability}
ZoneRedundantHaAndGeoBackupSupported: Enabled
ZoneRedundantHaSupported            : Enabled
```

Gets the comprehensive PostgreSQL Flexible Server capabilities available in the West Europe region for a specific subscription.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -LocationName
The name of the location.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability

## NOTES

## RELATED LINKS
