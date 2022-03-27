---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/powershell/module/az.signalr/new-azwebpubsubhub
schema: 2.0.0
---

# New-AzWebPubSubHub

## SYNOPSIS
Create or update a hub setting.

## SYNTAX

```
New-AzWebPubSubHub -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-AnonymousConnectPolicy <String>] [-EventHandler <IEventHandler[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a hub setting.

## EXAMPLES

### Example 1: Create a hub setting
```powershell
$eventHandler = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; }

New-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps -EventHandler $eventHandler
```

```output
Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```

The example first creates a list of hash tables containing two event handler settings, one for system events and the other for user events.
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

### -EventHandler
Event handler of a hub.
To construct, see NOTES section for EVENTHANDLER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IEventHandler[]
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

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IWebPubSubHub

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


EVENTHANDLER <IEventHandler[]>: Event handler of a hub.
  - `UrlTemplate <String>`: Gets or sets the EventHandler URL template. You can use a predefined parameter {hub} and {event} inside the template, the value of the EventHandler URL is dynamically calculated when the client request comes in.         For example, UrlTemplate can be `http://example.com/api/{hub}/{event}`. The host part can't contains parameters.
  - `[AuthType <UpstreamAuthType?>]`: Gets or sets the type of auth. None or ManagedIdentity is supported now.
  - `[ManagedIdentityResource <String>]`: The Resource indicating the App ID URI of the target resource.         It also appears in the aud (audience) claim of the issued token.
  - `[SystemEvent <String[]>]`: Gets ot sets the list of system events. Valid values contain: 'connect', 'connected', 'disconnected'.
  - `[UserEventPattern <String>]`: Gets or sets the matching pattern for event names.         There are 3 kind of patterns supported:             1. "*", it to matches any event name             2. Combine multiple events with ",", for example "event1,event2", it matches event "event1" and "event2"             3. The single event name, for example, "event1", it matches "event1"

## RELATED LINKS

