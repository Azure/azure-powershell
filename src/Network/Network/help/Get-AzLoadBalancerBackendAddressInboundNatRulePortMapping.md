---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:https://docs.microsoft.com/powershell/module/az.network/get-azloadbalancerbackendaddressinboundnatruleportmapping
schema: 2.0.0
---

# Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping

## SYNOPSIS
Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping retrieves inbound nat rule port mapping list for one backend address.

## SYNTAX

### GetByNameParameterSet
```
Get-AzLoadBalancerBackendAddressPool -ResourceGroupName <String> -LoadBalancerName <String> [-Name <String>] [-IpAddress <String>]
 [-NetworkInterfaceIpConfigurationId <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByParentObjectParameterSet
```
Get-AzLoadBalancerBackendAddressPool [-Name <String>] -LoadBalancer <PSLoadBalancer> [-IpAddress <String>]
 [-NetworkInterfaceIpConfigurationId <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetByResourceIdParameterSet
```
Get-AzLoadBalancerBackendAddressPool -ResourceId <String> [-IpAddress <String>]
 [-NetworkInterfaceIpConfigurationId <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Get-AzLoadBalancerBackendAddressPool retrieves inbound nat rule port mapping list for one backend address.

## EXAMPLES

### Example 1
```powershell
## Get inbound nat rule port mapping by NIC id
Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -NetworkInterfaceIpConfigurationId $ipconfig.Id -Name pool1
```

### Example 2
```powershell
## Get inbound nat rule port mapping by ip address
$testIpAddress1 = "10.0.0.5"
Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceGroupName $rgname -LoadBalancerName $lbName -Name $backendAddressPoolName -IpAddress $testIpAddress1
```

### Example 3
```powershell
## Get inbound nat rule port mapping by ip address and load balancer object
$slb = Get-AzLoadBalancer -Name "MyLoadBalancer" -ResourceGroupName "MyResourceGroup"
Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -LoadBalancer $slb -Name $backendAddressPoolName -IpAddress $testIpAddress1
```

### Example 4
```powershell
## Get inbound nat rule port mapping by ip address and backend pool id
Get-AzLoadBalancerBackendAddressInboundNatRulePortMapping -ResourceId $backendPool1.Id -IpAddress $testIpAddress1
```

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancer
Specifies the load balancer that has the backend address pool

```yaml
Type: PSLoadBalancer
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
Type: String
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
Type: String
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
Type: String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId

```yaml
Type: String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IpAddress

```yaml
Type: String
Parameter Sets:
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkInterfaceIpConfigurationId

```yaml
Type: String
Parameter Sets:
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSInboundNatRulePortMapping

## NOTES

## RELATED LINKS

[Get-AzLoadBalancer](./Get-AzLoadBalancer.md)
