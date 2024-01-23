---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricinternalnetwork
schema: 2.0.0
---

# New-AzNetworkFabricInternalNetwork

## SYNOPSIS
Creates InternalNetwork PUT method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricInternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -VlanId <Int32> [-Annotation <String>]
 [-BgpConfiguration <IInternalNetworkPropertiesBgpConfiguration>] [-ConnectedIPv4Subnet <IConnectedSubnet[]>]
 [-ConnectedIPv6Subnet <IConnectedSubnet[]>] [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>]
 [-ExportRoutePolicyId <String>] [-Extension <String>] [-ImportRoutePolicy <IImportRoutePolicy>]
 [-ImportRoutePolicyId <String>] [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-StaticRouteConfigurationBfdConfiguration <IBfdConfiguration>] [-StaticRouteConfigurationExtension <String>]
 [-StaticRouteConfigurationIpv4Route <IStaticRouteProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRouteProperties[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricInternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricInternalNetwork -Name <String> -L3IsolationDomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomainExpanded
```
New-AzNetworkFabricInternalNetwork -Name <String> -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -VlanId <Int32> [-Annotation <String>] [-BgpConfiguration <IInternalNetworkPropertiesBgpConfiguration>]
 [-ConnectedIPv4Subnet <IConnectedSubnet[]>] [-ConnectedIPv6Subnet <IConnectedSubnet[]>]
 [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicy>] [-ExportRoutePolicyId <String>]
 [-Extension <String>] [-ImportRoutePolicy <IImportRoutePolicy>] [-ImportRoutePolicyId <String>]
 [-IngressAclId <String>] [-IsMonitoringEnabled <String>] [-Mtu <Int32>]
 [-StaticRouteConfigurationBfdConfiguration <IBfdConfiguration>] [-StaticRouteConfigurationExtension <String>]
 [-StaticRouteConfigurationIpv4Route <IStaticRouteProperties[]>]
 [-StaticRouteConfigurationIpv6Route <IStaticRouteProperties[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityL3IsolationDomain
```
New-AzNetworkFabricInternalNetwork -Name <String> -L3IsolationDomainInputObject <IManagedNetworkFabricIdentity>
 -Body <IInternalNetwork> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates InternalNetwork PUT method.

## EXAMPLES

### EXAMPLE 1
```
$bgpConfiguration = @{
    AllowAs = 2
    AllowAsOverride = "Enable"
    BfdConfiguration = @{
        IntervalInMilliSecond = 300
        Multiplier = 3
    }
    DefaultRouteOriginate = "True"
    Ipv4ListenRangePrefix = @("20.10.10.2/28")
    Ipv4NeighborAddress = @(@{
        Address = "20.10.10.2"
    })
    PeerAsn = 65047
}
$connectedIPv4Subnet = @(@{
    Prefix = "20.10.10.2/28"
})
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ExportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
    ImportIpv6RoutePolicyId = "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/routePolicies/RoutePolicyName"
}
$staticRouteConfigurationBfdConfiguration = @{
    IntervalInMilliSecond = 300
    Multiplier = 3
}
$staticRouteConfigurationIpv4Route = @(@{
    NextHop = @("10.0.0.1")
    Prefix = "10.1.0.0/24"
})
```

New-AzNetworkFabricInternalNetwork -Name $name -L3IsolationDomainName $l3domainName -ResourceGroupName $resourceGroupName -VlanId "701" -BgpConfiguration $bgpConfiguration -ConnectedIPv4Subnet $connectedIPv4Subnet -EgressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -ExportRoutePolicy $exportRoutePolicy -Extension "NoExtension" -ImportRoutePolicy $importRoutePolicy -IngressAclId "/subscriptions/subscriptionId/resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/accessControlLists/aclName" -IsMonitoringEnabled "True" -Mtu 1500 -StaticRouteConfigurationBfdConfiguration $staticRouteConfigurationBfdConfiguration -StaticRouteConfigurationExtension "NPB" -StaticRouteConfigurationIpv4Route $staticRouteConfigurationIpv4Route

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

### -BgpConfiguration
BGP configuration properties.
To construct, see NOTES section for BGPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetworkPropertiesBgpConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Defines the Internal Network resource.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork
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

### -ConnectedIPv4Subnet
List of Connected IPv4 Subnets.
To construct, see NOTES section for CONNECTEDIPV4SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnet[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectedIPv6Subnet
List of connected IPv6 Subnets.
To construct, see NOTES section for CONNECTEDIPV6SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IConnectedSubnet[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### -EgressAclId
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

### -Extension
Extension.
Example: NoExtension | NPB.

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

### -IngressAclId
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

### -IsMonitoringEnabled
To check whether monitoring of internal network is enabled or not.

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

### -Mtu
Maximum transmission unit.
Default value is 1500.

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

### -Name
Name of the Internal Network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: InternalNetworkName

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

### -StaticRouteConfigurationBfdConfiguration
BFD configuration properties
To construct, see NOTES section for STATICROUTECONFIGURATIONBFDCONFIGURATION properties and create a hash table.

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

### -StaticRouteConfigurationExtension
Extension.
Example: NoExtension | NPB.

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

### -StaticRouteConfigurationIpv4Route
List of IPv4 Routes.
To construct, see NOTES section for STATICROUTECONFIGURATIONIPV4ROUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRouteProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StaticRouteConfigurationIpv6Route
List of IPv6 Routes.
To construct, see NOTES section for STATICROUTECONFIGURATIONIPV6ROUTE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IStaticRouteProperties[]
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: False
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

### -VlanId
Vlan identifier.
Example: 1001.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityL3IsolationDomainExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork
### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IInternalNetwork
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BGPCONFIGURATION \<IInternalNetworkPropertiesBgpConfiguration\>: BGP configuration properties.
  \[AllowAs \<Int32?\>\]: Allows for routes to be received and processed even if the router detects its own ASN in the AS-Path.
0 is disable, Possible values are 1-10, default is 2.
  \[AllowAsOverride \<String\>\]: Enable Or Disable state.
  \[BfdConfigurationIntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
  \[BfdConfigurationMultiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[DefaultRouteOriginate \<String\>\]: Originate a defaultRoute.
Ex: "True" | "False".
  \[Ipv4ListenRangePrefix \<List\<String\>\>\]: List of BGP IPv4 Listen Range prefixes.
  \[Ipv4NeighborAddress \<List\<INeighborAddress\>\>\]: List with stringified IPv4 Neighbor Addresses.
    \[Address \<String\>\]: IP Address.
  \[Ipv6ListenRangePrefix \<List\<String\>\>\]: List of BGP IPv6 Listen Ranges prefixes.
  \[Ipv6NeighborAddress \<List\<INeighborAddress\>\>\]: List with stringified IPv6 Neighbor Address.
  \[PeerAsn \<Int64?\>\]: Peer ASN.
Example: 65047.
  \[Annotation \<String\>\]: Switch configuration description.

BODY \<IInternalNetwork\>: Defines the Internal Network resource.
  VlanId \<Int32\>: Vlan identifier.
Example: 1001.
  \[Annotation \<String\>\]: Switch configuration description.
  \[BgpConfiguration \<IInternalNetworkPropertiesBgpConfiguration\>\]: BGP configuration properties.
    \[AllowAs \<Int32?\>\]: Allows for routes to be received and processed even if the router detects its own ASN in the AS-Path.
0 is disable, Possible values are 1-10, default is 2.
    \[AllowAsOverride \<String\>\]: Enable Or Disable state.
    \[BfdConfigurationIntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
    \[BfdConfigurationMultiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
    \[DefaultRouteOriginate \<String\>\]: Originate a defaultRoute.
Ex: "True" | "False".
    \[Ipv4ListenRangePrefix \<List\<String\>\>\]: List of BGP IPv4 Listen Range prefixes.
    \[Ipv4NeighborAddress \<List\<INeighborAddress\>\>\]: List with stringified IPv4 Neighbor Addresses.
      \[Address \<String\>\]: IP Address.
    \[Ipv6ListenRangePrefix \<List\<String\>\>\]: List of BGP IPv6 Listen Ranges prefixes.
    \[Ipv6NeighborAddress \<List\<INeighborAddress\>\>\]: List with stringified IPv6 Neighbor Address.
    \[PeerAsn \<Int64?\>\]: Peer ASN.
Example: 65047.
    \[Annotation \<String\>\]: Switch configuration description.
  \[ConnectedIPv4Subnet \<List\<IConnectedSubnet\>\>\]: List of Connected IPv4 Subnets.
    Prefix \<String\>: Prefix of the Connected Subnet.
  \[ConnectedIPv6Subnet \<List\<IConnectedSubnet\>\>\]: List of connected IPv6 Subnets.
  \[EgressAclId \<String\>\]: Egress Acl.
ARM resource ID of Access Control Lists.
  \[ExportRoutePolicy \<IExportRoutePolicy\>\]: Export Route Policy either IPv4 or IPv6.
    \[ExportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
    \[ExportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ExportRoutePolicyId \<String\>\]: ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.
  \[Extension \<String\>\]: Extension.
Example: NoExtension | NPB.
  \[ImportRoutePolicy \<IImportRoutePolicy\>\]: Import Route Policy either IPv4 or IPv6.
    \[ImportIpv4RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
    \[ImportIpv6RoutePolicyId \<String\>\]: ARM resource ID of RoutePolicy.
  \[ImportRoutePolicyId \<String\>\]: ARM Resource ID of the RoutePolicy.
This is used for the backward compatibility.
  \[IngressAclId \<String\>\]: Ingress Acl.
ARM resource ID of Access Control Lists.
  \[IsMonitoringEnabled \<String\>\]: To check whether monitoring of internal network is enabled or not.
  \[Mtu \<Int32?\>\]: Maximum transmission unit.
Default value is 1500.
  \[StaticRouteConfigurationBfdConfiguration \<IBfdConfiguration\>\]: BFD configuration properties
    \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
    \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[StaticRouteConfigurationExtension \<String\>\]: Extension.
Example: NoExtension | NPB.
  \[StaticRouteConfigurationIpv4Route \<List\<IStaticRouteProperties\>\>\]: List of IPv4 Routes.
    NextHop \<List\<String\>\>: List of next hop addresses.
    Prefix \<String\>: Prefix of the route.
  \[StaticRouteConfigurationIpv6Route \<List\<IStaticRouteProperties\>\>\]: List of IPv6 Routes.

CONNECTEDIPV4SUBNET \<IConnectedSubnet\[\]\>: List of Connected IPv4 Subnets.
  Prefix \<String\>: Prefix of the Connected Subnet.
  \[Annotation \<String\>\]: Switch configuration description.

CONNECTEDIPV6SUBNET \<IConnectedSubnet\[\]\>: List of connected IPv6 Subnets.
  Prefix \<String\>: Prefix of the Connected Subnet.
  \[Annotation \<String\>\]: Switch configuration description.

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

STATICROUTECONFIGURATIONBFDCONFIGURATION \<IBfdConfiguration\>: BFD configuration properties
  \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
  \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.

STATICROUTECONFIGURATIONIPV4ROUTE \<IStaticRouteProperties\[\]\>: List of IPv4 Routes.
  NextHop \<List\<String\>\>: List of next hop addresses.
  Prefix \<String\>: Prefix of the route.

STATICROUTECONFIGURATIONIPV6ROUTE \<IStaticRouteProperties\[\]\>: List of IPv6 Routes.
  NextHop \<List\<String\>\>: List of next hop addresses.
  Prefix \<String\>: Prefix of the route.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricinternalnetwork](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricinternalnetwork)

