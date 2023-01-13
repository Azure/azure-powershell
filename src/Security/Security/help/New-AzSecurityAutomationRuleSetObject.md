---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# New-AzSecurityAutomationRuleSetObject

## SYNOPSIS
Creates security automation rule set object

## SYNTAX

```
New-AzSecurityAutomationRuleSetObject -Rules <PSSecurityAutomationTriggeringRule[]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Creates security automation rule set object

## EXAMPLES

### Example 1
```powershell
New-AzSecurityAutomationRuleSetObject -Rule $rule
```

Creates security automation rule set object

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

### -Rules
A rule which is evaluated upon event interception.
The rule is configured by comparing a specific value from the event model to an expected value.
This comparison is done by using one of the supported operators set

```yaml
Type: PSSecurityAutomationTriggeringRule[]
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

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomationRuleSet

## NOTES

## RELATED LINKS
