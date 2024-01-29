---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricl2domain
schema: 2.0.0
---

# Get-AzNetworkFabricL2Domain

## SYNOPSIS
Implements L2 Isolation Domain GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricL2Domain [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricL2Domain -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricL2Domain -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricL2Domain -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [<CommonParameters>]
```

## DESCRIPTION
Implements L2 Isolation Domain GET method.

## EXAMPLES

### EXAMPLE 1
```
Get-AzNetworkFabricL2Domain -SubscriptionId $subscriptionId
```

### EXAMPLE 2
```
Get-AzNetworkFabricL2Domain -ResourceGroupName $resourceGroupName
```

### EXAMPLE 3
```
Get-AzNetworkFabricL2Domain -Name $name -ResourceGroupName $resourceGroupName
```

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the L2 Isolation Domain.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: L2IsolationDomainName

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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

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
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL2IsolationDomain
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IManagedNetworkFabricIdentity\>: Identity Parameter
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

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricl2domain](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricl2domain)

