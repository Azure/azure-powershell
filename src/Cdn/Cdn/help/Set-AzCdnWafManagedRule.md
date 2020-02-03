---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Cdn.dll-Help.xml
Module Name: Az.Cdn
online version: https://docs.microsoft.com/en-us/powershell/module/az.cdn/set-azcdnwafmanagedrule
schema: 2.0.0
---

# Set-AzCdnWafManagedRule

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
Set-AzCdnWafManagedRule -RuleId <String> [-Enabled] [-Action <PSActionType>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> $rule1 = New-AzCdnWafManagedRule -RuleId 942480 -Enabled -Action Redirect
```

Saves a managed rule which changes rule 942480 to redirect instead of block for use in a managed rule set. 

## PARAMETERS

### -Action
The action to take when the rule is matched

```yaml
Type: Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSActionType
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Block, Log, Redirect

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

### -Enabled
Enable the CDN WAF Managed Rule.

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

### -RuleId
ID of the CDN WAF managed rule to override.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall.PSManagedRuleOverride

## NOTES

## RELATED LINKS
