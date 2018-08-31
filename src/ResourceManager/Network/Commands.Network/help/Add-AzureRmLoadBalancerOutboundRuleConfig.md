---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version:
schema: 2.0.0
---

# Add-AzureRmLoadBalancerOutboundRuleConfig

## SYNOPSIS
{{Fill in the Synopsis}}

## SYNTAX

### SetByResource (Default)
```
Add-AzureRmLoadBalancerOutboundRuleConfig -LoadBalancer <PSLoadBalancer> [-Name <String>]
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSResourceId]>]
 [-BackendAddressPool <PSBackendAddressPool>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceId
```
Add-AzureRmLoadBalancerOutboundRuleConfig -LoadBalancer <PSLoadBalancer> [-Name <String>]
 [-AllocatedOutboundPort <Int32>] [-Protocol <String>] [-EnableTcpReset] [-IdleTimeoutInMinutes <Int32>]
 [-FrontendIpConfiguration <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSResourceId]>]
 [-BackendAddressPoolId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
{{Fill in the Description}}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AllocatedOutboundPort
The number of outbound ports to be used for NAT.

```yaml
Type: Int32
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
Type: PSBackendAddressPool
Parameter Sets: SetByResource
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
Type: String
Parameter Sets: SetByResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

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
Type: SwitchParameter
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
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSResourceId]
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
Type: Int32
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
Type: PSLoadBalancer
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Protocol - TCP, UDP or All

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer
System.Int32
System.String
System.Collections.Generic.List\`1[[Microsoft.Azure.Commands.Network.Models.PSResourceId, Microsoft.Azure.Commands.Network, Version=6.5.0.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.Network.Models.PSBackendAddressPool


## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer


## NOTES

## RELATED LINKS
