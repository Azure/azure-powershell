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

### ClearAll (Default)
```
Clear-AzConfig [-Force] [-PassThru] [-AppliesTo <String>] [-Scope <ConfigScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ClearByKey
```
Clear-AzConfig [-PassThru] [-AppliesTo <String>] [-Scope <ConfigScope>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-DefaultSubscriptionForLogin]
 [-DisplayBreakingChangeWarning] [-EnableDataCollection] [<CommonParameters>]
```

## DESCRIPTION
Clears the values of configs that are set by the user. By default all the configs will be cleared. You can also specify keys of configs to clear.

## EXAMPLES

### Example 1
```powershell
Clear-AzConfig -Force
```

Clear all the configs. `-Force` suppresses the prompt for confirmation.

### Example 2
```powershell
Clear-AzConfig -EnableDataCollection
```

Clear the "EnableDataCollection" config.

## PARAMETERS

### -AppliesTo
Specifies what part of Azure PowerShell the config applies to.
Possible values are:
- "Az": the config applies to all modules and cmdlets of Azure PowerShell.
- Module name: the config applies to a certain module of Azure PowerShell.
For example, "Az.Storage".
- Cmdlet name: the config applies to a certain cmdlet of Azure PowerShell.
For example, "Get-AzKeyVault".
If not specified, when getting or clearing configs, it defaults to all the above; when updating, it defaults to "Az".

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
Sets the default context for Azure PowerShell when logging in without specifying a subscription.

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

### -DisplayBreakingChangeWarning
Controls if warning messages for breaking changes are displayed or suppressed. When enabled, a breaking change warning is displayed when executing cmdlets with breaking changes in a future release.

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
When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experience.
For more information, see our privacy statement: https://aka.ms/privacy

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
Accepted values: CurrentUser, Process

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
