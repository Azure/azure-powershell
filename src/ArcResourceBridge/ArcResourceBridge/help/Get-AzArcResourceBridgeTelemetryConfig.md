---
external help file: Az.ArcResourceBridge-help.xml
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
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArcResourceBridgeTelemetryConfig -InputObject <IArcResourceBridgeIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

## RELATED LINKS
