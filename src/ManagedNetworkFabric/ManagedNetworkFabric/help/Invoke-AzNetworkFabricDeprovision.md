---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabricdeprovision
schema: 2.0.0
---

# Invoke-AzNetworkFabricDeprovision

## SYNOPSIS
Deprovisions the underlying resources in the given Network Fabric instance.

## SYNTAX

### Deprovision (Default)
```
Invoke-AzNetworkFabricDeprovision -NetworkFabricName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeprovisionViaIdentity
```
Invoke-AzNetworkFabricDeprovision -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait]
 [-Proxy <Uri>] [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Deprovisions the underlying resources in the given Network Fabric instance.

## EXAMPLES

### EXAMPLE 1
```
Invoke-AzNetworkFabricDeprovision -NetworkFabricName $name -ResourceGroupName $resourceGroupName
```

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
Parameter Sets: DeprovisionViaIdentity
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
Parameter Sets: Deprovision
Aliases:

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
Parameter Sets: Deprovision
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
Parameter Sets: Deprovision
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.ICommonPostActionResponseForDeviceUpdate
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

[https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabricdeprovision](https://learn.microsoft.com/powershell/module/az.managednetworkfabric/invoke-aznetworkfabricdeprovision)

