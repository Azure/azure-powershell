---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/get-aztrafficmanagerendpoint
schema: 2.0.0
---

# Get-AzTrafficManagerEndpoint

## SYNOPSIS
Gets a Traffic Manager endpoint.

## SYNTAX

### Get (Default)
```
Get-AzTrafficManagerEndpoint -EndpointName <String> -EndpointType <String> -ProfileName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTrafficManagerEndpoint -InputObject <ITrafficManagerIdentity> [<CommonParameters>]
```

## DESCRIPTION
Gets a Traffic Manager endpoint.

## EXAMPLES

### Example 1: Get a specific Traffic Manager endpoint
```powershell
Get-AzTrafficManagerEndpoint -EndpointName "myendpoint" -EndpointType "ExternalEndpoints" -ProfileName "myprofile" -ResourceGroupName "myRG"
```

```output
Name           : myendpoint
EndpointStatus : Enabled
Target         : www.contoso.com
Weight         : 10
Priority       : 1
```

Gets a Traffic Manager endpoint by specifying the endpoint name, type, profile name, and resource group.

### Example 2: Get an endpoint using pipeline input
```powershell
$inputObject = @{ EndpointName = "myendpoint"; EndpointType = "ExternalEndpoints"; ProfileName = "myprofile"; ResourceGroupName = "myRG"; SubscriptionId = "00000000-0000-0000-0000-000000000000" }
Get-AzTrafficManagerEndpoint -InputObject $inputObject
```

Gets a Traffic Manager endpoint using the identity parameter.

## PARAMETERS

### -EndpointName
The name of the Traffic Manager endpoint.

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

### -EndpointType
The type of the Traffic Manager endpoint.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Az.TrafficManager.Models.ITrafficManagerIdentity

## OUTPUTS

### Az.TrafficManager.Models.IEndpoint

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

