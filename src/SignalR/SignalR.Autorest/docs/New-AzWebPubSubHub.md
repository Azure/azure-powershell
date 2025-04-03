---
external help file:
Module Name: Az.SignalR
online version: https://learn.microsoft.com/powershell/module/az.signalr/new-azwebpubsubhub
schema: 2.0.0
---

# New-AzWebPubSubHub

## SYNOPSIS
Create or update a hub setting.

## SYNTAX

```
New-AzWebPubSubHub -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AnonymousConnectPolicy <String>] [-EventHandler <IEventHandler[]>]
 [-EventListener <IEventListener[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create or update a hub setting.

## EXAMPLES

### Example 1: Add two event handlers for a hub
```powershell
$eventHandler = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; } ,
        @{ UrlTemplate = 'http://example.com/api/{hub}/userevent/{event}' ; AuthType = 'None' ; UserEventPattern = '*' }

New-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps -EventHandler $eventHandler
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```

The example first creates a list of hash tables containing two event handler settings, one for system events and the other for user events.
Then it creates a hub with the event handlers.

### Example 2: Add two event listeners for a hub
```powershell
$eventListeners =
@{
    Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName connectivityHub -FullyQualifiedNamespace example.servicebus.windows.net);
    Filter = $(New-AzWebPubSubEventNameFilterObject -SystemEvent connected, disconnected)
},
@{
    Endpoint = $(New-AzWebPubSubEventHubEndpointObject -EventHubName messageHub -FullyQualifiedNamespace example.servicebus.windows.net);
    Filter = $(New-AzWebPubSubEventNameFilterObject -UserEventPattern *)
}

$hub = New-AzWebPubSubHub -Name hub2 -ResourceGroupName rg -ResourceName psdemo -EventListener $eventListeners
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
hub2 deny
```

The example first creates a list of hash tables containing two event listener settings, one for system events and the other for user events.
Then it creates a hub with the event handlers.

## PARAMETERS

### -AnonymousConnectPolicy
The settings for configuring if anonymous connections are allowed for this hub: "allow" or "deny".
Default to "deny".

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

### -EventHandler
Event handler of a hub.
To construct, see NOTES section for EVENTHANDLER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.IEventHandler[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventListener
Event listener settings for forwarding your client events to listeners.Event listener is transparent to Web PubSub clients, and it doesn't return any result to clients nor interrupt the lifetime of clients.One event can be sent to multiple listeners, as long as it matches the filters in those listeners.
The order of the array elements doesn't matter.Maximum count of event listeners among all hubs is 10.
To construct, see NOTES section for EVENTLISTENER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.IEventListener[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The hub name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: HubName

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -ResourceName
The name of the resource.

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
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20220801Preview.IWebPubSubHub

## NOTES

## RELATED LINKS

