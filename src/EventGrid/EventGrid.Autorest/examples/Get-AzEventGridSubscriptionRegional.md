### Example 1: List all event subscriptions from the given location under a specific Azure subscription.
```powershell
Get-AzEventGridSubscriptionRegional -Location eastus
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsub     azps_test_group_eventgrid
azps-eventsubname azps_test_group_eventgrid
```

List all event subscriptions from the given location under a specific Azure subscription.

### Example 2: List all event subscriptions from the given location under a specific Azure subscription.
```powershell
Get-AzEventGridSubscriptionRegional -Location eastus -ResourceGroupName azps_test_group_eventgrid
```

```output
Name              ResourceGroupName
----              -----------------
azps-eventsub     azps_test_group_eventgrid
azps-eventsubname azps_test_group_eventgrid
```

List all event subscriptions from the given location under a specific Azure subscription.