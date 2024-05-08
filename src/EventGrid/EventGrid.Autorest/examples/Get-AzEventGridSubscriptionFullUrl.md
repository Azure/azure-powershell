### Example 1: Get the full endpoint URL for an event subscription.
```powershell
Get-AzEventGridSubscriptionFullUrl -EventSubscriptionName azps-eventsub -Scope "/subscriptions/{subId}/resourceGroups/azps_test_group_eventgrid/providers/Microsoft.EventGrid/topics/azps-topic"
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for an event subscription.