---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/powershell/module/az.accounts/clear-azconfig
schema: 2.0.0
---

# Clear-AzConfig

## SYNOPSIS
Clears the values of configs that are set by the user.

## SYNTAX

### ClearAll
```
Clear-AzConfig [-All] [-Force] [-PassThru] [-AppliesTo <String>] [-Scope <ConfigScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ClearByKey
```
Clear-AzConfig [-PassThru] [-AppliesTo <String>] [-Scope <ConfigScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-DefaultSubscriptionForLogin]
 [-EnableDataCollection] [-EnableInterceptSurvey] [-SuppressWarningMessage] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
Clear-AzConfig -Todo
```

```output
Todo
```

Todo

## PARAMETERS

### -All
Clear all configs.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearAll
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppliesTo
Specifies what part of Azure PowerShell the config applies to.
Possible values are:
- "Az": the config applies to all modules and cmdlets of Azure PowerShell.
- Module name: the config applies to a certain module of Azure PowerShell.
For example, "Az.Storage".
- Cmdlet name: the config applies to a certain cmdlet of Azure PowerShell.
For example, "Get-AzKeyVault".
If not specified, when getting configs, output will be all of the above; when updating or clearing configs, it defaults to "Az"

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

### -DefaultSubscriptionForLogin
Subscription name or GUID.
If defined, when logging in Azure PowerShell without specifying the subscription, this one will be used to select the default context.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearByKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableDataCollection
todo

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearByKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableInterceptSurvey
When enabled, a message of taking part in the survey about the user experience of Azure PowerShell will prompt at low frequency.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearByKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation when clearing all configs.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearAll
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true if cmdlet executes correctly.

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

### -Scope
Determines the scope of config changes, for example, whether changes apply only to the current process, or to all sessions started by this user.
By default it is CurrentUser.

```yaml
Type: Microsoft.Azure.PowerShell.Common.Config.ConfigScope
Parameter Sets: (All)
Aliases:
Accepted values: CurrentUser, Process, Default

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SuppressWarningMessage
Controls if the warning messages of upcoming breaking changes are enabled or suppressed.
The messages are typically displayed when a cmdlet that will have breaking change in the future is executed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ClearByKey
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

### None

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
