### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         lucas-rg-test
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitorTagRule -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 | Get-AzLogzMonitorTagRule

Name    ProvisioningState ResourceGroupName
----    ----------------- -----------------
default Succeeded         lucas-rg-test
```

{{ Add description here }}

