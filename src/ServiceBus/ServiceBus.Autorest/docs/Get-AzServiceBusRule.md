---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusrule
schema: 2.0.0
---

# Get-AzServiceBusRule

## SYNOPSIS
Retrieves the description for the specified rule.

## SYNTAX

### List (Default)
```
Get-AzServiceBusRule -NamespaceName <String> -ResourceGroupName <String> -SubscriptionName <String>
 -TopicName <String> [-SubscriptionId <String[]>] [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzServiceBusRule -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -SubscriptionName <String> -TopicName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceBusRule -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityNamespace
```
Get-AzServiceBusRule -Name <String> -NamespaceInputObject <IServiceBusIdentity> -SubscriptionName <String>
 -TopicName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentitySubscription
```
Get-AzServiceBusRule -Name <String> -SubscriptionInputObject <IServiceBusIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityTopic
```
Get-AzServiceBusRule -Name <String> -SubscriptionName <String> -TopicInputObject <IServiceBusIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves the description for the specified rule.

## EXAMPLES

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The rule name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace, GetViaIdentitySubscription, GetViaIdentityTopic
Aliases: RuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The namespace name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls.

```yaml
Type: System.Int32
Parameter Sets: List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentitySubscription
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionName
The subscription name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace, GetViaIdentityTopic, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
May be used to limit the number of results to the most recent N usageDetails.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentityTopic
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TopicName
The topic name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityNamespace, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IRule

## NOTES

## RELATED LINKS

