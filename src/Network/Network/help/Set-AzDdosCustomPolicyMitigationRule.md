---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/set-azddoscustompolicymitigationrule
schema: 2.0.0
---

# Set-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Replaces the configurable properties of a mitigation rule in a DDoS custom policy.

## SYNTAX

```
Set-AzDdosCustomPolicyMitigationRule [-DdosCustomPolicy] <PSDdosCustomPolicy> -Name <String>
 -TrafficScope <String> [-TcpPacketsPerSecond <Int32>] [-TcpConnectionsPerSecond <Int32>]
 [-UdpPacketsPerSecond <Int32>]
 [-SourcePolicyOverride <PSDdosCustomPolicySourcePolicyOverride[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Finds a mitigation rule by its case-insensitive name and replaces its configurable `Properties` while preserving read-only response metadata. Persist the returned policy with **Set-AzDdosCustomPolicy**. To rename a rule, remove it and add a new rule.

## EXAMPLES

### Example 1: Update and persist a mitigation rule
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" |
  Set-AzDdosCustomPolicyMitigationRule -Name "udpRule" -TrafficScope Udp -UdpPacketsPerSecond 75000 |
  Set-AzDdosCustomPolicy
```

## PARAMETERS

### -DdosCustomPolicy
Specifies the DDoS custom policy object containing the mitigation rule.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy
Parameter Sets: (All)
Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Specifies the existing mitigation rule name. Matching is case-insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrafficScope
Specifies the replacement traffic protocol. Suggested values are Tcp and Udp.

```yaml
Type: System.String
Parameter Sets: (All)
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpPacketsPerSecond
Specifies the replacement maximum TCP packet rate per source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TcpConnectionsPerSecond
Specifies the replacement maximum new TCP connection rate per source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UdpPacketsPerSecond
Specifies the replacement maximum UDP packet rate per source IP.

```yaml
Type: System.Nullable[System.Int32]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePolicyOverride
Specifies the complete replacement collection of source-specific overrides.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyOverride[]
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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicyMitigationRule](./Get-AzDdosCustomPolicyMitigationRule.md)

[Set-AzDdosCustomPolicy](./Set-AzDdosCustomPolicy.md)
