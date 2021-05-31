### Example 1: Update a monitor resource
```powershell
PS C:\> Update-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name lucasdatadog -Tag @{'key1'='value1'; 'key2'='value2'}

Location    Name         Type
--------    ----         ----
eastus2euap lucasdatadog microsoft.datadog/monitors
```

This command updates a monitor resource.

### Example 2: Update a monitor resource by pipeline
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName azure-rg-datadog -Name lucasdatadog | Update-AzDataDogMonitor -Tag @{'key1'='value1'; 'key2'='value2'}
Location    Name         Type
--------    ----         ----
eastus2euap lucasdatadog microsoft.datadog/monitors
```

This command updates a monitor resource by pipeline.

