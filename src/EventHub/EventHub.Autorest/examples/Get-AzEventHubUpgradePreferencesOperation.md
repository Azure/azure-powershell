### Example 1: Get the upgrade preferences for an Event Hubs Dedicated cluster
```powershell
Get-AzEventHubUpgradePreferencesOperation -ResourceGroupName contoso-rg -ClusterName contoso-cluster
```

```output
Id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.EventHub/clusters/contoso-cluster/upgradePreferences/default
Name                        : default
Type                        : Microsoft.EventHub/clusters/upgradePreferences
ExceptionWindow             : {{ Action = Block; Date = 2026-08-15; StartTimeOfDay = PT0S; DurationMinutes = 1440 }}
MaintenanceWindow           : {{ DayOfWeek = Saturday; StartTimeOfDay = PT2H; DurationMinutes = 960 }}
UpgradeStatusCompletesAt    : 7/2/2026 8:00:00 PM
UpgradeStatusInProgress     : True
UpgradeStatusPendingUpgrade : True
```

Gets the upgrade preferences (`default`) for the Event Hubs Dedicated cluster `contoso-cluster`, including its maintenance window, exception window, and current upgrade status.

