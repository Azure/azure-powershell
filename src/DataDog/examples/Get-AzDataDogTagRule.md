### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName lucas-dog -MonitorName lucasdatadog

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default'

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogTagRule -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' | Get-AzDataDogTagRule

Name    Type
----    ----
default microsoft.datadog/monitors/tagrules
```

{{ Add description here }}

