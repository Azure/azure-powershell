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
Add-AzDdosCustomPolicyMitigationRule [-DdosCustomPolicy] <PSDdosCustomPolicy> -Name <String>
 -TrafficScope <String> [-TcpPacketsPerSecond <Int32>] [-TcpConnectionsPerSecond <Int32>]
 [-UdpPacketsPerSecond <Int32>]
 [-SourcePolicyOverride <PSDdosCustomPolicySourcePolicyOverride[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Adds a validated mitigation rule to a DDoS custom policy object. Rule names and traffic scopes must be unique within the policy. Persist the returned policy with **Set-AzDdosCustomPolicy**.

## EXAMPLES

### Example 1: Add and persist a TCP mitigation rule
```powershell
Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy" |
  Add-AzDdosCustomPolicyMitigationRule -Name "tcpRule" -TrafficScope Tcp -TcpPacketsPerSecond 100000 |
  Set-AzDdosCustomPolicy
```

## PARAMETERS

### -DdosCustomPolicy
Specifies the DDoS custom policy object to modify.

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
Specifies the unique mitigation rule name.

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
Specifies the traffic protocol. Suggested values are Tcp and Udp.

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

### -TcpConnectionsPerSecond
Specifies the maximum new TCP connection rate per source IP.

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

### -SourcePolicyOverride
Specifies source-specific Permit or Deny overrides.

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

[Set-AzDdosCustomPolicy](./Set-AzDdosCustomPolicy.md)

[Set-AzDdosCustomPolicyMitigationRule](./Set-AzDdosCustomPolicyMitigationRule.md)
