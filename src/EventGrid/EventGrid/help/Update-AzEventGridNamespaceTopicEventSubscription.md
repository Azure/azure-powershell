---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgridnamespacetopiceventsubscription
schema: 2.0.0
---

# Update-AzEventGridNamespaceTopicEventSubscription

## SYNOPSIS
Update an existing event subscription of a namespace topic.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String>
 [-DeliveryConfigurationDeliveryMode <String>] [-EventDeliverySchema <String>]
 [-FilterConfigurationFilter <IFilter[]>] [-FilterConfigurationIncludedEventType <String[]>]
 [-IdentityType <String>] [-QueueEventTimeToLive <TimeSpan>] [-QueueMaxDeliveryCount <Int32>]
 [-QueueReceiveLockDurationInSecond <Int32>] [-UserAssignedIdentity <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -TopicName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityTopicExpanded
```
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName <String>
 -TopicInputObject <IEventGridIdentity> [-DeliveryConfigurationDeliveryMode <String>]
 [-EventDeliverySchema <String>] [-FilterConfigurationFilter <IFilter[]>]
 [-FilterConfigurationIncludedEventType <String[]>] [-IdentityType <String>] [-QueueEventTimeToLive <TimeSpan>]
 [-QueueMaxDeliveryCount <Int32>] [-QueueReceiveLockDurationInSecond <Int32>] [-UserAssignedIdentity <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityNamespaceExpanded
```
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName <String> -TopicName <String>
 -NamespaceInputObject <IEventGridIdentity> [-DeliveryConfigurationDeliveryMode <String>]
 [-EventDeliverySchema <String>] [-FilterConfigurationFilter <IFilter[]>]
 [-FilterConfigurationIncludedEventType <String[]>] [-IdentityType <String>] [-QueueEventTimeToLive <TimeSpan>]
 [-QueueMaxDeliveryCount <Int32>] [-QueueReceiveLockDurationInSecond <Int32>] [-UserAssignedIdentity <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridNamespaceTopicEventSubscription -InputObject <IEventGridIdentity>
 [-DeliveryConfigurationDeliveryMode <String>] [-EventDeliverySchema <String>]
 [-FilterConfigurationFilter <IFilter[]>] [-FilterConfigurationIncludedEventType <String[]>]
 [-IdentityType <String>] [-QueueEventTimeToLive <TimeSpan>] [-QueueMaxDeliveryCount <Int32>]
 [-QueueReceiveLockDurationInSecond <Int32>] [-UserAssignedIdentity <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an existing event subscription of a namespace topic.

## EXAMPLES

### Example 1: Update an existing event subscription of a namespace topic.
```powershell
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.

### Example 2: Update an existing event subscription of a namespace topic.
```powershell
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -NamespaceInputObject $namespace -TopicName azps-topic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.

### Example 3: Update an existing event subscription of a namespace topic.
```powershell
$namespaceTopic = Get-AzEventGridNamespaceTopic -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
Update-AzEventGridNamespaceTopicEventSubscription -EventSubscriptionName azps-eventsubname -TopicInputObject $namespaceTopic -DeliveryConfigurationDeliveryMode Queue -EventDeliverySchema CloudEventSchemaV1_0
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Update an existing event subscription of a namespace topic.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DeliveryConfigurationDeliveryMode
Delivery mode of the event subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventDeliverySchema
The event delivery schema for the event subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSubscriptionName
Name of the event subscription to be created.
Event subscription names must be between 3 and 100 characters in length and use alphanumeric letters only.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterConfigurationFilter
An array of filters that are used for filtering event subscriptions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IFilter[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterConfigurationIncludedEventType
A list of applicable event types that need to be part of the event subscription.
If it is desired to subscribe to all default event types, set the IncludedEventTypes to null.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
Name of the namespace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -QueueEventTimeToLive
Time span duration in ISO 8601 format that determines how long messages are available to the subscription from the time the message was published.This duration value is expressed using the following format: \'P(n)Y(n)M(n)DT(n)H(n)M(n)S\', where: - (n) is replaced by the value of each time element that follows the (n).
- P is the duration (or Period) designator and is always placed at the beginning of the duration.
- Y is the year designator, and it follows the value for the number of years.
- M is the month designator, and it follows the value for the number of months.
- W is the week designator, and it follows the value for the number of weeks.
- D is the day designator, and it follows the value for the number of days.
- T is the time designator, and it precedes the time components.
- H is the hour designator, and it follows the value for the number of hours.
- M is the minute designator, and it follows the value for the number of minutes.
- S is the second designator, and it follows the value for the number of seconds.This duration value cannot be set greater than the topic's EventRetentionInDays.
It is is an optional field where its minimum value is 1 minute, and its maximum is determinedby topic's EventRetentionInDays value.
The followings are examples of valid values: - \'P0DT23H12M\' or \'PT23H12M\': for duration of 23 hours and 12 minutes.
- \'P1D\' or \'P1DT0H0M0S\': for duration of 1 day.

```yaml
Type: System.TimeSpan
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueMaxDeliveryCount
The maximum delivery count of the events.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -QueueReceiveLockDurationInSecond
Maximum period in seconds in which once the message is in received (by the client) state and waiting to be accepted, released or rejected.If this time elapsed after a message has been received by the client and not transitioned into accepted (not processed), released or rejected,the message is available for redelivery.
This is an optional field, where default is 60 seconds, minimum is 60 seconds and maximum is 300 seconds.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: ResourceGroup

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: UpdateViaIdentityTopicExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TopicName
Name of the namespace topic.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The user identity associated with the resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityTopicExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases: IdentityId

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.ISubscription

## NOTES

## RELATED LINKS
