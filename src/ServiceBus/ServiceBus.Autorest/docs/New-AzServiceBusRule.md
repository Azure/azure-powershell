---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/new-azservicebusrule
schema: 2.0.0
---

# New-AzServiceBusRule

## SYNOPSIS
Creates a new rule and updates an existing rule

## SYNTAX

```
New-AzServiceBusRule -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -SubscriptionName <String> -TopicName <String> [-SubscriptionId <String>] [-ActionRequiresPreprocessing]
 [-ActionSqlExpression <String>] [-ContentType <String>] [-CorrelationFilterProperty <Hashtable>]
 [-CorrelationFilterRequiresPreprocessing] [-CorrelationId <String>] [-FilterType <FilterType>]
 [-Label <String>] [-MessageId <String>] [-ReplyTo <String>] [-ReplyToSessionId <String>]
 [-SessionId <String>] [-SqlExpression <String>] [-SqlFilterRequiresPreprocessing] [-To <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new rule and updates an existing rule

## EXAMPLES

### Example 1: Create a Correlation Filter
```powershell
New-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription -Name myCorrelationRule -FilterType CorrelationFilter -ContentType contenttype -CorrelationFilterProperty @{a='b';c='d'} -SessionId sessionid -CorrelationId correlationid -MessageId messageid -Label label -ReplyTo replyto -ReplyToSessionId replytosessionid
```

```output
ActionCompatibilityLevel               :
ActionRequiresPreprocessing            :
ActionSqlExpression                    :
ContentType                            : contenttype
CorrelationFilterProperty              : {
                                           "c": "d",
                                           "a": "b"
                                         }
CorrelationFilterRequiresPreprocessing :
CorrelationId                          : correlationid
FilterType                             : CorrelationFilter
Id                                     : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/topics/myTopic/subscriptions/mySubscription/rules/myCorrelationRule
Label                                  : label
Location                               : westus
MessageId                              : messageid
Name                                   : myCorrelationRule
ReplyTo                                : replyto
ReplyToSessionId                       : replytosessionid
ResourceGroupName                      : myResourceGroup
SessionId                              : sessionid
SqlExpression                          :
SqlFilterCompatibilityLevel            :
```

Create a correlation filter `myCorrelationRule` in ServiceBus subscription `mySubscription`.

### Example 2: Create a Sql Filter
```powershell
New-AzServiceBusRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -TopicName myTopic -SubscriptionName mySubscription -Name mySqlRule -FilterType SqlFilter -SqlExpression 3=2 -ActionSqlExpression "SET a=b"
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
SqlExpression                          : 3=2
SqlFilterCompatibilityLevel            : 20
SqlFilterRequiresPreprocessing         :
```

Create a sql filter `mySqlRule` in ServiceBus subscription `mySubscription`.

## PARAMETERS

### -ActionRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

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

### -ActionSqlExpression
SQL expression.
e.g.
MyProperty='ABC'

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

### -ContentType
Content type of the message.

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

### -CorrelationFilterProperty
dictionary object for custom filters

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorrelationFilterRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

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

### -CorrelationId
Identifier of the correlation.

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

### -FilterType
Filter type that is evaluated against a BrokeredMessage.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.FilterType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
Application specific label.

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

### -MessageId
Identifier of the message.

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

### -Name
The rule name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplyTo
Address of the queue to reply to.

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

### -ReplyToSessionId
Session identifier to reply to.

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

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SessionId
Session identifier.

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

### -SqlExpression
The SQL expression.
e.g.
MyProperty='ABC'

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

### -SqlFilterRequiresPreprocessing
Value that indicates whether the rule action requires preprocessing.

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

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionName
The subscription name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -To
Address to send to.

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

### -TopicName
The topic name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20221001Preview.IRule

## NOTES

ALIASES

## RELATED LINKS

