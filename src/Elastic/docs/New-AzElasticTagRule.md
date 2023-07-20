---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/new-azelastictagrule
schema: 2.0.0
---

# New-AzElasticTagRule

## SYNOPSIS
Create a tag rule set for a given monitor resource.

## SYNTAX

### CreateExpanded (Default)
```
New-AzElasticTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-LogRuleFilteringTag <IFilteringTag[]>] [-LogRuleSendAadLog] [-LogRuleSendActivityLog]
 [-LogRuleSendSubscriptionLog] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityMonitorExpanded
```
New-AzElasticTagRule -MonitorInputObject <IElasticIdentity> [-LogRuleFilteringTag <IFilteringTag[]>]
 [-LogRuleSendAadLog] [-LogRuleSendActivityLog] [-LogRuleSendSubscriptionLog] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzElasticTagRule -MonitorName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzElasticTagRule -MonitorName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: Create or fully update a tag rule set for a given monitor resource
```powershell
New-AzElasticTagRule -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -LogRuleSendSubscriptionLog -LogRuleSendAadLog -LogRuleSendActivityLog
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGr
                               oup01/providers/Microsoft.Elastic/monitors/Monitor01/tagRules/default
LogRuleFilteringTag          : {}
LogRuleSendAadLog            : True
LogRuleSendActivityLog       : True
LogRuleSendSubscriptionLog   : True
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : ElasticResourceGroup01
SystemDataCreatedAt          : 07/17/2023 06:42:52
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 07/20/2023 10:00:08
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Create or fully update a tag rule set for a given monitor resource.

### Example 2: Create or fully update a tag rule set for a given monitor resource via JSON string
```powershell
$ruleSetProps = @{
    properties = @{
        logRules = @{
            sendAadLogs          = $true
            sendActivityLogs     = $true
            sendSubscriptionLogs = $false
            filteringTags        = @(
                @{
                    action = "Include"
                    name   = "Tag1Name"
                    value  = "Tag1Val"
                }, @{
                    action = "Exclude"
                    name   = "Tag2Name"
                    value  = "Tag2Val"
                }
            )
        }
    }
}
$ruleSetPropsJson = ConvertTo-Json -InputObject $ruleSetProps -Depth 5
New-AzElasticTagRule -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 -JsonString $ruleSetPropsJson
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGr
                               oup01/providers/Microsoft.Elastic/monitors/Monitor02/tagRules/default
LogRuleFilteringTag          : {{
                                 "name": "Tag1Name",
                                 "value": "Tag1Val",
                                 "action": "Include"
                               }, {
                                 "name": "Tag2Name",
                                 "value": "Tag2Val",
                                 "action": "Exclude"
                               }}
LogRuleSendAadLog            : True
LogRuleSendActivityLog       : True
LogRuleSendSubscriptionLog   : False
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : ElasticResourceGroup01
SystemDataCreatedAt          : 07/19/2023 09:38:28
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 07/20/2023 10:02:33
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Create or fully update a tag rule set for a given monitor resource via JSON string.

### Example 3: Create or fully update a tag rule set for a given monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor03 | New-AzElasticTagRule -LogRuleSendSubscriptionLog
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGr
                               oup01/providers/Microsoft.Elastic/monitors/Monitor03/tagRules/default
LogRuleFilteringTag          : {}
LogRuleSendAadLog            : False
LogRuleSendActivityLog       : False
LogRuleSendSubscriptionLog   : True
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : ElasticResourceGroup01
SystemDataCreatedAt          : 07/19/2023 09:50:14
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 07/20/2023 10:05:18
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Create or fully update a tag rule set for a given monitor resource via pipeline.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IFilteringTag[]
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityMonitorExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitorInputObject
Identity Parameter
To construct, see NOTES section for MONITORINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: CreateViaIdentityMonitorExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MonitorName
Monitor resource name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group to which the Elastic resource belongs.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IMonitoringTagRules

## NOTES

## RELATED LINKS

