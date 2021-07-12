### Example 1: List the api keys for a given monitor resource
```powershell
PS C:\> Get-AzDatadogMonitorApiKey -ResourceGroupName azure-rg-Datadog -Name Datadog

Created             CreatedBy           Key                              Name
-------             ---------           ---                              ----
2021-05-24 07:25:35 user@microsoft.com xxxxxxxxxxxx Azure Admin User API Key
```

This command lists the api keys for a given monitor resource.

