---
external help file:
Module Name: TrafficManager
online version: https://learn.microsoft.com/powershell/module/az.trafficmanager/add-aztrafficmanagerendpointconfig
schema: 2.0.0
---

# Add-AzTrafficManagerEndpointConfig

## SYNOPSIS
Adds an endpoint to a local Traffic Manager profile object.

## SYNTAX

```
Add-AzTrafficManagerEndpointConfig [-EndpointName] <String> [-TrafficManagerProfile] <IProfile>
 [-Type] <String> [-EndpointStatus] <String> [[-TargetResourceId] <String>] [[-Target] <String>]
 [[-Weight] <Int64?>] [[-Priority] <Int64?>] [[-EndpointLocation] <String>] [[-AlwaysServe] <String>]
 [[-MinChildEndpoints] <Int64?>] [[-MinChildEndpointsIPv4] <Int64?>] [[-MinChildEndpointsIPv6] <Int64?>]
 [[-GeoMapping] <String[]>] [[-SubnetMapping] <IEndpointPropertiesSubnetsItem[]>]
 [[-CustomHeader] <IEndpointPropertiesCustomHeadersItem[]>] [<CommonParameters>]
```

## DESCRIPTION
The Add-AzTrafficManagerEndpointConfig cmdlet adds an endpoint to a local Azure Traffic Manager profile object.
This cmdlet modifies the object in memory only.
To update the profile in Azure, use Set-AzTrafficManagerProfile.

## EXAMPLES

### Example 1: Add an external endpoint to a profile
```powershell
$profile = Get-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG"
Add-AzTrafficManagerEndpointConfig -TrafficManagerProfile $profile -EndpointName "myendpoint" -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -Weight 10
Set-AzTrafficManagerProfile -Parameters $profile -ProfileName "myprofile" -ResourceGroupName "myRG"
```

Adds an external endpoint to a profile object in memory, then saves it to Azure using Set-AzTrafficManagerProfile.

### Example 2: Add an Azure endpoint with priority
```powershell
$profile = Get-AzTrafficManagerProfile -ProfileName "myprofile" -ResourceGroupName "myRG"
$webAppId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG/providers/Microsoft.Web/sites/mywebapp"
Add-AzTrafficManagerEndpointConfig -TrafficManagerProfile $profile -EndpointName "azureendpoint" -Type "AzureEndpoints" -TargetResourceId $webAppId -EndpointStatus "Enabled" -Priority 1
Set-AzTrafficManagerProfile -Parameters $profile -ProfileName "myprofile" -ResourceGroupName "myRG"
```

Adds an Azure endpoint with priority routing to a profile, then saves the changes.

## PARAMETERS

### -AlwaysServe
If Always Serve is enabled, probing for endpoint health will be disabled.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomHeader
List of custom header name and value pairs for probe requests.

```yaml
Type: Az.TrafficManager.Models.IEndpointPropertiesCustomHeadersItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 15
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointLocation
The endpoint location for performance routing.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointName
The name of the endpoint to add.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointStatus
The status of the endpoint (Enabled or Disabled).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoMapping
The list of regions mapped to this endpoint for Geographic routing.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 13
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinChildEndpoints
The minimum number of endpoints that must be available in the child profile.
Only applicable to NestedEndpoints.

```yaml
Type: System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinChildEndpointsIPv4
The minimum number of IPv4 endpoints that must be available in the child profile.
Only applicable to NestedEndpoints.

```yaml
Type: System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 11
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MinChildEndpointsIPv6
The minimum number of IPv6 endpoints that must be available in the child profile.
Only applicable to NestedEndpoints.

```yaml
Type: System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 12
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
The priority of the endpoint for priority routing.

```yaml
Type: System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetMapping
The list of subnets mapped to this endpoint for Subnet routing.

```yaml
Type: Az.TrafficManager.Models.IEndpointPropertiesSubnetsItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 14
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Target
The target FQDN of the endpoint.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceId
The Azure resource ID of the endpoint target.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficManagerProfile
The Traffic Manager profile object to add the endpoint to.

```yaml
Type: Az.TrafficManager.Models.IProfile
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Type
The type of the endpoint (AzureEndpoints, ExternalEndpoints, or NestedEndpoints).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Weight
The weight of the endpoint for weighted routing.

```yaml
Type: System.Nullable`1[[System.Int64, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Az.TrafficManager.Models.IProfile

## OUTPUTS

### Az.TrafficManager.Models.IProfile

## NOTES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMHEADER <IEndpointPropertiesCustomHeadersItem[]>`: List of custom header name and value pairs for probe requests.
  - `[Name <String>]`: Header name.
  - `[Value <String>]`: Header value.

`SUBNETMAPPING <IEndpointPropertiesSubnetsItem[]>`: The list of subnets mapped to this endpoint for Subnet routing.
  - `[First <String>]`: First address in the subnet.
  - `[Last <String>]`: Last address in the subnet.
  - `[Scope <Int32?>]`: Block size (number of leading bits in the subnet mask).

`TRAFFICMANAGERPROFILE <IProfile>`: The Traffic Manager profile object to add the endpoint to.
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

