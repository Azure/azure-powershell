---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/update-azloadbalanceroutboundruleconfig
schema: 2.0.0
---

# Update-AzLoadBalancerOutboundRuleConfig

## SYNOPSIS
Incrementally updates outbound rule of a load balancer.

## SYNTAX

### SetByResourceParent (Default)
```
Update-AzLoadBalancerOutboundRuleConfig -LoadBalancer <PSLoadBalancer> -Name <String>
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <PSResourceId[]>] [-BackendAddressPool <PSBackendAddressPool>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParent
```
Update-AzLoadBalancerOutboundRuleConfig -LoadBalancer <PSLoadBalancer> -Name <String>
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <PSResourceId[]>] [-BackendAddressPoolId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParentName
```
Update-AzLoadBalancerOutboundRuleConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <PSResourceId[]>] [-BackendAddressPoolId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceParentName
```
Update-AzLoadBalancerOutboundRuleConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <PSResourceId[]>] [-BackendAddressPool <PSBackendAddressPool>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzLoadBalancerOutboundRuleConfig** incrementally updates outbound rule of a load balancer. I.e. only the specified parameters values are changed and values of the unspecified properties are kept unlike of Set-AzLoadBalancerOutboundRuleConfig cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:> Update-AzLoadBalancerOutboundRuleConfig -LoadBalancer $lb -Name $outboundRuleName -IdleTimeoutInMinutes 17
```

This command updates outbound rule timeout in minutes keeping other properties unchanged.

## PARAMETERS

### -AllocatedOutboundPort
The number of outbound ports to be used for NAT.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BackendAddressPool
A reference to a pool of DIPs.
Outbound traffic is randomly load balanced across IPs in the backend IPs.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSBackendAddressPool
Parameter Sets: SetByResourceParent, SetByResourceParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -BackendAddressPoolId
A reference to a pool of DIPs.
Outbound traffic is randomly load balanced across IPs in the backend IPs.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParent, SetByResourceIdParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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

### -EnableTcpReset
Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
This element is only used when the protocol is set to TCP.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontendIpConfiguration
The Frontend IP addresses of the load balancer.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdleTimeoutInMinutes
The timeout for the TCP idle connection

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LoadBalancer
The reference of the load balancer resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSLoadBalancer
Parameter Sets: SetByResourceParent, SetByResourceIdParent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -LoadBalancerName
The reference of the load balancer resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParentName, SetByResourceParentName
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

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Protocol - TCP, UDP or All

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The reference of the load balancer resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParentName, SetByResourceParentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

### System.String

### System.Int32

### Microsoft.Azure.Commands.Network.Models.PSResourceId[]

### Microsoft.Azure.Commands.Network.Models.PSBackendAddressPool

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

## NOTES

## RELATED LINKS
