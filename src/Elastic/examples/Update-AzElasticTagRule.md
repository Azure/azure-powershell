### Example 1: Partially update a tag rule set for a given monitor resource
```powershell
Update-AzElasticTagRule -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor01 -LogRuleSendAadLog:$false
```

```output
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGr
                               oup01/providers/Microsoft.Elastic/monitors/Monitor01/tagRules/default
LogRuleFilteringTag          : {}
LogRuleSendAadLog            : False
LogRuleSendActivityLog       : True
LogRuleSendSubscriptionLog   : True
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : ElasticResourceGroup01
SystemDataCreatedAt          : 07/17/2023 06:42:52
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 07/20/2023 10:33:57
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules
```

Partially update a tag rule set for a given monitor resource

### Example 2: Partially update a tag rule set for a given monitor resource via pipeline
```powershell
Get-AzElasticMonitor -ResourceGroupName ElasticResourceGroup01 -MonitorName Monitor02 | Update-AzElasticTagRule -LogRuleSendAadLog:$false -LogRuleSendSubscriptionLog
```

Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/ElasticResourceGroup0
                               1/providers/Microsoft.Elastic/monitors/Monitor02/tagRules/default
LogRuleFilteringTag          : {{
                                 "name": "Tag1Name",
                                 "value": "Tag1Val",
                                 "action": "Include"
                               }, {
                                 "name": "Tag2Name",
                                 "value": "Tag2Val",
                                 "action": "Exclude"
                               }}
LogRuleSendAadLog            : False
LogRuleSendActivityLog       : True
LogRuleSendSubscriptionLog   : True
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : ElasticResourceGroup01
SystemDataCreatedAt          : 07/19/2023 09:38:28
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 07/20/2023 03:54:52
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Type                         : microsoft.elastic/monitors/tagrules

Partially update a tag rule set for a given monitor resource via pipeline.
