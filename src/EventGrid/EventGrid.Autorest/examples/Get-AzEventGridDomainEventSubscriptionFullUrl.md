### Example 1: Get the full endpoint URL for an event subscription for domain.
```powershell
Get-AzEventGridDomainEventSubscriptionFullUrl -ResourceGroupName azps_test_group_eventgrid -DomainName azps-domain -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for an event subscription for domain.

### Example 2: Get the full endpoint URL for an event subscription for domain.
```powershell
$domainObj = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainEventSubscriptionFullUrl -DomainInputObject $domainObj -EventSubscriptionName azps-eventsubname
```

```output
EndpointUrl
-----------
https://azpssite.azurewebsites.net/api/updates
```

Get the full endpoint URL for an event subscription for domain.