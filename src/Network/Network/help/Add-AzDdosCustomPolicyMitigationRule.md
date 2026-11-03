---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/add-azddoscustompolicymitigationrule
schema: 2.0.0
---

# Add-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Adds a mitigation rule to an in-memory DDoS custom policy.

## SYNTAX

```
Add-AzDdosCustomPolicyMitigationRule -DdosCustomPolicy <PSDdosCustomPolicy> -Name <String>
 -TrafficScope <String> [-TcpPacketsPerSecond <Int32>] [-TcpConnectionsPerSecond <Int32>]
 [-UdpPacketsPerSecond <Int32>] [-DenyIpPrefix <String[]>] [-DenyGeoMatch <String[]>]
 [-PermitIpPrefix <String[]>] [-PermitGeoMatch <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzDdosCustomPolicyMitigationRule** cmdlet creates a mitigation rule and adds it to a DDoS custom policy object. Deny matches drop traffic from matching sources. Permit matches skip source-level mitigations for matching sources, while destination-level mitigations still apply. Within one action, IP prefixes and geographic matches use OR semantics.

Geographic matches use `<Country>`, `<Continent>`, or `<Continent>.<Country>` format, such as `US`, `Africa`, or `Africa.ZM`. The cmdlet does not update Azure. Pipe the returned policy to **Set-AzDdosCustomPolicy** to persist the change.

## EXAMPLES

### Example 1: Add and persist a UDP mitigation rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$policy | Add-AzDdosCustomPolicyMitigationRule -Name "udpRule" -TrafficScope Udp -UdpPacketsPerSecond 90000 -DenyIpPrefix "192.0.2.0/24" | Set-AzDdosCustomPolicy
```

This example adds a UDP per-source packet rate limit with a prefix-specific Deny action and persists the updated policy.

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
Specifies the unique name of the mitigation rule.

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
Specifies the traffic protocol to which the rule applies. Common values are `Tcp` and `Udp`.

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

[New-AzDdosCustomPolicyMitigationRule](./New-AzDdosCustomPolicyMitigationRule.md)

[Set-AzDdosCustomPolicy](./Set-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicyMitigationRule](./Set-AzDdosCustomPolicyMitigationRule.md)

[Remove-AzDdosCustomPolicyMitigationRule](./Remove-AzDdosCustomPolicyMitigationRule.md)
