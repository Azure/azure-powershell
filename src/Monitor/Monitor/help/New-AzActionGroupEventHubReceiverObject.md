---
external help file: Az.ActionGroup.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azactiongroupeventhubreceiverobject
schema: 2.0.0
---

# New-AzActionGroupEventHubReceiverObject

## SYNOPSIS
Create an in-memory object for EventHubReceiver.

## SYNTAX

```
New-AzActionGroupEventHubReceiverObject -EventHubName <String> -EventHubNameSpace <String> -Name <String>
 -SubscriptionId <String> [-TenantId <String>] [-UseCommonAlertSchema <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EventHubReceiver.

## EXAMPLES

### Example 1: create action group event hub receiver
```powershell
New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "testEventHubNameSpace" -Name "sample eventhub" -SubscriptionId "187f412d-1758-44d9-b052-169e2564721d" -TenantId "68a4459a-ccb8-493c-b9da-dd30457d1b84"
```

```output
EventHubName         : testEventHub
EventHubNameSpace    : testEventHubNameSpace
Name                 : sample eventhub
SubscriptionId       : 187f412d-1758-44d9-b052-169e2564721d
TenantId             : 68a4459a-ccb8-493c-b9da-dd30457d1b84
UseCommonAlertSchema :
```

This command creates action group event hub receiver object.

### Example 2: create another action group event hub receiver
```powershell
New-AzActionGroupEventHubReceiverObject -EventHubName "testEventHub" -EventHubNameSpace "actiongrouptest" -Name "sample eventhub" -SubscriptionId 9e223dbe-3399-4e19-88eb-0975f02ac87f
```

```output
EventHubName         : testEventHub
EventHubNameSpace    : actiongrouptest
Name                 : sample eventhub
SubscriptionId       : 9e223dbe-3399-4e19-88eb-0975f02ac87f
TenantId             : 
UseCommonAlertSchema :
```

This command creates another action group event hub receiver object.

## PARAMETERS

### -EventHubName
The name of the specific Event Hub queue.

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

### -EventHubNameSpace
The Event Hub namespace.

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

### -Name
The name of the Event hub receiver.
Names must be unique across all receivers within an action group.

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

### -SubscriptionId
The Id for the subscription containing this event hub.

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

### -TenantId
The tenant Id for the subscription containing this event hub.

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

### -UseCommonAlertSchema
Indicates whether to use common alert schema.

```yaml
Type: System.Boolean
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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Models.EventHubReceiver

## NOTES

## RELATED LINKS
