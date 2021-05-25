### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default'

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzDataDogSingleSignOnConfiguration -ResourceGroupName lucas-dog -MonitorName lucasdatadog -Name 'default' | Get-AzDataDogSingleSignOnConfiguration

Name    Type
----    ----
default microsoft.datadog/monitors/singlesignonconfigurations
```

{{ Add description here }}
