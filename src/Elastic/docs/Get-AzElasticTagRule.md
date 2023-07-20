---
external help file:
Module Name: Az.Elastic
online version: https://learn.microsoft.com/powershell/module/az.elastic/get-azelastictagrule
schema: 2.0.0
---

# Get-AzElasticTagRule

## SYNOPSIS
Get a tag rule set for a given monitor resource.

## SYNTAX

### Get (Default)
```
Get-AzElasticTagRule -MonitorName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityMonitor
```
Get-AzElasticTagRule -MonitorInputObject <IElasticIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a tag rule set for a given monitor resource.

## EXAMPLES

### Example 1: Get a tag rule set for a given monitor resource
```powershell
Get-AzElasticTagRule -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01
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
SystemDataLastModifiedAt     : 07/19/2023 09:37:58
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Get a tag rule set for a given monitor resource.

### Example 2: Get a tag rule set for a given monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -Name Monitor02 | Get-AzElasticTagRule
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
SystemDataLastModifiedAt     : 07/19/2023 09:38:28
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Get a tag rule set for a given monitor resource via pipeline.

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

### -MonitorInputObject
Identity Parameter
To construct, see NOTES section for MONITORINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Elastic.Models.IElasticIdentity
Parameter Sets: GetViaIdentityMonitor
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
Parameter Sets: Get
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
Parameter Sets: Get
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
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

