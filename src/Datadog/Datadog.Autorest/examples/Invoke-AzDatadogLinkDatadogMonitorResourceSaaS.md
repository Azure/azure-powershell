### Example 1: Link a SaaS to the monitor's Datadog organization
```powershell
Invoke-AzDatadogLinkDatadogMonitorResourceSaaS -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -SaaSResourceId "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azure-rg-Datadog/providers/Microsoft.SaaS/resources/mySaaSResource"
```

```output
Location    Name         Type
--------    ----         ----
eastus2euap Datadog microsoft.Datadog/monitors
```

This command links a new SaaS to the Datadog organization of the underlying monitor. The SaaS resource id specifies the SaaS resource to link.

