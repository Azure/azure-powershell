---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://learn.microsoft.com/powershell/module/az.accounts/update-azconfig
schema: 2.0.0
---

# Update-AzConfig

## SYNOPSIS
Updates the configs of Azure PowerShell.

## SYNTAX

```
Update-AzConfig [-AppliesTo <String>] [-Scope <ConfigScope>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-CheckForUpgrade <Boolean>] [-DefaultSubscriptionForLogin <String>]
 [-DisableInstanceDiscovery <Boolean>] [-DisplayBreakingChangeWarning <Boolean>]
 [-DisplayRegionIdentified <Boolean>] [-DisplaySecretsWarning <Boolean>] [-DisplaySurveyMessage <Boolean>]
 [-EnableDataCollection <Boolean>] [-EnableErrorRecordsPersistence <Boolean>] [-EnableLoginByWam <Boolean>]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the configs of Azure PowerShell.
Depending on which config to update, you may specify the scope where the config is persisted and to which module or cmdlet it applies to.

> [!NOTE]
> It is discouraged to update configs in multiple PowerShell processes. Either do it in one process, or make sure the updates are at Process scope (`-Scope Process`) to avoid unexpected side-effects.

## EXAMPLES

### Example 1
```powershell
Update-AzConfig -DefaultSubscriptionForLogin "Name of subscription"
```

```output
Key                         Value                Applies To Scope       Help Message
---                         -----                ---------- -----       ------------
DefaultSubscriptionForLogin Name of subscription Az         CurrentUser Subscription name or GUID. Sets the default context for Azure PowerShell when lo…
```

Sets the "DefaultSubscriptionForLogin" config as "Name of subscription". When `Connect-AzAccount` the specified subscription will be selected as the default subscription.

### Example 2
```powershell
Update-AzConfig -DisplayBreakingChangeWarning $false -AppliesTo "Az.KeyVault"
```

```output
Key                          Value Applies To  Scope       Help Message
---                          ----- ----------  -----       ------------
DisplayBreakingChangeWarning False Az.KeyVault CurrentUser Controls if warning messages for breaking changes are displayed or suppressed. When enabled,…
```

Sets the "DisplayBreakingChangeWarnings" config as "$false" for "Az.KeyVault" module. This prevents all the warning messages for upcoming breaking changes in Az.KeyVault module from prompting.

### Example 3
```powershell
Update-AzConfig -EnableDataCollection $true
```

```output
Key                  Value Applies To Scope       Help Message
---                  ----- ---------- -----       ------------
EnableDataCollection True  Az         CurrentUser When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experi…
```

Sets the "EnableDataCollection" config as "$true". This enables sending the telemetry data.
Setting this config is equivalent to `Enable-AzDataCollection` and `Disable-AzDataCollection`.

### Example 4
```powershell
Update-AzConfig -DisplaySecretsWarning $true
```

```output
Key                   Value Applies To Scope       Help Message
---                   ----- ---------- -----       ------------
DisplaySecretsWarning True  Az         CurrentUser When enabled, a warning message for secrets redaction will be displ…
```

Sets the "DisplaySecretsWarning" config as "$true". This enables the secrets detection during the cmdlet execution and displays a warning message if any secrets are found in the output.

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
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisableInstanceDiscovery
Set it to true to disable both instance discovery and authority validation. This functionality is intended for use in scenarios where the metadata endpoint cannot be reached, such as in private clouds or Azure Stack. The process of instance discovery entails retrieving authority metadata from https://login.microsoft.com/ to validate the authority. By setting this to true, the validation of the authority is disabled. As a result, it is crucial to ensure that the configured authority host is valid and trustworthy.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayBreakingChangeWarning
Controls if warning messages for breaking changes are displayed or suppressed. When enabled, a breaking change warning is displayed when executing cmdlets with breaking changes in a future release.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayRegionIdentified
When enabled, Azure PowerShell displays recommendations on regions which may reduce your costs.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplaySecretsWarning
When enabled, a warning message will be displayed when the cmdlet output contains secrets. Learn more at https://go.microsoft.com/fwlink/?linkid=2258844

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplaySurveyMessage
When enabled, you are prompted infrequently to participate in user experience surveys for Azure PowerShell.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableDataCollection
When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experience.
For more information, see our privacy statement: https://aka.ms/privacy

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableErrorRecordsPersistence
When enabled, error records will be written to ~/.Azure/ErrorRecords.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableLoginByWam
\[Preview\] When enabled, Web Account Manager (WAM) will be the default interactive login experience.
It will fall back to using the browser if the platform does not support WAM.
Note that this feature is under preview. Microsoft Account (MSA) is currently not supported.
Feel free to reach out to Azure PowerShell team if you have any feedbacks: https://aka.ms/azpsissue

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LoginExperienceV2
Only active when authenticating interactively, allows the user to choose the subscription and tenant used in subsequent commands. Possible values ad 'On' (Default) and 'Off'. 'On' requires user's input. 'Off' will use the first tenant and subscription returned by Azure, can change without notice and lead to command execution in an unwanted context (not recommended).

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Config.Models.LoginExperienceConfig
Parameter Sets: (All)
Aliases:
Accepted values: On, Off

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.Boolean

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSConfig

## NOTES

## RELATED LINKS
