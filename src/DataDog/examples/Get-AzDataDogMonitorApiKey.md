### Example 1: List the api keys for a given monitor resource
```powershell
PS C:\> Get-AzDataDogMonitorApiKey -ResourceGroupName azure-rg-datadog -Name lucasdatadog

Created             CreatedBy           Key                              Name
-------             ---------           ---                              ----
2021-05-24 07:25:35 dixue@microsoft.com xxxxxxxxxxxx6607 Azure Admin User API Key
```

This command lists the api keys for a given monitor resource.

