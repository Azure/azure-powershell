---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/get-aztrafficmanagerprofile
schema: 2.0.0
---

# Get-AzTrafficManagerProfile

## SYNOPSIS
Gets a Traffic Manager profile.

## SYNTAX

### List (Default)
```
Get-AzTrafficManagerProfile -SubscriptionId <String> [<CommonParameters>]
```

### Get
```
Get-AzTrafficManagerProfile -ProfileName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTrafficManagerProfile -InputObject <ITrafficManagerIdentity> [<CommonParameters>]
```

### List1
```
Get-AzTrafficManagerProfile -ResourceGroupName <String> -SubscriptionId <String> [<CommonParameters>]
```

## DESCRIPTION
Gets a Traffic Manager profile.

## EXAMPLES

### Example 1: Get a specific Traffic Manager profile
```powershell
Get-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG"
```

```output
Name              : myprofile
ResourceGroupName : myRG
ProfileStatus     : Enabled
TrafficRoutingMethod : Performance
DnsConfigRelativeName : myprofile
DnsConfigTtl      : 30
MonitorConfigProtocol : HTTPS
MonitorConfigPort  : 443
MonitorConfigPath  : /health
```

Gets a Traffic Manager profile by specifying the profile name and resource group.

### Example 2: List all Traffic Manager profiles in a resource group
```powershell
Get-AzTrafficManagerProfile -ResourceGroupName "myRG"
```

Lists all Traffic Manager profiles in the specified resource group.

## PARAMETERS

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
Aliases:

Required: True
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

### Az.TrafficManager.Models.IProfile

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

