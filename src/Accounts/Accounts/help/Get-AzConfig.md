---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Accounts.dll-Help.xml
Module Name: Az.Accounts
online version: https://docs.microsoft.com/powershell/module/az.accounts/get-azconfig
schema: 2.0.0
---

# Get-AzConfig

## SYNOPSIS
Gets the configs of Azure PowerShell.

## SYNTAX

```
Get-AzConfig [-AppliesTo <String>] [-Scope <ConfigScope>] [-DefaultProfile <IAzureContextContainer>]
 [-DefaultSubscriptionForLogin] [-DisplayBreakingChangeWarnings] [-EnableDataCollection] [<CommonParameters>]
```

## DESCRIPTION
Gets the configs of Azure PowerShell.
By default it lists all the configs. You can filter the result using various parameters.

## EXAMPLES

### Example 1
```powershell
Get-AzConfig
```

```output
Key                           Value Applies To Scope       Help Message
---                           ----- ---------- -----       ------------
EnableDataCollection          False Az         CurrentUser When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the custom…
DefaultSubscriptionForLogin         Az         Default     Subscription name or GUID. Sets the default context for Azure PowerShell when logging in with…
DisplayBreakingChangeWarnings True  Az         Default     Controls if warning messages for breaking changes are displayed or suppressed. When enabled, …
```

Gets all the configs.

### Example 2
```powershell
Get-AzConfig -EnableDataCollection
```

```output
Key                           Value Applies To Scope       Help Message
---                           ----- ---------- -----       ------------
EnableDataCollection          False Az         CurrentUser When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the custom…
```

Gets the "EnableDataCollection" config.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayBreakingChangeWarnings
Controls if warning messages for breaking changes are displayed or suppressed.
When enabled, a breaking change warning is displayed when executing cmdlets with breaking changes in a future release.

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

### -EnableDataCollection
When enabled, Azure PowerShell cmdlets send telemetry data to Microsoft to improve the customer experience.
For more information, see our privacy statement: https://aka.ms/privacy

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Profile.Models.PSConfig

## NOTES

## RELATED LINKS
