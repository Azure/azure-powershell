---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgriddomaintopiceventsubscription
schema: 2.0.0
---

# Get-AzEventGridDomainTopicEventSubscription

## SYNOPSIS
Get properties of a nested event subscription for a domain topic.

## SYNTAX

### List (Default)
```
Get-AzEventGridDomainTopicEventSubscription -DomainName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] -TopicName <String> [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [-PassThru] [<CommonParameters>]
```

### Get
```
Get-AzEventGridDomainTopicEventSubscription -DomainName <String> -EventSubscriptionName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -TopicName <String> [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

### GetViaIdentityTopic
```
Get-AzEventGridDomainTopicEventSubscription -EventSubscriptionName <String>
 -TopicInputObject <IEventGridIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentityDomain
```
Get-AzEventGridDomainTopicEventSubscription -EventSubscriptionName <String> -TopicName <String>
 -DomainInputObject <IEventGridIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventGridDomainTopicEventSubscription -InputObject <IEventGridIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Get properties of a nested event subscription for a domain topic.

## EXAMPLES

### Example 1: Get properties of a nested event subscription for a domain topic.
```powershell
Get-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 2: Get properties of a nested event subscription for a domain topic.
```powershell
Get-AzEventGridDomainTopicEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 3: Get properties of a nested event subscription for a domain topic.
```powershell
$domainTopicObj = Get-AzEventGridDomainTopic -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Get-AzEventGridDomainTopicEventSubscription -TopicInputObject $domainTopicObj -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

### Example 4: Get properties of a nested event subscription for a domain topic.
```powershell
$domainObj = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainTopicEventSubscription -DomainInputObject $domainObj -TopicName azps-topic -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of a nested event subscription for a domain topic.

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

### -DomainInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: GetViaIdentityDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DomainName
Name of the top level domain.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventSubscriptionName
Name of the event subscription.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityTopic, GetViaIdentityDomain
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The query used to filter the search results using OData syntax.
Filtering is permitted on the 'name' property only and with limited number of OData operations.
These operations are: the 'contains' function as well as the following logical operations: not, and, or, eq (for equal), and ne (for not equal).
No arithmetic operations are supported.
The following is a valid filter example: $filter=contains(namE, 'PATTERN') and name ne 'PATTERN-1'.
The following is not a valid filter example: $filter=location eq 'westus'.

```yaml
Type: System.String
Parameter Sets: List
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of results to return per page for the list operation.
Valid range for top parameter is 1 to 100.
If not specified, the default number of results to be returned is 20 items per page.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: GetViaIdentityTopic
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -TopicName
Name of the domain topic.

```yaml
Type: System.String
Parameter Sets: List, Get, GetViaIdentityDomain
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscription

## NOTES

## RELATED LINKS
