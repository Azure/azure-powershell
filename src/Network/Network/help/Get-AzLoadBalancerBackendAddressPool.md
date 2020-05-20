---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:https://docs.microsoft.com/en-us/powershell/module/az.network/get-azloadbalancerbackendaddresspool
schema: 2.0.0
---

# Get-AzLoadBalancerBackendAddressPool

## SYNOPSIS
Get-AzLoadBalancerBackendAddressPool retrieves one or more backend address pools associated with a load balancer. 

## SYNTAX

### GetByNameParameterSet
```
Get-AzLoadBalancerBackendAddressPool -ResourceGroupName <String> -LoadBalancerName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzLoadBalancerBackendAddressPool [-Name <String>] -LoadBalancer <PSLoadBalancer>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzLoadBalancerBackendAddressPool -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get-AzLoadBalancerBackendAddressPool retrieves one or more backend address pools associated with a load balancer. This cmdlet takes 

## EXAMPLES

### Example 1
```powershell
$lb = Get-AzLoadBalancer -ResourceGroupName $resourceGroup -Name $loadBalancerName

## Get all backends under loadbalancer
PS C:\> $lb | Get-AzLoadBalancerBackendAddressPool
Name                           : test-backendPool
Id                             : /subscriptions/xxxxxx/resourceGroups/test-resourcegroup/providers/Microsoft.Network/loadBalancers/xxxxx/backendAddressPools/xxxxx
Etag                           : W/"b0c98b2c-7ebb-43e7-bcdb-af0b34360b80"
ProvisioningState              : Succeeded
BackendIpConfigurations        : []
LoadBalancerBackendIPAddresses : [
                                   {
                                     "Name": "TestVNetRef",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                       "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.5"
                                   },
                                   {
                                     "Name": "TestVNetRef2",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                           "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.6"
                                   }
                                 ]
LoadBalancingRules             : []

Name                           : test-backendPool2
Id                             : /subscriptions/xxxxxx/resourceGroups/test-resourcegroup/providers/Microsoft.Network/loadBalancers/xxxxx/backendAddressPools/xxxxx
Etag                           : W/"b0c98b2c-7ebb-43e7-bcdb-af0b34360b80"
ProvisioningState              : Succeeded
BackendIpConfigurations        : []
LoadBalancerBackendIPAddresses : [
                                   {
                                     "Name": "TestVNetRef",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                       "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.5"
                                   },
                                   {
                                     "Name": "TestVNetRef2",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                           "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.6"
                                   }
                                 ]
LoadBalancingRules             : []

### Example 2
```powershell

#Get specific backend from loadbalancer
PS C:\> $lb | Get-AzLoadBalancerBackendAddressPool -Name $backendPool1
Name                           : test-backendPool
Id                             : /subscriptions/xxxxxx/resourceGroups/test-resourcegroup/providers/Microsoft.Network/loadBalancers/xxxxx/backendAddressPools/xxxxx
Etag                           : W/"b0c98b2c-7ebb-43e7-bcdb-af0b34360b80"
ProvisioningState              : Succeeded
BackendIpConfigurations        : []
LoadBalancerBackendIPAddresses : [
                                   {
                                     "Name": "TestVNetRef",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                       "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.5"
                                   },
                                   {
                                     "Name": "TestVNetRef2",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                           "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.6"
                                   }
                                 ]
LoadBalancingRules             : []

### Example 3
```powershell

#Get a backend by resource Id
PS C:\> Get-AzLoadBalancerBackendAddressPool -ResourceId $backendPool1.Id
Name                           : test-backendPool
Id                             : /subscriptions/xxxxxx/resourceGroups/test-resourcegroup/providers/Microsoft.Network/loadBalancers/xxxxx/backendAddressPools/xxxxx
Etag                           : W/"b0c98b2c-7ebb-43e7-bcdb-af0b34360b80"
ProvisioningState              : Succeeded
BackendIpConfigurations        : []
LoadBalancerBackendIPAddresses : [
                                   {
                                     "Name": "TestVNetRef",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                       "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.5"
                                   },
                                   {
                                     "Name": "TestVNetRef2",
                                     "VirtualNetwork": {
                                       "Subnets": [],
                                           "VirtualNetworkPeerings": [],
                                       "Id": "/subscriptions/xxxxxxx/resourceGroups/xxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxx"
                                     },
                                     "IpAddress": "10.0.0.6"
                                   }
                                 ]
LoadBalancingRules             : []

```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancer
The load balancer.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSLoadBalancer
Parameter Sets: GetByParentObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadBalancerName
The name of the load balancer.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the backend address pool.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet, GetByParentObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name of the load balancer.

```yaml
Type: System.String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Azure Resource Id

```yaml
Type: System.String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSBackendAddressPool

## NOTES

## RELATED LINKS
