---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressroutecircuitpeering
schema: 2.0.0
---

# New-AzExpressRouteCircuitPeering

## SYNOPSIS
Creates or updates a peering in the specified express route circuits.

## SYNTAX

### Create (Default)
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PeeringParameter <IExpressRouteCircuitPeering>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-AdvertisedCommunity <String[]>] [-AdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>] [-AzureAsn <Int32>]
 [-Connection <IExpressRouteCircuitConnection[]>] [-CustomerAsn <Int32>] [-GatewayManagerEtag <String>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-IPv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-IPv6PeeringConfigRouteFilterId <String>]
 [-IPv6PeeringConfigRouteFilterLocation <String>]
 [-IPv6PeeringConfigRouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-IPv6PeeringConfigRouteFilterPropertiesRule <IRouteFilterRule[]>]
 [-IPv6PeeringConfigRouteFilterTag <Hashtable>] [-IPv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-IPv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-Id <String>] [-LastModifiedBy <String>]
 [-LegacyMode <Int32>] [-Location <String>] [-Name <String>] [-PeerAsn <Int64>]
 [-PeeringType <ExpressRoutePeeringType>] [-PrimaryAzurePort <String>] [-PrimaryPeerAddressPrefix <String>]
 [-PropertiesRouteFilterId <String>] [-ProvisioningState <String>]
 [-RouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-RouteFilterPropertiesRule <IRouteFilterRule[]>] [-RoutingRegistryName <String>]
 [-SecondaryAzurePort <String>] [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>]
 [-StatPrimarybytesIn <Int64>] [-StatPrimarybytesOut <Int64>] [-StatSecondarybytesIn <Int64>]
 [-StatSecondarybytesOut <Int64>] [-State <ExpressRoutePeeringState>] [-Tag <Hashtable>] [-VlanId <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzExpressRouteCircuitPeering -InputObject <INetworkIdentity> [-AdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>] [-AzureAsn <Int32>]
 [-Connection <IExpressRouteCircuitConnection[]>] [-CustomerAsn <Int32>] [-GatewayManagerEtag <String>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-IPv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-IPv6PeeringConfigRouteFilterId <String>]
 [-IPv6PeeringConfigRouteFilterLocation <String>]
 [-IPv6PeeringConfigRouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-IPv6PeeringConfigRouteFilterPropertiesRule <IRouteFilterRule[]>]
 [-IPv6PeeringConfigRouteFilterTag <Hashtable>] [-IPv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-IPv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-Id <String>] [-LastModifiedBy <String>]
 [-LegacyMode <Int32>] [-Location <String>] [-Name <String>] [-PeerAsn <Int64>]
 [-PeeringType <ExpressRoutePeeringType>] [-PrimaryAzurePort <String>] [-PrimaryPeerAddressPrefix <String>]
 [-PropertiesRouteFilterId <String>] [-ProvisioningState <String>]
 [-RouteFilterPropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-RouteFilterPropertiesRule <IRouteFilterRule[]>] [-RoutingRegistryName <String>]
 [-SecondaryAzurePort <String>] [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>]
 [-StatPrimarybytesIn <Int64>] [-StatPrimarybytesOut <Int64>] [-StatSecondarybytesIn <Int64>]
 [-StatSecondarybytesOut <Int64>] [-State <ExpressRoutePeeringState>] [-Tag <Hashtable>] [-VlanId <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzExpressRouteCircuitPeering -InputObject <INetworkIdentity>
 [-PeeringParameter <IExpressRouteCircuitPeering>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a peering in the specified express route circuits.

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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -AzureAsn
The Azure ASN.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CircuitName
The name of the express route circuit.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Connection
The list of circuit connections associated with Azure Private Peering for this circuit.
To construct, see NOTES section for CONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigCustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigLegacyMode
The legacy mode of the peering.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigPrimaryPeerAddressPrefix
The primary address prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigRouteFilterId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigRouteFilterLocation
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigRouteFilterPropertiesPeering
A collection of references to express route circuit peerings.
To construct, see NOTES section for IPV6PEERINGCONFIGROUTEFILTERPROPERTIESPEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigRouteFilterPropertiesRule
Collection of RouteFilterRules contained within a route filter.
To construct, see NOTES section for IPV6PEERINGCONFIGROUTEFILTERPROPERTIESRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigRouteFilterTag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigSecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPv6PeeringConfigState
The state of peering.
Possible values are: 'Disabled' and 'Enabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeeringName
The name of the peering.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PeeringParameter
Peering in an ExpressRouteCircuit resource.
To construct, see NOTES section for PEERINGPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PeeringType
The peering type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrimaryAzurePort
The primary port.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesRouteFilterId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RouteFilterPropertiesPeering
A collection of references to express route circuit peerings.
To construct, see NOTES section for ROUTEFILTERPROPERTIESPEERING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RouteFilterPropertiesRule
Collection of RouteFilterRules contained within a route filter.
To construct, see NOTES section for ROUTEFILTERPROPERTIESRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SecondaryAzurePort
The secondary port.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StatPrimarybytesIn
Gets BytesIn of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StatPrimarybytesOut
Gets BytesOut of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StatSecondarybytesIn
Gets BytesIn of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -StatSecondarybytesOut
Gets BytesOut of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONNECTION <IExpressRouteCircuitConnection[]>: The list of circuit connections associated with Azure Private Peering for this circuit.
  - `[AddressPrefix <String>]`: /29 IP address space to carve out Customer addresses for tunnels.
  - `[AuthorizationKey <String>]`: The authorization key.
  - `[ExpressRouteCircuitPeeringId <String>]`: Resource ID.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[PeerExpressRouteCircuitPeeringId <String>]`: Resource ID.

#### IPV6PEERINGCONFIGROUTEFILTERPROPERTIESPEERING <IExpressRouteCircuitPeering[]>: A collection of references to express route circuit peerings.
  - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
  - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
  - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
  - `[AzureAsn <Int32?>]`: The Azure ASN.
  - `[Connection <IExpressRouteCircuitConnection[]>]`: The list of circuit connections associated with Azure Private Peering for this circuit.
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

#### IPV6PEERINGCONFIGROUTEFILTERPROPERTIESRULE <IRouteFilterRule[]>: Collection of RouteFilterRules contained within a route filter.
  - `Access <Access>`: The access type of the rule.
  - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
  - `[Location <String>]`: Resource location.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

#### PEERINGPARAMETER <IExpressRouteCircuitPeering>: Peering in an ExpressRouteCircuit resource.
  - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
  - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
  - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
  - `[AzureAsn <Int32?>]`: The Azure ASN.
  - `[Connection <IExpressRouteCircuitConnection[]>]`: The list of circuit connections associated with Azure Private Peering for this circuit.
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

#### ROUTEFILTERPROPERTIESPEERING <IExpressRouteCircuitPeering[]>: A collection of references to express route circuit peerings.
  - `[AdvertisedCommunity <String[]>]`: The communities of bgp peering. Specified for microsoft peering
  - `[AdvertisedPublicPrefix <String[]>]`: The reference of AdvertisedPublicPrefixes.
  - `[AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState?>]`: AdvertisedPublicPrefixState of the Peering resource. Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.
  - `[AzureAsn <Int32?>]`: The Azure ASN.
  - `[Connection <IExpressRouteCircuitConnection[]>]`: The list of circuit connections associated with Azure Private Peering for this circuit.
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

#### ROUTEFILTERPROPERTIESRULE <IRouteFilterRule[]>: Collection of RouteFilterRules contained within a route filter.
  - `Access <Access>`: The access type of the rule.
  - `Community <String[]>`: The collection for bgp community values to filter on. e.g. ['12076:5010','12076:5020']
  - `[Location <String>]`: Resource location.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.

## RELATED LINKS

