---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecircuit
schema: 2.0.0
---

# Set-AzExpressRouteCircuit

## SYNOPSIS
Creates or updates an express route circuit.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzExpressRouteCircuit -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AllowClassicOperations] [-Authorization <IExpressRouteCircuitAuthorization[]>] [-BandwidthInGbps <Single>]
 [-CircuitProvisioningState <String>] [-EnableGlobalReach] [-ExpressRoutePortId <String>]
 [-GatewayManagerEtag <String>] [-Id <String>] [-Location <String>] [-Peering <IExpressRouteCircuitPeering[]>]
 [-ProvisioningState <String>] [-ServiceKey <String>] [-ServiceProviderBandwidthInMbps <Int32>]
 [-ServiceProviderName <String>] [-ServiceProviderNote <String>] [-ServiceProviderPeeringLocation <String>]
 [-ServiceProviderProvisioningState <ServiceProviderProvisioningState>]
 [-SkuFamily <ExpressRouteCircuitSkuFamily>] [-SkuName <String>] [-SkuTier <ExpressRouteCircuitSkuTier>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzExpressRouteCircuit -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ExpressRouteCircuit <IExpressRouteCircuit> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an express route circuit.

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

### -AllowClassicOperations
Allow classic operations

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
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

### -Authorization
The list of authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BandwidthInGbps
The bandwidth of the circuit when the circuit is provisioned on an ExpressRoutePort resource.

```yaml
Type: System.Single
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CircuitProvisioningState
The CircuitProvisioningState state of the resource.

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

### -EnableGlobalReach
Flag denoting Global reach status.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ExpressRouteCircuit
ExpressRouteCircuit resource
To construct, see NOTES section for EXPRESSROUTECIRCUIT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuit
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ExpressRoutePortId
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
The name of the circuit.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CircuitName

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Gets the provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

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

### -ServiceKey
The ServiceKey.

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

### -ServiceProviderBandwidthInMbps
The BandwidthInMbps.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases: BandwidthInMbps

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceProviderName
The serviceProviderName.

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

### -ServiceProviderNote
The ServiceProviderNotes.

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

### -ServiceProviderPeeringLocation
The peering location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: PeeringLocation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServiceProviderProvisioningState
The ServiceProviderProvisioningState state of the resource.

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

### -SkuFamily
The family of the SKU.
Possible values are: 'UnlimitedData' and 'MeteredData'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuFamily
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The name of the SKU.

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

### -SkuTier
The tier of the SKU.
Possible values are 'Standard', 'Premium' or 'Local'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitSkuTier
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuit

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuit

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AUTHORIZATION <IExpressRouteCircuitAuthorization[]>: The list of authorizations.
  - `[Id <String>]`: Resource ID.
  - `[AuthorizationKey <String>]`: The authorization key.
  - `[AuthorizationUseStatus <AuthorizationUseStatus?>]`: AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### EXPRESSROUTECIRCUIT <IExpressRouteCircuit>: ExpressRouteCircuit resource
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AllowClassicOperations <Boolean?>]`: Allow classic operations
  - `[Authorization <IExpressRouteCircuitAuthorization[]>]`: The list of authorizations.
    - `[Id <String>]`: Resource ID.
    - `[AuthorizationKey <String>]`: The authorization key.
    - `[AuthorizationUseStatus <AuthorizationUseStatus?>]`: AuthorizationUseStatus. Possible values are: 'Available' and 'InUse'.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[BandwidthInGbps <Single?>]`: The bandwidth of the circuit when the circuit is provisioned on an ExpressRoutePort resource.
  - `[CircuitProvisioningState <String>]`: The CircuitProvisioningState state of the resource.
  - `[EnableGlobalReach <Boolean?>]`: Flag denoting Global reach status.
  - `[ExpressRoutePortId <String>]`: Resource ID.
  - `[GatewayManagerEtag <String>]`: The GatewayManager Etag.
  - `[Peering <IExpressRouteCircuitPeering[]>]`: The list of peerings.
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
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ServiceKey <String>]`: The ServiceKey.
  - `[ServiceProviderBandwidthInMbps <Int32?>]`: The BandwidthInMbps.
  - `[ServiceProviderName <String>]`: The serviceProviderName.
  - `[ServiceProviderNote <String>]`: The ServiceProviderNotes.
  - `[ServiceProviderPeeringLocation <String>]`: The peering location.
  - `[ServiceProviderProvisioningState <ServiceProviderProvisioningState?>]`: The ServiceProviderProvisioningState state of the resource.
  - `[SkuFamily <ExpressRouteCircuitSkuFamily?>]`: The family of the SKU. Possible values are: 'UnlimitedData' and 'MeteredData'.
  - `[SkuName <String>]`: The name of the SKU.
  - `[SkuTier <ExpressRouteCircuitSkuTier?>]`: The tier of the SKU. Possible values are 'Standard', 'Premium' or 'Local'.

#### PEERING <IExpressRouteCircuitPeering[]>: The list of peerings.
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

## RELATED LINKS

