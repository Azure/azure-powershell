---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridsystemtopiceventsubscription
schema: 2.0.0
---

# New-AzEventGridSystemTopicEventSubscription

## SYNOPSIS
Asynchronously creates or updates an event subscription with the specified parameters.
Existing event subscriptions will be updated with this API.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -SystemTopicName <String> [-DeadLetterWithResourceIdentityType <String>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -SystemTopicName <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -SystemTopicName <String> -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentitySystemTopicExpanded
```
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String>
 -SystemTopicInputObject <IEventGridIdentity> [-DeadLetterWithResourceIdentityType <String>]
 [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridSystemTopicEventSubscription -InputObject <IEventGridIdentity>
 [-DeadLetterWithResourceIdentityType <String>] [-DeadLetterWithResourceIdentityUserAssignedIdentity <String>]
 [-DeliveryWithResourceIdentityDestination <IEventSubscriptionDestination>]
 [-DeliveryWithResourceIdentityType <String>] [-DeliveryWithResourceIdentityUserAssignedIdentity <String>]
 [-Destination <IEventSubscriptionDestination>] [-EventDeliverySchema <String>] [-ExpirationTimeUtc <DateTime>]
 [-FilterAdvancedFilter <IAdvancedFilter[]>] [-FilterEnableAdvancedFilteringOnArray]
 [-FilterIncludedEventType <String[]>] [-FilterIsSubjectCaseSensitive] [-FilterSubjectBeginsWith <String>]
 [-FilterSubjectEndsWith <String>] [-Label <String[]>] [-RetryPolicyEventTimeToLiveInMinute <Int32>]
 [-RetryPolicyMaxDeliveryAttempt <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Asynchronously creates or updates an event subscription with the specified parameters.
Existing event subscriptions will be updated with this API.

## EXAMPLES

### Example 1: Asynchronously Create an event subscription with the specified parameters.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net"
New-AzEventGridSystemTopicEventSubscription -EventSubscriptionName azps-evnetsub -ResourceGroupName azps_test_group_eventgrid -SystemTopicName azps-systopic -FilterIsSubjectCaseSensitive:$false -FilterSubjectBeginsWith "ExamplePrefix" -FilterSubjectEndsWith "ExampleSuffix" -Destination $obj
```

```output
Name          ResourceGroupName
----          -----------------
azps-evnetsub azps_test_group_eventgrid
```

Asynchronously Create an event subscription with the specified parameters.
Existing event subscriptions will be updated with this API.

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

### -DeadLetterWithResourceIdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterWithResourceIdentityUserAssignedIdentity
The user identity associated with the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
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

### -DeliveryWithResourceIdentityDestination
Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryWithResourceIdentityType
The type of managed identity used.
The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities.
The type 'None' will remove any identity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeliveryWithResourceIdentityUserAssignedIdentity
The user identity associated with the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Destination
Information about the destination where events have to be delivered for the event subscription.Uses Azure Event Grid's identity to acquire the authentication tokens being used during delivery / dead-lettering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionDestination
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: DeliverySchema

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentitySystemTopicExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTimeUtc
Expiration time of the event subscription.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: ExpirationDate

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterAdvancedFilter
An array of advanced filters that are used for filtering event subscriptions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IAdvancedFilter[]
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: AdvancedFilter

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterEnableAdvancedFilteringOnArray
Allows advanced filters to be evaluated against an array of values instead of expecting a singular value.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: AdvancedFilteringOnArray

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterIncludedEventType
A list of applicable event types that need to be part of the event subscription.
If it is desired to subscribe to all default event types, set the IncludedEventTypes to null.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: IncludedEventType

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterIsSubjectCaseSensitive
Specifies if the SubjectBeginsWith and SubjectEndsWith properties of the filtershould be compared in a case sensitive manner.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: SubjectCaseSensitive

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSubjectBeginsWith
An optional string to filter events for an event subscription based on a resource path prefix.The format of this depends on the publisher of the events.Wildcard characters are not supported in this path.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: SubjectBeginsWith

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilterSubjectEndsWith
An optional string to filter events for an event subscription based on a resource path suffix.Wildcard characters are not supported in this path.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: SubjectEndsWith

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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Label
List of user defined labels.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyEventTimeToLiveInMinute
Time To Live (in minutes) for events.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: EventTtl

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RetryPolicyMaxDeliveryAttempt
Maximum number of delivery retry attempts for events.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentitySystemTopicExpanded, CreateViaIdentityExpanded
Aliases: MaxDeliveryAttempt

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemTopicInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentitySystemTopicExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SystemTopicName
Name of the system topic.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscription

## NOTES

## RELATED LINKS
