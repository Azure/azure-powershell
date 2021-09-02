### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticTagRule -ResourceGroupName lucas-elastic-test -MonitorName elastic-pwsh02 -Name default

Name    Type
----    ----
default microsoft.elastic/monitors/tagrules
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> New-AzElasticTagRule -ResourceGroupName azps-elastic-test -MonitorName elastic-pwsh02 -Name default | Get-AzElasticTagRule

Name    Type
----    ----
default microsoft.elastic/monitors/tagrules
```

{{ Add description here }}

