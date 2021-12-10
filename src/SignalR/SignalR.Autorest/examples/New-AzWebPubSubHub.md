### Example 1: Create a hub setting
```powershell
PS C:\> $eventHandler = @{UrlTemplate = 'http://example.com/api/{hub}/connect/{event}' ; AuthType = 'None' ; SystemEvent = 'connect' ; }

PS C:\> New-AzWebPubSubHub -Name testHub -ResourceGroupName psdemo -ResourceName psdemo-wps -EventHandler $eventHandler

Name    AnonymousConnectPolicy
----    ----------------------
testHub deny
```

The example first creates a list of hash tables containing two event handler settings, one for system events and the other for user events. Then it creates a hub with the event handlers.


