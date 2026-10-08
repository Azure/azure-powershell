---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azddoscustompolicymitigationrule
schema: 2.0.0
---

# Set-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Updates a mitigation rule in an in-memory DDoS custom policy.

## SYNTAX

```
Set-AzDdosCustomPolicyMitigationRule -DdosCustomPolicy <PSDdosCustomPolicy> -Name <String>
 [-TrafficScope <String>] [-TcpPacketsPerSecond <Int32>] [-TcpConnectionsPerSecond <Int32>]
 [-UdpPacketsPerSecond <Int32>] [-DenyIpPrefix <String[]>] [-DenyGeoMatch <String[]>]
 [-PermitIpPrefix <String[]>] [-PermitGeoMatch <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzDdosCustomPolicyMitigationRule** cmdlet updates the explicitly specified properties of an existing named mitigation rule. Omitted parameters retain their existing values, a supplied list replaces that list, and an empty array clears that list. When both lists for an action are empty, that action is removed.

Deny matches drop traffic from matching sources. Permit matches skip source-level mitigations for matching sources, while destination-level mitigations still apply. Within one action, IP prefixes and geographic matches use OR semantics. Geographic matches use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format.

Rule-name matching is case-insensitive, and response metadata and unmodified service-provided actions are preserved. The cmdlet does not update Azure. Pipe the returned policy to **Set-AzDdosCustomPolicy** to persist the change.

## EXAMPLES

### Example 1: Update and persist a TCP mitigation rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Set-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -TcpConnectionsPerSecond 15000 | Set-AzDdosCustomPolicy
```

This example updates only the TCP connection rate on `tcpRule`. The existing packet rate and source policy overrides are retained when the updated policy is persisted.

### Example 2: Replace a Deny geographic match list
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Set-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -DenyGeoMatch "US", "Africa.ZM", "MX" | Set-AzDdosCustomPolicy
```

This example replaces the complete Deny geographic match list.

### Example 3: Clear a Permit IP prefix list
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Set-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -PermitIpPrefix @() | Set-AzDdosCustomPolicy
```

This example clears the Permit IP prefix list while preserving the Permit geographic match list.

### Example 4: Remove a TCP packet rate limit
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Set-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -TcpPacketsPerSecond $null | Set-AzDdosCustomPolicy
```

This example removes the TCP packet rate limit while preserving other rule properties.

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

### -DdosCustomPolicy
Specifies the DDoS custom policy object to modify.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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
Specifies the name of the existing mitigation rule to update.

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
Specifies the replacement geographic match list for the Deny action. Matching traffic is dropped. Use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format. Specify an empty array to clear this list. If omitted, the current list is retained.

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
Specifies the replacement IPv4 or IPv6 CIDR prefix list for the Deny action. Matching traffic is dropped. Specify an empty array to clear this list. If omitted, the current list is retained.

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
Specifies the replacement geographic match list for the Permit action. Matching sources skip source-level mitigations, while destination-level mitigations still apply. Use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format. Specify an empty array to clear this list. If omitted, the current list is retained.

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
Specifies the replacement IPv4 or IPv6 CIDR prefix list for the Permit action. Matching sources skip source-level mitigations, while destination-level mitigations still apply. Specify an empty array to clear this list. If omitted, the current list is retained.

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
Specifies the maximum new TCP connection rate per source IP address.

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
Specifies the maximum TCP packet rate per source IP address.

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
Specifies the traffic protocol to which the rule applies. If this parameter is omitted, the existing traffic scope is retained. Common values are `Tcp` and `Udp`.

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

### -UdpPacketsPerSecond
Specifies the maximum UDP packet rate per source IP address.

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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicyMitigationRule](./Get-AzDdosCustomPolicyMitigationRule.md)

[Add-AzDdosCustomPolicyMitigationRule](./Add-AzDdosCustomPolicyMitigationRule.md)

[Set-AzDdosCustomPolicy](./Set-AzDdosCustomPolicy.md)

[Remove-AzDdosCustomPolicyMitigationRule](./Remove-AzDdosCustomPolicyMitigationRule.md)
