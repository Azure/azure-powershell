---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/get-aztrafficmanagerheatmap
schema: 2.0.0
---

# Get-AzTrafficManagerHeatMap

## SYNOPSIS
Gets latest heatmap for Traffic Manager profile.

## SYNTAX

### Get (Default)
```
Get-AzTrafficManagerHeatMap -ProfileName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-BotRight <List<Double>>] [-TopLeft <List<Double>>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTrafficManagerHeatMap -InputObject <ITrafficManagerIdentity> [-BotRight <List<Double>>]
 [-TopLeft <List<Double>>] [<CommonParameters>]
```

## DESCRIPTION
Gets latest heatmap for Traffic Manager profile.

## EXAMPLES

### Example 1: Get the heatmap for a profile
```powershell
Get-AzTrafficManagerHeatMap -ProfileName "myprofile" -ResourceGroupName "myRG"
```

```output
Name        : default
StartTime   : 2026-05-01T00:00:00Z
EndTime     : 2026-05-27T00:00:00Z
```

Gets the latest heatmap data for the specified Traffic Manager profile, showing traffic patterns by source IP location.

### Example 2: Get heatmap for a specific geographic area
```powershell
Get-AzTrafficManagerHeatMap -ProfileName "myprofile" -ResourceGroupName "myRG" -TopLeft @(49.0, -125.0) -BotRight @(24.0, -66.0)
```

Gets the heatmap data filtered to the continental United States region using latitude/longitude bounding box coordinates.

## PARAMETERS

### -BotRight
The bottom right latitude,longitude pair of the rectangular viewport to query for.

```yaml
Type: System.Collections.Generic.List`1[[System.Double, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Az.TrafficManager.Models.ITrafficManagerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
The name of the Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: Get
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
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopLeft
The top left latitude,longitude pair of the rectangular viewport to query for.

```yaml
Type: System.Collections.Generic.List`1[[System.Double, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Az.TrafficManager.Models.ITrafficManagerIdentity

## OUTPUTS

### Az.TrafficManager.Models.IHeatMapModel

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ITrafficManagerIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: The name of the Traffic Manager endpoint.
  - `[EndpointType <String>]`: The type of the Traffic Manager endpoint.
  - `[HeatMapType <String>]`: The type of the heatmap.
  - `[ProfileName <String>]`: The name of the Traffic Manager profile.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

## RELATED LINKS

