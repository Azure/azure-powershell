### Example 1: {{ Add title here }}
```powershell
PS C:\> Invoke-AzLogzHostSubAccount -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01

ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzLogzSubAccount -ResourceGroupName lucas-rg-test -MonitorName pwsh-logz04 -Name logz-pwshsub01 | Invoke-AzLogzHostSubAccount

ApiKey                           Region
------                           ------
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx   westus2
```

{{ Add description here }}

