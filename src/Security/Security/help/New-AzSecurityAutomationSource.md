---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# New-AzSecurityAutomationSource

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### SecurityAutomationSource (Default)
```
New-AzSecurityAutomationSource [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SecurityAutomationActionLogicApp
```
New-AzSecurityAutomationSource -EventSource <String> -RuleSets <PSSecurityAutomationRuleSet[]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
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

### -RuleSets
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
