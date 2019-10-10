---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version:
schema: 2.0.0
---

# Set-AzCdnWafManagedRuleGroup

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### SpecifyRuleParameterSet
```
Set-AzCdnWafManagedRuleGroup -RuleGroupName <String> -RuleOverride <PSManagedRuleOverride[]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DisableAllParameterSet
```
Set-AzCdnWafManagedRuleGroup -RuleGroupName <String> [-DisableAll] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisableAll
Disable all rules of the rule group.

```yaml
Type: SwitchParameter
Parameter Sets: DisableAllParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleGroupName
Name of the CDN WAF rule group to override.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleOverride
One or more rules to override.

```yaml
Type: PSManagedRuleOverride[]
Parameter Sets: SpecifyRuleParameterSet
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSManagedRuleGroupOverride

## NOTES

## RELATED LINKS
