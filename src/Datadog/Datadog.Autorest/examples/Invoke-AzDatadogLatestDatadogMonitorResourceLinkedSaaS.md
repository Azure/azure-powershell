### Example 1: Get the latest SaaS linked to the monitor's Datadog organization
```powershell
Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
IsHiddenSaaS SaaSResourceId
------------ --------------
        True /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/MpDatadog_Datadog_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command returns the latest SaaS linked to the Datadog organization of the underlying monitor.

### Example 2: Get the latest linked SaaS by pipeline
```powershell
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Invoke-AzDatadogLatestDatadogMonitorResourceLinkedSaaS
```

```output
IsHiddenSaaS SaaSResourceId
------------ --------------
        True /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/MpDatadog_Datadog_xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

This command returns the latest SaaS linked to the Datadog organization of the underlying monitor by pipeline.

