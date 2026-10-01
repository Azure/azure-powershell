---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicymitigationrule
schema: 2.0.0
---

# New-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Creates a DDoS custom policy mitigation rule.

## SYNTAX

```
New-AzDdosCustomPolicyMitigationRule -Name <String> -TrafficScope <String>
 [-TcpPacketsPerSecond <Int32>] [-TcpConnectionsPerSecond <Int32>]
 [-UdpPacketsPerSecond <Int32>]
 [-SourcePolicyOverride <PSDdosCustomPolicySourcePolicyOverride[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates an in-memory mitigation rule for use with **New-AzDdosCustomPolicy** or the mitigation rule mutation cmdlets. The returned object preserves the service model hierarchy under its `Properties` member.

## EXAMPLES

### Example 1: Create a TCP mitigation rule
```powershell
$rule = New-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -TrafficScope Tcp `
    -TcpPacketsPerSecond 100000 -TcpConnectionsPerSecond 10000
```

### Example 2: Create a UDP rule with a source override
```powershell
$override = New-AzDdosCustomPolicySourcePolicyOverride -ActionType Permit -IpPrefix "203.0.113.0/24"
$rule = New-AzDdosCustomPolicyMitigationRule -Name "udpRule" -TrafficScope Udp `
    -UdpPacketsPerSecond 50000 -SourcePolicyOverride $override
```

## PARAMETERS

### -Name
Specifies the stable name used to identify the mitigation rule within the custom policy.

```yaml
Type: System.String
Parameter Sets: (All)
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePolicyOverride
Specifies source-specific Permit or Deny overrides created with **New-AzDdosCustomPolicySourcePolicyOverride**.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyOverride[]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpConnectionsPerSecond
Specifies the maximum number of new TCP connections established per second from a source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpPacketsPerSecond
Specifies the maximum TCP packet rate per source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficScope
Specifies the traffic protocol to which the rule applies. Suggested values are Tcp and Udp. The service can accept future supported values.

```yaml
Type: System.String
Parameter Sets: (All)
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UdpPacketsPerSecond
Specifies the maximum UDP packet rate per source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
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
Required: False
Position: Named
Default value: None
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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
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
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyMitigationRule

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyMitigationRule](./Add-AzDdosCustomPolicyMitigationRule.md)
