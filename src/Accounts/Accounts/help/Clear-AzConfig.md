---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/clear-azconfig
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
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [-CheckForUpgrade]
 [-DefaultSubscriptionForLogin] [-DisableInstanceDiscovery] [-DisplayBreakingChangeWarning]
 [-DisplayRegionIdentified] [-DisplaySecretsWarning] [-DisplaySurveyMessage] [-EnableDataCollection]
 [-EnableErrorRecordsPersistence] [-EnableLoginByWam] [-LoginExperienceV2] [<CommonParameters>]
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

### -CheckForUpgrade
When enabled, Azure PowerShell will check for updates automatically and display a hint message when an update is available. The default value is true.

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

### -DisableInstanceDiscovery
Set it to true to disable both instance discovery and authority validation. This functionality is intended for use in scenarios where the metadata endpoint cannot be reached, such as in private clouds or Azure Stack. The process of instance discovery entails retrieving authority metadata from https://login.microsoft.com/ to validate the authority. By setting this to true, the validation of the authority is disabled. As a result, it is crucial to ensure that the configured authority host is valid and trustworthy.

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

### -DisplayRegionIdentified
When enabled, Azure PowerShell displays recommendations on regions which may reduce your costs.

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

### -DisplaySecretsWarning
When enabled, a warning message will be displayed when the cmdlet output contains secrets. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844

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

### -DisplaySurveyMessage
When enabled, you are prompted infrequently to participate in user experience surveys for Azure PowerShell.

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

### -EnableErrorRecordsPersistence
When enabled, error records will be written to ~/.Azure/ErrorRecords.

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

### -EnableLoginByWam
\[Preview\] When enabled, Web Account Manager (WAM) will be the default interactive login experience.
It will fall back to using the browser if the platform does not support WAM.
Note that this feature is under preview. Microsoft Account (MSA) is currently not supported.
Feel free to reach out to Azure PowerShell team if you have any feedbacks: https://aka.ms/azpsissue

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

### -LoginExperienceV2
Only active when authenticating interactively, allows the user to choose the subscription and tenant used in subsequent commands. Possible values ad 'On' (Default) and 'Off'. 'On' requires user's input. 'Off' will use the first tenant and subscription returned by Azure, can change without notice and lead to command execution in an unwanted context (not recommended).

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
Accepted values: CurrentUser, Process, Default, Environment

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
