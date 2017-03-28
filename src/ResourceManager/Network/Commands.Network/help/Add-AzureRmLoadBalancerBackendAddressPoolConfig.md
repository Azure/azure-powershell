---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 9EB11283-0189-4333-8142-DCC3F770F91A
online version: 
schema: 2.0.0
---

# Add-AzureRmLoadBalancerBackendAddressPoolConfig

## SYNOPSIS
Adds a backend address pool configuration to a load balancer.

## SYNTAX

```
Add-AzureRmLoadBalancerBackendAddressPoolConfig -Name <String> -LoadBalancer <PSLoadBalancer>
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmLoadBalancerBackend** cmdlet adds a backend address pool to an Azure load balancer.

## EXAMPLES

### Example 1 Add a backend address pool configuration to a load balancer
```
PS C:\>Get-AzureRmLoadBalancer -Name "MyLoadBalancer" -ResourceGroupName "myrg" | Add-AzureRmLoadBalancerBackendAddressPoolConfig -Name "BackendAddressPool02" | Set-AzureRmLoadBalancer
```

This command gets the load balancer named MyLoadBalancer, adds the backend address pool named BackendAddressPool02 to MyLoadBalancer, and then uses the **Set-AzureRmLoadBalancer** cmdlet to update MyLoadBalancer.

## PARAMETERS

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LoadBalancer
Specifies a **LoadBalancer** object.

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

### -Name
Specifies the name of the backend address pool configuration to add.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmLoadBalancer](./Get-AzureRmLoadBalancer.md)

[Get-AzureRmNetworkInterface](./Get-AzureRmNetworkInterface.md)

[Get-AzureRmLoadBalancerBackendAddressPoolConfig](./Get-AzureRmLoadBalancerBackendAddressPoolConfig.md)

[New-AzureRmLoadBalancerBackendAddressPoolConfig](./New-AzureRmLoadBalancerBackendAddressPoolConfig.md)

[Remove-AzureRmLoadBalancerBackendAddressPoolConfig](./Remove-AzureRmLoadBalancerBackendAddressPoolConfig.md)


