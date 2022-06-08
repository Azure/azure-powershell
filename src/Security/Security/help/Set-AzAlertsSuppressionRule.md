---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version:
schema: 2.0.0
---

# Set-AzAlertsSuppressionRule

## SYNOPSIS
Create or update an alerts suppression rule.

## SYNTAX

### RuleNameWithParameters (Default)
```
Set-AzAlertsSuppressionRule -Name <String> -AlertType <String> [-ExpirationDateUtc <DateTime>] -Reason <String>
 -State <PSRuleState> [-Comment <String>] [-SuppressionAlertsScope <PSSuppressionAlertsScope>]
 [-AllOf <PSIScopeElement[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObject
```
Set-AzAlertsSuppressionRule -InputObject <PSAlertsSuppressionRule> [-Name <String>] [-AlertType <String>]
 [-ExpirationDateUtc <DateTime>] [-Reason <String>] [-State <PSRuleState>] [-Comment <String>]
 [-SuppressionAlertsScope <PSSuppressionAlertsScope>] [-AllOf <PSIScopeElement[]>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update an alerts suppression rule.

## EXAMPLES

### Example 1
```powershell
Set-AzAlertsSuppressionRule -Name "Example" -State Enabled -Comment "Example of a comment" -AlertType "AzureDNS_CurrencyMining" -Reason "Other" -AllOf @([Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSScopeElementContains]::new("entities.account.name", "example")) -ExpirationDateUtc 2024-10-17T15:02:24.7511441Z
```

The above example creates a new suppression rule with the name "Example" to suppress alerts of type (Digital currency mining activity)[https://docs.microsoft.com/en-us/azure/defender-for-cloud/alerts-reference] that contains "example" as part of their account name.

## PARAMETERS

### -AlertType
Alert type to suppress.

```yaml
Type: System.String
Parameter Sets: RuleNameWithParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllOf
Scope the suppression rule using specific entities.

```yaml
Type: Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSIScopeElement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Comment
Comment.

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

### -ExpirationDateUtc
Set an expiration data for the rule, expected to be in a UTC format.

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Input Object.

```yaml
Type: Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSAlertsSuppressionRule
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Alert suppression rule name, needs to be unique per subscription.

```yaml
Type: System.String
Parameter Sets: RuleNameWithParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Reason
The reason for creating the suppression rule.

```yaml
Type: System.String
Parameter Sets: RuleNameWithParameters
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: InputObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
State of the rule, Enabled/Disabled

```yaml
Type: Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSRuleState
Parameter Sets: RuleNameWithParameters
Aliases:
Accepted values: Enabled, Disabled, Expired

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSRuleState
Parameter Sets: InputObject
Aliases:
Accepted values: Enabled, Disabled, Expired

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressionAlertsScope
Scope the suppression rule using specific entities.

```yaml
Type: Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSSuppressionAlertsScope
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

### Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSAlertsSuppressionRule

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.AlertsSuppressionRules.PSAlertsSuppressionRule

## NOTES

## RELATED LINKS
