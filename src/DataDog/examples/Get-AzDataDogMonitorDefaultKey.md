### Example 1: Get the default api key
```powershell
PS C:\> Get-AzDataDogMonitorDefaultKey -ResourceGroupName azure-rg-datadog -Name datadog

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key.

### Example 2: Get the default api key by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name datadog | Get-AzDataDogMonitorDefaultKey

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key by pipeline.

