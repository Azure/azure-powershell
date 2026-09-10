---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/set-aztrafficmanagerendpoint
schema: 2.0.0
---

# Set-AzTrafficManagerEndpoint

## SYNOPSIS
Update a Traffic Manager endpoint.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzTrafficManagerEndpoint -EndpointName <String> -EndpointType <String> -ProfileName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-AlwaysServe <String>]
 [-CustomHeaders <IEndpointPropertiesCustomHeadersItem[]>] [-EndpointLocation <String>]
 [-EndpointMonitorStatus <String>] [-EndpointStatus <String>] [-GeoMapping <String[]>] [-Id <String>]
 [-MinChildEndpoints <Int64>] [-MinChildEndpointsIPv4 <Int64>] [-MinChildEndpointsIPv6 <Int64>]
 [-Name <String>] [-Priority <Int64>] [-Subnets <IEndpointPropertiesSubnetsItem[]>] [-Target <String>]
 [-TargetResourceId <String>] [-Type <String>] [-Weight <Int64>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzTrafficManagerEndpoint -EndpointName <String> -EndpointType <String> -ProfileName <String>
 -ResourceGroupName <String> -SubscriptionId <String> -Parameters <IEndpoint> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzTrafficManagerEndpoint -InputObject <ITrafficManagerIdentity> -Parameters <IEndpoint> [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzTrafficManagerEndpoint -InputObject <ITrafficManagerIdentity> [-AlwaysServe <String>]
 [-CustomHeaders <IEndpointPropertiesCustomHeadersItem[]>] [-EndpointLocation <String>]
 [-EndpointMonitorStatus <String>] [-EndpointStatus <String>] [-GeoMapping <String[]>] [-Id <String>]
 [-MinChildEndpoints <Int64>] [-MinChildEndpointsIPv4 <Int64>] [-MinChildEndpointsIPv6 <Int64>]
 [-Name <String>] [-Priority <Int64>] [-Subnets <IEndpointPropertiesSubnetsItem[]>] [-Target <String>]
 [-TargetResourceId <String>] [-Type <String>] [-Weight <Int64>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Traffic Manager endpoint.

## EXAMPLES

### Example 1: Update the weight of an endpoint
```powershell
Set-AzTrafficManagerEndpoint -EndpointName "myendpoint" -EndpointType "ExternalEndpoints" -ProfileName "myprofile" -ResourceGroupName "myRG" -Weight 20
```

```output
Name           : myendpoint
Weight         : 20
```

Updates the weight of an existing Traffic Manager endpoint.

### Example 2: Disable an endpoint
```powershell
Set-AzTrafficManagerEndpoint -EndpointName "myendpoint" -EndpointType "ExternalEndpoints" -ProfileName "myprofile" -ResourceGroupName "myRG" -EndpointStatus "Disabled"
```

Updates the endpoint status to Disabled.

## PARAMETERS

### -AlwaysServe
If Always Serve is enabled, probing for endpoint health will be disabled and endpoints will be included in the traffic routing method.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHeaders
List of custom headers.

```yaml
Type: Az.TrafficManager.Models.IEndpointPropertiesCustomHeadersItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointLocation
Specifies the location of the external or nested endpoints when using the 'Performance' traffic routing method.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointMonitorStatus
The monitoring status of the endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointName
The name of the Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointStatus
The status of the endpoint.
If the endpoint is Enabled, it is probed for endpoint health and is included in the traffic routing method.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointType
The type of the Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoMapping
The list of countries/regions mapped to this endpoint when using the 'Geographic' traffic routing method.
Please consult Traffic Manager Geographic documentation for a full list of accepted values.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Fully qualified resource Id for the resource.
Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{resourceName}

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MinChildEndpoints
The minimum number of endpoints that must be available in the child profile in order for the parent profile to be considered available.
Only applicable to endpoint of type 'NestedEndpoints'.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinChildEndpointsIPv4
The minimum number of IPv4 (DNS record type A) endpoints that must be available in the child profile in order for the parent profile to be considered available.
Only applicable to endpoint of type 'NestedEndpoints'.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinChildEndpointsIPv6
The minimum number of IPv6 (DNS record type AAAA) endpoints that must be available in the child profile in order for the parent profile to be considered available.
Only applicable to endpoint of type 'NestedEndpoints'.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Class representing a Traffic Manager endpoint.

```yaml
Type: Az.TrafficManager.Models.IEndpoint
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Priority
The priority of this endpoint when using the 'Priority' traffic routing method.
Possible values are from 1 to 1000, lower values represent higher priority.
This is an optional parameter.
If specified, it must be specified on all endpoints, and no two endpoints can share the same priority value.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The name of the Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Subnets
The list of subnets, IP addresses, and/or address ranges mapped to this endpoint when using the 'Subnet' traffic routing method.
An empty list will match all ranges not covered by other endpoints.

```yaml
Type: Az.TrafficManager.Models.IEndpointPropertiesSubnetsItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
The fully-qualified DNS name or IP address of the endpoint.
Traffic Manager returns this value in DNS responses to direct traffic to this endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The Azure Resource URI of the of the endpoint.
Not applicable to endpoints of type 'ExternalEndpoints'.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The type of the resource.
Ex- Microsoft.Network/trafficManagerProfiles.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
The weight of this endpoint when using the 'Weighted' traffic routing method.
Possible values are from 1 to 1000.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Az.TrafficManager.Models.IEndpoint

### Az.TrafficManager.Models.ITrafficManagerIdentity

## OUTPUTS

### Az.TrafficManager.Models.IEndpoint

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMHEADERS <IEndpointPropertiesCustomHeadersItem[]>`: List of custom headers.
  - `[Name <String>]`: Header name.
  - `[Value <String>]`: Header value.

`INPUTOBJECT <ITrafficManagerIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: The name of the Traffic Manager endpoint.
  - `[EndpointType <String>]`: The type of the Traffic Manager endpoint.
  - `[HeatMapType <String>]`: The type of the heatmap.
  - `[ProfileName <String>]`: The name of the Traffic Manager profile.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

`PARAMETERS <IEndpoint>`: Class representing a Traffic Manager endpoint.
  - `[Id <String>]`: Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{resourceName}
  - `[Name <String>]`: The name of the resource
  - `[Type <String>]`: The type of the resource. Ex- Microsoft.Network/trafficManagerProfiles.
  - `[AlwaysServe <String>]`: If Always Serve is enabled, probing for endpoint health will be disabled and endpoints will be included in the traffic routing method.
  - `[CustomHeaders <List<IEndpointPropertiesCustomHeadersItem>>]`: List of custom headers.
    - `[Name <String>]`: Header name.
    - `[Value <String>]`: Header value.
  - `[EndpointLocation <String>]`: Specifies the location of the external or nested endpoints when using the 'Performance' traffic routing method.
  - `[EndpointMonitorStatus <String>]`: The monitoring status of the endpoint.
  - `[EndpointStatus <String>]`: The status of the endpoint. If the endpoint is Enabled, it is probed for endpoint health and is included in the traffic routing method.
  - `[GeoMapping <List<String>>]`: The list of countries/regions mapped to this endpoint when using the 'Geographic' traffic routing method. Please consult Traffic Manager Geographic documentation for a full list of accepted values.
  - `[MinChildEndpoints <Int64?>]`: The minimum number of endpoints that must be available in the child profile in order for the parent profile to be considered available. Only applicable to endpoint of type 'NestedEndpoints'.
  - `[MinChildEndpointsIPv4 <Int64?>]`: The minimum number of IPv4 (DNS record type A) endpoints that must be available in the child profile in order for the parent profile to be considered available. Only applicable to endpoint of type 'NestedEndpoints'.
  - `[MinChildEndpointsIPv6 <Int64?>]`: The minimum number of IPv6 (DNS record type AAAA) endpoints that must be available in the child profile in order for the parent profile to be considered available. Only applicable to endpoint of type 'NestedEndpoints'.
  - `[Priority <Int64?>]`: The priority of this endpoint when using the 'Priority' traffic routing method. Possible values are from 1 to 1000, lower values represent higher priority. This is an optional parameter.  If specified, it must be specified on all endpoints, and no two endpoints can share the same priority value.
  - `[Subnets <List<IEndpointPropertiesSubnetsItem>>]`: The list of subnets, IP addresses, and/or address ranges mapped to this endpoint when using the 'Subnet' traffic routing method. An empty list will match all ranges not covered by other endpoints.
    - `[First <String>]`: First address in the subnet.
    - `[Last <String>]`: Last address in the subnet.
    - `[Scope <Int32?>]`: Block size (number of leading bits in the subnet mask).
  - `[Target <String>]`: The fully-qualified DNS name or IP address of the endpoint. Traffic Manager returns this value in DNS responses to direct traffic to this endpoint.
  - `[TargetResourceId <String>]`: The Azure Resource URI of the of the endpoint. Not applicable to endpoints of type 'ExternalEndpoints'.
  - `[Weight <Int64?>]`: The weight of this endpoint when using the 'Weighted' traffic routing method. Possible values are from 1 to 1000.

`SUBNETS <IEndpointPropertiesSubnetsItem[]>`: The list of subnets, IP addresses, and/or address ranges mapped to this endpoint when using the 'Subnet' traffic routing method. An empty list will match all ranges not covered by other endpoints.
  - `[First <String>]`: First address in the subnet.
  - `[Last <String>]`: Last address in the subnet.
  - `[Scope <Int32?>]`: Block size (number of leading bits in the subnet mask).

## RELATED LINKS

