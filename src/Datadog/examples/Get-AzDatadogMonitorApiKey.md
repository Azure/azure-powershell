### Example 1: List the api keys for a given monitor resource
```powershell
<<<<<<< HEAD
Get-AzDatadogMonitorApiKey -ResourceGroupName azure-rg-Datadog -Name Datadog
```

```output
=======
PS C:\> Get-AzDatadogMonitorApiKey -ResourceGroupName azure-rg-Datadog -Name Datadog

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Created             CreatedBy           Key                              Name
-------             ---------           ---                              ----
2021-05-24 07:25:35 user@microsoft.com xxxxxxxxxxxx Azure Admin User API Key
```

This command lists the api keys for a given monitor resource.

