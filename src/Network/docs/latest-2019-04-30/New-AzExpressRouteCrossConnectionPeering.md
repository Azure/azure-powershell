---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressroutecrossconnectionpeering
schema: 2.0.0
---

# New-AzExpressRouteCrossConnectionPeering

## SYNOPSIS
Creates or updates a peering in the specified ExpressRouteCrossConnection.

## SYNTAX

### Create (Default)
```
New-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String>
 [-PeeringParameter <IExpressRouteCrossConnectionPeering>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-AdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-CustomerAsn <Int32>] [-GatewayManagerEtag <String>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-IPv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-IPv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-IPv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-Id <String>] [-LastModifiedBy <String>]
 [-LegacyMode <Int32>] [-Name <String>] [-PeerAsn <Int64>] [-Peering <IExpressRouteCircuitPeering[]>]
 [-PeeringType <ExpressRoutePeeringType>] [-PrimaryPeerAddressPrefix <String>] [-RouteFilterId <String>]
 [-RouteFilterLocation <String>] [-RouteFilterTag <IResourceTags>] [-RoutingRegistryName <String>]
 [-Rule <IRouteFilterRule[]>] [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>]
 [-State <ExpressRoutePeeringState>] [-VlanId <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzExpressRouteCrossConnectionPeering -InputObject <INetworkIdentity> [-AdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-CustomerAsn <Int32>] [-GatewayManagerEtag <String>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigLegacyMode <Int32>]
 [-IPv6PeeringConfigMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-IPv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-IPv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-IPv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-Id <String>] [-LastModifiedBy <String>]
 [-LegacyMode <Int32>] [-Name <String>] [-PeerAsn <Int64>] [-Peering <IExpressRouteCircuitPeering[]>]
 [-PeeringType <ExpressRoutePeeringType>] [-PrimaryPeerAddressPrefix <String>] [-RouteFilterId <String>]
 [-RouteFilterLocation <String>] [-RouteFilterTag <IResourceTags>] [-RoutingRegistryName <String>]
 [-Rule <IRouteFilterRule[]>] [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>]
 [-State <ExpressRoutePeeringState>] [-VlanId <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzExpressRouteCrossConnectionPeering -InputObject <INetworkIdentity>
 [-PeeringParameter <IExpressRouteCrossConnectionPeering>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
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

### -CrossConnectionName
The name of the ExpressRouteCrossConnection.

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

### -Peering
A collection of references to express route circuit peerings.

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
Peering in an ExpressRoute Cross Connection resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering
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

### -RouteFilterId
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

### -RouteFilterLocation
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

### -RouteFilterTag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags
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

### -Rule
Collection of RouteFilterRules contained within a route filter.

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering

## ALIASES

## RELATED LINKS

