---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/get-azeventgridtopiceventsubscriptionfullurl
schema: 2.0.0
---

# Get-AzEventGridTopicEventSubscriptionFullUrl

## SYNOPSIS
Get the full endpoint URL for an event subscription for topic.

## SYNTAX

### Get (Default)
```
Get-AzEventGridTopicEventSubscriptionFullUrl -EventSubscriptionName <String> -ResourceGroupName <String>
 -TopicName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzEventGridTopicEventSubscriptionFullUrl -InputObject <IEventGridIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityTopic
```
Get-AzEventGridTopicEventSubscriptionFullUrl -EventSubscriptionName <String>
 -TopicInputObject <IEventGridIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get the full endpoint URL for an event subscription for topic.

## EXAMPLES

### Example 1: Get the full endpoint URL for an event subscription for topic.
```powershell
Get-AzEventGridTopicEventSubscriptionFullUrl -ResourceGroupName azps_test_group_eventgrid -EventSubscriptionName azps-eventsub -TopicName azps-topic
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription for topic.

### Example 2: Get the full endpoint URL for an event subscription for topic.
```powershell
$topic = Get-AzEventGridTopic -ResourceGroupName azps_test_group_eventgrid -Name azps-topic
Get-AzEventGridTopicEventSubscriptionFullUrl -TopicInputObject $topic -EventSubscriptionName azps-eventsub
```

```output
EndpointUrl
-----------
https://azpsweb.azurewebsites.net
```

Get the full endpoint URL for an event subscription for topic.

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

### -EventSubscriptionName
Name of the event subscription.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityTopic
Aliases:

Required: True
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
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventSubscriptionFullUrl

## NOTES

## RELATED LINKS

