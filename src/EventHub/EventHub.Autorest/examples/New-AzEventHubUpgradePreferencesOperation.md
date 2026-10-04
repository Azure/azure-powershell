### Example 1: Create upgrade preferences for an Event Hubs Dedicated cluster
```powershell
$maintenanceWindow1 = @{ DayOfWeek = 'Saturday'; StartTimeOfDay = 'PT2H'; DurationMinutes = 480 }
$maintenanceWindow2 = @{ DayOfWeek = 'Sunday'; StartTimeOfDay = 'PT2H'; DurationMinutes = 480 }
$exceptionWindow = @{ Action = 'Allow'; Date = '2026-08-22'; StartTimeOfDay = 'PT4H'; DurationMinutes = 480 }

New-AzEventHubUpgradePreferencesOperation -ResourceGroupName contoso-rg -ClusterName contoso-cluster -MaintenanceWindow $maintenanceWindow1, $maintenanceWindow2 -ExceptionWindow $exceptionWindow
```

```output
Id                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.EventHub/clusters/contoso-cluster/upgradePreferences/default
Name                    : default
Type                    : Microsoft.EventHub/clusters/upgradePreferences
ExceptionWindow         : {{ Action = Allow; Date = 2026-08-22; StartTimeOfDay = PT4H; DurationMinutes = 480 }}
MaintenanceWindow       : {{ DayOfWeek = Saturday; StartTimeOfDay = PT2H; DurationMinutes = 480 }, { DayOfWeek = Sunday; StartTimeOfDay = PT2H; DurationMinutes = 480 }}
UpgradeStatusInProgress : False
UpgradeStatusPendingUpgrade : False
```

Creates the upgrade preferences (`default`) for the Event Hubs Dedicated cluster `contoso-cluster` with two recurring weekly maintenance windows (Saturday and Sunday) and a date-specific exception window on `2026-08-22`.

