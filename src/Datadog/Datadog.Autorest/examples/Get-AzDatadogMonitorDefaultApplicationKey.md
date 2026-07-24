### Example 1: Get the default application key
```powershell
Get-AzDatadogMonitorDefaultApplicationKey -ResourceGroupName azure-rg-Datadog -MonitorName Datadog
```

```output
CreatedBy Key          Name
--------- ---          ----
          xxxxxxxxxxxx
```

This command gets the default application key for the given monitor resource.

### Example 2: Get the default application key by pipeline
```powershell
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitorDefaultApplicationKey
```

```output
CreatedBy Key          Name
--------- ---          ----
          xxxxxxxxxxxx
```

This command gets the default application key for the given monitor resource by pipeline.

