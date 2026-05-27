---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/set-aztrafficmanagerprofile
schema: 2.0.0
---

# Set-AzTrafficManagerProfile

## SYNOPSIS
Update a Traffic Manager profile.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzTrafficManagerProfile -ProfileName <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AllowedEndpointRecordTypes <String[]>] [-DnsConfigRelativeName <String>] [-DnsConfigTtl <Int64>]
 [-Endpoints <IEndpoint[]>] [-Id <String>] [-Location <String>] [-MaxReturn <Int64>]
 [-MonitorConfigCustomHeaders <IMonitorConfigCustomHeadersItem[]>]
 [-MonitorConfigExpectedStatusCodeRanges <IMonitorConfigExpectedStatusCodeRangesItem[]>]
 [-MonitorConfigIntervalInSeconds <Int64>] [-MonitorConfigPath <String>] [-MonitorConfigPort <Int64>]
 [-MonitorConfigProfileMonitorStatus <String>] [-MonitorConfigProtocol <String>]
 [-MonitorConfigTimeoutInSeconds <Int64>] [-MonitorConfigToleratedNumberOfFailures <Int64>] [-Name <String>]
 [-ProfileStatus <String>] [-RecordType <String>] [-Tags <Hashtable>] [-TrafficRoutingMethod <String>]
 [-TrafficViewEnrollmentStatus <String>] [-Type <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzTrafficManagerProfile -ProfileName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Parameters <IProfile> [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzTrafficManagerProfile -InputObject <ITrafficManagerIdentity> -Parameters <IProfile> [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzTrafficManagerProfile -InputObject <ITrafficManagerIdentity> [-AllowedEndpointRecordTypes <String[]>]
 [-DnsConfigRelativeName <String>] [-DnsConfigTtl <Int64>] [-Endpoints <IEndpoint[]>] [-Id <String>]
 [-Location <String>] [-MaxReturn <Int64>] [-MonitorConfigCustomHeaders <IMonitorConfigCustomHeadersItem[]>]
 [-MonitorConfigExpectedStatusCodeRanges <IMonitorConfigExpectedStatusCodeRangesItem[]>]
 [-MonitorConfigIntervalInSeconds <Int64>] [-MonitorConfigPath <String>] [-MonitorConfigPort <Int64>]
 [-MonitorConfigProfileMonitorStatus <String>] [-MonitorConfigProtocol <String>]
 [-MonitorConfigTimeoutInSeconds <Int64>] [-MonitorConfigToleratedNumberOfFailures <Int64>] [-Name <String>]
 [-ProfileStatus <String>] [-RecordType <String>] [-Tags <Hashtable>] [-TrafficRoutingMethod <String>]
 [-TrafficViewEnrollmentStatus <String>] [-Type <String>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Traffic Manager profile.

## EXAMPLES

### Example 1: Update the TTL of a Traffic Manager profile
```powershell
$profile = Get-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG"
$profile.DnsConfigTtl = 60
Set-AzTrafficManagerProfile -Parameters $profile -ProfileName "myprofile" -ResourceGroupName "myRG"
```

```output
Name              : myprofile
DnsConfigTtl      : 60
```

Updates the DNS TTL of an existing Traffic Manager profile.

### Example 2: Update the monitoring path
```powershell
Set-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG" -MonitorConfigPath "/healthcheck"
```

Updates the health monitoring path of a Traffic Manager profile.

## PARAMETERS

### -AllowedEndpointRecordTypes
The list of allowed endpoint record types.

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

### -DnsConfigRelativeName
The relative DNS name provided by this Traffic Manager profile.
This value is combined with the DNS domain name used by Azure Traffic Manager to form the fully-qualified domain name (FQDN) of the profile.

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

### -DnsConfigTtl
The DNS Time-To-Live (TTL), in seconds.
This informs the local DNS resolvers and DNS clients how long to cache DNS responses provided by this Traffic Manager profile.

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

### -Endpoints
The list of endpoints in the Traffic Manager profile.

```yaml
Type: Az.TrafficManager.Models.IEndpoint[]
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

### -Location
The Azure Region where the resource lives

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

### -MaxReturn
Maximum number of endpoints to be returned for MultiValue routing type.

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

### -MonitorConfigCustomHeaders
List of custom headers.

```yaml
Type: Az.TrafficManager.Models.IMonitorConfigCustomHeadersItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorConfigExpectedStatusCodeRanges
List of expected status code ranges.

```yaml
Type: Az.TrafficManager.Models.IMonitorConfigExpectedStatusCodeRangesItem[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorConfigIntervalInSeconds
The monitor interval for endpoints in this profile.
This is the interval at which Traffic Manager will check the health of each endpoint in this profile.

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

### -MonitorConfigPath
The path relative to the endpoint domain name used to probe for endpoint health.

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

### -MonitorConfigPort
The TCP port used to probe for endpoint health.

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

### -MonitorConfigProfileMonitorStatus
The profile-level monitoring status of the Traffic Manager profile.

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

### -MonitorConfigProtocol
The protocol (HTTP, HTTPS or TCP) used to probe for endpoint health.

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

### -MonitorConfigTimeoutInSeconds
The monitor timeout for endpoints in this profile.
This is the time that Traffic Manager allows endpoints in this profile to response to the health check.

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

### -MonitorConfigToleratedNumberOfFailures
The number of consecutive failed health check that Traffic Manager tolerates before declaring an endpoint in this profile Degraded after the next failed health check.

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
Class representing a Traffic Manager profile.

```yaml
Type: Az.TrafficManager.Models.IProfile
Parameter Sets: Update, UpdateViaIdentity
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileStatus
The status of the Traffic Manager profile.

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

### -RecordType
When record type is set, a traffic manager profile will allow only endpoints that match this type.

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

### -Tags
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficRoutingMethod
The traffic routing method of the Traffic Manager profile.

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

### -TrafficViewEnrollmentStatus
Indicates whether Traffic View is 'Enabled' or 'Disabled' for the Traffic Manager profile.
Null, indicates 'Disabled'.
Enabling this feature will increase the cost of the Traffic Manage profile.

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

### Az.TrafficManager.Models.ITrafficManagerIdentity

## OUTPUTS

### Az.TrafficManager.Models.IProfile

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ENDPOINTS <IEndpoint[]>`: The list of endpoints in the Traffic Manager profile.
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

`INPUTOBJECT <ITrafficManagerIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: The name of the Traffic Manager endpoint.
  - `[EndpointType <String>]`: The type of the Traffic Manager endpoint.
  - `[HeatMapType <String>]`: The type of the heatmap.
  - `[ProfileName <String>]`: The name of the Traffic Manager profile.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.

`MONITORCONFIGCUSTOMHEADERS <IMonitorConfigCustomHeadersItem[]>`: List of custom headers.
  - `[Name <String>]`: Header name.
  - `[Value <String>]`: Header value.

`MONITORCONFIGEXPECTEDSTATUSCODERANGES <IMonitorConfigExpectedStatusCodeRangesItem[]>`: List of expected status code ranges.
  - `[Max <Int32?>]`: Max status code.
  - `[Min <Int32?>]`: Min status code.

`PARAMETERS <IProfile>`: Class representing a Traffic Manager profile.
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

