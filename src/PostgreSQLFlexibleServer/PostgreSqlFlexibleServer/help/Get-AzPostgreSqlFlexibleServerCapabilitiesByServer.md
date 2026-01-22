---
external help file: Az.PostgreSqlFlexibleServer-help.xml
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservercapabilitiesbyserver
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerCapabilitiesByServer

## SYNOPSIS
Lists the capabilities available for a given server.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Lists the capabilities available for a given server.

## EXAMPLES

### Example 1: Get PostgreSQL Flexible Server capabilities for a specific server
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
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

Gets the available capabilities for the specified PostgreSQL Flexible Server, including supported scaling options, backup features, and version upgrades.

### Example 2: Get capabilities for a server in a specific subscription
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01" -SubscriptionId "ssssssss-ssss-ssss-ssss-ssssssssssss"
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

Gets the available capabilities for a production PostgreSQL Flexible Server in a specific subscription.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ServerName
The name of the server.

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
