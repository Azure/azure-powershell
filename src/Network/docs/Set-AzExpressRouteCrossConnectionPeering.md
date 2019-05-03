---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecrossconnectionpeering
schema: 2.0.0
---

# Set-AzExpressRouteCrossConnectionPeering

## SYNOPSIS
Creates or updates a peering in the specified ExpressRouteCrossConnection.

## SYNTAX

### UpdateSubscriptionIdViaHost (Default)
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> [-PeeringParameter <IExpressRouteCrossConnectionPeering>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String>
 [-AdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-ExpressRouteCircuitPeeringConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-ExpressRouteCircuitPeeringConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-ExpressRouteCircuitPeeringConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-GatewayManagerEtag <String>] [-Id <String>] [-Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-LastModifiedBy <String>]
 [-LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-Name <String>] [-PeerAsn <Int64>]
 [-Peering <IExpressRouteCircuitPeering[]>] [-PeeringType <ExpressRoutePeeringType>]
 [-PrimaryPeerAddressPrefix <String>] [-RouteFilterId <String>] [-RouteFilterLocation <String>]
 [-RouteFilterTag <IResourceTags>] [-RoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Rule <IRouteFilterRule[]>] [-Schemas446CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-Schemas446LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-SecondaryPeerAddressPrefix <String>]
 [-SharedKey <String>] [-State <ExpressRoutePeeringState>] [-VlanId <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> -SubscriptionId <String> [-PeeringParameter <IExpressRouteCrossConnectionPeering>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Set-AzExpressRouteCrossConnectionPeering -CrossConnectionName <String> -PeeringName <String>
 -ResourceGroupName <String> [-AdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-ExpressRouteCircuitPeeringConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-ExpressRouteCircuitPeeringConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-ExpressRouteCircuitPeeringConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-GatewayManagerEtag <String>] [-Id <String>] [-Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-LastModifiedBy <String>]
 [-LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-Name <String>] [-PeerAsn <Int64>]
 [-Peering <IExpressRouteCircuitPeering[]>] [-PeeringType <ExpressRoutePeeringType>]
 [-PrimaryPeerAddressPrefix <String>] [-RouteFilterId <String>] [-RouteFilterLocation <String>]
 [-RouteFilterTag <IResourceTags>] [-RoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Rule <IRouteFilterRule[]>] [-Schemas446CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-Schemas446LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-SecondaryPeerAddressPrefix <String>]
 [-SharedKey <String>] [-State <ExpressRoutePeeringState>] [-VlanId <Int32>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a peering in the specified ExpressRouteCrossConnection.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvertisedPublicPrefixesStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -CustomerAsnMicrosoftPeeringConfigCustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCircuitPeeringConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCircuitPeeringConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpressRouteCircuitPeeringConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GatewayManagerEtag
The GatewayManager Etag.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6PeeringConfigPrimaryPeerAddressPrefix
The primary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6PeeringConfigSecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv6PeeringConfigState
The state of peering.
Possible values are: 'Disabled' and 'Enabled'

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringState
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastModifiedBy
Gets whether the provider or the customer last modified the peering.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LegacyModeMicrosoftPeeringConfigLegacyMode
The legacy mode of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerAsn
The peer ASN.

```yaml
Type: System.Int64
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Peering
A collection of references to express route circuit peerings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
The name of the peering.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringParameter
Peering in an ExpressRoute Cross Connection resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering
Parameter Sets: UpdateSubscriptionIdViaHost, Update
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PeeringType
The peering type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringType
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryPeerAddressPrefix
The primary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -RouteFilterId
Resource ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteFilterLocation
Resource location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteFilterTag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
Collection of RouteFilterRules contained within a route filter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[]
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schemas446CustomerAsnMicrosoftPeeringConfigCustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Schemas446LegacyModeMicrosoftPeeringConfigLegacyMode
The legacy mode of the peering.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharedKey
The shared key.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
The peering state.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePeeringState
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VlanId
The VLAN ID.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCrossConnectionPeering
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecrossconnectionpeering](https://docs.microsoft.com/en-us/powershell/module/az.network/set-azexpressroutecrossconnectionpeering)

