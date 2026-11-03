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
New-AzDdosCustomPolicyMitigationRule -Name <String> -TrafficScope <String> [-TcpPacketsPerSecond <Int32>]
 [-TcpConnectionsPerSecond <Int32>] [-UdpPacketsPerSecond <Int32>]
 [-DenyIpPrefix <String[]>] [-DenyGeoMatch <String[]>] [-PermitIpPrefix <String[]>]
 [-PermitGeoMatch <String[]>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDdosCustomPolicyMitigationRule** cmdlet creates an in-memory mitigation rule for TCP or UDP traffic. Deny matches drop traffic from matching sources. Permit matches skip source-level mitigations for matching sources, while destination-level mitigations still apply. Within one action, IP prefixes and geographic matches use OR semantics, so a source matches if it matches any entry.

Geographic matches use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format, such as `US`, `Africa`, or `Africa.ZM`. Pass the rule to **New-AzDdosCustomPolicy** or add it to an existing policy object.

## EXAMPLES

### Example 1: Create a TCP mitigation rule
```powershell
$rule = New-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -TrafficScope Tcp -TcpPacketsPerSecond 100000 -TcpConnectionsPerSecond 10000
```

This example creates a TCP rule with per-source packet and new-connection rate limits.

### Example 2: Create a UDP rule with source actions
```powershell
$rule = New-AzDdosCustomPolicyMitigationRule -Name "udpRule" -TrafficScope Udp -UdpPacketsPerSecond 90000 -DenyIpPrefix "192.0.2.0/24" -PermitGeoMatch "US", "Africa.ZM"
```

This example creates a UDP rule that drops traffic from the specified IP prefix and skips source-level mitigations for traffic from the specified geographic sources.

## PARAMETERS

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

### -Name
The mitigation rule name.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenyGeoMatch
Specifies geographic sources whose matching traffic is dropped. Use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format. Deny IP prefixes and geographic matches use OR semantics.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DenyIpPrefix
Specifies IPv4 or IPv6 CIDR prefixes whose matching traffic is dropped. Deny IP prefixes and geographic matches use OR semantics.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitGeoMatch
Specifies geographic sources that skip source-level mitigations. Destination-level mitigations still apply. Use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format. Permit IP prefixes and geographic matches use OR semantics.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PermitIpPrefix
Specifies IPv4 or IPv6 CIDR prefixes that skip source-level mitigations. Destination-level mitigations still apply. Permit IP prefixes and geographic matches use OR semantics.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpConnectionsPerSecond
The maximum new TCP connection rate per source IP.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpPacketsPerSecond
The maximum TCP packet rate per source IP.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficScope
The traffic protocol to which the rule applies.

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

### -UdpPacketsPerSecond
The maximum UDP packet rate per source IP.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyMitigationRule

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicy](./New-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyMitigationRule](./Add-AzDdosCustomPolicyMitigationRule.md)
