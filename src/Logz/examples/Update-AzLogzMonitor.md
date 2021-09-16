### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzLogzMonitor -ResourceGroupName lucas-rg-test -Name pwsh-logz04 -Tag @{'key01'=1;'key02'=2;'key03'=3}

Name        MonitoringStatus Location ResourceGroupName
----        ---------------- -------- -----------------
pwsh-logz04 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzMonitor -ResourceGroupName lucas-rg-test -Name pwsh-logz04 | Update-AzLogzMonitor -Tag @{'key01'=1;'key02'=2;'key03'=3}

Name        MonitoringStatus Location ResourceGroupName
----        ---------------- -------- -----------------
pwsh-logz04 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

