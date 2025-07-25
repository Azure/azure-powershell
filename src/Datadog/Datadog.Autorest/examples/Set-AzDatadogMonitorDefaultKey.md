### Example 1: Set the default api key for monitor resource
```powershell
Set-AzDatadogMonitorDefaultKey -ResourceGroupName azure-rg-Datadog -MonitorName Datadog -Key 'xxxxxxxxxxxxxxxxxxxxxx'
```

```output
Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxxxxxxxxxxx
```

This command sets the default api key for monitor resource.

