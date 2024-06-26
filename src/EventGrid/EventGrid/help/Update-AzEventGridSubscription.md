---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgridsubscription
schema: 2.0.0
---

# Update-AzEventGridSubscription

## SYNOPSIS
Asynchronously updates an existing event subscription.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridSubscription -Name <String> -Scope <String> [-DeadLetterWithResourceIdentityType <String>]
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

### UpdateViaJsonString
```
Update-AzEventGridSubscription -Name <String> -Scope <String> -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzEventGridSubscription -Name <String> -Scope <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridSubscription -InputObject <IEventGridIdentity> [-DeadLetterWithResourceIdentityType <String>]
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

## DESCRIPTION
Asynchronously updates an existing event subscription.

## EXAMPLES

### Example 1: Asynchronously updates an existing event subscription.
```powershell
$obj = New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
Update-AzEventGridSubscription -Name azps-eventsub -Scope "subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX" -Destination $obj -FilterIsSubjectCaseSensitive:$false
```

```output
Name          ResourceGroupName
----          -----------------
azps-eventsub
```

Asynchronously updates an existing event subscription.

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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: DeliverySchema

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTimeUtc
Information about the expiration time for the event subscription.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -Label
List of user defined labels.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the event subscription to be updated.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: EventSubscriptionName

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

### -RetryPolicyEventTimeToLiveInMinute
Time To Live (in minutes) for events.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases: MaxDeliveryAttempt

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Scope
The scope of existing event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.

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
