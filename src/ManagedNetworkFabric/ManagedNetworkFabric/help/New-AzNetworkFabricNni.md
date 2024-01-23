---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricnni
schema: 2.0.0
---

# New-AzNetworkFabricNni

## SYNOPSIS
Configuration used to setup CE-PE connectivity PUT Method.

## SYNTAX

### CreateExpanded (Default)
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -UseOptionB <String> [-EgressAclId <String>]
 [-ExportRoutePolicy <IExportRoutePolicyInformation>] [-ImportRoutePolicy <IImportRoutePolicyInformation>]
 [-IngressAclId <String>] [-IsManagementType <String>] [-Layer2Configuration <ILayer2Configuration>]
 [-NniType <String>] [-NpbStaticRouteConfiguration <INpbStaticRouteConfiguration>]
 [-OptionBLayer3Configuration <INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkFabricExpanded
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricInputObject <IManagedNetworkFabricIdentity>
 -UseOptionB <String> [-EgressAclId <String>] [-ExportRoutePolicy <IExportRoutePolicyInformation>]
 [-ImportRoutePolicy <IImportRoutePolicyInformation>] [-IngressAclId <String>] [-IsManagementType <String>]
 [-Layer2Configuration <ILayer2Configuration>] [-NniType <String>]
 [-NpbStaticRouteConfiguration <INpbStaticRouteConfiguration>]
 [-OptionBLayer3Configuration <INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNetworkFabric
```
New-AzNetworkFabricNni -Name <String> -NetworkFabricInputObject <IManagedNetworkFabricIdentity>
 -Body <INetworkToNetworkInterconnect> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Configuration used to setup CE-PE connectivity PUT Method.

## EXAMPLES

### EXAMPLE 1
```
$optionBLayer3Configuration = @{
    PrimaryIpv4Prefix = "172.31.0.0/31"
    SecondaryIpv4Prefix = "172.31.0.20/31"
    PeerAsn = 28
    VlanId = 501
}
$layer2Configuration = @{
    Interface = @("/subscriptions//resourceGroups/example-rg/providers/Microsoft.ManagedNetworkFabric/networkFabrics/example-fabric/networkToNetworkInterconnects/example-interface")
    Mtu = 1500
}
$importRoutePolicy = @{
    ImportIpv4RoutePolicyId = $global:config.nni.importIpv4RoutePolicyId
    ImportIpv6RoutePolicyId = $global:config.nni.importIpv6RoutePolicyId
}
$exportRoutePolicy = @{
    ExportIpv4RoutePolicyId = $global:config.nni.exportIpv4RoutePolicyId
    ExportIpv6RoutePolicyId = $global:config.nni.exportIpv6RoutePolicyId
}
```

New-AzNetworkFabricNni -Name $name -NetworkFabricName $nfName -ResourceGroupName $resourceGroupName -UseOptionB "True" -IsManagementType "True" -Layer2Configuration $layer2Configuration -NniType "CE" -OptionBLayer3Configuration $optionBLayer3Configuration -ExportRoutePolicy $ExportRoutePolicy -ImportRoutePolicy $importRoutePolicy

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
```

### -Body
The Network To Network Interconnect resource definition.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect
Parameter Sets: CreateViaIdentityNetworkFabric
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

### -EgressAclId
Egress Acl.
ARM resource ID of Access Control Lists.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExportRoutePolicy
Export Route Policy configuration.
To construct, see NOTES section for EXPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IExportRoutePolicyInformation
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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
Import Route Policy configuration.
To construct, see NOTES section for IMPORTROUTEPOLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IImportRoutePolicyInformation
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsManagementType
Configuration to use NNI for Infrastructure Management.
Example: True/False.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
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

### -Layer2Configuration
Common properties for Layer2 Configuration.
To construct, see NOTES section for LAYER2CONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ILayer2Configuration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Network to Network Interconnect.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkToNetworkInterconnectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkFabricInputObject
Identity Parameter
To construct, see NOTES section for NETWORKFABRICINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: CreateViaIdentityNetworkFabricExpanded, CreateViaIdentityNetworkFabric
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NetworkFabricName
Name of the Network Fabric.

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

### -NniType
Type of NNI used.
Example: CE | NPB

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
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

### -NpbStaticRouteConfiguration
NPB Static Route Configuration properties.
To construct, see NOTES section for NPBSTATICROUTECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INpbStaticRouteConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OptionBLayer3Configuration
Common properties for Layer3Configuration.
To construct, see NOTES section for OPTIONBLAYER3CONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: False
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

### -UseOptionB
Based on this option layer3 parameters are mandatory.
Example: True/False

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNetworkFabricExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkToNetworkInterconnect
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

BODY \<INetworkToNetworkInterconnect\>: The Network To Network Interconnect resource definition.
  UseOptionB \<String\>: Based on this option layer3 parameters are mandatory.
Example: True/False
  \[EgressAclId \<String\>\]: Egress Acl.
ARM resource ID of Access Control Lists.
  \[ExportRoutePolicy \<IExportRoutePolicyInformation\>\]: Export Route Policy configuration.
    \[ExportIpv4RoutePolicyId \<String\>\]: Export IPv4 Route Policy Id.
    \[ExportIpv6RoutePolicyId \<String\>\]: Export IPv6 Route Policy Id.
  \[ImportRoutePolicy \<IImportRoutePolicyInformation\>\]: Import Route Policy configuration.
    \[ImportIpv4RoutePolicyId \<String\>\]: Import IPv4 Route Policy Id.
    \[ImportIpv6RoutePolicyId \<String\>\]: Import IPv6 Route Policy Id.
  \[IngressAclId \<String\>\]: Ingress Acl.
ARM resource ID of Access Control Lists.
  \[IsManagementType \<String\>\]: Configuration to use NNI for Infrastructure Management.
Example: True/False.
  \[Layer2Configuration \<ILayer2Configuration\>\]: Common properties for Layer2 Configuration.
    \[Interface \<List\<String\>\>\]: List of network device interfaces resource IDs.
    \[Mtu \<Int32?\>\]: MTU of the packets between PE & CE.
  \[NniType \<String\>\]: Type of NNI used.
Example: CE | NPB
  \[NpbStaticRouteConfiguration \<INpbStaticRouteConfiguration\>\]: NPB Static Route Configuration properties.
    \[BfdConfiguration \<IBfdConfiguration\>\]: BFD Configuration properties.
      \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
      \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
    \[Ipv4Route \<List\<IStaticRouteProperties\>\>\]: List of IPv4 Routes.
      NextHop \<List\<String\>\>: List of next hop addresses.
      Prefix \<String\>: Prefix of the route.
    \[Ipv6Route \<List\<IStaticRouteProperties\>\>\]: List of IPv6 Routes.
  \[OptionBLayer3Configuration \<INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration\>\]: Common properties for Layer3Configuration.
    \[PeerAsn \<Int64?\>\]: ASN of PE devices for CE/PE connectivity.Example : 28
    \[VlanId \<Int32?\>\]: VLAN for CE/PE Layer 3 connectivity.Example : 501
    \[PrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
    \[PrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
    \[SecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
    \[SecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.

EXPORTROUTEPOLICY \<IExportRoutePolicyInformation\>: Export Route Policy configuration.
  \[ExportIpv4RoutePolicyId \<String\>\]: Export IPv4 Route Policy Id.
  \[ExportIpv6RoutePolicyId \<String\>\]: Export IPv6 Route Policy Id.

IMPORTROUTEPOLICY \<IImportRoutePolicyInformation\>: Import Route Policy configuration.
  \[ImportIpv4RoutePolicyId \<String\>\]: Import IPv4 Route Policy Id.
  \[ImportIpv6RoutePolicyId \<String\>\]: Import IPv6 Route Policy Id.

LAYER2CONFIGURATION \<ILayer2Configuration\>: Common properties for Layer2 Configuration.
  \[Interface \<List\<String\>\>\]: List of network device interfaces resource IDs.
  \[Mtu \<Int32?\>\]: MTU of the packets between PE & CE.

NETWORKFABRICINPUTOBJECT \<IManagedNetworkFabricIdentity\>: Identity Parameter
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

NPBSTATICROUTECONFIGURATION \<INpbStaticRouteConfiguration\>: NPB Static Route Configuration properties.
  \[BfdConfiguration \<IBfdConfiguration\>\]: BFD Configuration properties.
    \[IntervalInMilliSecond \<Int32?\>\]: Interval in milliseconds.
Example: 300.
    \[Multiplier \<Int32?\>\]: Multiplier for the Bfd Configuration.
Example: 5.
  \[Ipv4Route \<List\<IStaticRouteProperties\>\>\]: List of IPv4 Routes.
    NextHop \<List\<String\>\>: List of next hop addresses.
    Prefix \<String\>: Prefix of the route.
  \[Ipv6Route \<List\<IStaticRouteProperties\>\>\]: List of IPv6 Routes.

OPTIONBLAYER3CONFIGURATION \<INetworkToNetworkInterconnectPropertiesOptionBLayer3Configuration\>: Common properties for Layer3Configuration.
  \[PeerAsn \<Int64?\>\]: ASN of PE devices for CE/PE connectivity.Example : 28
  \[VlanId \<Int32?\>\]: VLAN for CE/PE Layer 3 connectivity.Example : 501
  \[PrimaryIpv4Prefix \<String\>\]: IPv4 Address Prefix.
  \[PrimaryIpv6Prefix \<String\>\]: IPv6 Address Prefix.
  \[SecondaryIpv4Prefix \<String\>\]: Secondary IPv4 Address Prefix.
  \[SecondaryIpv6Prefix \<String\>\]: Secondary IPv6 Address Prefix.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricnni](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/new-aznetworkfabricnni)

