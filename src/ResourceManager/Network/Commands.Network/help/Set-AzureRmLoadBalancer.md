---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 494E185D-3746-4959-846E-660017A1F392
online version: 
schema: 2.0.0
---

# Set-AzureRmLoadBalancer

## SYNOPSIS
Sets the goal state for a load balancer.

## SYNTAX

```
Set-AzureRmLoadBalancer -LoadBalancer <PSLoadBalancer> [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmLoadBalancer** cmdlet sets the goal state for an Azure load balancer.

## EXAMPLES

### Example 1: Modify a load balancer
```
PS C:\>$slb = Get-AzureRmLoadBalancer -Name "NRPLB" -ResourceGroupName "NRP-RG"
PS C:\> $slb | Add-AzureRmLoadBalancerInboundNatRuleConfig -Name "NewRule" -FrontendIpConfiguration $slb.FrontendIpConfigurations[0] -FrontendPort 81 -BackendPort 8181 -Protocol "TCP"
PS C:\> $slb | Set-AzureRmLoadBalancer
```

The first command gets the load balancer named NRPLB, and then stores it in the $slb variable.

The second command uses the pipeline operator to pass the load balancer in $slb to Add-AzureRmLoadBalancerInboundNatRuleConfig, which adds an inbound NAT rule named NewRule.

The third command passes the load balancer to **Set-AzureRmLoadBalancer**, which updates the load balancer configuration and saves it.

## PARAMETERS

### -LoadBalancer
Specifies a load balancer.
This cmdlet sets the goal state for the load balancer that this parameter specifies.

```yaml
Type: PSLoadBalancer
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSLoadBalancer

Parameter 'LoadBalancer' accepts value of type 'PSLoadBalancer' from the pipeline

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmLoadBalancer](./Get-AzureRmLoadBalancer.md)

[New-AzureRmLoadBalancer](./New-AzureRmLoadBalancer.md)

[Remove-AzureRmLoadBalancer](./Remove-AzureRmLoadBalancer.md)


