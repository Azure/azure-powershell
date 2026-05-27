---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/disable-aztrafficmanagerprofile
schema: 2.0.0
---

# Disable-AzTrafficManagerProfile

## SYNOPSIS
Disables a Traffic Manager profile.

## SYNTAX

### Fields (Default)
```
Disable-AzTrafficManagerProfile -Name <String> -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [-Force] [-SubscriptionId <String[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Object
```
Disable-AzTrafficManagerProfile -TrafficManagerProfile <IProfile> [-DefaultProfile <PSObject>] [-Force]
 [-SubscriptionId <String[]>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Disable-AzTrafficManagerProfile cmdlet disables an Azure Traffic Manager profile.
You can specify the profile by name and resource group, or you can pass a profile object.
Use the Force parameter to suppress the confirmation prompt.

## EXAMPLES

### Example 1: Disable a Traffic Manager profile
```powershell
Disable-AzTrafficManagerProfile -Name "myprofile" -ResourceGroupName "myRG"
```

```output
True
```

Disables a Traffic Manager profile. Prompts for confirmation before disabling.

### Example 2: Disable a profile without confirmation
```powershell
Disable-AzTrafficManagerProfile -Name "myprofile" -ResourceGroupName "myRG" -Force
```

```output
True
```

Disables a Traffic Manager profile, suppressing the confirmation prompt using the -Force parameter.

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

### -TrafficManagerProfile
The Traffic Manager profile object.

```yaml
Type: Az.TrafficManager.Models.IProfile
Parameter Sets: Object
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Az.TrafficManager.Models.IProfile

## OUTPUTS

### System.Boolean

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRAFFICMANAGERPROFILE <IProfile>`: The Traffic Manager profile object.
  - `[Location <String>]`: The Azure Region where the resource lives
  - `[Tags <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Id <String>]`: Fully qualified resource Id for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{resourceName}
  - `[Name <String>]`: The name of the resource
  - `[Type <String>]`: The type of the resource. Ex- Microsoft.Network/trafficManagerProfiles.
  - `[AllowedEndpointRecordTypes <List<String>>]`: The list of allowed endpoint record types.
  - `[DnsConfigRelativeName <String>]`: The relative DNS name provided by this Traffic Manager profile. This value is combined with the DNS domain name used by Azure Traffic Manager to form the fully-qualified domain name (FQDN) of the profile.
  - `[DnsConfigTtl <Int64?>]`: The DNS Time-To-Live (TTL), in seconds. This informs the local DNS resolvers and DNS clients how long to cache DNS responses provided by this Traffic Manager profile.
  - `[Endpoints <List<IEndpoint>>]`: The list of endpoints in the Traffic Manager profile.
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
  - `[MaxReturn <Int64?>]`: Maximum number of endpoints to be returned for MultiValue routing type.
  - `[MonitorConfigCustomHeaders <List<IMonitorConfigCustomHeadersItem>>]`: List of custom headers.
    - `[Name <String>]`: Header name.
    - `[Value <String>]`: Header value.
  - `[MonitorConfigExpectedStatusCodeRanges <List<IMonitorConfigExpectedStatusCodeRangesItem>>]`: List of expected status code ranges.
    - `[Max <Int32?>]`: Max status code.
    - `[Min <Int32?>]`: Min status code.
  - `[MonitorConfigIntervalInSeconds <Int64?>]`: The monitor interval for endpoints in this profile. This is the interval at which Traffic Manager will check the health of each endpoint in this profile.
  - `[MonitorConfigPath <String>]`: The path relative to the endpoint domain name used to probe for endpoint health.
  - `[MonitorConfigPort <Int64?>]`: The TCP port used to probe for endpoint health.
  - `[MonitorConfigProfileMonitorStatus <String>]`: The profile-level monitoring status of the Traffic Manager profile.
  - `[MonitorConfigProtocol <String>]`: The protocol (HTTP, HTTPS or TCP) used to probe for endpoint health.
  - `[MonitorConfigTimeoutInSeconds <Int64?>]`: The monitor timeout for endpoints in this profile. This is the time that Traffic Manager allows endpoints in this profile to response to the health check.
  - `[MonitorConfigToleratedNumberOfFailures <Int64?>]`: The number of consecutive failed health check that Traffic Manager tolerates before declaring an endpoint in this profile Degraded after the next failed health check.
  - `[ProfileStatus <String>]`: The status of the Traffic Manager profile.
  - `[RecordType <String>]`: When record type is set, a traffic manager profile will allow only endpoints that match this type.
  - `[TrafficRoutingMethod <String>]`: The traffic routing method of the Traffic Manager profile.
  - `[TrafficViewEnrollmentStatus <String>]`: Indicates whether Traffic View is 'Enabled' or 'Disabled' for the Traffic Manager profile. Null, indicates 'Disabled'. Enabling this feature will increase the cost of the Traffic Manage profile.

## RELATED LINKS

