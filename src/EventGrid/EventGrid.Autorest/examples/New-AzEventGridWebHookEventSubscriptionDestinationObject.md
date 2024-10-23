### Example 1: Create an in-memory object for WebHookEventSubscriptionDestination.
```powershell
New-AzEventGridWebHookEventSubscriptionDestinationObject -EndpointUrl "https://azpsweb.azurewebsites.net/api/updates"
```

```output
EndpointType
------------
WebHook
```

Create an in-memory object for WebHookEventSubscriptionDestination.
A usable EndpointUrl can be created from this link: https://learn.microsoft.com/en-us/azure/event-grid/custom-event-quickstart-powershell