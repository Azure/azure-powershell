---
external help file: Az.Network-help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressroutecircuitpeering
schema: 2.0.0
---

# New-AzExpressRouteCircuitPeering

## SYNOPSIS
Creates or updates a peering in the specified express route circuits.

## SYNTAX

### CreateSubscriptionIdViaHost (Default)
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 [-PeeringParameter <IExpressRouteCircuitPeering>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateExpanded
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-AdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-AdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-AzureAsn <Int32>] [-ConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-ConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-ConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Connection <IExpressRouteCircuitConnection[]>] [-CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-GatewayManagerEtag <String>] [-Id <String>] [-IdRouteFilterId <String>]
 [-Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-LastModifiedBy <String>]
 [-LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-LocationRouteFilterLocation <String>] [-Name <String>]
 [-PeerAsn <Int64>] [-PeeringType <ExpressRoutePeeringType>] [-PrimaryAzurePort <String>]
 [-PrimaryPeerAddressPrefix <String>] [-PropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-PropertiesRule <IRouteFilterRule[]>] [-ProvisioningState <String>] [-ResourceIdRouteFilterId <String>]
 [-ResourceLocationRouteFilterLocation <String>] [-ResourceTagsRouteFilterTag <IResourceTags>]
 [-RouteFilterPropertiesFormatPeering <IExpressRouteCircuitPeering[]>]
 [-RouteFilterPropertiesFormatRule <IRouteFilterRule[]>]
 [-RoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Schemas446CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-Schemas446LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-SecondaryAzurePort <String>]
 [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>] [-State <ExpressRoutePeeringState>]
 [-StatsPrimarybytesIn <Int64>] [-StatsPrimarybytesOut <Int64>] [-StatsSecondarybytesIn <Int64>]
 [-StatsSecondarybytesOut <Int64>] [-TagsRouteFilterTag <IResourceTags>] [-VlanId <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PeeringParameter <IExpressRouteCircuitPeering>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateSubscriptionIdViaHostExpanded
```
New-AzExpressRouteCircuitPeering -CircuitName <String> -PeeringName <String> -ResourceGroupName <String>
 [-AdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-AdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-AdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-AdvertisedPublicPrefixesStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState <ExpressRouteCircuitPeeringAdvertisedPublicPrefixState>]
 [-AzureAsn <Int32>] [-ConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity <String[]>]
 [-ConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix <String[]>]
 [-ConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Connection <IExpressRouteCircuitConnection[]>] [-CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-GatewayManagerEtag <String>] [-Id <String>] [-IdRouteFilterId <String>]
 [-Ipv6PeeringConfigPrimaryPeerAddressPrefix <String>] [-Ipv6PeeringConfigSecondaryPeerAddressPrefix <String>]
 [-Ipv6PeeringConfigState <ExpressRouteCircuitPeeringState>] [-LastModifiedBy <String>]
 [-LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-LocationRouteFilterLocation <String>] [-Name <String>]
 [-PeerAsn <Int64>] [-PeeringType <ExpressRoutePeeringType>] [-PrimaryAzurePort <String>]
 [-PrimaryPeerAddressPrefix <String>] [-PropertiesPeering <IExpressRouteCircuitPeering[]>]
 [-PropertiesRule <IRouteFilterRule[]>] [-ProvisioningState <String>] [-ResourceIdRouteFilterId <String>]
 [-ResourceLocationRouteFilterLocation <String>] [-ResourceTagsRouteFilterTag <IResourceTags>]
 [-RouteFilterPropertiesFormatPeering <IExpressRouteCircuitPeering[]>]
 [-RouteFilterPropertiesFormatRule <IRouteFilterRule[]>]
 [-RoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName <String>]
 [-Schemas446CustomerAsnMicrosoftPeeringConfigCustomerAsn <Int32>]
 [-Schemas446LegacyModeMicrosoftPeeringConfigLegacyMode <Int32>] [-SecondaryAzurePort <String>]
 [-SecondaryPeerAddressPrefix <String>] [-SharedKey <String>] [-State <ExpressRoutePeeringState>]
 [-StatsPrimarybytesIn <Int64>] [-StatsPrimarybytesOut <Int64>] [-StatsSecondarybytesIn <Int64>]
 [-StatsSecondarybytesOut <Int64>] [-TagsRouteFilterTag <IResourceTags>] [-VlanId <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a peering in the specified express route circuits.

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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState
AdvertisedPublicPrefixState of the Peering resource.
Possible values are 'NotConfigured', 'Configuring', 'Configured', and 'ValidationNeeded'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRouteCircuitPeeringAdvertisedPublicPrefixState
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases: ExpressRouteCircuitPeeringAdvertisedPublicPrefixStateMicrosoftPeeringConfigAdvertisedPublicPrefixesState

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

### -AzureAsn
The Azure ASN.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -CircuitName
The name of the express route circuit.

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

### -ConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity
The communities of bgp peering.
Specified for microsoft peering

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases: ExpressRouteCircuitPeeringConfigAdvertisedCommunitiesMicrosoftPeeringConfigAdvertisedCommunity

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix
The reference of AdvertisedPublicPrefixes.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases: ExpressRouteCircuitPeeringConfigAdvertisedPublicPrefixesMicrosoftPeeringConfigAdvertisedPublicPrefix

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName
The RoutingRegistryName of the configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases: ExpressRouteCircuitPeeringConfigRoutingRegistryNameMicrosoftPeeringConfigRoutingRegistryName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
The list of circuit connections associated with Azure Private Peering for this circuit.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitConnection[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerAsnMicrosoftPeeringConfigCustomerAsn
The CustomerASN of the peering.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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

### -GatewayManagerEtag
The GatewayManager Etag.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdRouteFilterId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationRouteFilterLocation
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Gets name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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
Peering in an ExpressRouteCircuit resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering
Parameter Sets: CreateSubscriptionIdViaHost, Create
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryAzurePort
The primary port.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesPeering
A collection of references to express route circuit peerings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesRule
Collection of RouteFilterRules contained within a route filter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Gets the provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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

### -ResourceIdRouteFilterId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceLocationRouteFilterLocation
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceTagsRouteFilterTag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteFilterPropertiesFormatPeering
A collection of references to express route circuit peerings.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RouteFilterPropertiesFormatRule
Collection of RouteFilterRules contained within a route filter.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRouteFilterRule[]
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryAzurePort
The secondary port.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecondaryPeerAddressPrefix
The secondary address prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatsPrimarybytesIn
Gets BytesIn of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatsPrimarybytesOut
Gets BytesOut of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatsSecondarybytesIn
Gets BytesIn of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -StatsSecondarybytesOut
Gets BytesOut of the peering.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagsRouteFilterTag
Resource tags.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VlanId
The VLAN ID.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitPeering
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressroutecircuitpeering](https://docs.microsoft.com/en-us/powershell/module/az.network/new-azexpressroutecircuitpeering)

