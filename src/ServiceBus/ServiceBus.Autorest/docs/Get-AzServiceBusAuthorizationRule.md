---
external help file:
Module Name: Az.ServiceBus
online version: https://learn.microsoft.com/powershell/module/az.servicebus/get-azservicebusauthorizationrule
schema: 2.0.0
---

# Get-AzServiceBusAuthorizationRule

## SYNOPSIS
Gets the Authorization Rule of a ServiceBus namespace, queue or topic.

## SYNTAX

### GetExpandedNamespace (Default)
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetExpandedAlias
```
Get-AzServiceBusAuthorizationRule -AliasName <String> -NamespaceName <String> -ResourceGroupName <String>
 [-Name <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetExpandedQueue
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -QueueName <String> -ResourceGroupName <String>
 [-Name <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetExpandedTopic
```
Get-AzServiceBusAuthorizationRule -NamespaceName <String> -ResourceGroupName <String> -TopicName <String>
 [-Name <String>] [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzServiceBusAuthorizationRule -InputObject <IServiceBusIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the Authorization Rule of a ServiceBus namespace, queue or topic.

## EXAMPLES

### Example 1: Get a ServiceBus Namespace Authorization Rule
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of ServiceBus namespace `myNamespace`.

### Example 2: Get a ServiceBus queue authorization rule
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace -QueueName queue1 -Name myAuthRule
```

```output
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.ServiceBus/namespaces/myNamespace/queues/queue1/authorizationRules
                               /myAuthRule
Location                     : Central US
Name                         : myAuthRule
ResourceGroupName            : myResourceGroup
Rights                       : {Listen, Manage, Send}
```

Gets details of authorization rule `myAuthRule` of ServiceBus queue `queue1` from namespace `myNamespace`.

### Example 3: List all authorization rules in a ServiceBus namespace
```powershell
Get-AzServiceBusAuthorizationRule -ResourceGroupName myResourceGroup -NamespaceName myNamespace
```

Lists all authorization rules in ServiceBus namespace `myNamespace`.

## PARAMETERS

### -AliasName
The name of the disaster recovery config

```yaml
Type: System.String
Parameter Sets: GetExpandedAlias
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.IServiceBusIdentity
Parameter Sets: GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Authorization Rule

```yaml
Type: System.String
Parameter Sets: GetExpandedAlias, GetExpandedNamespace, GetExpandedQueue, GetExpandedTopic
Aliases: AuthorizationRuleName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of ServiceBus namespace

```yaml
Type: System.String
Parameter Sets: GetExpandedAlias, GetExpandedNamespace, GetExpandedQueue, GetExpandedTopic
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueName
The name of the Service Bus queue.

```yaml
Type: System.String
Parameter Sets: GetExpandedQueue
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
Parameter Sets: GetExpandedAlias, GetExpandedNamespace, GetExpandedQueue, GetExpandedTopic
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
Type: System.String[]
Parameter Sets: GetExpandedAlias, GetExpandedNamespace, GetExpandedQueue, GetExpandedTopic
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicName
The name of the Service Bus topic.

```yaml
Type: System.String
Parameter Sets: GetExpandedTopic
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.ISbAuthorizationRule

## NOTES

## RELATED LINKS

