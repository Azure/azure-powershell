### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor

Location      Name                        Type
--------      ----                        ----
westus2       kk-elastictest02            microsoft.elastic/monitors
westus2       kk-elastictest03            microsoft.elastic/monitors
westus2       wusDeployValidate           microsoft.elastic/monitors
westus2       poshett-WestUS2-01          microsoft.elastic/monitors
westus2       hashahdemo01                microsoft.elastic/monitors
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test

Location Name             Type
-------- ----             ----
westus2  elastic-portal01 microsoft.elastic/monitors
westus2  elastic-portal02 microsoft.elastic/monitors
westus2  elastic-pwsh01   microsoft.elastic/monitors
westus2  elastic-pwsh02   microsoft.elastic/monitors
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02

Location Name           Type
-------- ----           ----
westus2  elastic-pwsh02 microsoft.elastic/monitors
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com' | Get-AzElasticMonitor

Location Name           Type
-------- ----           ----
westus2  elastic-pwsh02 microsoft.elastic/monitors
```

{{ Add description here }}
