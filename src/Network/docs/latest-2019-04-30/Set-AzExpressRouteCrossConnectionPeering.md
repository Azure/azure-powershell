---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecrossconnectionpeering
schema: 2.0.0
---

# Set-AzExpressRouteCrossConnectionPeering

## SYNOPSIS
Creates or updates a peering in the specified ExpressRouteCrossConnection.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-AdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-CustomerAsn <Int32>] [-GatewayManagerEtag <String>] [-IPv6AdvertisedCommunity <String[]>]
 [-IPv6AdvertisedPublicPrefix <String[]>]
 [-IPv6AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-IPv6CustomerAsn <Int32>] [-IPv6LegacyMode <Int32>] [-IPv6PrimaryPeerAddressPrefix <String>]
 [-IPv6RouteFilter <IRouteFilter_Reference>] [-IPv6RoutingRegistryName <String>]
 [-IPv6SecondaryPeerAddressPrefix <String>] [-IPv6State <ExpressRouteCircuitPeeringState>] [-Id <String>]
 [-LastModifiedBy <String>] [-LegacyMode <Int32>] [-PeerAsn <Int64>] [-PeeringType <ExpressRoutePeeringType>]
 [-PrimaryPeerAddressPrefix <String>] [-ResourceName <String>] [-RoutingRegistryName <String>]
 [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>] [-State <ExpressRoutePeeringState>]
 [-VlanId <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -Name <String>
 -ResourceGroupName <String> -SubscriptionId <String>
 -CrossConnectionPeering <IExpressRouteCrossConnectionPeering> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a peering in the specified ExpressRouteCrossConnection.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CrossConnectionName
The name of the ExpressRouteCrossConnection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CrossConnectionPeering
Peering in an ExpressRoute Cross Connection resource.
To construct, see NOTES section for CROSSCONNECTIONPEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -CustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -GatewayManagerEtag
The GatewayManager Etag.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6AdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6AdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6AdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6CustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6LegacyMode
The legacy mode of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PrimaryPeerAddressPrefix
The primary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6RouteFilter
The reference of the RouteFilter resource.
To construct, see NOTES section for IPV6ROUTEFILTER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilter_Reference
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6RoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6SecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6State
The state of peering.
Possible values are: 'Disabled' and 'Enabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LastModifiedBy
Gets whether the provider or the customer last modified the peering.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LegacyMode
The legacy mode of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the peering.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PeeringName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeerAsn
The peer ASN.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeeringType
The peering type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrimaryPeerAddressPrefix
The primary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SharedKey
The shared key.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -State
The peering state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VlanId
The VLAN ID.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CROSSCONNECTIONPEERING <IExpressRouteCrossConnectionPeering>: Peering in an ExpressRoute Cross Connection resource.
  - `[Id <String>]`: Resource ID.
  - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
  - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
  - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
  - `[CustomerAsn <Int32?>]`: The CustomerASN of the peering.
  - `[GatewayManagerEtag <String>]`: The GatewayManager Etag.
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32?>]`: The CustomerASN of the peering.
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32?>]`: The legacy mode of the peering.
  - `[Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
  - `[Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>]`: The primary address prefix.
  - `[Ipv6PeeringConfigRouteFilter <IRouteFilter>]`: The reference of the RouteFilter resource.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Peering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
      - `[Id <String>]`: Resource ID.
      - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
      - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
      - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
      - `[AzureAsn <Int32?>]`: The Azure ASN.
      - `[Connection <IExpressRouteCircuitConnection[]>]`: The list of circuit connections associated with Azure Private Peering for this circuit.
        - `[Id <String>]`: Resource ID.
        - `[AddressPrefix <String>]`: /29 IP address space to carve out Customer addresses for tunnels.
        - `[AuthorizationKey <String>]`: The authorization key.
        - `[ExpressRouteCircuitPeeringId <String>]`: Resource ID.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[PeerExpressRouteCircuitPeeringId <String>]`: Resource ID.
      - `[CustomerAsn <Int32?>]`: The CustomerASN of the peering.
      - `[GatewayManagerEtag <String>]`: The GatewayManager Etag.
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32?>]`: The CustomerASN of the peering.
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32?>]`: The legacy mode of the peering.
      - `[Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
      - `[Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>]`: The primary address prefix.
      - `[Ipv6PeeringConfigRouteFilter <IRouteFilter>]`: The reference of the RouteFilter resource.
      - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
      - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
      - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
      - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[PeerAsn <Int64?>]`: The peer ASN.
      - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
      - `[PrimaryAzurePort <String>]`: The primary port.
      - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[RouteFilter <IRouteFilter>]`: The reference of the RouteFilter resource.
      - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
      - `[SecondaryAzurePort <String>]`: The secondary port.
      - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
      - `[SharedKey <String>]`: The shared key.
      - `[StatPrimarybytesIn <Int64?>]`: Gets BytesIn of the peering.
      - `[StatPrimarybytesOut <Int64?>]`: Gets BytesOut of the peering.
      - `[StatSecondarybytesIn <Int64?>]`: Gets BytesIn of the peering.
      - `[StatSecondarybytesOut <Int64?>]`: Gets BytesOut of the peering.
      - `[State <ExpressRoutePeeringState?>]`: The peering state.
      - `[VlanId <Int32?>]`: The VLAN ID.
    - `[Rule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
      - `Access <Access>`: The access type of the rule.
      - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
  - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
  - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
  - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PeerAsn <Int64?>]`: The peer ASN.
  - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
  - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
  - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
  - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
  - `[SharedKey <String>]`: The shared key.
  - `[State <ExpressRoutePeeringState?>]`: The peering state.
  - `[VlanId <Int32?>]`: The VLAN ID.

#### IPV6ROUTEFILTER <IRouteFilter_Reference>: The reference of the RouteFilter resource.
  - `[Peering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
    - `[Id <String>]`: Resource ID.
    - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
    - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
    - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
    - `[AzureAsn <Int32?>]`: The Azure ASN.
    - `[Connection <IExpressRouteCircuitConnection[]>]`: The list of circuit connections associated with Azure Private Peering for this circuit.
      - `[Id <String>]`: Resource ID.
      - `[AddressPrefix <String>]`: /29 IP address space to carve out Customer addresses for tunnels.
      - `[AuthorizationKey <String>]`: The authorization key.
      - `[ExpressRouteCircuitPeeringId <String>]`: Resource ID.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[PeerExpressRouteCircuitPeeringId <String>]`: Resource ID.
    - `[CustomerAsn <Int32?>]`: The CustomerASN of the peering.
    - `[GatewayManagerEtag <String>]`: The GatewayManager Etag.
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32?>]`: The CustomerASN of the peering.
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32?>]`: The legacy mode of the peering.
    - `[Ipv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
    - `[Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>]`: The primary address prefix.
    - `[Ipv6PeeringConfigRouteFilter <IRouteFilter>]`: The reference of the RouteFilter resource.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Peering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
      - `[Rule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
        - `Access <Access>`: The access type of the rule.
        - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
    - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
    - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PeerAsn <Int64?>]`: The peer ASN.
    - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
    - `[PrimaryAzurePort <String>]`: The primary port.
    - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RouteFilter <IRouteFilter>]`: The reference of the RouteFilter resource.
    - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
    - `[SecondaryAzurePort <String>]`: The secondary port.
    - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[SharedKey <String>]`: The shared key.
    - `[StatPrimarybytesIn <Int64?>]`: Gets BytesIn of the peering.
    - `[StatPrimarybytesOut <Int64?>]`: Gets BytesOut of the peering.
    - `[StatSecondarybytesIn <Int64?>]`: Gets BytesIn of the peering.
    - `[StatSecondarybytesOut <Int64?>]`: Gets BytesOut of the peering.
    - `[State <ExpressRoutePeeringState?>]`: The peering state.
    - `[VlanId <Int32?>]`: The VLAN ID.
  - `[Rule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.

## RELATED LINKS

