---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-aznetworkvirtualapplianceloadbalancerconfiguration
schema: 2.0.0
---

# New-AzNetworkVirtualApplianceLoadBalancerConfiguration

## SYNOPSIS
Creates load balancer settings for a managed NVA or a Permanent Internet Ingress rule.

## SYNTAX

```
New-AzNetworkVirtualApplianceLoadBalancerConfiguration [-LoadDistribution <String>]
 [-IdleTimeoutInMinutes <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates a configuration object without deploying Azure resources. Pass it to New-AzNetworkVirtualAppliance or Update-AzNetworkVirtualAppliance for the managed internal load balancer, or to New-AzVirtualApplianceInboundSecurityRulesProperty for an individual Permanent Internet Ingress rule.

Default uses a five-tuple hash (source IP, destination IP, source port, destination port, protocol). SourceIP uses a two-tuple hash (source IP, destination IP). SourceIPProtocol uses a three-tuple hash (source IP, destination IP, protocol). Values are case-insensitive and canonicalized.

Each omitted member uses its own default: Default distribution and a 5-minute timeout. Configurations replace previous values; they are not merged. Omitting configuration from an NVA update also resets settings to defaults. Partner-managed SaaS load balancers and AutoExpire ingress rules do not support this configuration.

## EXAMPLES

### Example 1: Configure three-tuple distribution
```powershell
$configuration = New-AzNetworkVirtualApplianceLoadBalancerConfiguration -LoadDistribution SourceIPProtocol -IdleTimeoutInMinutes 15
Update-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -LoadBalancerConfiguration $configuration
```

Uses three-tuple distribution and a 15-minute timeout.

### Example 2: Specify only the timeout
```powershell
New-AzNetworkVirtualApplianceLoadBalancerConfiguration -IdleTimeoutInMinutes 15
```

Returns Default distribution with a 15-minute timeout.

### Example 3: Reset explicitly to defaults
```powershell
$defaults = New-AzNetworkVirtualApplianceLoadBalancerConfiguration
Update-AzNetworkVirtualAppliance -ResourceGroupName testrg -Name nva -LoadBalancerConfiguration $defaults
```

Resets distribution to Default and timeout to 5 minutes.

## PARAMETERS

### -LoadDistribution
The distribution policy: Default, SourceIP, or SourceIPProtocol.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Default, SourceIP, SourceIPProtocol

Required: False
Position: Named
Default value: Default
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdleTimeoutInMinutes
The idle timeout in minutes, from 4 through 100 inclusive.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 5
Accept pipeline input: False
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

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ChangeReference
The change reference resource ID for this resource operation.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters.

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkVirtualApplianceLoadBalancerConfiguration

## NOTES

## RELATED LINKS

[New-AzNetworkVirtualAppliance](New-AzNetworkVirtualAppliance.md)
[Update-AzNetworkVirtualAppliance](Update-AzNetworkVirtualAppliance.md)
[New-AzVirtualApplianceInboundSecurityRulesProperty](New-AzVirtualApplianceInboundSecurityRulesProperty.md)
