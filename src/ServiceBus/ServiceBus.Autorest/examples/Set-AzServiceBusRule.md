### Example 1: Update a Correlation Filter
```powershell
Set-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription -Name myCorrelationRule -ContentType updatedContentType -ReplyToSessionId updatedReplyToSessionId
```

```output
ActionCompatibilityLevel               :
ActionRequiresPreprocessing            :
ActionSqlExpression                    :
ContentType                            : updatedContentType
CorrelationFilterProperty              : {
                                           "c": "d",
                                           "a": "b"
                                         }
CorrelationFilterRequiresPreprocessing :
CorrelationId                          : correlationid
FilterType                             : CorrelationFilter
Id                                     : /subscriptions/000000000000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription/rules/myCorrelationRule
Label                                  : label
Location                               : westus
MessageId                              : messageid
Name                                   : myCorrelationRule
ReplyTo                                : replyto
ReplyToSessionId                       : updatedReplyToSessionId
ResourceGroupName                      : myResourceGroup
SessionId                              : sessionid
SqlExpression                          :
SqlFilterCompatibilityLevel            :
```

Update `ContentType` and `ReplyToSessionId` parameters of a correlation filter `myCorrelationRule` in ServiceBus subscription `mySubscription`.

### Example 2: Update an Sql Filter using InputObject parameter set
```powershell
$rule = Get-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription -Name mySqlRule
Set-AzServiceBusRule -InputObject $rule -SqlExpression 5=3
```

```output
ActionCompatibilityLevel               : 20
ActionRequiresPreprocessing            :
ActionSqlExpression                    : SET a=b
ContentType                            :
CorrelationFilterProperty              : {
                                         }
CorrelationFilterRequiresPreprocessing :
CorrelationId                          :
FilterType                             : SqlFilter
Id                                     : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription/rules/mySqlRule
Label                                  :
Location                               : westus
MessageId                              :
Name                                   : mySqlRule
ReplyTo                                :
ReplyToSessionId                       :
ResourceGroupName                      : myResourceGroup
SessionId                              :
SqlExpression                          : 5=3
SqlFilterCompatibilityLevel            : 20
SqlFilterRequiresPreprocessing         :
```

Updating SqlExpression of SqlFilter `mySqlRule` using InputObject parameter set.

