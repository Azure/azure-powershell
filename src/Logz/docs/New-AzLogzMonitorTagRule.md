---
external help file:
Module Name: Az.Logz
online version: https://docs.microsoft.com/powershell/module/az.logz/new-azlogzmonitortagrule
schema: 2.0.0
---

# New-AzLogzMonitorTagRule

## SYNOPSIS
Create or update a tag rule set for a given monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzLogzMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 [-SubscriptionId <String>] [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog]
 [-LogRuleSendActivityLog] [-LogRuleSendSubscriptionLog] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzLogzMonitorTagRule -MonitorName <String> -ResourceGroupName <String> -RuleSetName <String>
 -Body <IMonitoringTagRules> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzLogzMonitorTagRule -InputObject <ILogzIdentity> -Body <IMonitoringTagRules> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzLogzMonitorTagRule -InputObject <ILogzIdentity> [-LogRuleFilteringTag <IFilteringTag[]>]
 [-LogRuleSendAadLog] [-LogRuleSendActivityLog] [-LogRuleSendSubscriptionLog] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Capture logs and metrics of Azure resources based on ARM tags.
To construct, see NOTES section for BODY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IMonitoringTagRules
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LogRuleFilteringTag
List of filtering tags to be used for capturing logs.
This only takes effect if SendActivityLogs flag is enabled.
If empty, all resources will be captured.
If only Exclude action is specified, the rules will apply to the list of all available resources.
If Include actions are specified, the rules will only include resources with the associated tags.
To construct, see NOTES section for LOGRULEFILTERINGTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IFilteringTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendAadLog
Flag specifying if AAD logs should be sent for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendActivityLog
Flag specifying if activity logs from Azure resources should be sent for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogRuleSendSubscriptionLog
Flag specifying if subscription logs should be sent for the Monitor resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetName
.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IMonitoringTagRules

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.ILogzIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Logz.Models.Api20201001Preview.IMonitoringTagRules

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


BODY <IMonitoringTagRules>: Capture logs and metrics of Azure resources based on ARM tags.
  - `[CreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[CreatedBy <String>]`: The identity that created the resource.
  - `[CreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[LastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[LastModifiedBy <String>]`: The identity that last modified the resource.
  - `[LastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[LogRuleFilteringTag <IFilteringTag[]>]`: List of filtering tags to be used for capturing logs. This only takes effect if SendActivityLogs flag is enabled. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
    - `[Action <TagAction?>]`: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
    - `[Name <String>]`: The name (also known as the key) of the tag.
    - `[Value <String>]`: The value of the tag.
  - `[LogRuleSendAadLog <Boolean?>]`: Flag specifying if AAD logs should be sent for the Monitor resource.
  - `[LogRuleSendActivityLog <Boolean?>]`: Flag specifying if activity logs from Azure resources should be sent for the Monitor resource.
  - `[LogRuleSendSubscriptionLog <Boolean?>]`: Flag specifying if subscription logs should be sent for the Monitor resource.
  - `[PropertiesSystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[PropertiesSystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[PropertiesSystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[PropertiesSystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[PropertiesSystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[PropertiesSystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.

INPUTOBJECT <ILogzIdentity>: Identity Parameter
  - `[ConfigurationName <String>]`: 
  - `[Id <String>]`: Resource identity path
  - `[MonitorName <String>]`: Monitor resource name
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RuleSetName <String>]`: 
  - `[SubAccountName <String>]`: Sub Account resource name
  - `[SubscriptionId <String>]`: The ID of the target subscription.

LOGRULEFILTERINGTAG <IFilteringTag[]>: List of filtering tags to be used for capturing logs. This only takes effect if SendActivityLogs flag is enabled. If empty, all resources will be captured. If only Exclude action is specified, the rules will apply to the list of all available resources. If Include actions are specified, the rules will only include resources with the associated tags.
  - `[Action <TagAction?>]`: Valid actions for a filtering tag. Exclusion takes priority over inclusion.
  - `[Name <String>]`: The name (also known as the key) of the tag.
  - `[Value <String>]`: The value of the tag.

## RELATED LINKS

