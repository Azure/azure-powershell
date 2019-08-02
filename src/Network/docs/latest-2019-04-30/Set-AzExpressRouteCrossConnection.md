---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecrossconnection
schema: 2.0.0
---

# Set-AzExpressRouteCrossConnection

## SYNOPSIS
Update the specified ExpressRouteCrossConnection.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzExpressRouteCrossConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-BandwidthInMbps <Int32>] [-ExpressRouteCircuitId <String>] [-Id <String>] [-Location <String>]
 [-Peering <IExpressRouteCrossConnectionPeering[]>] [-PeeringLocation <String>]
 [-ServiceProviderNote <String>] [-ServiceProviderProvisioningState <ServiceProviderProvisioningState>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzExpressRouteCrossConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ExpressRouteCrossConnection <IExpressRouteCrossConnection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the specified ExpressRouteCrossConnection.

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

### -BandwidthInMbps
The circuit bandwidth In Mbps.

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

### -ExpressRouteCircuitId
Corresponding Express Route Circuit Id.

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

### -ExpressRouteCrossConnection
ExpressRouteCrossConnection resource
To construct, see NOTES section for EXPRESSROUTECROSSCONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnection
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Location
Resource location.

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

### -Name
The name of the ExpressRouteCrossConnection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CrossConnectionName

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

### -Peering
The list of peerings.
To construct, see NOTES section for PEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering[]
Parameter Sets: UpdateExpanded
Aliases: Peerings

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeeringLocation
The peering location of the ExpressRoute circuit.

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

### -ServiceProviderNote
Additional read only notes set by the connectivity provider.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ServiceProviderNotes

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceProviderProvisioningState
The provisioning state of the circuit in the connectivity provider system.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState
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

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnection

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### EXPRESSROUTECROSSCONNECTION <IExpressRouteCrossConnection>: ExpressRouteCrossConnection resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BandwidthInMbps <Int32?>]`: The circuit bandwidth In Mbps.
  - `[ExpressRouteCircuitId <String>]`: Corresponding Express Route Circuit Id.
  - `[Peering <IExpressRouteCrossConnectionPeering[]>]`: The list of peerings.
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
    - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
    - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
    - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PeerAsn <Int64?>]`: The peer ASN.
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
      - `[Ipv6PeeringConfigRouteFilterId <String>]`: Resource ID.
      - `[Ipv6PeeringConfigRouteFilterLocation <String>]`: Resource location.
      - `[Ipv6PeeringConfigRouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
      - `[Ipv6PeeringConfigRouteFilterPropertiesRule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
        - `Access <Access>`: The access type of the rule.
        - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Ipv6PeeringConfigRouteFilterTag <IResourceTags>]`: Resource tags.
      - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
      - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
      - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
      - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
      - `[Location <String>]`: Resource location.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[PeerAsn <Int64?>]`: The peer ASN.
      - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
      - `[PrimaryAzurePort <String>]`: The primary port.
      - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
      - `[PropertiesRouteFilterId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[RouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
      - `[RouteFilterPropertiesRule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
      - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
      - `[SecondaryAzurePort <String>]`: The secondary port.
      - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
      - `[SharedKey <String>]`: The shared key.
      - `[StatPrimarybytesIn <Int64?>]`: Gets BytesIn of the peering.
      - `[StatPrimarybytesOut <Int64?>]`: Gets BytesOut of the peering.
      - `[StatSecondarybytesIn <Int64?>]`: Gets BytesIn of the peering.
      - `[StatSecondarybytesOut <Int64?>]`: Gets BytesOut of the peering.
      - `[State <ExpressRoutePeeringState?>]`: The peering state.
      - `[Tag <IResourceTags>]`: Resource tags.
      - `[VlanId <Int32?>]`: The VLAN ID.
    - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
    - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
    - `[RouteFilterId <String>]`: Resource ID.
    - `[RouteFilterLocation <String>]`: Resource location.
    - `[RouteFilterTag <IResourceTags>]`: Resource tags.
    - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
    - `[Rule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
    - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[SharedKey <String>]`: The shared key.
    - `[State <ExpressRoutePeeringState?>]`: The peering state.
    - `[VlanId <Int32?>]`: The VLAN ID.
  - `[PeeringLocation <String>]`: The peering location of the ExpressRoute circuit.
  - `[ServiceProviderNote <String>]`: Additional read only notes set by the connectivity provider.
  - `[ServiceProviderProvisioningState <ServiceProviderProvisioningState?>]`: The provisioning state of the circuit in the connectivity provider system.

#### PEERING <IExpressRouteCrossConnectionPeering[]>: The list of peerings.
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
  - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
  - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
  - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
  - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PeerAsn <Int64?>]`: The peer ASN.
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
    - `[Ipv6PeeringConfigRouteFilterId <String>]`: Resource ID.
    - `[Ipv6PeeringConfigRouteFilterLocation <String>]`: Resource location.
    - `[Ipv6PeeringConfigRouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
    - `[Ipv6PeeringConfigRouteFilterPropertiesRule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
      - `Access <Access>`: The access type of the rule.
      - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Ipv6PeeringConfigRouteFilterTag <IResourceTags>]`: Resource tags.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState?>]`: The state of peering. Possible values are: 'Disabled' and 'Enabled'
    - `[LastModifiedBy <String>]`: Gets whether the provider or the customer last modified the peering.
    - `[LegacyMode <Int32?>]`: The legacy mode of the peering.
    - `[Location <String>]`: Resource location.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[PeerAsn <Int64?>]`: The peer ASN.
    - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
    - `[PrimaryAzurePort <String>]`: The primary port.
    - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
    - `[PropertiesRouteFilterId <String>]`: Resource ID.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[RouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]`: A collection of references to express route circuit peerings.
    - `[RouteFilterPropertiesRule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
    - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
    - `[SecondaryAzurePort <String>]`: The secondary port.
    - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
    - `[SharedKey <String>]`: The shared key.
    - `[StatPrimarybytesIn <Int64?>]`: Gets BytesIn of the peering.
    - `[StatPrimarybytesOut <Int64?>]`: Gets BytesOut of the peering.
    - `[StatSecondarybytesIn <Int64?>]`: Gets BytesIn of the peering.
    - `[StatSecondarybytesOut <Int64?>]`: Gets BytesOut of the peering.
    - `[State <ExpressRoutePeeringState?>]`: The peering state.
    - `[Tag <IResourceTags>]`: Resource tags.
    - `[VlanId <Int32?>]`: The VLAN ID.
  - `[PeeringType <ExpressRoutePeeringType?>]`: The peering type.
  - `[PrimaryPeerAddressPrefix <String>]`: The primary address prefix.
  - `[RouteFilterId <String>]`: Resource ID.
  - `[RouteFilterLocation <String>]`: Resource location.
  - `[RouteFilterTag <IResourceTags>]`: Resource tags.
  - `[RoutingRegistryName <String>]`: The RoutingRegistryName of the configuration.
  - `[Rule <IRouteFilterRule[]>]`: Collection of RouteFilterRules contained within a route filter.
  - `[SecondaryPeerAddressPrefix <String>]`: The secondary address prefix.
  - `[SharedKey <String>]`: The shared key.
  - `[State <ExpressRoutePeeringState?>]`: The peering state.
  - `[VlanId <Int32?>]`: The VLAN ID.

## RELATED LINKS

