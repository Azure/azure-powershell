---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azddoscustompolicymitigationrule
schema: 2.0.0
---

# Get-AzDdosCustomPolicyMitigationRule

## SYNOPSIS
Gets mitigation rules from an in-memory DDoS custom policy.

## SYNTAX

```
Get-AzDdosCustomPolicyMitigationRule -DdosCustomPolicy <PSDdosCustomPolicy> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDdosCustomPolicyMitigationRule** cmdlet returns one named mitigation rule or all mitigation rules from a DDoS custom policy object. Rule-name matching is case-insensitive.

## EXAMPLES

### Example 1: Get a named mitigation rule
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$rule = $policy | Get-AzDdosCustomPolicyMitigationRule -Name "tcpRule"
```

This example gets the mitigation rule named `tcpRule`.

### Example 2: Get all mitigation rules
```powershell
$policy = Get-AzDdosCustomPolicy -ResourceGroupName "myRG" -Name "myPolicy"
$rules = $policy | Get-AzDdosCustomPolicyMitigationRule
```

This example returns every mitigation rule in the policy.

## PARAMETERS

### -DdosCustomPolicy
Specifies the DDoS custom policy object that contains the mitigation rules.

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
The mitigation rule name.
Omit to return every rule.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicy

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyMitigationRule

## NOTES

## RELATED LINKS

[Get-AzDdosCustomPolicy](./Get-AzDdosCustomPolicy.md)

[Add-AzDdosCustomPolicyMitigationRule](./Add-AzDdosCustomPolicyMitigationRule.md)

[Set-AzDdosCustomPolicyMitigationRule](./Set-AzDdosCustomPolicyMitigationRule.md)

[Remove-AzDdosCustomPolicyMitigationRule](./Remove-AzDdosCustomPolicyMitigationRule.md)
