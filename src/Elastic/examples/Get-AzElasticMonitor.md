### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor

Name                           SkuName                         MonitoringStatus Location      ResourceGroupName
----                           -------                         ---------------- --------      -----------------
kk-elastictest02               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
kk-elastictest03               ess-monthly-consumption_Monthly Enabled          westus2       kk-rg
wusDeployValidate              ess-monthly-consumption_Monthly Enabled          westus2       poshett-rg
poshett-WestUS2-01             staging_Monthly                 Enabled          westus2       poshett-rg
hashahdemo01                   staging_Monthly                 Enabled          westus2       test-sub
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test

Name             SkuName                         MonitoringStatus Location ResourceGroupName
----             -------                         ---------------- -------- -----------------
elastic-portal01 ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
elastic-portal02 ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
elastic-pwsh01   ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
elastic-pwsh02   ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzElasticMonitor -ResourceGroupName lucas-elastic-test -Name elastic-pwsh02

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> New-AzElasticMonitor -ResourceGroupName azps-elastic-test -Name elastic-pwsh02 -Location "westus2" -SkuName "ess-monthly-consumption_Monthly" -UserInfoEmailAddress 'xxx@microsoft.com' | Get-AzElasticMonitor

Name           SkuName                         MonitoringStatus Location ResourceGroupName
----           -------                         ---------------- -------- -----------------
elastic-pwsh02 ess-monthly-consumption_Monthly Enabled          westus2  lucas-elastic-test
```

{{ Add description here }}
