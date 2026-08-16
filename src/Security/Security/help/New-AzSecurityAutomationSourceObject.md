---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azsecurityautomationsourceobject
schema: 2.0.0
---

# New-AzSecurityAutomationSourceObject

## SYNOPSIS
Creates security automation source object

## SYNTAX

### SecurityAutomationSource (Default)
```
New-AzSecurityAutomationSourceObject [-DefaultProfile <IAzureContextContainer>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### SecurityAutomationActionLogicApp
```
New-AzSecurityAutomationSourceObject -EventSource <String> -RuleSet <PSSecurityAutomationRuleSet[]>
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken]
 [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates security automation source object

## EXAMPLES

### Example 1
```powershell
New-AzSecurityAutomationSourceObject -EventSource 'Assessments' -RuleSet $ruleSet
```

Creates security automation source object

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

### -EventSource
The triggered Logic App Azure Resource ID.
This can also reside on other subscriptions, given that you have permissions to trigger the Logic App

```yaml
Type: System.String
Parameter Sets: SecurityAutomationActionLogicApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSet
The Logic App trigger URI endpoint (it will not be included in any response)

```yaml
Type: Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomationRuleSet[]
Parameter Sets: SecurityAutomationActionLogicApp
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

### Microsoft.Azure.Commands.Security.Models.Automations.PSSecurityAutomationSource

## NOTES

## RELATED LINKS
