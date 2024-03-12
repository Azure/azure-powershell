---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridazurefunctioneventsubscriptiondestinationobject
schema: 2.0.0
---

# New-AzEventGridAzureFunctionEventSubscriptionDestinationObject

## SYNOPSIS
Create an in-memory object for AzureFunctionEventSubscriptionDestination.

## SYNTAX

```
New-AzEventGridAzureFunctionEventSubscriptionDestinationObject
 [-DeliveryAttributeMapping <IDeliveryAttributeMapping[]>] [-MaxEventsPerBatch <Int32>]
 [-PreferredBatchSizeInKilobyte <Int32>] [-ResourceId <String>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureFunctionEventSubscriptionDestination.

## EXAMPLES

### EXAMPLE 1
```
$damObj = New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
$eventSubObj = Get-AzEventGridEventSubscription -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -TopicName azps-topic
New-AzEventGridAzureFunctionEventSubscriptionDestinationObject -DeliveryAttributeMapping $damObj -ResourceId $eventSubObj.Id
```

## PARAMETERS

### -DeliveryAttributeMapping
Delivery attribute details.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IDeliveryAttributeMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxEventsPerBatch
Maximum number of events per batch.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredBatchSizeInKilobyte
Preferred batch size in Kilobytes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure Resource Id that represents the endpoint of the Azure Function destination of an event subscription.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.AzureFunctionEventSubscriptionDestination
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

DELIVERYATTRIBUTEMAPPING \<IDeliveryAttributeMapping\[\]\>: Delivery attribute details.
  Type \<String\>: Type of the delivery attribute or header name.
  \[Name \<String\>\]: Name of the delivery attribute or header.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridazurefunctioneventsubscriptiondestinationobject](https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridazurefunctioneventsubscriptiondestinationobject)

