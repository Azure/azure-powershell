### Example 1: Get the default api key
```powershell
PS C:\> Get-AzDataDogMonitorDefaultKey -ResourceGroupName azure-rg-datadog -Name lucasdatadog

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx78416607
```

This command gets the default api key.

### Example 2: Get the default api key by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name lucasdatadog | Get-AzDataDogMonitorDefaultKey

Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx78416607
```

This command gets the default api key by pipeline.

