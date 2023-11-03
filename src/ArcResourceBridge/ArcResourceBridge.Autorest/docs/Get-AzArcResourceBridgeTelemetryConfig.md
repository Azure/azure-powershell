---
external help file:
Module Name: Az.ArcResourceBridge
online version: https://learn.microsoft.com/powershell/module/az.arcresourcebridge/get-azarcresourcebridgetelemetryconfig
schema: 2.0.0
---

# Get-AzArcResourceBridgeTelemetryConfig

## SYNOPSIS
Gets the telemetry config.

## SYNTAX

### Get (Default)
```
Get-AzArcResourceBridgeTelemetryConfig [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcResourceBridgeTelemetryConfig -InputObject <IArcResourceBridgeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the telemetry config.

## EXAMPLES

### Example 1: Gets the telemetry config.
```powershell
Get-AzArcResourceBridgeTelemetryConfig
```

```output
8340f324-76bb-4716-9838-7b3eedd19914
```

Gets the telemetry config.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.IArcResourceBridgeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ArcResourceBridge.Models.IArcResourceBridgeIdentity

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IArcResourceBridgeIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceName <String>]`: Appliances name.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpgradeGraph <String>]`: Upgrade graph version, ex - stable

## RELATED LINKS

