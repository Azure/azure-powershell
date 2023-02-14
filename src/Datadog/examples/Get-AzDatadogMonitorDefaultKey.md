### Example 1: Get the default api key
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitorDefaultKey -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
=======
PS C:\> Get-AzDatadogMonitorDefaultKey -ResourceGroupName azure-rg-Datadog -Name Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key.

### Example 2: Get the default api key by pipeline
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitorDefaultKey
```

```output
=======
PS C:\> Get-AzDatadogMonitor -ResourceGroupName azure-rg-Datadog -Name Datadog | Get-AzDatadogMonitorDefaultKey

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Created CreatedBy Key                              Name
------- --------- ---                              ----
                  xxxxxxxxxxxxx
```

This command gets the default api key by pipeline.

