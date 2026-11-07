---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/disable-aztrafficmanagerendpoint
schema: 2.0.0
---

# Disable-AzTrafficManagerEndpoint

## SYNOPSIS
Disables a Traffic Manager endpoint.

## SYNTAX

### Fields (Default)
```
Disable-AzTrafficManagerEndpoint -Name <String> -ProfileName <String> -ResourceGroupName <String>
 -Type <String> [-DefaultProfile <PSObject>] [-Force] [-SubscriptionId <String[]>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Object
```
Disable-AzTrafficManagerEndpoint -TrafficManagerEndpoint <IEndpoint> [-DefaultProfile <PSObject>] [-Force]
 [-SubscriptionId <String[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Disable-AzTrafficManagerEndpoint cmdlet disables an endpoint in an Azure Traffic Manager profile.
You can specify the endpoint by name, type, profile name, and resource group, or you can pass an endpoint object.
Use the Force parameter to suppress the confirmation prompt.

## EXAMPLES

### Example 1: Disable a Traffic Manager endpoint
```powershell
Disable-AzTrafficManagerEndpoint -Name "myendpoint" -Type "ExternalEndpoints" -ProfileName "myprofile" -ResourceGroupName "myRG"
```

```output
True
```

Disables a specific endpoint. Prompts for confirmation before disabling.

### Example 2: Disable an endpoint without confirmation
```powershell
Disable-AzTrafficManagerEndpoint -Name "myendpoint" -Type "AzureEndpoints" -ProfileName "myprofile" -ResourceGroupName "myRG" -Force
```

```output
True
```

Disables an Azure endpoint, suppressing the confirmation prompt using the -Force parameter.

## PARAMETERS

### -DefaultProfile


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

### -Force
Do not ask for confirmation.

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

### -Name
The name of the Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
The name of the Traffic Manager profile.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId


```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficManagerEndpoint
The Traffic Manager endpoint object.

```yaml
Type: Az.TrafficManager.Models.IEndpoint
Parameter Sets: Object
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Type
The type of the Traffic Manager endpoint.

```yaml
Type: System.String
Parameter Sets: Fields
Aliases:

Required: True
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

## OUTPUTS

### System.Boolean

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRAFFICMANAGERENDPOINT <IEndpoint>`: The Traffic Manager endpoint object.
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

## RELATED LINKS

