### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzDataDogMonitor -ResourceGroupName lucas-dog -Name lucasdatadog -Tag @{'key1'='value1'; 'key2'='value2'}

Location    Name         Type
--------    ----         ----
eastus2euap lucasdatadog microsoft.datadog/monitors
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogMonitor -ResourceGroupName lucas-dog -Name lucasdatadog | Update-AzDataDogMonitor -Tag @{'key1'='value1'; 'key2'='value2'}
Location    Name         Type
--------    ----         ----
eastus2euap lucasdatadog microsoft.datadog/monitors
```

{{ Add description here }}

