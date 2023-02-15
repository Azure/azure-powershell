### Example 1: Get details of a ServiceBus Rule
```powershell
Get-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name '$Default' -TopicName myTopic -SubscriptionName mySubscription
```

```output
ActionCompatibilityLevel               :
ActionRequiresPreprocessing            :
ActionSqlExpression                    :
ContentType                            :
CorrelationFilterProperty              : {
                                         }
CorrelationFilterRequiresPreprocessing :
CorrelationId                          :
FilterType                             : SqlFilter
Id                                     : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription/rules/$Default
Label                                  :
Location                               : westus
MessageId                              :
Name                                   : $Default
ReplyTo                                :
ReplyToSessionId                       :
ResourceGroupName                      : myResourceGroup
SessionId                              :
SqlExpression                          : 1=1
SqlFilterCompatibilityLevel            : 20
```

Gets the details of `$Default` rule from subscription `mySubscription` of topic `myTopic`.

### Example 2: List all rules in a ServiceBus subscription
```powershell
Get-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription
```

Lists all rules in ServiceBus subscription `mySubscription`.
