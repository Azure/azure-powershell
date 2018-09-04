---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/get-azurermloadbalanceroutboundruleconfig
schema: 2.0.0
---

# Get-AzureRmLoadBalancerOutboundRuleConfig

## SYNOPSIS
Gets an outbound rule configuration in a load balancer.

## SYNTAX

```
Get-AzureRmLoadBalancerOutboundRuleConfig -LoadBalancer <PSLoadBalancer> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmLoadBalancerOutboundRuleConfig** cmdlet gets an outbound rule configuration or a list of outbound rule configurations in a load balancer.

## EXAMPLES

### Example 1: Get an outbound rule configuration in a load balancer
```powershell
PS C:\>$slb = Get-AzureRmLoadBalancer -ResourceGroupName "MyResourceGroup" -Name "MyLoadBalancer"
PS C:\>Get-AzureRmLoadBalancerOutboundRuleConfig -LoadBalancer $slb -Name "MyRule"
```

The first command gets the load balancer named MyLoadBalancer, and then stores it in the variable $slb.
The second command gets the outbound rule configuration named MyRule associated with that load balancer.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancer
The reference of the load balancer resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSLoadBalancer
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Name of the outbound rule.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSOutboundRule

## NOTES

## RELATED LINKS
