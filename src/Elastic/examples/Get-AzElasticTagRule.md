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
