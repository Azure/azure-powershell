### Example 1: Get the default api key
```powershell
PS C:\> Get-AzDatadogMonitorDefaultKey -ResourceGroupName azure-rg-Datadog -Name Datadog

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key.

### Example 2: Get the default api key by pipeline
```powershell
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitorDefaultKey

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key by pipeline.

