### Example 1: Get properties of an event subscription of a domain.
```powershell
Get-AzEventGridDomainEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a domain.

### Example 2: Get properties of an event subscription of a domain.
```powershell
Get-AzEventGridDomainEventSubscription -DomainName azps-domain -ResourceGroupName azps_test_group_eventgrid -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a domain.

### Example 3: Get properties of an event subscription of a domain.
```powershell
$domainObj = Get-AzEventGridDomain -ResourceGroupName azps_test_group_eventgrid -Name azps-domain
Get-AzEventGridDomainEventSubscription -DomainInputObject $domainObj -EventSubscriptionName azps-eventsubname
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsubname azps_test_group_eventgrid
```

Get properties of an event subscription of a domain.