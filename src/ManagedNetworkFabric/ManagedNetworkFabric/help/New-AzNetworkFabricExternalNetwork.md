---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricexternalnetwork
schema: 2.0.0
---

# New-AzNetworkFabricExternalNetwork

## SYNOPSIS
Creates ExternalNetwork PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricExternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -PeeringOption <String> [-Annotation <String>]
 [-ExportRoutePolicy <IExportRoutePolicy>] [-ExportRoutePolicyId <String>]
 [-ImportRoutePolicy <IImportRoutePolicy>] [-ImportRoutePolicyId <String>]
 [-OptionAPropertyBfdConfiguration <IBfdConfiguration>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBProperty <IL3OptionBProperties>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricExternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricExternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomainExpanded
```
New-AzNetworkFabricExternalNetwork -Name <String> -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -PeeringOption <String> [-Annotation <String>] [-ExportRoutePolicy <IExportRoutePolicy>]
 [-ExportRoutePolicyId <String>] [-ImportRoutePolicy <IImportRoutePolicy>] [-ImportRoutePolicyId <String>]
 [-OptionAPropertyBfdConfiguration <IBfdConfiguration>] [-OptionAPropertyEgressAclId <String>]
 [-OptionAPropertyIngressAclId <String>] [-OptionAPropertyMtu <Int32>] [-OptionAPropertyPeerAsn <Int64>]
 [-OptionAPropertyPrimaryIpv4Prefix <String>] [-OptionAPropertyPrimaryIpv6Prefix <String>]
 [-OptionAPropertySecondaryIpv4Prefix <String>] [-OptionAPropertySecondaryIpv6Prefix <String>]
 [-OptionAPropertyVlanId <Int32>] [-OptionBProperty <IL3OptionBProperties>] [-DefaultProfile <PSObject>]
 [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomain
```
New-AzNetworkFabricExternalNetwork -Name <String> -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Body <IExternalNetwork> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates ExternalNetwork PUT method.

## EXAMPLES

### EXAMPLE 1
```
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$routeTarget = @{
    ExportIpv4RouteTarget = @("65046:10039")
    ExportIpv6RouteTarget = @("65046:10039")
    ImportIpv4RouteTarget = @("65046:10039")
    ImportIpv6RouteTarget = @("65046:10039")
}
$optionBProperty = @{
    RouteTarget = $routeTarget
}
```

$optionAPropertyBfdConfiguration = @{
    IntervalInMilliSecond = 300
    Multiplier = 3
}

New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionB" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionBProperty $optionBProperty

### EXAMPLE 2
```
New-AzNetworkFabricExternalNetwork -L3IsolationDomainName $l3domainName -Name $name -ResourceGroupName $resourceGroupName -PeeringOption "OptionA" -ExportRoutePolicy $exportRoutePolicy -ImportRoutePolicy $importRoutePolicy -OptionAPropertyBfdConfiguration $optionAPropertyBfdConfiguration -OptionAPropertyEgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/egressAclName" -OptionAPropertyIngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/ingressAclName" -OptionAPropertyMtu 1500 -OptionAPropertyPeerAsn 65123 -OptionAPropertyPrimaryIpv4Prefix "172.31.0.0/30" -OptionAPropertySecondaryIpv4Prefix "172.31.0.0/30" -OptionAPropertyVlanId 501
```

## PARAMETERS

### -Annotation
Switch configuration description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
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

### -Body
Defines the External Network resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork
Parameter Sets: CreateViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -ExportRoutePolicy
Export Route Policy either IPv4 or IPv6.
To construct, see NOTES section for EXPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExportRoutePolicy
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicyId
ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicy
Import Route Policy either IPv4 or IPv6.
To construct, see NOTES section for IMPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IImportRoutePolicy
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportRoutePolicyId
ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -L3IsolationDomainInputObject
Identity Parameter
To construct, see NOTES section for L3ISOLATIONDOMAININPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: CreateViaIdentityL3IsolationDomainExpanded, CreateViaIdentityL3IsolationDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -L3IsolationDomainName
Name of the L3 Isolation Domain.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the External Network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExternalNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -OptionAPropertyBfdConfiguration
BFD configuration properties
To construct, see NOTES section for OPTIONAPROPERTYBFDCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IBfdConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyEgressAclId
Egress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyIngressAclId
Ingress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyMtu
MTU to use for option A peering.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPeerAsn
Peer ASN number.Example : 28

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPrimaryIpv4Prefix
IPv4 Address Prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyPrimaryIpv6Prefix
IPv6 Address Prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertySecondaryIpv4Prefix
Secondary IPv4 Address Prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertySecondaryIpv6Prefix
Secondary IPv6 Address Prefix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionAPropertyVlanId
Vlan identifier.
Example : 501

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBProperty
option B properties object
To construct, see NOTES section for OPTIONBPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL3OptionBProperties
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringOption
Peering option list.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork
### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExternalNetwork
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BODY \<IExternalNetwork\>: Defines the External Network resource.
  PeeringOption \<String\>: Peering option list.
  \[Annotation \<String\>\]: Switch configuration description.
  \[ExportRoutePolicy \<IExportRoutePolicy\>\]: Export Route Policy either IPv4 or IPv6.
    \[ExportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
    \[ExportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ExportRoutePolicyId \<String\>\]: ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.
  \[ImportRoutePolicy \<IImportRoutePolicy\>\]: Import Route Policy either IPv4 or IPv6.
    \[ImportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
    \[ImportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ImportRoutePolicyId \<String\>\]: ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.
  \[OptionAPropertyBfdConfiguration \<IBfdConfiguration\>\]: BFD configuration properties
    \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
    \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[OptionAPropertyEgressAclId \<String\>\]: Egress Acl.
ARM resource ID of Access Control Lists.
  \[OptionAPropertyIngressAclId \<String\>\]: Ingress Acl.
ARM resource ID of Access Control Lists.
  \[OptionAPropertyMtu \<Int32?\>\]: MTU to use for option A peering.
  \[OptionAPropertyPeerAsn \<Int64?\>\]: Peer ASN number.Example : 28
  \[OptionAPropertyPrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
  \[OptionAPropertyPrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
  \[OptionAPropertySecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
  \[OptionAPropertySecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.
  \[OptionAPropertyVlanId \<Int32?\>\]: Vlan identifier.
Example : 501
  \[OptionBProperty \<IL3OptionBProperties\>\]: option B properties object
    \[ExportRouteTarget \<List\<String\>\>\]: RouteTargets to be applied.
This is used for the backward compatibility.
    \[ImportRouteTarget \<List\<String\>\>\]: RouteTargets to be applied.
This is used for the backward compatibility.
    \[RouteTarget \<IRouteTargetInformation\>\]: RouteTargets to be applied.
      \[ExportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes into CE.
      \[ExportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
      \[ImportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
      \[ImportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes from CE.

EXPORTROUTEPOLICY \<IExportRoutePolicy\>: Export Route Policy either IPv4 or IPv6.
  \[ExportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ExportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.

IMPORTROUTEPOLICY \<IImportRoutePolicy\>: Import Route Policy either IPv4 or IPv6.
  \[ImportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ImportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.

L3ISOLATIONDOMAININPUTOBJECT \<IManagedNetworkFabricIdentity\>: Identity Parameter
  \[AccessControlListName \<String\>\]: Name of the Access Control List.
  \[ExternalNetworkName \<String\>\]: Name of the External Network.
  \[IPCommunityName \<String\>\]: Name of the IP Community.
  \[IPExtendedCommunityName \<String\>\]: Name of the IP Extended Community.
  \[IPPrefixName \<String\>\]: Name of the IP Prefix.
  \[Id \<String\>\]: Resource identity path
  \[InternalNetworkName \<String\>\]: Name of the Internal Network.
  \[InternetGatewayName \<String\>\]: Name of the Internet Gateway.
  \[InternetGatewayRuleName \<String\>\]: Name of the Internet Gateway rule.
  \[L2IsolationDomainName \<String\>\]: Name of the L2 Isolation Domain.
  \[L3IsolationDomainName \<String\>\]: Name of the L3 Isolation Domain.
  \[NeighborGroupName \<String\>\]: Name of the Neighbor Group.
  \[NetworkDeviceName \<String\>\]: Name of the Network Device.
  \[NetworkDeviceSkuName \<String\>\]: Name of the Network Device SKU.
  \[NetworkFabricControllerName \<String\>\]: Name of the Network Fabric Controller.
  \[NetworkFabricName \<String\>\]: Name of the Network Fabric.
  \[NetworkFabricSkuName \<String\>\]: Name of the Network Fabric SKU.
  \[NetworkInterfaceName \<String\>\]: Name of the Network Interface.
  \[NetworkPacketBrokerName \<String\>\]: Name of the Network Packet Broker.
  \[NetworkRackName \<String\>\]: Name of the Network Rack.
  \[NetworkTapName \<String\>\]: Name of the Network Tap.
  \[NetworkTapRuleName \<String\>\]: Name of the Network Tap Rule.
  \[NetworkToNetworkInterconnectName \<String\>\]: Name of the Network to Network Interconnect.
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[RoutePolicyName \<String\>\]: Name of the Route Policy.
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
The value must be an UUID.

OPTIONAPROPERTYBFDCONFIGURATION \<IBfdConfiguration\>: BFD configuration properties
  \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
  \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.

OPTIONBPROPERTY \<IL3OptionBProperties\>: option B properties object
  \[ExportRouteTarget \<List\<String\>\>\]: RouteTargets to be applied.
This is used for the backward compatibility.
  \[ImportRouteTarget \<List\<String\>\>\]: RouteTargets to be applied.
This is used for the backward compatibility.
  \[RouteTarget \<IRouteTargetInformation\>\]: RouteTargets to be applied.
    \[ExportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes into CE.
    \[ExportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for outgoing routes from CE.
    \[ImportIpv4RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes into CE.
    \[ImportIpv6RouteTarget \<List\<String\>\>\]: Route Targets to be applied for incoming routes from CE.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricexternalnetwork](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricexternalnetwork)

