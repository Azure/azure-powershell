### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 -Tag @{'key01'=1;'key02'=2;'key03'=3}

Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Update-AzLogzSubAccount -Tag @{'key01'=1;'key02'=2;'key03'=3}

Name           MonitoringStatus Location ResourceGroupName
----           ---------------- -------- -----------------
logz-pwshsub01 Enabled          westus2  lucas-rg-test
```

{{ Add description here }}

